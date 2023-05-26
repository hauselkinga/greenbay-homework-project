import { getSession } from "next-auth/react";
import axios from "axios";

export default function PageNode({page, onDataLoaded}) {
  async function loadItems() {
    try {
      const session = await getSession();
      const result = await axios.get(
        `api/items?isSellable=true&size=10&page=${page}`,
        {
          headers: { Authorization: `Bearer ${session.accessToken}` },
        }
      );
      const data = result.data;
      onDataLoaded(data);
    } catch (err) {
      console.log(err);
    }
  }

  return (
    <button onClick={loadItems}>{page}</button>
  )
}