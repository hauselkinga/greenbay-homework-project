import { signIn, signOut, useSession } from "next-auth/react";
import styles from "../styles/Navbar.module.css";
import Link from "next/link";

export default function Navbar() {
  const { data: session } = useSession();

  return (
    <div className={styles.navbar}>
      <Link href="/">GreenBay</Link>

      {session?.user ? (
        <>
          <p>Hello {session.user.username}!</p>
          <button className={styles.button} onClick={() => signOut()}>
            Sign Out
          </button>
        </>
      ) : (
        <button className={styles.button} onClick={() => signIn()}>
          Sign In
        </button>
      )}
    </div>
  );
}
