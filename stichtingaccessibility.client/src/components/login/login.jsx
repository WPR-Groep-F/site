
import classes from "./login.module.css"
import logo from "../../assets/Logo-accessibility.png";



function Login() {
  return (

    <>
      <div className={classes["wrapper"]}>
        <div className={classes["bg-cirkel"]}></div>
        <div className={classes["bg-vector"]}>
          <svg width="821" height="722" viewBox="0 0 821 722" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M257.5 140C121.9 152.8 29.6667 52 0.5 0L864.5 3.5V721.5H768C469.2 683.5 519.5 532 582 461C618.5 411.167 684.5 291.1 656.5 209.5C621.5 107.5 427 124 257.5 140Z" fill="#3877FF" />
          </svg>
        </div>
        <form action="">
          <div className={classes["logo"]}>
            <img src={logo} alt='logo' />
            <h1>Accessibility</h1>
          </div>

          <div className={classes["input-box"]}>
            <input type="email" placeholder='Username' />
            <i class='bx bxs-user'></i>
          </div>
          <div className={classes["input-box"]}>
            <input type="Password" placeholder='Password' />
            <i class="bx bxs-lock-alt"></i>
          </div>
          <button type="Submit" className={classes["btn--login"]}>Login</button>
          <div className={classes["forgot-password"]}>
            <a href="#">Forgot password?</a>
          </div>
          <div className={classes["OR"]}><p>OR</p></div>
          <div className={classes["Google-btn"]}>
            <button type="Submit" className={classes["btn--google"]}>Login with google</button>
            <i class='bx bxl-google'></i>
          </div>
        </form>
      </div>
    </>
  );
}

export default Login;
