import React, { useState } from 'react';
import { useContext } from 'react';
import Context from '../Context/Context.js';
import { Link, useNavigate } from 'react-router-dom';


export default function Group() {

    const [group, setGroup] = useState([]);
    const [filterGroup, setFilterGroup] = useState("");
    const [context, setContext] = useContext(Context);
    const navigate = useNavigate();

    const joinGroup = (idGroup) => {
        //
        fetch("http://localhost:5191/api/user?id=" + context.id, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                groupId: idGroup,
            })
        })
            .then(alert("Entrou no grupo, redirecionando para o feed..."))
            .then(setContext({ ...context, groupId: idGroup }))
            .then(navigate('/feed'))
    }

    const searchGroup = (e) => {
        e.preventDefault();
        if (filterGroup === "") {
            fetch("http://localhost:5191/api/Group")
                .then(e => e.json())
                .then(data => {
                    setGroup(data);
                });
        }
        else {
            fetch("http://localhost:5191/api/Group?name=" + filterGroup)
                .then(e => e.json())
                .then(data => {
                    setGroup(data);
                });
        }
    }

    return (
        <div>
            <h1>Grupos</h1>
            <form onSubmit={(e) => { searchGroup(e) }}>
                <input type="text" placeholder="Pesquisar" onChange={(e) => { setFilterGroup(e.target.value) }} />
                <button type="submit">Pesquisar</button>
                <button ><Link to='/feed'>Voltar</Link></button>
            </form>

            {group.map((e) => {
                return (
                    <div style={{ margin: "10px", border: "1px solid red" }} key={e.id}>
                        <h2>{e.name}</h2>
                        <p>{e.description}</p>
                        <button onClick={() => { joinGroup(e.id) }}>Entrar</button>
                    </div>
                )
            })}

        </div>
    );
}