import axios from "axios";
import Card from "../../comps/Card.js";
import style from "../../styles/Card.module.css";
import { getSession } from "next-auth/react";

export default function Items({ data }) {
  if (data) {
    return (
      <div className={`${style.card} container`}>
        {data.map((item) => {
          return <Card item={item} key={item.id} />;
        })}
      </div>
    );
  } else {
    return <div className="container centered">Please Sign In!</div>;
  }
}

export async function getServerSideProps(context) {
  try {
    const session = await getSession(context);
    const result = await axios.get(`${process.env.NEXT_PUBLIC_API_URL}/items`, {
      headers: { Authorization: `Bearer ${session.accessToken}` },
    });
    const data = result.data;
    return { props: { data } };
  } catch (err) {
    console.log(err);
  }

  return { props: {} };
}
