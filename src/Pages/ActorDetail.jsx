import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";

function ActorDetail({ dark }) {
    const { id } = useParams();
    const [actor, setActor] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        fetch(`https://localhost:7107/api/actorapi/${id}`)
            .then(res => res.json())
            .then(data => setActor(data))
            .catch(err => console.error(err))
    }, [id])

    const styles = {
        main: { padding: "2rem", maxWidth: "960px", margin: "0 auto", minHeight: "100vh" },
        backBtn: { fontSize: "13px", color: dark ? "#a0a0a5" : "#6e6e73", cursor: "pointer", marginBottom: "1.5rem", display: "block",textAlign: "left"  },
        card: { background: dark ? "#2c2c2e" : "#f0ede8", border: dark ? "0.5px solid #3a3a3c" : "0.5px solid #e0ddd8", borderRadius: "12px", padding: "2rem" },
        name: { fontSize: "24px", fontWeight: "600", color: dark ? "#f5f5f5" : "#1c1c1e", marginBottom: "8px" },
        age: { fontSize: "14px", color: dark ? "#a0a0a5" : "#6e6e73" },
    }

    if (!actor) return <p style={{ padding: "2rem" }}>Loading...</p>

    return (
        <div style={styles.main}>
            <span style={styles.backBtn} onClick={() => navigate(-1)}>← Back</span>
            <div style={styles.card}>
                <div style={styles.name}>{actor.fullName}</div>
                <div style={styles.age}>{actor.age} years old</div>
            </div>
        </div>
    )
}

export default ActorDetail