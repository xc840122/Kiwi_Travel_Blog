/**
 * This component will provide fields for the article title, text, category, 
 * and any optional images. It will send a POST request to the backend to save the article.
 */
import React, { useState, useEffect } from 'react';
import api from '../utils/api';

function PostArticle() {
  const [title, setTitle] = useState('');
  const [text, setText] = useState('');
  const [category, setCategory] = useState('');
  const [categories, setCategories] = useState([]);
  const [images, setImages] = useState([]);

  // Fetch categories for selection
  useEffect(() => {
    api.get('/user/category/all')
      .then(response => setCategories(response.data))
      .catch(error => console.error('Error fetching categories:', error));
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post('/user/article', {
        title,
        text,
        categoryId: category,
        images: images.map((url) => ({ url }))  // Array of image URLs
      });
      console.info('Article posted successfully:', response.data);
      // Clear the form fields after successful submission
      setTitle('');
      setText('');
      setCategory('');
      setImages([]);
    } catch (error) {
      console.error('Error posting article:', error);
    }
  };

  return (
    <div className="container">
      <h2>Post a New Article</h2>
      <form onSubmit={handleSubmit}>

        {/* Article Title */}
        <div className="form-group">
          <label>Title</label>
          <input
            type="text"
            className="form-control"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </div>

        {/* Article Text */}
        <div className="form-group">
          <label>Content</label>
          <textarea
            className="form-control"
            value={text}
            onChange={(e) => setText(e.target.value)}
            rows="5"
            required
          />
        </div>

        {/* Category Selection */}
        <div className="form-group">
          <label>Category</label>
          <select
            className="form-control"
            value={category}
            onChange={(e) => setCategory(e.target.value)}
            required
          >
            <option value="">Select a category</option>
            {categories.map((cat) => (
              <option key={cat.id} value={cat.id}>
                {cat.name}
              </option>
            ))}
          </select>
        </div>

        {/* Image URLs */}
        <div className="form-group">
          <label>Image URLs (optional)</label>
          <input
            type="text"
            className="form-control"
            placeholder="Add an image URL and press Enter"
            onKeyDown={(e) => {
              if (e.key === 'Enter' && e.target.value) {
                setImages([...images, e.target.value]);
                e.target.value = '';
                e.preventDefault();
              }
            }}
          />
          <div>
            {images.map((url, index) => (
              <div key={index} className="badge badge-secondary m-1">
                {url}
              </div>
            ))}
          </div>
        </div>

        {/* Submit Button */}
        <button type="submit" className="btn btn-primary">
          Submit Article
        </button>
      </form>
    </div>
  );
}

export default PostArticle;