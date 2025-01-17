import "./App.css";
import Home from "./component/Home/Home";
import Register from "./component/Register/Register";
import Login from "./component/Login/Login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import PlayMusic from "./component/PlayMusic/PlayMusic";
import Library from "./component/Library/Library";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/home" element={<Home />} />
          <Route path="/register" element={<Register />} />
          <Route path="/musicPlay" element={<PlayMusic />} />
          <Route path="/library" element={<Library />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
