import RegistrationForm from "../../comps/RegistrationForm";

export default function Registration() {
  async function handleSubmitCallback(data) {
    // console.log(data);
  }

  return (
    <div className="container">
      <div className="content">
        <h1>Registration</h1>
        <div className="center">
          <RegistrationForm handleSubmitCallback={handleSubmitCallback} />
        </div>
      </div>
    </div>
  );
}