import Sidebar from "../Sidebar/Sidebar";
import Card from "../Card/Card";
import "./style.css";
import { useState } from "react";

const Main = () => {
  const [favorites, setFavorites] = useState([]);

  const handleFavorite = (item) => {
    // Əgər artıq favorilər siyahısındadırsa, çıxar
    if (favorites.some((fav) => fav.title === item.title)) {
      setFavorites(favorites.filter((fav) => fav.title !== item.title));
    } else {
      // Əks halda əlavə et
      setFavorites([...favorites, item]);
    }
  };
  return (
    <div className="main-container">
      <Sidebar />
      <div className="content">
        <h2>Home</h2>
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            marginTop: "50px",
          }}
        >
          <Card
            title="Relaxing Music"
            uploader="John Doe"
            image="/assets/apple-music-note.jpg"
            fileUrl="/assets/music/musicc.mp3" // Public qovluğundakı faylın yolu
          />
        </div>
        <ul className="favorites-list">
          {favorites.map((fav, index) => (
            <li key={index}>
              {fav.title} - {fav.uploader}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Main;
