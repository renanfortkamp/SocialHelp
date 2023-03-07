import React, { useState } from 'react';
import Context from './pages/Context/Context.js';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Feed from './pages/feed/feed.js';
import Login from './pages/login/login.js';
import Group from './pages/Group/Group.js';
import UserRegister from './pages/register/UserRegister.js';
import GroupRegister from './pages/register/GroupRegister.js';

function App() {
  
  const [context, setContext] = useState([]);
  
  return (
    <div className="App" style={{backgroundColor:"#FFFFD2",width:"100vw",height:"100vh"}}>
      <BrowserRouter>
        <Context.Provider value={[context, setContext]}>
          <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/userRegister" element={<UserRegister />} />
            <Route path="/groupRegister" element={<GroupRegister />} />
            <Route path="/group" element={<Group />} />
            <Route path="/feed" element={<Feed />} />
          </Routes>
        </Context.Provider>
      </BrowserRouter>
    </div>
  );
}

export default App;
