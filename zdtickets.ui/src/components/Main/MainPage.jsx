import React from "react";
import Trains from "./Trains";

function MainPage({ userName }) {
  return (
    <>
      <div className="userName">{userName}</div>
      <Trains />
    </>
  )
}

export default MainPage