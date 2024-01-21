import classes from "./AuthForm.module.css"
import rmstyle from "./removestyle.module.css";
import {Form, useActionData, Link} from "react-router-dom";
import logo from "../assets/Logo/logo_darkblue.png";

function AuthForm() {
    const data = useActionData();
    return (
        <>
            <Form method="post">
                {data && data.errors && (
                    <ul className={rmstyle.ulError}>
                        {Object.entries(data.errors).map(([field, errors]) => (
                            <li key={field}>{field}: {errors[0]}</li>
                        ))}
                    </ul>
                )}
                {data && data.message && <p>{data.message}</p>}
                <div className={classes["logo"]}>
                    <img src={logo} alt="logo"/>
                    <h1>Accessibility</h1>
                </div>

                <div className={classes["input-box"]}>
                    <input type="username" name="username" placeholder="Username"/>
                    <i className="bx bxs-user"></i>
                </div>
                <div className={classes["input-box"]}>
                    <input type="Password" name="password" placeholder="Password"/>
                    <i className="bx bxs-lock-alt"></i>
                </div>
                <button type="Submit" className={classes["btn--login"]}>
                    Login
                </button>
                <div className={classes["forgot-password"]}>
                    <Link to={"/forgot"}>Forgot password?</Link>
                    <br/>
                    <Link to={"/register"}>Register here <i className='bx bx-right-arrow-alt'></i></Link>
                </div>
                <div className={classes["OR"]}>
                    <p>OR</p>
                </div>
                <div className={classes["Google-btn"]}>
                    <button type="Submit" className={classes["btn--google"]}>
                        Login with google
                    </button>
                    <i className="bx bxl-google"></i>
                </div>

            </Form>
        </>
    )
}

export default AuthForm;