// main.js

const API_BASE_URL = 'http://localhost:5000/api';

document.addEventListener('DOMContentLoaded', () => {
  const app = document.getElementById('app');
  app.appendChild(createHeader());
  app.appendChild(createAuthForms());
  app.appendChild(createNavBar());
  app.appendChild(createTravelGrid());

  // Event listeners for auth forms
  document.getElementById('registerForm').addEventListener('submit', handleRegister);
  document.getElementById('loginForm').addEventListener('submit', handleLogin);
});

function createHeader() {
  const header = document.createElement('header');
  
  const title = document.createElement('h1');
  title.textContent = 'Discover New Zealand';
  
  const searchContainer = document.createElement('div');
  searchContainer.className = 'search-container';
  
  const searchInput = document.createElement('input');
  searchInput.type = 'text';
  searchInput.placeholder = 'Search NZ destinations';
  
  const searchIcon = document.createElement('span');
  searchIcon.className = 'search-icon';
  searchIcon.innerHTML = '🔍';
  
  searchContainer.appendChild(searchInput);
  searchContainer.appendChild(searchIcon);
  
  header.appendChild(title);
  header.appendChild(searchContainer);
  
  return header;
}

function createAuthForms() {
  const container = document.createElement('div');
  container.className = 'auth-forms-container';

  const registerForm = document.createElement('form');
  registerForm.id = 'registerForm';
  registerForm.className = 'auth-form';
  registerForm.innerHTML = `
    <h2>Register</h2>
    <input type="text" name="userName" placeholder="Username" required>
    <input type="email" name="email" placeholder="Email" required>
    <input type="password" name="password" placeholder="Password" required>
    <button type="submit">Register</button>
  `;

  const loginForm = document.createElement('form');
  loginForm.id = 'loginForm';
  loginForm.className = 'auth-form';
  loginForm.innerHTML = `
    <h2>Login</h2>
    <input type="text" name="userName" placeholder="Username" required>
    <input type="password" name="password" placeholder="Password" required>
    <button type="submit">Login</button>
  `;

  container.appendChild(registerForm);
  container.appendChild(loginForm);

  return container;
}

async function handleRegister(event) {
  event.preventDefault();
  const formData = new FormData(event.target);
  const userData = Object.fromEntries(formData.entries());

  try {
    const response = await fetch(`${API_BASE_URL}/register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(userData),
    });

    if (response.ok) {
      alert('Registration successful! Please login.');
    } else {
      const error = await response.json();
      alert(`Registration failed: ${error.message}`);
    }
  } catch (error) {
    console.error('Registration error:', error);
    alert('Registration failed. Please try again.');
  }
}

async function handleLogin(event) {
  event.preventDefault();
  const formData = new FormData(event.target);
  const userData = Object.fromEntries(formData.entries());

  try {
    const response = await fetch(`${API_BASE_URL}/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(userData),
    });

    if (response.ok) {
      const data = await response.json();
      localStorage.setItem('token', data.token);
      alert('Login successful!');
      fetchCategories();
    } else {
      const error = await response.json();
      alert(`Login failed: ${error.message}`);
    }
  } catch (error) {
    console.error('Login error:', error);
    alert('Login failed. Please try again.');
  }
}

async function fetchCategories() {
  const token = localStorage.getItem('token');
  if (!token) {
    console.error('No token found');
    return;
  }

  try {
    const response = await fetch(`${API_BASE_URL}/user/category/all`, {
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });

    if (response.ok) {
      const categories = await response.json();
      updateNavBar(categories);
    } else {
      console.error('Failed to fetch categories');
    }
  } catch (error) {
    console.error('Error fetching categories:', error);
  }
}

function updateNavBar(categories) {
  const nav = document.querySelector('nav');
  nav.innerHTML = '';
  categories.forEach(category => {
    const button = document.createElement('button');
    button.textContent = category.name;
    button.onclick = () => fetchArticles(category.id);
    nav.appendChild(button);
  });
}

async function fetchArticles(categoryId) {
  const token = localStorage.getItem('token');
  if (!token) {
    console.error('No token found');
    return;
  }

  try {
    const response = await fetch(`${API_BASE_URL}/user/article?categoryId=${categoryId}`, {
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });

    if (response.ok) {
      const articles = await response.json();
      updateTravelGrid(articles);
    } else {
      console.error('Failed to fetch articles');
    }
  } catch (error) {
    console.error('Error fetching articles:', error);
  }
}

function updateTravelGrid(articles) {
  const grid = document.querySelector('.travel-grid');
  grid.innerHTML = '';
  articles.forEach(article => {
    grid.appendChild(createTravelCard(article));
  });
}

function createNavBar() {
  const nav = document.createElement('nav');
  return nav;
}

function createTravelCard(data) {
  const card = document.createElement('div');
  card.className = 'travel-card';
  
  const image = document.createElement('img');
  image.src = data.images && data.images.length > 0 ? data.images[0].url : "/api/placeholder/400/300";
  image.alt = data.name;
  
  const content = document.createElement('div');
  content.className = 'travel-card-content';
  
  const title = document.createElement('h3');
  title.textContent = data.name;
  
  const author = document.createElement('p');
  author.className = 'author';
  author.textContent = `By ${data.author}`;
  
  const excerpt = document.createElement('p');
  excerpt.textContent = data.text.substring(0, 100) + '...';
  
  content.appendChild(title);
  content.appendChild(author);
  content.appendChild(excerpt);
  
  card.appendChild(image);
  card.appendChild(content);
  
  return card;
}

function createTravelGrid() {
  const grid = document.createElement('div');
  grid.className = 'travel-grid';
  return grid;
}
