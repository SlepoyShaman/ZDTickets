import React, { useState } from "react";
import AuthForm from "./components/AuthForm/AuthForm";
import MainPage from "./components/Main/MainPage";

function App() {
    const [user, setUser] = useState({ login: "" })
    return (
        <>
            {user.login === "" ? < AuthForm setUser={setUser} /> : <MainPage userName={user.login} />}
        </>
    );
}

export default App;
