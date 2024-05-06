import React from "react";
import Trains from "./Trains";
import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";
import { MyTickets } from "../MyTickets/MyTickets";


function MainPage({ user, setUser }) {
  const logout = async () => {
    const url = `http://localhost:8080/api/Users/logout`;
    try {
      const response = await fetch(url,
        {
          method: 'POST',
          credentials: 'include',
        });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
    } catch (error) {
      console.error('Error logout:', error);
    }
    setUser({ login: "" })
  }

  return (
    <>
      <BrowserRouter>
        <header>
          <div className="container">
            <div className="header">
              <NavLink to="/" className="nav_item">Главная</NavLink>
              <NavLink to="/me" className="nav_item">Мои билеты</NavLink>
              <div className="userName">{user.login}</div>
              <button onClick={logout}>Выйти</button>
            </div>
          </div>
        </header>
        <Routes>
          <Route path="/" element={<Trains />} />
          <Route path="/me" element={<MyTickets />} />
        </Routes>
      </BrowserRouter>

    </>
  )
}

export default MainPage