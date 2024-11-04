/**
 * Component of ArticleList
 */
import React, { useEffect, useState } from 'react';
import api from '../utils/api';
import { Link } from 'react-router-dom';

function ArticleList({ categoryId }) {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    if (categoryId) {
      api.get(`/user/article?CategoryId=${categoryId}`)
        .then(response => setArticles(response.data.data))
        .catch(error => console.error("Error fetching articles:", error));
    }
  }, [categoryId]);

  return (
    <div className="container mt-4">
      <div className="row article-list">
        {articles.length > 0 ? (
          articles.map(article => (
            <div key={article.id} className="col-md-5 mb-4">
              <Link to={`/article/${article.id}`} className="text-decoration-none text-dark">
                <div className="card h-100">
                  <img
                    src={article.coverImage.url}
                    className="card-img-top"
                    alt={article.name}
                    style={{ maxHeight: '200px', objectFit: 'cover' }}
                  />
                  <div className="card-body">
                    <h5 className="card-title">{article.name}</h5>
                    <p className="card-text">by {article.author}</p>
                  </div>
                </div>
              </Link>
            </div>
          ))
        ) : (
          <p className="text-center">No articles found for this category.</p>
        )}
      </div>
    </div>
  );
}

export default ArticleList;

