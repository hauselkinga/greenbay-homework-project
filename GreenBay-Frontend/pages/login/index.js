import LoginForm from "../../comps/LoginForm.js";
import { signIn } from "next-auth/react";
import { useRouter } from "next/router.js";
import { useState } from "react";

export default function Login() {
  const [error, setError] = useState("");
  const router = useRouter();

  async function handleSubmitCallback(data) {
    setError("");
    const result = await signIn("credentials", {
      username: data.username,
      password: data.password,
      redirect: false,
    });

    if (result.ok) {
      router.push("/items");
    } else if (result.error.includes("ECONNREFUSED")) {
      setError("Something went wrong. :(  Please try again later!");
    } else {
      setError("Wrong username or password. :(");
    }

    return result;
  }

  return (
    <div className="container">
      <div className="content">
        <h1>Login</h1>
        <small className="small">{error}</small>
        <div className="center">
          <LoginForm handleSubmitCallback={handleSubmitCallback} />
        </div>
      </div>
    </div>
  );
}
