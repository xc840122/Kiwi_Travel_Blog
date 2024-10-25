const API_BASE_URL = 'http://localhost:3000/api';

document.addEventListener('DOMContentLoaded', function () {
  const app = document.getElementById('app');
  app.appendChild(createHeader());
  app.appendChild(createNavBar());
  loadContent(); // Load the travel grid by default
});

function createHeader() {
  const header = document.createElement('header');

  const title = document.createElement('h1');
  title.textContent = 'Nature of Aotearoa';

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

function createNavBar() {
  const nav = document.createElement('nav');
  return nav;
}

function loadContent() {
  fetch(`${API_BASE_URL}/articles`) // Update the endpoint if necessary
    .then(response => response.json())
    .then(articles => {
      const gridContainer = document.createElement('div');
      gridContainer.className = 'grid-container';

      articles.forEach(article => {
        const gridItem = document.createElement('div');
        gridItem.className = 'grid-item';

        const img = document.createElement('img');
        img.src = article.images[0].url; // Use the first image from the images array
        img.alt = article.name;

        const title = document.createElement('h2');
        title.textContent = article.name;

        const author = document.createElement('p');
        author.textContent = `Author: ${article.author}`;

        const text = document.createElement('p');
        text.textContent = article.text.substring(0, 100) + '...'; // Short excerpt

        gridItem.appendChild(img);
        gridItem.appendChild(title);
        gridItem.appendChild(author);
        gridItem.appendChild(text);

        gridContainer.appendChild(gridItem);
      });

      const app = document.getElementById('app');
      app.appendChild(gridContainer);
    })
    .catch(error => console.error('Error fetching articles:', error));
}
