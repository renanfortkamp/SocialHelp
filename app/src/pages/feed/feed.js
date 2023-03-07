import React, { useState, useEffect, useContext } from 'react';
import Context from '../Context/Context.js';
import { Link, useNavigate } from 'react-router-dom';


export default function Feed() {
    const [text, setText] = useState('');
    const [posts, setPosts] = useState([]);
    const [context, setContext] = useContext(Context);
    const navigate = useNavigate();

    const updatePost = () => {
        fetch("http://localhost:5191/api/message?groupId=" + context.groupId)
            .then(e => e.json())
            .then(data => {
                setPosts(data);
            });
    }

    const Logout = () => {
        setContext([]);
        navigate('/');

    };

    useEffect(() => {
        updatePost();
    },[] );

    const postMessage = (e) => {
        if(text !== ""){
        try {
            e.preventDefault();
            if (text === "") {
                alert("Digite algo");
                return;
            }
            fetch("http://localhost:5266/api/Message", 
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    text: text,
                    userId: context.userId,
                    groupId: context.groupId,
                    userName: context.userName
                })
            })
                .then(
                    document.getElementById("text").value = "",
                    setText("")
                )
                .then(
                    (res) => {
                        if (res.status === 400) {
                            alert("Erro ao postar");
                        }
                        else {
                            updatePost();
                        }
                    })
        } catch (error) {
            alert(error);
        }};
    };

    return (
        <div className='posts' style={{ display: 'flex', justifyContent: "center", alignItems: "center", flexDirection: "column", border: "solid 1px red" }}>
            <h1>Feed</h1>
            {<p>Bem vindo {context.userName}</p>}

            { }
            <form onSubmit={(e) => { postMessage(e) }}>
                <input type="text" id='text' placeholder="text" onChange={(e) => setText(e.target.value)} />
                <button type="submit">Submit</button>
            </form>
            <button onClick={() => { Logout() }}>Logout</button>
            <Link to="/group">Entra em um Grupo</Link>
            <Link to="/groupRegister">Cria um Grupo</Link>

            {posts.map(post => (
                <div key={post.id} className='post' style={{ border: "solid 1px red", width: "400px" }}>
                    <div>@{post.userName}</div>
                    <div>{post.text}</div>
                    <div>{post.dateMessage}</div>
                </div>))
            }





        </div>


    )
        ;
};