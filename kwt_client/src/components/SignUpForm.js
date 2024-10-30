/**
 * Component of sign up
 */
// SignUpForm.js
import React, { useState, useEffect } from 'react';
import { Form, Button, Alert } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import '../styles/AuthForms.css';

function SignUpForm() {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('http://localhost:5082/api/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'accept': '*/*'
        },
        body: JSON.stringify({
          userName: username,
          email: email,
          password: password
        })
      });

      if (!response.ok) {
        throw new Error('Registration failed. Please check the details and try again.');
      }

      setSuccess(true);
      setTimeout(() => navigate('/login'), 2000); // Redirect to login after success message

    } catch (err) {
      setUsername('')
      setPassword('')
      setEmail('')
      setError(err.message);
    }
  };

  // Auto-dismiss alerts after 3 seconds
  useEffect(() => {
    if (error || success) {
      const timer = setTimeout(() => {
        setError(null);
        setSuccess(false);
      }, 2000);

      return () => clearTimeout(timer); // Clear timeout if component unmounts or state changes
    }
  }, [error, success]);

  return (
    <div className="auth-form">
      <h2 className="text-center mb-4">Join Now</h2>
      {error && <Alert variant="danger">{error}</Alert>}
      {success && <Alert variant="success">Registration successful! Redirecting to login...</Alert>}
      <Form onSubmit={handleRegister}>
        <Form.Group controlId="username" className="mb-3">
          <Form.Control
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </Form.Group>
        <Form.Group controlId="email" className="mb-3">
          <Form.Control
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Group>
        <Form.Group controlId="password" className="mb-3">
          <Form.Control
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>
        <Button type="submit" variant="primary" className="w-100 fancy-button">Join Now</Button>
      </Form>
    </div>
  );
}

export default SignUpForm;
