import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useState, useEffect, use } from "react";
import Sidebar from "./Components/Sidebar";
import HomePage from "./Pages/HomePage";
import MoviePage from "./Pages/MoviePage";
import MovieDetail from "./Pages/MovieDetail";
import ActorPage from "./Pages/ActorPage";
import ActorDetail from "./Pages/ActorDetail";
import Director from "./Pages/DirectorPage";
import DirectorDetail from "./Pages/DirectorDetail";

function App() {
    const [dark, setDark] = useState(false);
    const [sidebarOpen, setSidebarOpen] = useState(false);

    useEffect(() => {
        document.body.style.background = dark ? "#1c1c1e" : "#f5f5f5";
    }, [dark]);

    useEffect(() => {

    }, [])

    return (
        <BrowserRouter>
            <Sidebar dark={dark} setDark={setDark} open={sidebarOpen} setOpen={setSidebarOpen} />
            <div style={{ 
              marginLeft: sidebarOpen ? "180px" : "52px", 
              transition: "margin-left 0.25s ease",
              width: sidebarOpen ? "calc(100% - 180px)" : "calc(100% - 52px)"
              }}>

              <Routes>
                <Route path="/" element={<HomePage dark={dark} />} />
                <Route path="/movies" element={<MoviePage dark={dark} />} />
                <Route path="/movies/:id" element={<MovieDetail dark={dark} />} />
                <Route path="/actors" element={<ActorPage dark={dark} />} />
                <Route path="/actors/:id" element={<ActorDetail dark={dark} />} />
                <Route path="/directors" element={<Director dark={dark} />} />
                <Route path="/directors/:id" element={<DirectorDetail dark={dark} />} />
              </Routes>
            </div>
        </BrowserRouter>
    );
}

export default App;