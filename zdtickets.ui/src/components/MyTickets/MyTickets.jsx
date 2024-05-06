import React, { useEffect, useState } from "react";

export const MyTickets = () => {
  const [tickets, setTickets] = useState([])

  const fetchTickets = async () => {
    const url = `http://localhost:8080/api/Tickets/booked`;
    try {
      const response = await fetch(url, { credentials: 'include' });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      setTickets(data);
    } catch (error) {
      console.error('Error fetching trains:', error);
    }
  }

  const cancelBook = async (ticketid) => {
    const url = `http://localhost:8080/api/Tickets/cancel`;
    try {
      const response = await fetch(url,
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          credentials: 'include',
          body: JSON.stringify([ticketid])
        });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      await fetchTickets();
    } catch (error) {
      console.error('Error booking ticket:', error);
    }
  }

  useEffect(() => { fetchTickets() }, [])
  return (
    <div className="container">
      <h2>Мои билеты</h2>
      <ul className="tickets">
        {tickets.map(ticket => (
          <li className="ticket_info" key={ticket.ticketId}>
            <div>Город отправления: {ticket.from}</div>
            <div>Город прибытия: {ticket.to}</div>
            <div>Номер места: {ticket.seatNumber}</div>
            <div>Цена: {ticket.price}</div>
            <button onClick={() => cancelBook(ticket.ticketId)}>Отменить бронь</button>
          </li>
        ))}
      </ul>
    </div>
  )
}