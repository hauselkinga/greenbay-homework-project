import styles from "../styles/Navbar.module.css";
import Link from "next/link";

export default function Navbar() {
  return (
    <div className={styles.navbar}>
      <Link href="/">GreenBay</Link>
      <Link className={styles.button} href="/login">Login</Link>
    </div>
  );
}
