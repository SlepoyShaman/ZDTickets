import React from "react";
import Trains from "./Trains";

function MainPage({ userName }) {
    return (
        <>
            <header>
                <div className="container">
                    <div className="userName">{userName}</div>
                </div>
            </header>
            <Trains />
        </>
    )
}

export default MainPage