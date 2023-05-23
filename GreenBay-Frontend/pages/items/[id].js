import axios from "axios";
import { getSession, useSession } from "next-auth/react";
import { useRouter } from "next/router.js";

export default function ItemDetails({ item }) {
  const { status } = useSession();
  const router = useRouter();

  if (status === "unauthenticated") {
    router.push("/login");
  }

  if (item) {
    return (
      <div className="content">
        <img src={item.photoURL} />
        <h1>Item name: {item.name}</h1>
        <p>Price: {item.price} GBD</p>
        <p>Description: {item.description}</p>
        <p>Seller: {item.seller}</p>
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
