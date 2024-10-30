/**
 * Component of sign up
 */
import React from 'react';
import { Form, Button } from 'react-bootstrap';
import '../styles/AuthForms';

function SignUpForm() {
  return (
    <div className="auth-form">
      <h2 className="text-center mb-4">Join Now</h2>
      <Form>
        <Form.Group controlId="username" className="mb-3">
          <Form.Control type="text" placeholder="Username" />
        </Form.Group>
        <Form.Group controlId="email" className="mb-3">
          <Form.Control type="email" placeholder="Email" />
        </Form.Group>
        <Form.Group controlId="password" className="mb-3">
          <Form.Control type="password" placeholder="Password" />
        </Form.Group>
        <Button type="submit" variant="primary" className="w-100 fancy-button">Join Now</Button>
      </Form>
    </div>
  );
}

export default SignUpForm;