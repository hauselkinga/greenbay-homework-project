import { signIn, signOut, useSession } from "next-auth/react";
import styles from "../styles/Navbar.module.css";
import Link from "next/link";
import { useRouter } from "next/router";
import { useEffect } from "react";
import axios from "axios";
import { useUserStore } from "../store/useUserStore";

export default function Navbar() {
  const { data: session } = useSession();
  const router = useRouter();
  const balance = useUserStore(state => state.balance);
  const updateBalance = useUserStore(state => state.updateBalance);
  
  useEffect(() => {
    if (session?.user) {
      fetchBalance();
    }
  }, [session]);

  async function fetchBalance() {
    try {
      const result = await axios.get(`/api/users/${session.user.id}`, {
        headers: { Authorization: `Bearer ${session.accessToken}` },
      });
      const data = result.data;
      updateBalance(data.balance)
    } catch (err) {
      updateBalance("Uh oh...")
    }
  }

  return (
    <div className={styles.navbar}>
      <Link className={styles.absoluteLeft} href="/">
        GreenBay
      </Link>

      {session?.user ? (
        <>
        <div className={styles.welcome}>
          <p>Hello <strong>{session.user.username}</strong>!</p>
          <p>Account balance: <strong>{balance} GBD</strong></p>
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
