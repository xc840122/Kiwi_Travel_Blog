/**
 * This component will provide fields for the article title, text, category, 
 * and any optional images. It will send a POST request to the backend to save the article.
 */
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../utils/api';
import '../styles/PostArticle.css';
import { Button, Form, Alert } from 'react-bootstrap';

function PostArticle() {
  const navigate = useNavigate();
  const [articleData, setArticleData] = useState({
    name: '',
    text: '',
    author: '',
    location: '',
    categoryId: '',
    images: []
  });
  const [imageFiles, setImageFiles] = useState([]);
  const [error, setError] = useState('');

  // Handle form input changes
  const handleChange = (e) => {
    setArticleData({ ...articleData, [e.target.name]: e.target.value });
  };

  // Handle image upload
  const handleImageUpload = (e) => {
    const files = Array.from(e.target.files);
    setImageFiles(files);
    const imagePreviews = files.map((file) => ({
      url: URL.createObjectURL(file)
    }));
    setArticleData({ ...articleData, images: imagePreviews });
  };

  // Submit the article
  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem('token');
    if (!token) {
      setError('You must be signed in to post an article.');
      navigate('/login');
      return;
    }

    try {
      // Step 1: Upload images first, get URLs from backend
      const imageUrls = [];
      for (const file of imageFiles) {
        const formData = new FormData();
        formData.append('file', file);
        const imageResponse = await api.post('/path-to-upload-image-api', formData, {
          headers: { Authorization: `Bearer ${token}` }
        });
        imageUrls.push({ url: imageResponse.data.url });
      }

      // Step 2: Submit article with images
      const response = await api.post(
        '/user/article',
        {
          ...articleData,
          images: imageUrls
        },
        { headers: { Authorization: `Bearer ${token}` } }
      );

      // Redirect after successful submission
      navigate(`/article/${response.data.id}`);
    } catch (error) {
      console.error('Error posting article:', error);
      setError('Failed to post article. Please try again.');
    }
  };

  return (
    <div className="post-article container mt-5">
      <h2 className="text-center mb-4">Post a New Article</h2>

      {error && <Alert variant="danger">{error}</Alert>}

      <Form onSubmit={handleSubmit}>
        <Form.Group controlId="name" className="mb-3">
          <Form.Label>Title</Form.Label>
          <Form.Control
            type="text"
            name="name"
            placeholder="Enter article title"
            value={articleData.name}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group controlId="text" className="mb-3">
          <Form.Label>Content</Form.Label>
          <Form.Control
            as="textarea"
            name="text"
            rows={4}
            placeholder="Write your article content here..."
            value={articleData.text}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group controlId="author" className="mb-3">
          <Form.Label>Author</Form.Label>
          <Form.Control
            type="text"
            name="author"
            placeholder="Author's name"
            value={articleData.author}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group controlId="location" className="mb-3">
          <Form.Label>Location</Form.Label>
          <Form.Control
            type="text"
            name="location"
            placeholder="Location"
            value={articleData.location}
            onChange={handleChange}
          />
        </Form.Group>

        <Form.Group controlId="categoryId" className="mb-3">
          <Form.Label>Category ID</Form.Label>
          <Form.Control
            type="number"
            name="categoryId"
            placeholder="Category ID"
            value={articleData.categoryId}
            onChange={handleChange}
            required
          />
        </Form.Group>

        <Form.Group controlId="images" className="mb-4">
          <Form.Label>Upload Images</Form.Label>
          <Form.Control
            type="file"
            multiple
            onChange={handleImageUpload}
            accept="image/*"
          />
          <div className="image-previews mt-3">
            {articleData.images.map((img, index) => (
              <img key={index} src={img.url} alt="Preview" className="preview-img" />
            ))}
          </div>
        </Form.Group>

        <Button type="submit" variant="primary" className="w-100">
          Submit Article
        </Button>
      </Form>
    </div>
  );
}

export default PostArticle;