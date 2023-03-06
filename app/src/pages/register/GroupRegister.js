import React, { useState } from 'react';
import { useContext } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import Context from '..//Context//Context.js';


export default function GroupRegister() {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const navigate = useNavigate();
    //eslint-disable-next-line
    const [context, setContext] = useContext(Context);

    const PostGroup = (e) => {
        e.preventDefault();
        fetch("http://localhost:5191/api/Group", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "name": name,
                "description": description,
                "image": null,
                "userId": context.id
            })
        })
            .then((res) => {
                if (res.status === 400) {
                    alert("Grupo já cadastrado");
                }
                else {
                    alert("Cadastro realizado com sucesso, redirecionando para o feed");
                    setTimeout(() => {
                        navigate('/feed');
                    }, 3000);


                }
            }
            )

    }


    return (
        <div className='register' style={{ display: 'flex', justifyContent: "center", alignItems: "center", flexDirection: "column", border: "solid 1px red" }}>
            <h1>Register</h1>
            <div style={{display:"flex"}}>
                <form onSubmit={(e) => { PostGroup(e) }}>
                    <input type="text" placeholder="Name do grupo" onChange={(e) => { setName(e.target.value) }} />
                    <input type="text" placeholder="Descrição do grupo" onChange={(e) => { setDescription(e.target.value) }} />
                    <button type="submit">Submit</button>
                </form>
                <button ><Link to='/feed'>Voltar</Link></button>
            </div>


        </div>
    );
};