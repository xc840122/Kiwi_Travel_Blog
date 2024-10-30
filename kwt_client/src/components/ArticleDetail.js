/**
 * Display Article and Comments, Allow Adding Comments:
 * */
import React, { useEffect, useState } from 'react';
import api from '../utils/api';
import { useParams, useNavigate } from 'react-router-dom';  // Import useNavigate
import { Carousel, Button, Form, ListGroup } from 'react-bootstrap';
import defaultAvatar from '../assets/default_avatar_min.png';
import '../styles/ArticleDetail.css';

function ArticleDetail() {
  const { id } = useParams();
  const navigate = useNavigate();  // Initialize navigate function
  const [article, setArticle] = useState({});
  const [comments, setComments] = useState([]);
  const [commentText, setCommentText] = useState('');

  useEffect(() => {
    const fetchArticle = async () => {
      try {
        const { data } = await api.get(`/user/article/${id}`);
        setArticle(data.data);
        setComments(data.data.comments);
      } catch (error) {
        console.error("Error fetching article details:", error);
      }
    };
    fetchArticle();
  }, [id]);

  const handleCommentSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem('token');
    if (!token) {
      alert('You must be logged in to post a comment.');
      return;
    }

    try {
      const response = await api.post(`/user/comment`, {
        articleId: article.id,
        text: commentText,
      });
      setComments([...comments, response.data.data]);
      setCommentText('');
    } catch (error) {
      console.error("Error posting comment:", error);
    }
  };

  return (
    <div className="article-detail container mt-4">

      {/* Return Button */}
      <Button variant="outline-secondary" onClick={() => navigate(-1)} className="mb-3 return-button">
        &larr; Back
      </Button>

      <h2 className="text-center mb-3">{article.name}</h2>

      <Carousel className="mb-4" interval={3000} indicators={true}>
        {article.images?.map((image, index) => (
          <Carousel.Item key={index}>
            <img
              className="d-block w-100"
              src={image.url}
              alt={`Slide ${index + 1}`}
            />
          </Carousel.Item>
        ))}
      </Carousel>

      {/* Article Meta Section */}
      <div className="article-meta">
        <div className="d-flex align-items-center">
          <img src={defaultAvatar} alt="author" className="rounded-circle me-2" />
          <div>
            <p>{article.author || "Unknown Author"}</p>
            <small>Location: {article.location}</small>
          </div>
        </div>
        <div className="text-end">
          <small>Created: {new Date(article.createTime).toLocaleDateString()}</small><br />
          <small>Modified: {new Date(article.updateTime).toLocaleDateString()}</small>
        </div>
      </div>

      {/* Article Content */}
      <div className="article-content">
        {article.text}
      </div>

      <div className="interaction-buttons">
        <Button variant="outline-danger">Favourites: {article.favourites || 0}</Button>
        <Button variant="outline-success">Likes: {article.likes || 0}</Button>
        <Button variant="outline-primary">Share</Button>
      </div>

      <h4>Comments</h4>
      <ListGroup className="comments-section mb-4">
        {comments.length > 0 ? comments.map((comment, index) => (
          <ListGroup.Item key={index} className="border mb-2">
            <p><strong>{comment.user?.name || 'Anonymous'}</strong> - {new Date(comment.createdAt).toLocaleDateString()}</p>
            <p>{comment.text}</p>
            <p className="text-muted">Location: {comment.location || 'New Zealand'}</p>
            <div className="d-flex justify-content-between">
              <span>Likes: {comment.likes || 0}</span>
            </div>
          </ListGroup.Item>
        )) : (
          <p>No comments yet. Be the first to comment!</p>
        )}
      </ListGroup>

      <Form onSubmit={handleCommentSubmit}>
        <Form.Group controlId="commentText">
          <Form.Control
            type="text"
            placeholder="Add a comment"
            value={commentText}
            onChange={(e) => setCommentText(e.target.value)}
            required
          />
        </Form.Group>
        <Button type="submit" className="mt-3" variant="primary">Submit</Button>
      </Form>
    </div>
  );
}

export default ArticleDetail;