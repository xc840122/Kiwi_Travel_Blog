/**
 * Common component of aleart bubble
 * @param {message} param0 
 * @returns 
 */
import '../styles/AlertBubble.css'

const AlertBubble = ({ message }) => (
  <div className="alert-bubble">
    {message}
  </div>
);

export default AlertBubble