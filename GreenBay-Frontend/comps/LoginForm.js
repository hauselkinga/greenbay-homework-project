import styles from "../styles/LoginForm.module.css";
import { useState } from "react";

export default function LoginForm({ handleSubmitCallback }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();
    
    const data = {
      username: username,
      password: password,
    };

    handleSubmitCallback(data);
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
      </div>
      <button className={styles.button} onClick={handleSubmit}>
        Submit
      </button>
    </form>
  );
}
