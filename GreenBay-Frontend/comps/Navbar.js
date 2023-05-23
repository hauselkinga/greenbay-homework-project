import { signIn, signOut, useSession } from "next-auth/react";
import styles from "../styles/Navbar.module.css";
import Link from "next/link";
import { useRouter } from "next/router";

export default function Navbar() {
  const { data: session } = useSession();
  const router = useRouter();

  return (
    <div className={styles.navbar}>
      <Link className={styles.absoluteLeft} href="/">
        GreenBay
      </Link>

      {session?.user ? (
        <>
        <div className={styles.welcome}>
          <p>Hello <strong>{session.user.username}</strong>!</p>
          <p>Account balance: <strong>{session.user.balance} GBD</strong></p>
        </div>
          <div className={styles.absoluteRight}>
            <button
              className={styles.button}
              onClick={() => router.push("/items")}
            >
              View Items
            </button>
            <button
              className={styles.button}
              onClick={() => router.push("/items/create")}
            >
              Add New Item
            </button>
            <button className={styles.button} onClick={() => signOut()}>
              Sign Out
            </button>
          </div>
        </>
      ) : (
        <div className={styles.absoluteRight}>
          <button className={styles.button} onClick={() => signIn()}>
            Sign In
          </button>
          <button
            href={"/register"}
            className={styles.button}
            onClick={() => router.push("/registration")}
          >
            Register
          </button>
        </div>
      )}
    </div>
  );
}
