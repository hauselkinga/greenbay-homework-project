import { signIn, signOut, useSession } from "next-auth/react";
import styles from "../styles/Navbar.module.css";
import Link from "next/link";
import { useRouter } from "next/router";

export default function Navbar() {
  const { data: session } = useSession();
  const router = useRouter();

  return (
    <div className={styles.navbar}>
      <Link href="/">GreenBay</Link>

      {session?.user ? (
        <>
          <p>Hello {session.user.username}!</p>
          <div>
            <button
              className={styles.button}
              onClick={() => router.push("/items")}
            >
              View Items
            </button>
            <button className={styles.button} onClick={() => signOut()}>
              Sign Out
            </button>
          </div>
        </>
      ) : (
        <div>
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
