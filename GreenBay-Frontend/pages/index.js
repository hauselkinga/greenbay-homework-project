import axios from "axios";
import Card from "../comps/Card.js";
import style from "../styles/Card.module.css";

export default function Home({ data }) {
  return (
    <div className={`${style.card} container`}>
      {data.map((item) => {
        return <Card item={item} key={item.id}/>;
      })}
    </div>
  );
}

export async function getServerSideProps() {
  const result = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/items`);
  const data = result.data;
  return { props: { data } };
}
