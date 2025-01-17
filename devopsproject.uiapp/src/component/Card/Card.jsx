import { useState } from "react";
import PlayMusic from "../PlayMusic/PlayMusic";
import "./style.css";

const Card = ({ title, uploader, image, fileUrl, onFavorite }) => {
  const [isFavorite, setIsFavorite] = useState(false);

  const handleFavorite = () => {
    setIsFavorite(!isFavorite);
    onFavorite({ title, uploader, image, fileUrl }); // Favori funksiyasını çağır
  };

  return (
    <div className="card">
      <img src={image} alt={title} className="card-image" />
      <h3 className="card-title">{title}</h3>
      <p className="card-uploader">Uploaded by {uploader}</p>
      <div className="card-controls">
        <a href={fileUrl} download className="card-download">
          Download
        </a>
        <PlayMusic />
        <button
          className={`favorite-button ${isFavorite ? "active" : ""}`}
          onClick={handleFavorite}
        >
          ❤️
        </button>
      </div>
    </div>
  );
};

export default Card;
