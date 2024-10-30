import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Articles from './components/Articles';
import ArticleDetail from './components/ArticleDetail';
import Auth from './components/Auth';
import PostArticle from './components/PostArticle';
import AppNavbar from './components/AppNavBar';

function App() {
  return (
    <Router>
      <AppNavbar />
      <Routes>
        <Route path="/login" element={<Auth isLogin />} />
        <Route path="/register" element={<Auth />} />
        <Route path="/" element={<Articles />} />
        <Route path="/article/:id" element={<ArticleDetail />} />
        <Route path="/post-article" element={<PostArticle />} />
      </Routes>
    </Router>
  );
}

export default App;
