import styles from "../styles/Navbar.module.css";

export default function Navbar() {
  return (
    <div className={styles.navbar}>
      <div>GreenBay</div>
      <button>Login</button>
    </div>
  );
}