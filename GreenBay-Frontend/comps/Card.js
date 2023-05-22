import Link from "next/link";
import style from "../styles/Card.module.css";

export default function Card({ item }) {
  return (
    <Link href={`/items/${item.id}`} className={`${style.container} center`}>
      <img src={item.photoURL} />
      <p>{item.name}</p>
      <p>{item.price} GBD</p>
    </Link>
  );
}
