import Sidebar from "../Sidebar/Sidebar";
import Card from "../Card/Card";
import "./style.css";

const Library = () => {
  return (
    <div className="main-container">
      <Sidebar />
      <div className="content">
        <h2>Library</h2>
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
            image="https://via.placeholder.com/300"
            fileUrl="/assets/music/musicc.mp3" // Public qovluğundakı faylın yolu
          />
        
        </div>
      </div>
    </div>
  );
};

export default Library;
