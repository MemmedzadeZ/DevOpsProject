import { useState } from "react";
import "./style.css";

const Register = () => {
  const [passwordVisible, setPasswordVisible] = useState(false);
  const [formData, setFormData] = useState({
    name: "",
    username: "",
    email: "",
    password: "",
  });

  const togglePasswordVisibility = () => {
    setPasswordVisible(!passwordVisible);
  };

  const handleChange = (e) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(
        "https://localhost:7131/api/Identity/register",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(formData),
        }
      );

      if (response.ok) {
        const data = await response.json();
        console.log("Registration successful!", data);
        alert("Registration successful!");
      } else {
        const errorData = await response.json();
        console.error("Registration failed", errorData);
        alert("Registration failed: " + errorData.message || "Unknown error");
      }
    } catch (error) {
      console.error("Error occurred while registering:", error);
      alert("An error occurred. Please try again later.");
    }
  };

  return (
    <div className="register-container">
      <h1>Registration to Music </h1>
      <form onSubmit={handleRegister}>
        <label htmlFor="name">Name</label>
        <input
          type="text"
          id="name"
          placeholder="Enter your name"
          value={formData.name}
          onChange={handleChange}
          required
        />

        <label htmlFor="username">Username</label>
        <input
          type="text"
          id="username"
          placeholder="Enter your username"
          value={formData.username}
          onChange={handleChange}
          required
        />

        <label htmlFor="email">Email</label>
        <input
          type="email"
          id="email"
          placeholder="Enter your email"
          value={formData.email}
          onChange={handleChange}
          required
        />

        <label htmlFor="password">Password</label>
        <div className="password-wrapper">
          <input
            type={passwordVisible ? "text" : "password"}
            id="password"
            placeholder="Enter your password"
            value={formData.password}
            onChange={handleChange}
            required
          />
          <span className="toggle-password" onClick={togglePasswordVisibility}>
            {passwordVisible ? "👁️" : "👁️‍🗨️"}
          </span>
        </div>

        <button type="submit" className="register-button">
          <a href="/" style={{ color: "white" }}>
            Register
          </a>
        </button>
      </form>
      <p className="already-account">
        Already have an account? <a href="/">Login</a>
      </p>
    </div>
  );
};

export default Register;
