import axios from "axios";
import { useState } from "react";
import { getSession, useSession } from "next-auth/react";
import styles from "../../styles/form.module.css";
import { useRouter } from "next/router";

export default function CreateItem() {
  const router = useRouter();
  const { status } = useSession();

  if (status === "unauthenticated") {
    router.replace("/login");
  }

  const initialValues = {
    name: "",
    description: "",
    photoURL: "",
    price: 0,
    userId: 0,
  };

  const [data, setData] = useState(initialValues);
  const [errors, setErrors] = useState({});
  const [error, setError] = useState({});

  function handleChange(e) {
    const { name, value } = e.target;
    setData({ ...data, [name]: value });
  }

  async function verifyInput(data) {
    const errors = {};

    if (!data.name) {
      errors.name = "Item name is required!";
    } else if (data.name.length < 3) {
      errors.name = "Item name must be at least 3 characters long!";
    }

    if (!data.description) {
      errors.description = "Description is required!";
    }

    if (!data.photoURL) {
      errors.photoURL = "Photo URL is required!";
    } else if (!validateURL(data.photoURL)) {
      errors.photoURL = "URL is invalid!";
    }

    if (!data.price) {
      errors.price = "Price is required!";
    } else if (data.price <= 0 || data.price % 1 != 0) {
      errors.price = "Price must be a positive whole number!";
    }

    return errors;
  }

  function validateURL(url) {
    const urlRegex =
      /https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)/;
    return urlRegex.test(url);
  }

  async function handleSubmit(e) {
    e.preventDefault();

    const verifyResult = await verifyInput(data);
    setErrors(verifyResult);

    const session = await getSession();
    if (!session) {
      return;
    }

    if (Object.keys(verifyResult).length === 0) {
      try {
        const updatedData = { ...data, userId: session.user.id };
        setData(updatedData);

        const result = await axios.post(`/api/items`, updatedData, {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${session.accessToken}`,
          },
        });
        router.push(`/items/${result.data.id}`);
      } catch (err) {
        if (err.response.status === 500) {
          setError({general: "Something went wrong. :(" });
        } else {
          console.log(err);
        }
      }
    }
  }

  if (status === "authenticated") {
    return (
      <div className="content">
        <h1>Add a new item for sale!</h1>
        <small className="small">{error.general}</small>
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
              onChange={handleChange}
            ></input>
            <small className="small">{errors.name}</small>
          </div>
          <div className={styles.formControl}>
            <label htmlFor="description" className={styles.label}>
              Description:
            </label>
            <textarea
              id="description"
              name="description"
              rows="4"
              cols="50"
              className={styles.input}
              onChange={handleChange}
            ></textarea>
            <small className="small">{errors.description}</small>
          </div>
          <div className={styles.formControl}>
            <label htmlFor="photoURL" className={styles.label}>
              Photo URL:
            </label>
            <input
              id="photoURL"
              name="photoURL"
              type="url"
              className={styles.input}
              onChange={handleChange}
            ></input>
            <small className="small">{errors.photoURL}</small>
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
              onChange={handleChange}
            ></input>
            <small className="small">{errors.price}</small>
          </div>
          <button className={styles.button} onClick={handleSubmit}>
            Submit
          </button>
        </form>
      </div>
    );
  }
}
