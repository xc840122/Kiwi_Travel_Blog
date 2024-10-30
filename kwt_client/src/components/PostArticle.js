import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../utils/api';
import '../styles/PostArticle.css';
import { Button, Form, Alert } from 'react-bootstrap';
import { AiOutlineClose } from 'react-icons/ai';
/**
 * 
 * This component will provide fields for the article title, text, category, 
 * and any optional images. It will send a POST request to the backend to save the article.
 * @returns 
 */

const PostArticle = () => {
  const navigate = useNavigate();
  const [articleData, setArticleData] = useState({
    name: '',
    text: '',
    author: '',
    location: 'Auckland, New Zealand',
    categoryId: '',
    images: []
  });
  const [imageFiles, setImageFiles] = useState([]);
  const [error, setError] = useState('');
  const [categories, setCategories] = useState([]); // State to store categories

  // Fetch categories on component mount
  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await api.get('/user/Category/all');
        setCategories(response.data.data);
      } catch (error) {
        console.error('Error fetching categories:', error);
        setError('Failed to load categories. Please try again.');
      }
    };

    fetchCategories();
  }, []);

  // Handle form input changes
  const handleChange = (e) => {
    setArticleData({ ...articleData, [e.target.name]: e.target.value });
  };

  // Handle image upload
  const handleImageUpload = async (e) => {
    const files = Array.from(e.target.files);
    setImageFiles(files);
    const imagePreviews = files.map((file) => ({
      url: URL.createObjectURL(file)
    }));
    setArticleData({ ...articleData, images: imagePreviews });
  };

  // Handle image removal
  const handleRemoveImage = (index) => {
    const updatedFiles = [...imageFiles];
    updatedFiles.splice(index, 1);
    setImageFiles(updatedFiles);

    const updatedImages = [...articleData.images];
    updatedImages.splice(index, 1);
    setArticleData({ ...articleData, images: updatedImages });
  };

  // Submit the article
  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem('token');
    if (!token) {
      setError('You must be signed in to post an article.');
      // navigate('/login');
      return;
    }

    try {
      // POST article data
      const response = await api.post('/user/article',
        {
          ...articleData,
        }
      );

      // After successful submission, fetch and show the new article
      const articleId = response.data.id;
      const articleResponse = await api.get(`/user/article/${articleId}`);

      console.log('Posted article:', articleResponse.data);
      navigate(`/article/${articleId}`);
    } catch (error) {
      console.error('Error posting article:', error);
      setError('Failed to post article. Please try again.');
    }
  };

  return (
    <div className="post-article container mt-5">
      <h2 className="text-center mb-4">Post a New Article</h2>
      {error && <Alert variant="danger">{error}</Alert>}

      {/* Title, Text, Location, Images, Category fields */}
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
        <Form.Group controlId="categoryId" className="mb-3">
          <Form.Label>Category</Form.Label>
          <Form.Control
            as="select"
            name="categoryId"
            value={articleData.categoryId}
            onChange={handleChange}
            required
          >
            <option value="">Select a category</option>
            {categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </Form.Control>
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
              < div key={index} className="image-preview-container" >
                <img src={img.url} alt="Preview" className="preview-img" />
                <button
                  type="button"
                  className="remove-image-btn"
                  onClick={() => handleRemoveImage(index)}
                >
                  <AiOutlineClose />
                </button>
              </div>
            ))}
          </div>
        </Form.Group>
        <Button type="submit" variant="primary" className="w-100">
          Submit Article
        </Button>
      </Form>
    </div >
  );
};

export default PostArticle;