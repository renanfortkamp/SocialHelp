import React, { useState } from 'react';
import Context from './pages/Context/Context.js';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Feed from './pages/feed/feed.js';
import Login from './pages/login/login.js';
import Register from './pages/register/register.js';

function App() {
  
  const [context, setContext] = useState([]);
  
  return (
    <div className="App">
      <BrowserRouter>
        <Context.Provider value={[context, setContext]}>
          <Routes>
            <Route path="/" element={<Login />} />
            <Route path="/feed" element={<Feed />} />
            <Route path="/register" element={<Register />} />
          </Routes>
        </Context.Provider>
      </BrowserRouter>
    </div>
  );
}

export default App;
