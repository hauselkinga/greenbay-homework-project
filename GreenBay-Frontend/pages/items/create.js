import axios from "axios";
import styles from "../../styles/form.module.css";

export default function CreateItem() {
  async function handleSubmit(e) {
    e.preventDefault();

    try {
      const result = axios.post(
        `/api/items`,
        { data: "asd" },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
    } catch (err) {
      console.log(err);
    }
  }

  return (
    <div className="content">
      <h1>Add a new item for sale!</h1>
      <form>
        <div className={styles.formControl}>
          <label htmlFor="name" className={styles.label}>
            Name:
          </label>
          <input
            id="name"
            name="name"
            type="text"
            className={styles.input}
            // onChange={handleChange}
          ></input>
        </div>
        <div className={styles.formControl}>
          <label htmlFor="description" className={styles.label}>
            Description:
          </label>
          <textarea
            id="description"
            name="description"
            rows="4" cols="50"
            className={styles.input}
            // onChange={handleChange}
          ></textarea>
        </div>
        <div className={styles.formControl}>
          <label htmlFor="url" className={styles.label}>
            Photo URL:
          </label>
          <input
            id="url"
            name="url"
            type="url"
            className={styles.input}
            // onChange={handleChange}
          ></input>
        </div>
        <div className={styles.formControl}>
          <label htmlFor="price" className={styles.label}>
            Price:
          </label>
          <input
            id="price"
            name="price"
            type="number"
            className={styles.input}
            // onChange={handleChange}
          ></input>
        </div>
        <button className={styles.button} onClick={handleSubmit}>
          Submit
        </button>
      </form>
    </div>
  );
}
