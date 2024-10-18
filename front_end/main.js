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
  header.className = 'flex justify-between items-center p-4 bg-white shadow-sm';
  
  const title = document.createElement('h1');
  title.className = 'text-xl font-bold';
  title.textContent = 'Discover New Zealand';
  
  const searchContainer = document.createElement('div');
  searchContainer.className = 'flex items-center space-x-4';
  
  const searchWrapper = document.createElement('div');
  searchWrapper.className = 'relative';
  
  const searchInput = document.createElement('input');
  searchInput.type = 'text';
  searchInput.placeholder = 'Search NZ destinations';
  searchInput.className = 'pl-8 pr-2 py-1 border rounded-full';
  
  const searchIcon = document.createElement('span');
  searchIcon.className = 'absolute left-2 top-1/2 transform -translate-y-1/2 text-gray-400';
  searchIcon.innerHTML = '🔍';
  
  searchWrapper.appendChild(searchInput);
  searchWrapper.appendChild(searchIcon);
  searchContainer.appendChild(searchWrapper);
  
  header.appendChild(title);
  header.appendChild(searchContainer);
  
  return header;
}

function createAuthForms() {
  const container = document.createElement('div');
  container.className = 'flex justify-center space-x-4 my-4';

  const registerForm = document.createElement('form');
  registerForm.id = 'registerForm';
  registerForm.className = 'bg-white p-4 rounded shadow';
  registerForm.innerHTML = `
    <h2 class="text-lg font-bold mb-2">Register</h2>
    <input type="text" name="userName" placeholder="Username" required class="block w-full mb-2 p-2 border rounded">
    <input type="email" name="email" placeholder="Email" required class="block w-full mb-2 p-2 border rounded">
    <input type="password" name="password" placeholder="Password" required class="block w-full mb-2 p-2 border rounded">
    <button type="submit" class="w-full bg-blue-500 text-white p-2 rounded">Register</button>
  `;

  const loginForm = document.createElement('form');
  loginForm.id = 'loginForm';
  loginForm.className = 'bg-white p-4 rounded shadow';
  loginForm.innerHTML = `
    <h2 class="text-lg font-bold mb-2">Login</h2>
    <input type="text" name="userName" placeholder="Username" required class="block w-full mb-2 p-2 border rounded">
    <input type="password" name="password" placeholder="Password" required class="block w-full mb-2 p-2 border rounded">
    <button type="submit" class="w-full bg-green-500 text-white p-2 rounded">Login</button>
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
    button.className = 'text-sm whitespace-nowrap';
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
  const grid = document.querySelector('.grid');
  grid.innerHTML = '';
  articles.forEach(article => {
    grid.appendChild(createTravelCard(article));
  });
}

function createNavBar() {
  const nav = document.createElement('nav');
  nav.className = 'flex space-x-4 p-4 bg-gray-100 overflow-x-auto';
  return nav;
}

function createTravelCard(data) {
  const card = document.createElement('div');
  card.className = 'bg-white rounded-lg overflow-hidden shadow-md';
  
  const image = document.createElement('img');
  image.src = data.images && data.images.length > 0 ? data.images[0].url : "/api/placeholder/400/300";
  image.alt = data.name;
  image.className = 'w-full h-40 object-cover';
  
  const content = document.createElement('div');
  content.className = 'p-4';
  
  const title = document.createElement('h3');
  title.className = 'font-semibold text-sm mb-1';
  title.textContent = data.name;
  
  const author = document.createElement('p');
  author.className = 'text-xs text-gray-500 mb-2';
  author.textContent = `By ${data.author}`;
  
  const excerpt = document.createElement('p');
  excerpt.className = 'text-sm';
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
  grid.className = 'grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5 gap-4 p-4';
  return grid;
}
