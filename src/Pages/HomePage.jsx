import { useState, useEffect, use } from "react";
import { Link } from "react-router-dom";

function HomePage({dark}) {

    const [movies, setMovies] = useState([])
    const [actors, setActors] = useState([])
    const [directors, setDirectors] = useState([])
    
    useEffect(() => {
      fetch("https://localhost:7107/api/movieapi")
          .then(res => res.json())
          .then(data => setMovies(data))
    }, [])
    useEffect(() => {
      fetch("https://localhost:7107/api/actorapi")
          .then(res => res.json())
          .then(data => setActors(data))
    }, [])
    useEffect(() => {
      fetch("https://localhost:7107/api/directorapi")
          .then(res => res.json())
          .then(data => setDirectors(data))
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
      <p style={styles.sectionTitle}>Featured Actors</p>
      <div style={styles.featuredGrid}>
        {actors.slice(0, 4).map(a => (
          <Link key={a.actorID} style={styles.card}>
            <div style={styles.cardTitle}>{a.fullName}</div>
            <div style={styles.cardOverview}>Age: {a.age}</div>
          </Link>
        ))}
      </div>
      
      <p style={styles.sectionTitle}>Featured Directors</p>
      <div style={styles.featuredGrid}>
        {directors.slice(0,4).map(d => (
          <Link key={d.directorID} style={styles.card}>
            <div style={styles.cardTitle}>{d.fullName}</div>
            <div style={styles.cardOverview}>Age: {d.age}</div>
          </Link>
        ))}
      </div>

      <p style={styles.sectionTitle}>Featured Movies</p>
      <div style={styles.listSection}>
        {movies.map((m, i) => (
          <Link key={m.movieID} style={styles.listRow}>
            <div style={styles.listInfo}>
              <div style={styles.listTitle}>{m.title}</div>
              <div style={styles.listSub}>{new Date(m.releaseDate).getFullYear()} · {m.runtimeMinutes} min</div>
            </div>
            <span style={styles.listRating}>rating: {m.rating}</span>
          </Link>
        ))}
      </div>
    </div>
    ) 
}


export default HomePage