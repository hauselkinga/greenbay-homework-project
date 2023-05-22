import axios from "axios";
import { getSession } from "next-auth/react";

export default function ItemDetails({ item }) {
  return <div>
    <img src={item.photoURL} />
    <h1>Item name: {item.name}</h1>
    <p>Price: {item.price} GBD</p>
    <p>Description: {item.description}</p>
    <p>Seller: {item.seller}</p>
  </div>;
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
