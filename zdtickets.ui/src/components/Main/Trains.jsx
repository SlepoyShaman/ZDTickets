import React, { useState } from "react";
import TrainsFilter from "./TrainsFilter";
import TicketsList from "./TicketsList";

function Trains() {
  const [, setTicket] = useState(0)
  const [trains, setTrains] = useState([]);
  const [filter, setFilter] = useState(
    {
      cityFrom: '',
      cityTo: '',
      departudeDate: '',
      page: 1,
      size: 5
    });

  const fetchTrains = async () => {
    const url = `http://localhost:8080/api/Tickets/trains?page=${filter.page}&size=${filter.size}&from=${filter.cityFrom}&to=${filter.cityTo}&date=${filter.departudeDate}`;
    try {
      const response = await fetch(url);
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      setTrains(data);
    } catch (error) {
      console.error('Error fetching trains:', error);
    }
  }

  const updateComponent = () => {
    setTicket(ticket => ticket + 1)
  }

  return (
    <>
      <TrainsFilter trainsFilter={filter} setFilter={setFilter} onSubmit={fetchTrains} />
      <h2>Train List</h2>
      <ul>
        {trains.map(train => (
          <li key={train.id}>
            <div>Departure Time: {train.departureTime}</div>
            <div>Arrival Time: {train.arrivalTime}</div>
            <div>From: {train.from}</div>
            <div>To: {train.to}</div>
            <TicketsList trainId={train.id} trigger={updateComponent} />
          </li>
        ))}
      </ul>
    </>
  );
}

export default Trains