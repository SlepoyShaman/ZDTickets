import React, { useState } from 'react';

function RegistrationForm({ setUser }) {
  const [error, setError] = useState("");
  const [formData, setFormData] = useState({
    login: '',
    password: '',
    confirmPassword: ''
  });

  const [formErrors, setFormErrors] = useState({});

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const registerUser = async (event) => {
    event.preventDefault();
    setFormErrors({});
    if (formData.password !== formData.confirmPassword) {
      setFormErrors({ confirmPassword: 'Passwords do not match.' });
      return;
    }
    try {
      const response = await fetch('http://localhost:8080/api/Users/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
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
      <h1>Зарегистрироваться</h1>
      <form onSubmit={registerUser}>
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

        <label htmlFor="confirmPassword">Подтвердите пароль:</label>
        <input
          type="password"
          id="confirmPassword"
          name="confirmPassword"
          value={formData.confirmPassword}
          onChange={handleInputChange}
          required
        />
        {formErrors.confirmPassword && <span className="error-message">{formErrors.confirmPassword}</span>}

        <button type="submit" >Зарегистрироваться </button>
        {error && <span className="error">{error}</span>}
      </form>
    </>
  );
}

export default RegistrationForm;
