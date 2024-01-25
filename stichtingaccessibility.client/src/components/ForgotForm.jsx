import classes from "./AuthForm.module.css"
import {Form, useActionData, Link} from "react-router-dom";
import logo from "../assets/Logo/logo_darkblue.png";

function ForgotForm() {
    const data = useActionData();
    return (
        <>
            <Form method="post">
                {data && data.message && <p>{data.message}</p>}
                <div className={classes["logo"]}>
                    <img src={logo} alt="logo"/>
                    <h1>Accessibility</h1>
                </div>
                <div className={classes["input-box"]}>
                    <input type="email" placeholder="E-mail" name="email"/>
                    <i className='bx bxs-envelope'></i>
                </div>
                {data && data.errors && (
                    <ul>
                        {Object.values(data.errors).map((err) => (
                            <li key={err}>{err}</li>
                        ))}
                    </ul>
                )}
                <button type="Submit" className={classes["btn--register"]}>
                    Forgot password
                </button>
                <div className={classes["forgot-password"]}>
                    <Link to={"/"}><i className='bx bx-left-arrow-alt'></i> Back to Login</Link>
                </div>

            </Form>
        </>
    )
}

export default ForgotForm;