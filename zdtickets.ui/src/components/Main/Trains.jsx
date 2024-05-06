import React, { useState } from "react";
import TrainsFilter from "./TrainsFilter";
import TicketsList from "./TicketsList";

function Trains() {
  const [trains, setTrains] = useState([]);
  console.log(trains)
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
      const response = await fetch(url, { credentials: 'include' });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      setTrains(data);
    } catch (error) {
      console.error('Error fetching trains:', error);
    }
  }

  return (
    <div className="container">
      <h2>Список поездов</h2>
      <TrainsFilter trainsFilter={filter} setFilter={setFilter} onSubmit={fetchTrains} />
      <ul className="trains">
        {trains.map(train => (
          <li className="trains_info" key={train.id}>
            <div>Departure Time: {train.departureTime}</div>
            <div>Arrival Time: {train.arrivalTime}</div>
            <div>From: {train.from}</div>
            <div>To: {train.to}</div>
            <TicketsList trainId={train.id} />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Trains