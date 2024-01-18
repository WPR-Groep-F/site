import classes from "./RegisterForm.module.css"
import {Form,useActionData} from "react-router-dom";
import logo from "../assets/Logo/logo_darkblue.png";

function RegisterForm(){
    const data = useActionData();
    return(
        <>
            <Form method="post">
                {data && data.errors && (
                    <ul>
                        {Object.values(data.errors).map((err) => (
                            <li key={err}>{err}</li>
                        ))}
                    </ul>
                )}
                {data && data.message && <p>{data.message}</p>}
            <div className={classes["logo"]}>
              <img src={logo} alt="logo" />
              <h1>Accessibility</h1>
            </div>

            <div className={classes["input-box"]}>
              <input type="username" placeholder="Username" name="username"/>
              <i class="bx bxs-user"></i>
            </div>
            <div className={classes["input-box"]}>
              <input type="email" placeholder="E-mail" name="email"/>
              <i class='bx bxs-envelope' ></i>
            </div>
            <div className={classes["input-box"]}>
              <input type="password" placeholder="Password" name="password"/>
              <i class="bx bxs-lock-alt"></i>
            </div>
            <div className={classes["input-box"]}>
              <input type="password" placeholder="Confirm Password" />
              <i class="bx bxs-lock-alt"></i>
            </div>

            <button type="Submit" className={classes["btn--register"]}>
              Registreer
            </button>

            </Form>
        </>
    )
}

export default RegisterForm;