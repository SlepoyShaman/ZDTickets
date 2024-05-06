import React from "react";

function TrainsFilter({ trainsFilter, setFilter, onSubmit }) {

    const saveFilter = (event) => {
        const { name, value } = event.target
        setFilter({ ...trainsFilter, [name]: value })
        console.log(trainsFilter);
    };

    const submit = async (event) => {
        event.preventDefault();
        await onSubmit();
    }

    return (
        <form onSubmit={submit}>
            <label>Город отправления:</label>
            <input
                type="text"
                name="cityFrom"
                id="cityFrom"
                value={trainsFilter.cityFrom}
                onChange={saveFilter} />
            <br />
            <label>Город прибытия:</label>
            <input
                type="text"
                name="cityTo"
                id="cityTo"
                value={trainsFilter.cityTo}
                onChange={saveFilter} />
            <br />
            <label>Дата прибытия:</label>
            <input
                type="text"
                name="departudeDate"
                id="departudeDate"
                value={trainsFilter.departudeDate}
                onChange={saveFilter} />
            <button type="submit">Посмотреть поезда</button>
        </form>
    );
}

export default TrainsFilter