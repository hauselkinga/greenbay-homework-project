import styles from "../styles/LoginForm.module.css";
import { useState } from "react";

export default function RegistrationForm({ handleSubmitCallback }) {
  const initialValues = {
    username: "",
    password1: "",
    password2: "",
  };

  const [data, setData] = useState(initialValues);
  const [errors, setErrors] = useState({});

  async function handleSubmit(e) {
    e.preventDefault();

    const verifyResult = await verifyInput(data);
    setErrors(verifyResult);
    
    if (Object.keys(verifyResult).length === 0) {
      handleSubmitCallback(data);
    }
  }

  function handleChange(e) {
    const { name, value } = e.target;
    setData({ ...data, [name]: value });
  }

  async function verifyInput(data) {
    const errors = {};
    if (!data.username) {
      errors.username = "Username is required!";
    } else if (data.username.length < 3) {
      errors.username = "Username must be at least 3 characters long!";
    }

    if (!data.password1) {
      errors.password1 = "Password is required!";
    } else if (data.password1.length < 8) {
      errors.password1 = "Password must be at least 8 characters long!";
    }

    if (!data.password2) {
      errors.password2 = "Password confirmation is required!";
    } else if (data.password1 !== data.password2) {
      errors.password2 = "Passwords do not match!";
    }

    return errors;
  }

  return (
    <form className={styles.form}>
      <div className={styles.formControl}>
        <label htmlFor="username" className={styles.label}>
          Username:
        </label>
        <input
          id="username"
          name="username"
          type="text"
          className={styles.input}
          onChange={handleChange}
        ></input>
        <small className="small">{errors.username}</small>
      </div>
      <div className={styles.formControl}>
        <label htmlFor="password1" className={styles.label}>
          Password:
        </label>
        <input
          id="password1"
          name="password1"
          type="password"
          className={styles.input}
          onChange={handleChange}
        ></input>
        <small className="small">{errors.password1}</small>
      </div>
      <div className={styles.formControl}>
        <label htmlFor="password2" className={styles.label}>
          Confirm Password:
        </label>
        <input
          id="password2"
          name="password2"
          type="password"
          className={styles.input}
          onChange={handleChange}
        ></input>
        <small className="small">{errors.password2}</small>
      </div>
      <button className={styles.button} onClick={handleSubmit}>
        Submit
      </button>
    </form>
  );
}
