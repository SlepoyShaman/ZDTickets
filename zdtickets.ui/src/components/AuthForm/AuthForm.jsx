import { useState } from "react"
import RegistrationForm from "../RegistrationForm/RegistrationForm";
import LoginForm from "../LoginForm/LoginForm";

function AuthForm({ setUser }) {
  const [hasAccount, setHasAccount] = useState(false);
  return (
    <>
      {
        hasAccount ? 
        <LoginForm setUser={setUser} setMissingAccount={()=>setHasAccount(false)}/> 
        : 
        <RegistrationForm setUser={setUser} setExistingAccount={()=>setHasAccount(true)}/>
       }
    </>
  )
}

export default AuthForm