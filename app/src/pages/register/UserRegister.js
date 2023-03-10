import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';


export default function UserRegister() {
    const [name , setName] = useState('');
    const [email , setEmail] = useState('');
    const [password , setPassword] = useState('');
    const navigate = useNavigate();

    const PostMessage = (e) => {
        e.preventDefault();
        //http://localhost:5191/api/user
        fetch("http://localhost:5191/api/user", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                userName: name,
                email: email,
                password: password
            })
        })
            .then((res) => {
                if (res.status === 400) {
                    alert("Email já cadastrado");
                }
                else {
                    alert("Cadastro realizado com sucesso, redirecionando para o login...");
                    setTimeout(() => {
                        navigate('/');
                    }, 3000);
                    

                }
            }
            )

    }


    return (
        <div className='register' style={{ display: 'flex', justifyContent: "center", alignItems: "center", flexDirection: "column", border: "solid 1px red" }}>
            <h1>Register</h1>
            <form onSubmit={(e)=>{PostMessage(e)}}>
                <input type="text" placeholder="Name" onChange={(e)=>{setName(e.target.value)}} />
                <input type="text" placeholder="Email" onChange={(e)=>{setEmail(e.target.value)}} />
                <input type="text" placeholder="Password" onChange={(e)=>{setPassword(e.target.value)}} />
                <button type="submit">Submit</button>
            </form>
        </div>
            );
};