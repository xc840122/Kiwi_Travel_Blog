// /**
//  * This component manages state for selectedCategoryId and include CategoryList and ArticleList.
//  */

// src/components/Articles.js
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import CategoryList from './CategoryList';
import ArticleList from './ArticleList';
import { Button } from 'react-bootstrap';
import '../styles/Articles.css';

function Articles() {
  const token = localStorage.getItem('token');
  const isAuthenticated = Boolean(token);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);

  const handleCategorySelect = (categoryId) => {
    setSelectedCategoryId(categoryId);
  };

  return (
    <div className="articles-page">
      {/* Hero Section */}
      <div className="hero-section">
        <div className="hero-content">
          <h1>Discover Incredible Places</h1>
          <p>Explore travel stories, tips, and guides from around the world.</p>
        </div>
      </div>

      <div className="container mt-4">
        {/* Post Article Button for Authenticated Users */}
        {isAuthenticated && (
          <div className="text-end mb-4">
            <Button as={Link} to="/post-article" variant="success">Post New Article</Button>
          </div>
        )}

        {/* Main Layout with Sidebar and Masonry Content */}
        <div className="row">
          <div className="col-md-3">
            <div className="sticky-sidebar">
              <h4 className="text-center mb-3">Explore Categories</h4>
              <CategoryList onCategorySelect={handleCategorySelect} />
            </div>
          </div>
          <div className="col-md-9">
            {selectedCategoryId ? (
              <ArticleList categoryId={selectedCategoryId} />
            ) : (
              <p className="text-center mt-4">Select a category to see articles</p>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Articles;