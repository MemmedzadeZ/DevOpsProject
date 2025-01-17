import { useState } from "react";
import "./style.css";

const Login = () => {
  const [passwordVisible, setPasswordVisible] = useState(false);

  const togglePasswordVisibility = () => {
    setPasswordVisible(!passwordVisible);
  };

  return (
    <div className="login-container">
      <h1>Login to Music</h1>
      <div className="social-login-buttons">
        <button className="google-login">Login with Google</button>
        <button className="facebook-login">Login with Facebook</button>
        <button className="apple-login">Login with Apple</button>
      </div>
      <hr />
      <form>
        <label htmlFor="email">Email or Username</label>
        <input type="text" id="email" placeholder="Email or Username" />
        <label htmlFor="password">Password</label>
        <div className="password-wrapper">
          <input
            type={passwordVisible ? "text" : "password"}
            id="password"
            placeholder="Password"
          />
          <span className="toggle-password" onClick={togglePasswordVisibility}>
            👁️
          </span>
        </div>
        <button type="submit" className="login-button">
          <a href="/home" style={{ color: "white" }}>
            Login
          </a>
        </button>
        <p className="already-account">
          Create a New Account.
          <a href="/register" style={{ color: "#1db954" }}>
            Register
          </a>
        </p>
      </form>
    </div>
  );
};

export default Login;
