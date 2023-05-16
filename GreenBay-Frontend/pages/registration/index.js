import RegistrationForm from "../../comps/RegistrationForm";
import { useState } from "react";
import { useRouter } from "next/router";
import axios from "axios";

export default function Registration() {
  const [error, setError] = useState("");
  const router = useRouter("");
  
  async function handleSubmitCallback(data) {
    try {
      setError("");
      const { username, password1: password } = data;
      const result = await axios.post(
        `/api/users/register`,
        {
          username,
          password,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      router.push("/login");
    } catch (err) {
      if (err.response.status >= 500) {
        setError("Something went wrong :( Please try again later!");
      } else if (err.response.status >= 400) {
        setError(err.response.data + " :(");
      }
    }
  }

  return (
    <div className="container">
      <div className="content">
        <h1>Registration</h1>
        <small className="small">{error}</small>
        <div className="center">
          <RegistrationForm handleSubmitCallback={handleSubmitCallback} />
        </div>
      </div>
    </div>
  );
}
