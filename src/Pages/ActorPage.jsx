import { useState, useEffect, use } from "react";
import { Link } from "react-router-dom";

function ActorPage({dark}) {

    const [actors, setActors] = useState([])
    
    useEffect(() => {
        fetch("https://localhost:7107/api/actorapi")
            .then(res => res.json())
            .then(data => setActors(data))
    }, [])


const styles = {
  main: { padding: "2rem", maxWidth: "960px", marginLeft: "0 auto", minHeight: "100vh" },
  sectionTitle: { fontSize: "13px", fontWeight: "500", color: dark ? "#f5f5f5" : "#1c1c1e", textTransform: "uppercase", letterSpacing: "0.06em", marginBottom: "1rem" },
  featuredGrid: { display: "grid", gridTemplateColumns: "repeat(auto-fit, minmax(200px, 1fr))", gap: "16px", marginBottom: "2.5rem" },
  card: { background: dark ? "#2c2c2e" : "#f0ede8", border: dark ? "0.5px solid #3a3a3c" : "0.5px solid #e0ddd8", borderRadius: "12px", padding: "1.25rem", cursor: "pointer" },
  cardTitle: { fontSize: "15px", fontWeight: "500", marginBottom: "6px", color: "var(--color-text-primary)" },
  cardOverview: { fontSize: "13px", color: "var(--color-text-secondary)", lineHeight: "1.5", marginBottom: "12px", display: "-webkit-box", WebkitLineClamp: 2, WebkitBoxOrient: "vertical", overflow: "hidden" },
  cardMeta: { display: "flex", gap: "12px", alignItems: "center" },
  ratingPill: { fontSize: "13px", fontWeight: "500", background: "var(--color-background-warning)", color: "var(--color-text-warning)", padding: "3px 10px", borderRadius: "99px" },
  runtime: { fontSize: "12px", color: "var(--color-text-secondary)" },
  listSection: { background: dark ? "#2c2c2e" : "#f0ede8", border: dark ? "0.5px solid #3a3a3c" : "0.5px solid #e0ddd8", borderRadius: "12px", overflow: "hidden" },
  listRow: { display: "flex", alignItems: "center", padding: "0.85rem 1.25rem", borderBottom: dark ? "0.5px solid #3a3a3c" : "0.5px solid #e0ddd8", gap: "1rem", cursor: "pointer" },
  listNum: { fontSize: "13px", color: "var(--color-text-secondary)", minWidth: "20px", textAlign: "right" },
  listInfo: { flex: 1 },
  listTitle: { fontSize: "14px", fontWeight: "500", color: "var(--color-text-primary)" },
  listSub: { fontSize: "12px", color: "var(--color-text-secondary)", marginTop: "2px" },
  listRating: { fontSize: "13px", color: "var(--color-text-secondary)" }
}



return (
    <div style={styles.main}>
      <p style={styles.sectionTitle}>Actors</p>
      <div style={styles.listSection}>
        {actors.map((a, i) => (
          <Link key={a.actorID} to={`/actors/${a.actorID}`} style={{...styles.listRow, textDecoration: "none"}}>
            <div style={styles.listInfo}>
              <div style={styles.listTitle}>{a.fullName}</div>
              <div style={styles.listSub}>{a.age} years old</div>
            </div>
  </Link>
))}
      </div>
    </div>
    ) 
}


export default ActorPage