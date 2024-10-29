/**
 * Display Article and Comments, Allow Adding Comments:
 * */
import React, { useEffect, useState } from 'react';
import api from '../utils/api';

function ArticleDetail({ match }) {
  const [article, setArticle] = useState({});
  const [comments, setComments] = useState([]);
  const [commentText, setCommentText] = useState('');

  useEffect(() => {
    api.get(`/user/article/${match.params.id}`)
      .then(({ data }) => {
        setArticle(data.article);
        setComments(data.comments);
      });
  }, [match.params.id]);

  const handleCommentSubmit = async (e) => {
    e.preventDefault();
    // Ensure only logined user can add comments
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
      setComments([...comments, response.data]);
      setCommentText('');
    } catch (error) {
      console.error("Error posting comment:", error);
    }
  };

  return (
    <div className="container">
      <h2>{article.title}</h2>
      <p>{article.text}</p>
      <div className="comments">
        {comments.map((comment, index) => (
          <div key={index}>{comment.text}</div>
        ))}
      </div>
      <form onSubmit={handleCommentSubmit}>
        <input
          value={commentText}
          onChange={(e) => setCommentText(e.target.value)}
          placeholder="Add a comment"
        />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
}

export default ArticleDetail;