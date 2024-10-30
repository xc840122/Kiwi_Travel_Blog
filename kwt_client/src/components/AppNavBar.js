/**
 * Component of nav bar
 */
// AppNavbar.js
// AppNavbar.js
import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Navbar, Nav, Button, Dropdown, Form } from 'react-bootstrap';
import defaultAvatar from '../assets/default_avatar_min.png';
import '../styles/AppNavBar.css';

function AppNavbar() {
  const navigate = useNavigate();
  const token = localStorage.getItem('token');
  const isAuthenticated = Boolean(token);

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login');
  };

  return (
    <Navbar expand="lg" className="app-navbar fixed-top">
      <Navbar.Brand as={Link} to="/" className="brand-logo">
        🌍 Kiwi Travel Blog
      </Navbar.Brand>
      <Navbar.Toggle aria-controls="navbar-content" />
      <Navbar.Collapse id="navbar-content">
        <Nav className="mx-auto">
          <Form inline className="search-form">
            <input
              type="text"
              className="form-control search-bar"
              placeholder="Search..."
            />
          </Form>
        </Nav>
        <Nav className="ms-auto d-flex align-items-center">
          <Nav.Item>
            <Button
              as={Link}
              to={isAuthenticated ? "/post-article" : "#"}
              variant="primary"
              onClick={() => !isAuthenticated && navigate('/login')}
              className="post-article-button"
            >
              Post Article
            </Button>
          </Nav.Item>
          {isAuthenticated ? (
            <Dropdown align="end" className="ms-3">
              <Dropdown.Toggle variant="light" className="profile-dropdown">
                <img src={defaultAvatar} alt="avatar" className="navbar-avatar" />
                <span className="ms-2 username">Username</span>
              </Dropdown.Toggle>
              <Dropdown.Menu>
                <Dropdown.Item as={Link} to="/profile">Profile</Dropdown.Item>
                <Dropdown.Item as={Link} to="/settings">Settings</Dropdown.Item>
                <Dropdown.Item as={Link} to="/history">History</Dropdown.Item>
                <Dropdown.Divider />
                <Dropdown.Item onClick={handleLogout}>Logout</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          ) : (
            <>
              <Button as={Link} to="/login" variant="light" className="ms-3 fancy-button">Sign In</Button>
              <Button as={Link} to="/register" variant="success" className="ms-2 fancy-button">Join Now</Button>
            </>
          )}
        </Nav>
      </Navbar.Collapse>
    </Navbar>
  );
}

export default AppNavbar;

