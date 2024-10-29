const API_BASE_URL = 'http://localhost:3000/api';

document.addEventListener('DOMContentLoaded', function () {
  const app = document.getElementById('app');
  app.appendChild(createHeader());
  app.appendChild(createMainContent()); // Create a main content container
  loadContent(); // Load the travel grid by default
});

function createHeader() {
  const header = document.createElement('header');
  header.style.display = 'flex';
  header.style.flexDirection = 'column';
  header.style.alignItems = 'center';
  header.style.padding = '10px';

  const title = document.createElement('h1');
  title.textContent = 'Nature of Aotearoa';

  const searchContainer = document.createElement('div');
  searchContainer.className = 'search-container';
  searchContainer.style.display = 'flex';
  searchContainer.style.alignItems = 'center';
  searchContainer.style.marginTop = '10px';

  const searchInput = document.createElement('input');
  searchInput.type = 'text';
  searchInput.placeholder = 'Search NZ destinations';

  const searchIcon = document.createElement('span');
  searchIcon.className = 'search-icon';
  searchIcon.innerHTML = '🔍';

  searchContainer.appendChild(searchInput);
  searchContainer.appendChild(searchIcon);

  const authContainer = createAuthButtons();
  authContainer.style.display = 'flex';
  authContainer.style.gap = '10px';
  authContainer.style.marginTop = '10px';

  header.appendChild(title);
  header.appendChild(searchContainer);
  header.appendChild(authContainer);

  return header;
}

function createAuthButtons() {
  const authContainer = document.createElement('div');
  authContainer.className = 'auth-container';

  const loginButton = document.createElement('button');
  loginButton.textContent = 'Login';
  loginButton.addEventListener('click', showLoginForm);

  const registerButton = document.createElement('button');
  registerButton.textContent = 'Register';
  registerButton.addEventListener('click', showRegisterForm);

  authContainer.appendChild(loginButton);
  authContainer.appendChild(registerButton);

  return authContainer;
}

function showLoginForm() {
  // Implement the logic to show the login form
  alert('Show login form');
}

function showRegisterForm() {
  // Implement the logic to show the register form
  alert('Show register form');
}

function createMainContent() {
  const mainContent = document.createElement('main');
  mainContent.id = 'main-content';
  mainContent.style.padding = '20px';
  return mainContent;
}

function loadContent() {
  fetch(`${API_BASE_URL}/articles`) // Update the endpoint if necessary
    .then(response => response.json())
    .then(articles => {
      const mainContent = document.getElementById('main-content');

      // Create and append the category filter dropdown
      const categoryFilter = document.createElement('select');
      categoryFilter.id = 'category-filter';
      categoryFilter.innerHTML = `
        <option value="all">All Categories</option>
        ${[...new Set(articles.map(article => article.category))].map(category => `
          <option value="${category}">${category}</option>
        `).join('')}
      `;
      mainContent.appendChild(categoryFilter);

      const gridContainer = document.createElement('div');
      gridContainer.className = 'grid-container';
      gridContainer.style.display = 'grid';
      gridContainer.style.gridTemplateColumns = 'repeat(2, 1fr)';
      gridContainer.style.gap = '20px';
      mainContent.appendChild(gridContainer);

      function renderArticles(filteredArticles) {
        gridContainer.innerHTML = ''; // Clear previous content
        filteredArticles.forEach(article => {
          const gridItem = document.createElement('div');
          gridItem.className = 'grid-item';

          const img = document.createElement('img');
          img.src = article.images[0].url; // Use the first image from the images array
          img.alt = article.name;

          const title = document.createElement('h2');
          title.textContent = article.name;

          const categoryButton = document.createElement('button');
          categoryButton.textContent = article.category;
          categoryButton.classList.add('category-button');

          gridItem.appendChild(img);
          gridItem.appendChild(title);
          gridItem.appendChild(categoryButton);
          gridContainer.appendChild(gridItem);
        });
      }

      // Initial render
      renderArticles(articles);

      // Add event listener for category filter
      categoryFilter.addEventListener('change', (event) => {
        const selectedCategory = event.target.value;
        if (selectedCategory === 'all') {
          renderArticles(articles);
        } else {
          const filteredArticles = articles.filter(article => article.category === selectedCategory);
          renderArticles(filteredArticles);
        }
      });
    });
}