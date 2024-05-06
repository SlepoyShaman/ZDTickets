import React, { useState } from "react";

function TicketsList({ trainId, trigger }) {
  const [tickets, setTickets] = useState([])

  const fetchTickets = async () => {
    console.log('aboba')
    const url = `http://localhost:8080/api/Tickets/train/${trainId}`
    try {
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      setTickets(data)
      console.log(tickets)
    } catch (error) {
      console.error('Error fetching tickets:', error);
    }
  }

  const onClick = async () => {
    await fetchTickets();
    trigger()
  }

  return (
    <>
      <button onClick={onClick}>Посмотреть билеты</button>
      {tickets.length === 0 && <ul>
        {tickets.map(ticket => (
          <li key={ticket.ticketId}>
            <div>aboba: {ticket.seatNumber}</div>
          </li>
        ))}
      </ul>}
    </>
  )
}

export default TicketsList