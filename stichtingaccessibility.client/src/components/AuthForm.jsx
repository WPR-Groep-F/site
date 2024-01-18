import classes from "./AuthForm.module.css"
import {Form,useActionData} from "react-router-dom";
import logo from "../assets/Logo/logo_darkblue_transparent.png";

function AuthForm(){
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
              <input type="username" placeholder="Username" />
              <i class="bx bxs-user"></i>
            </div>
            <div className={classes["input-box"]}>
              <input type="Password" placeholder="Password" />
              <i class="bx bxs-lock-alt"></i>
            </div>
            <button type="Submit" className={classes["btn--login"]}>
              Login
            </button>
            <div className={classes["forgot-password"]}>
              <a href="#">Forgot password?</a>
            </div>
            <div className={classes["OR"]}>
              <p>OR</p>
            </div>
            <div className={classes["Google-btn"]}>
              <button type="Submit" className={classes["btn--google"]}>
                Login with google
              </button>
              <i class="bx bxl-google"></i>
            </div>

            </Form>
        </>
    )
}

export default AuthForm;