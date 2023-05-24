import axios from "axios";
import styles from "../../styles/details.module.css";
import { getSession, useSession } from "next-auth/react";
import { useRouter } from "next/router.js";

export default function ItemDetails({ item }) {
  const { data: session, status } = useSession();
  const router = useRouter();

  if (status === "unauthenticated") {
    router.push("/login");
  }

  function refreshData() {
    router.reload();
  }

  if (item) {
    async function buy() {
      try {
        const result = await axios.put(`/api/items/${item.id}`, session.user.id, {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${session.accessToken}`,
          },
        });
        if (result.status < 300) {
          refreshData();
        }
      } catch (err) {
        console.log(err);
      }
    }

    return (
      <div className={`${styles.container} content`}>
        <div className={styles.imgContainer}>
          <img src={item.photoURL} />
        </div>
        <div className={styles.flex}>
          <h1>Item name: {item.name}</h1>
          <p>Price: {item.price} GBD</p>
          <p>Description: {item.description}</p>
          <p>Seller: {item.seller}</p>
          <button onClick={buy}>Buy</button>
        </div>
      </div>
    );
  }
}

export async function getServerSideProps(context) {
  const id = context.params.id;
  try {
    const session = await getSession(context);
    const result = await axios.get(
      `${process.env.NEXT_PUBLIC_API_URL}/items/${id}`,
      {
        headers: { Authorization: `Bearer ${session.accessToken}` },
      }
    );
    const item = result.data;
    return { props: { item } };
  } catch (err) {
    console.log(err);
  }

  return { props: {} };
}
