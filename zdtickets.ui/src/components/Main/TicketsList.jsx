import React, { useState } from "react";

function TicketsList({ trainId }) {
  const [tickets, setTickets] = useState([])

  const fetchTickets = async () => {
    const url = `http://localhost:8080/api/Tickets/train/${trainId}`
    try {
      const response = await fetch(url, { credentials: 'include' });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      setTickets(data)
    } catch (error) {
      console.error('Error fetching tickets:', error);
    }
  }

  const bookTicket = async (ticketid) => {
    const url = 'http://localhost:8080/api/Tickets/book'
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

  return (
    <>
      {
        tickets.length ? <ul className="tickets">
          {tickets.map(ticket => (
            <li className="ticket_info" key={ticket.ticketId}>
              <div>Номер места: {ticket.seatNumber}</div>
              {
                !ticket.reserved && <>
                  <div>Цена: {ticket.price}</div>
                  <button onClick={() => bookTicket(ticket.ticketId)}>Забронировать</button>
                </>
              }
            </li>
          ))}
          <button onClick={() => setTickets([])}>Скрыть билеты</button>
        </ul>
          :
          <button onClick={fetchTickets}>Посмотреть билеты</button>
      }
    </>
  )
}

export default TicketsList