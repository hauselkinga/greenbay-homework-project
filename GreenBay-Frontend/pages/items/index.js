import axios from "axios";
import Card from "../../comps/Card.js";
import style from "../../styles/Card.module.css";
import { getSession } from "next-auth/react";
import { useState } from "react";
import PageNode from "../../comps/PageNode.js";

export default function Items({ data }) {
  if (data) {
    const [dataToLoad, setDataToLoad] = useState(data.slice(0, 10));

    function countPages(data) {
      const size = 10;
      let pages = Math.ceil(data.length / size);
      let pageCount = [];

      for (let i = 0; i < pages; i++) {
        pageCount.push(i + 1);
      }
      return pageCount;
    }

    function handleDataLoaded(newData) {
      setDataToLoad(newData);
    }

    return (
      <>
        <div className={`${style.card} container`}>
          {dataToLoad.map((item) => {
            return <Card item={item} key={item.id} />;
          })}
        </div>
        <div className="center" style={{ marginTop: "2rem" }}>
          {countPages(data).map((page) => {
            return (
              <PageNode
                page={page}
                key={page}
                onDataLoaded={handleDataLoaded}
              ></PageNode>
            );
          })}
        </div>
      </>
    );
  } else {
    return <div className="center">Something went wrong. :(</div>;
  }
}

export async function getServerSideProps(context) {
  try {
    const session = await getSession(context);

    if (!session) {
      return {
        redirect: {
          destination: "/login",
          permanent: false
        },
      };
    }

    const result = await axios.get(
      `${process.env.NEXT_PUBLIC_API_URL}/items?isSellable=true`,
      {
        headers: { Authorization: `Bearer ${session.accessToken}` },
      }
    );
    const data = result.data;
    return { props: { data } };
  } catch (err) {
    return { props: {} };
  }
}
