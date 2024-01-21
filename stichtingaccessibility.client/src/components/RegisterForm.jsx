import classes from "./AuthForm.module.css"
import {Form, useActionData, Link} from "react-router-dom";
import logo from "../assets/Logo/logo_darkblue.png";
import rmstyle from "./removestyle.module.css";


function RegisterForm() {
    const data = useActionData();
    return (
        <>
            <Form method="post">
                {data && data.errors && (
                    <ul className={rmstyle.ulError}>
                        {data.errors.map((error, index) => (
                            <li key={index}>{error.description}</li>
                        ))}
                    </ul>
                )}
                {data && data.message && <p>{data.message}</p>}
                <div className={classes["logo"]}>
                    <img src={logo} alt="logo"/>
                    <h1>Accessibility</h1>
                </div>

                <div className={classes["input-box"]}>
                    <input type="username" placeholder="Username" name="username"/>
                    <i className="bx bxs-user"></i>
                </div>
                <div className={classes["input-box"]}>
                    <input type="email" placeholder="E-mail" name="email"/>
                    <i className='bx bxs-envelope'></i>
                </div>
                <div className={classes["input-box"]}>
                    <input type="password" placeholder="Password" name="password"/>
                    <i className="bx bxs-lock-alt"></i>
                </div>
                <div className={classes["input-box"]}>
                    <input type="password" placeholder="Confirm Password"/>
                    <i className="bx bxs-lock-alt"></i>
                </div>
                <div className={classes["forgot-password"]}>
                    <Link to={"/"}><i className='bx bx-left-arrow-alt'></i> Back to Login</Link>
                </div>
                <button type="Submit" className={classes["btn--register"]}>
                    Registreer
                </button>

            </Form>
        </>
    )
}

export default RegisterForm;