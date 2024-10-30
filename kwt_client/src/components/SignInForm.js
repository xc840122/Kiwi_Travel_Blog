/**
 * Components of sign in form
 */
import React from 'react';
import { Form, Button } from 'react-bootstrap';
import '../styles/AuthForms';

function SignInForm() {
  return (
    <div className="auth-form">
      <h2 className="text-center mb-4">Sign In</h2>
      <Form>
        <Form.Group controlId="email" className="mb-3">
          <Form.Control type="email" placeholder="Email" />
        </Form.Group>
        <Form.Group controlId="password" className="mb-3">
          <Form.Control type="password" placeholder="Password" />
        </Form.Group>
        <Button type="submit" variant="primary" className="w-100 fancy-button">Sign In</Button>
      </Form>
    </div>
  );
}

export default SignInForm;