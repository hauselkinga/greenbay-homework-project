import styles from "../styles/LoginForm.module.css";
import { useState } from "react";

export default function LoginForm({ handleSubmitCallback }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [errors, setErrors] = useState({});

  async function handleSubmit(e) {
    e.preventDefault();

    const data = {
      username: username,
      password: password,
    };

    const verifyResult = await verifyInput(data);
    setErrors(verifyResult);
    
    if (Object.keys(verifyResult).length === 0) {
      handleSubmitCallback(data);
    }
  }

  async function verifyInput(data) {
    let errors = {};

    if(!data.username) {
      errors.username = "Username is required!"
    }

    if(!data.password) {
      errors.password = "Password is required!"
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
          type="text"
          className={styles.input}
          onChange={({ target }) => setUsername(target.value)}
        ></input>
        <small className="small">{errors.username}</small>
      </div>
      <div className={styles.formControl}>
        <label htmlFor="password" className={styles.label}>
          Password:
        </label>
        <input
          id="password"
          type="password"
          className={styles.input}
          onChange={({ target }) => setPassword(target.value)}
        ></input>
        <small className="small">{errors.password}</small>
      </div>
      <button className={styles.button} onClick={handleSubmit}>
        Submit
      </button>
    </form>
  );
}
