import LoginForm from "../../comps/LoginForm.js";
import { signIn } from "next-auth/react";
import { useRouter } from "next/router.js";

export default function Login() {
  const router = useRouter();

  async function handleSubmitCallback(data) {
    const result = await signIn("credentials", {
      username: data.username,
      password: data.password,
      redirect: false,
    });

    if (result.ok) {
      router.push("/");
    } else {
      console.log("Wrong username or password!");
    }

    return result;
  }

  return (
    <div className="container">
      <div className="content">
        <h1>Login</h1>
        <div className="center">
          <LoginForm handleSubmitCallback={handleSubmitCallback} />
        </div>
      </div>
    </div>
  );
}
