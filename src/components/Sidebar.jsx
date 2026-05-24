import { Link } from "react-router-dom";
import { useState, useEffect } from "react";

function Sidebar({ dark, setDark, open, setOpen }) {
    

    const styles = {
        sidebar: {
            position: "fixed", top: 0, left: 0, bottom: 0,
            width: open ? "180px" : "52px",
            background: dark ? "#2c2c2e" : "#d1ba92",
            borderRight: "0.5px solid rgba(0,0,0,0.1)",
            display: "flex", flexDirection: "column",
            padding: "10px 0", gap: "4px",
            transition: "width 0.25s ease",
            overflow: "hidden", zIndex: 100
        },
        toggle: {
            display: "flex", alignItems: "center", justifyContent: "center",
            width: "36px", height: "36px", marginLeft: "8px",
            cursor: "pointer", borderRadius: "8px",
            color: dark ? "#f5f5f5" : "#1c1c1e",
            fontSize: "20px", flexShrink: 0,
            background: "transparent", border: "none"
        },
        link: {
            display: "flex", alignItems: "center", gap: "10px",
            height: "36px", padding: "0 8px", marginLeft: "6px", marginRight: "6px",
            color: dark ? "#ababab" : "#3a3a3a",
            textDecoration: "none", borderRadius: "8px",
            fontSize: "13px", whiteSpace: "nowrap", flexShrink: 0
        },
        label: {
            opacity: open ? 1 : 0,
            transition: "opacity 0.15s",
            pointerEvents: "none"
        },
        icon: { fontSize: "18px", flexShrink: 0 },
        darkBtn: {
            display: "flex", alignItems: "center", gap: "10px",
            height: "36px", padding: "0 8px", marginLeft: "6px", marginRight: "6px",
            color: dark ? "#ababab" : "#3a3a3a",
            borderRadius: "8px", fontSize: "13px",
            whiteSpace: "nowrap", flexShrink: 0,
            background: "transparent", border: "none", cursor: "pointer"
        }
    };

    const toggleTheme = () => {
        setDark(!dark);
        //document.body.style.background = dark ? "#f5f5f5" : "#1c1c1e";
    };
    

    return (
        <div style={styles.sidebar}>
            <button style={styles.toggle} onClick={() => setOpen(!open)}>
                ☰
            </button>

            <Link to="/" style={styles.link}>
                <span style={styles.icon}>🏠</span>
                <span style={styles.label}>Home</span>
            </Link>
            <Link to="/movies" style={styles.link}>
                <span style={styles.icon}>🎬</span>
                <span style={styles.label}>Movies</span>
            </Link>
            <Link to="/actors" style={styles.link}>
                <span style={styles.icon}>🎭</span>
                <span style={styles.label}>Actors</span>
            </Link>
            <Link to="/directors" style={styles.link}>
                <span style={styles.icon}>🎥</span>
                <span style={styles.label}>Directors</span>
            </Link>

            <div style={{ flex: 1 }} />

            <button style={styles.darkBtn} onClick={toggleTheme}>
                <span style={styles.icon}>{dark ? "☀️" : "🌙"}</span>
                <span style={styles.label}>{dark ? "Light" : "Dark"}</span>
            </button>
        </div>
    );
}

export default Sidebar;