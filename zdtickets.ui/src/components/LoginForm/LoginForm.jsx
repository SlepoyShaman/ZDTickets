import React, { useState } from "react";

function LoginForm({ setUser, setMissingAccount }) {
  const [error, setError] = useState("")

  const [formData, setFormData] = useState({
    login: '',
    password: ''
  });

  const [formErrors, setFormErrors] = useState({});

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const loginUser = async (event) => {
    event.preventDefault();
    setFormErrors({});
    try {
      const response = await fetch('http://localhost:8080/api/Users/login', {
        method: 'POST',
        credentials: 'include',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData)
      });
      if (!response.ok) {
        const error = await response.json();
        setError(error.ErrorMessage)
      }
      else {
        setUser({ login: formData.login })
      }
    }
    catch (error) {
      console.error('Error during registration:', error);
    }
  };

  return (
    <>
      <h1>Вход</h1>
      <form onSubmit={loginUser}>
        <label htmlFor="login">Имя пользователя:</label>
        <input
          type="text"
          id="login"
          name="login"
          value={formData.login}
          onChange={handleInputChange}
          required
        />
        {formErrors.login && <span className="error-message">{formErrors.login}</span>}

        <label htmlFor="password">Пароль:</label>
        <input
          type="password"
          id="password"
          name="password"
          value={formData.password}
          onChange={handleInputChange}
          required
        />
        {formErrors.password && <span className="error-message">{formErrors.password}</span>}

        {error && <span className="error">{error}</span>}
        <button type="submit">Войти</button>
        <button onClick={setMissingAccount}>У меня нет аккаунта</button>
      </form>
    </>
  );
}

export default LoginForm