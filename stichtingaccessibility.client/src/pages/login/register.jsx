import RegisterForm from "../../components/RegisterForm";
import classes from "./login.module.css";
import axios from "axios";
import {redirect} from "react-router-dom";
import {apiPath} from "../../util/api.jsx";

function register() {
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
            <RegisterForm />
          </div>
        </div>
      </>
    );
  }
  
  export default register;

export async function action({ request }) {
    
    try {
        const data = await request.formData();
        const registerData = {
            userName: data.get('username'),
            password: data.get('password'),
            email: data.get('email'),
        };
        const response = await axios.post(apiPath + "/api/account/registreer", registerData);
        
        if (error.response.status === 400 ) {
            throw json({ message: 'Could not create user.' }, { status: 500 });
        }
        else if (!error.response.status === 200){
            return {status: error.response.status , message: "test" }
        }

        return redirect('/');
    }
    catch (error){
        console.log("In catch")
        console.log(error.response)
        if (error.response.status === 400 ) {
            return { errors: error.response.data.errors, status: error.response.status };
        }
        else if (!error.response.status === 200 ){
            return {status: 500, message: "test" }
        }
    }


    // soon: manage that token
    
}