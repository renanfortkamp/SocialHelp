import React, { useState } from 'react';
import { useContext } from 'react';
import Context from '..//Context//Context.js';
import { Link, useNavigate } from 'react-router-dom';

export default function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    // eslint-disable-next-line no-unused-vars
    const [context, setContext] = useContext(Context);
    const [userFound, setUserFound] = useState(false);
    const navigate = useNavigate();

    const Login = (e) => {
        if(email === "" || password === ""){
            alert("Preencha todos os campos");
            return;
        }
        e.preventDefault();
        fetch(`http://localhost:5191/api/user/${email}&${password}`)
            .then(e => e.json())
            .then(data => {
                if (data.length === 0) {
                    setUserFound(false);
                    alert('Email ou senha incorretos')
                }
                else {
                    setUserFound(true);
                    setContext(data);
                    navigate('/feed');
                }

            }
            )
            .catch(e => {
                if (userFound === false) {
                    alert("Email ou senha incorretos");
                }
            }
            )
    }

    return (

        <div className='login' style={{ display: 'flex', justifyContent: "center", alignItems: "center", flexDirection: "column" }}>
            <h1 style={{ color: "#AA96DA", lineHeight: 0, marginTop: "100px", fontSize: "5em", textShadow: "1px 1px 2px black" }}>Social Help</h1>
            <p style={{ lineHeight: 0, fontWeight: "bold", color: "#C5FAD5", fontSize: "2em", textShadow: "1px 1px 2px black" }}>Encontre seu grupo e ajude quem precisa!</p>
            <div style={{ width: "400px", marginTop: "30px", display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }}>
                <form style={{ display: "flex", flexDirection: "column", width: "350px" }} onSubmit={(e) => { Login(e) }}>
                    <input style={{ fontSize: "1.2em", height: "30px", borderRadius: "25px", textAlign: "Center", margin: "5px" }} type="text" placeholder="Email" onChange={(e) => setEmail(e.target.value)} />
                    <input style={{ fontSize: "1.2em", height: "30px", borderRadius: "25px", textAlign: "Center", margin: "5px" }} type="password" placeholder="Password" onChange={(e) => setPassword(e.target.value)} />
                    <button style={{ fontSize: "1.2em", height: "35px", borderRadius: "25px", textAlign: "Center", margin: "5px", backgroundColor: "#AA96DA" }} type="submit">Login</button>
                </form>
                <Link style={{ color: "#C5FAD5", textShadow: "1px 1px 2px black", textDecoration: "" }} to="/userRegister">Register</Link>
            </div>



        </div>
    );



}
