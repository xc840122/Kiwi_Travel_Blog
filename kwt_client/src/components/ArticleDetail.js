/**
 * Display Article and Comments, Allow Adding Comments:
 * */
import React, { useEffect, useState } from 'react';
import api from '../utils/api';
import { useParams } from 'react-router-dom';
import { Carousel, Button, Form, ListGroup } from 'react-bootstrap';

function ArticleDetail() {
  const { id } = useParams();
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
    <div className="container mt-4">
      <h2 className="text-center">{article.title}</h2>
      <p className="text-muted text-center">{article.description}</p>

      {/* Carousel */}
      <Carousel className="mb-4">
        {article.images?.map((image, index) => (
          <Carousel.Item key={index}>
            <img
              className="d-block w-100"
              src={image.url}
              alt={`Slide ${index + 1}`}
              style={{ maxHeight: '400px', objectFit: 'cover' }}
            />
          </Carousel.Item>
        ))}
      </Carousel>

      {/* Article Details */}
      <div className="mb-4">
        <p><strong>Author:</strong> {article.author?.name}</p>
        <p><strong>Location:</strong> New Zealand</p>
        <p><strong>Created:</strong> {new Date(article.createdAt).toLocaleDateString()}</p>
        <p><strong>Last Updated:</strong> {new Date(article.updatedAt).toLocaleDateString()}</p>
        <div className="d-flex justify-content-around my-3">
          <Button variant="outline-primary">
            Favourites: {article.favourites || 0}
          </Button>
          <Button variant="outline-success">
            Likes: {article.likes || 0}
          </Button>
          <Button variant="outline-info">Share</Button>
        </div>
      </div>

      {/* Comments Section */}
      <h4>Comments</h4>
      <ListGroup className="mb-4">
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

      {/* Comment Form */}
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