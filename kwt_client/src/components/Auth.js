/**
 *  Components of login
 */
import React, { useState } from 'react';
import api from '../utils/api';

function Auth({ isLogin, onAuthSuccess }) {
  const [formData, setFormData] = useState({ userName: '', password: '', email: '' });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const url = isLogin ? '/login' : '/register';
    try {
      const { data } = await api.post(url, formData);
      if (data.token) {
        localStorage.setItem('token', data.token);
        onAuthSuccess();
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="form">
      {!isLogin && <input name="email" placeholder="Email" onChange={handleChange} />}
      <input name="userName" placeholder="Username" onChange={handleChange} />
      <input name="password" type="password" placeholder="Password" onChange={handleChange} />
      <button type="submit" className="btn btn-primary">{isLogin ? 'Login' : 'Register'}</button>
    </form>
  );
}
export default Auth;