import { Link } from "react-router-dom"; // React Router Link importu
import "./style.css";
import photo from "../../assets/spotify.webp";

const Sidebar = () => {
  return (
    <div className="sidebar">
      <div className="sidebar-header">
        <img src={photo} alt="photo" className="sidebar-photo" />
        <div className="logo">MusicApp</div>
      </div>
      <ul className="menu">
        <li className="menu-item">
          <Link to="/home">Home</Link>
        </li>
        <li className="menu-item">
          <Link to="/library">Library</Link>
        </li>
        <li className="menu-item">
          <Link to="/favorites">Favorites</Link>
        </li>
        <li className="menu-item active">
          <Link to="/">Log Out</Link>
        </li>
      </ul>
    </div>
  );
};

export default Sidebar;
