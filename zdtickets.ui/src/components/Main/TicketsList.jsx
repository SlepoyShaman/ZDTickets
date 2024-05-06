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
        } catch (error) {
            console.error('Error fetching tickets:', error);
        }
    }

    return (
        <>
            {
                tickets.length ? <ul>
                    {tickets.map(ticket => (
                        <li key={ticket.ticketId}>
                            <div>Номер места: {ticket.seatNumber}</div>
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