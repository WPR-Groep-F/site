import classes from "./login.module.css";

import AuthForm from "../../components/AuthForm";
import {redirect,json} from "react-router-dom";
import axios from "axios";
import {apiPath} from "../../util/api.jsx";
import {isDev} from "../../util/development.jsx";

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
          <AuthForm />
        </div>
      </div>
      {console.log(apiPath)}
      {console.log(isDev())}
    </>
  );
}

export default Login;

export async function action({ request }) {
  
  const data = await request.formData();
  const authData = {
    userName: data.get('username'),
    password: data.get('password'),
  };
  const response = await axios.post(apiPath + "/api/account/login", authData);
  
  if (!response.status == "200") {
    throw json({ message: 'Could not authenticate user.' }, { status: 500 });
  }
  

  // soon: manage that token
  
  const token = response.data;
  
  localStorage.setItem('token',JSON.stringify(token))
  
  return redirect('/deskundig');
}