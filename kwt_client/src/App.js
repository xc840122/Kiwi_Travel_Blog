import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Articles from './components/Articles';
import ArticleDetail from './components/ArticleDetail';
import PostArticle from './components/PostArticle';
import AppNavbar from './components/AppNavBar';
import SignInForm from './components/SignInForm'
import SignUpForm from './components/SignUpForm'
// import ProtectedRoute from './components/ProtectedRoute';

function App() {
  return (
    <Router>
      <AppNavbar />
      <Routes>
        <Route path="/login" element={<SignInForm />} />
        <Route path="/register" element={<SignUpForm />} />
        <Route path="/" element={<Articles />} />
        <Route path="/article/:id" element={<ArticleDetail />} />
        <Route path="/post-article" element={<PostArticle />} />
        {/* <Route path="/post-article" element={<ProtectedRoute component={PostArticle} />} /> */}
      </Routes>
    </Router>
  );
}

export default App;
