import styles from "../styles/LoginForm.module.css";

export default function LoginForm() {
  return (
    <form>
      <div className={styles.formControl}>
        <label htmlFor="username" className={styles.label}>
          Username:
        </label>
        <input id="username" type="text" className={styles.input}></input>
      </div>
      <div className={styles.formControl}>
        <label htmlFor="password" className={styles.label}>
          Password:
        </label>
        <input id="password" type="password" className={styles.input}></input>
      </div>
      <button className={styles.button}>Submit</button>
    </form>
  );
}
