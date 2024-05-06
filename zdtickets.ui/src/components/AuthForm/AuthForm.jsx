import { useState } from "react"
import RegistrationForm from "../RegistrationForm/RegistrationForm";
import LoginForm from "../LoginForm/LoginForm";

function AuthForm({ setUser }) {
  const [hasAccount, setHasAccount] = useState(false);
  return (
    <>
      {hasAccount ? <LoginForm setUser={setUser} /> : <RegistrationForm setUser={setUser} />}
      <button onClick={() => setHasAccount(!hasAccount)}>{hasAccount ? 'У меня нет аккаунта' : 'У меня есть аккаунт'}</button>
    </>
  )
}

export default AuthForm