import classes from "./login.module.css";

import AuthForm from "../../components/AuthForm";
import axios from "axios";
import {apiPath} from "../../util/api.jsx";
import {jwtDecode} from "jwt-decode";
import {redirect} from "react-router-dom";


function Login() {
    return (
        <>
            <div className={classes["page-wrapper"]}>
                <div className={classes["wrapper"]}>
                    <div className={classes["bg-cirkel"]}></div>
                    <div className={classes["bg-vector"]}>
                        <svg
                            width="821"
                            height="722"
                            viewBox="0 0 821 722"
                            fill="none"
                            xmlns="http://www.w3.org/2000/svg"
                        >
                            <path
                                d="M257.5 140C121.9 152.8 29.6667 52 0.5 0L864.5 3.5V721.5H768C469.2 683.5 519.5 532 582 461C618.5 411.167 684.5 291.1 656.5 209.5C621.5 107.5 427 124 257.5 140Z"
                                fill="#3877FF"
                            />
                        </svg>
                    </div>
                    <AuthForm/>
                </div>
            </div>
        </>
    );
}

export default Login;

export async function action({request}) {
    try {
        const data = await request.formData();
        const authData = {
            userName: data.get('username'),
            password: data.get('password'),
        };

        const response = await axios.post(apiPath + "/api/account/login", authData);

        if (response.status !== 200) {
            return {status: response.status, message: 'Could not authenticate user.'};
        }

        const token = response.data;
        const tokenString = JSON.stringify(token);
        localStorage.setItem('token', tokenString);


        if (tokenString) {

            const decodedToken = jwtDecode(tokenString);


            const role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

            switch (role) {
                case 'Ervaringsdeskundig':
                    return redirect('/deskundig');
                    break;
                case 'BedrijfMedewerker':
                    return redirect('/bedrijfportaal');
                    break;
                case 'Beheerder':
                    return redirect('/beheerderportaal');
                    break;
                default:
                    return redirect('/');
                    break;
            }
        }


    } catch (error) {
        console.log(error)
        if (error.response) {
            if (error.response.status === 404) {
                return {status: 404, message: error.response.data};
            } else if (error.response.status === 400) {
                return {status: 400, errors: error.response.data.errors}
            } else if (error.response.status === 401) {
                return {status: 401, message: error.response.data};
            } else {
                return {status: error.response.status, message: 'Could not authenticate user.'};
            }
        }
        return {status: 500, message: 'An error occurred while making the request.'};
    }
}