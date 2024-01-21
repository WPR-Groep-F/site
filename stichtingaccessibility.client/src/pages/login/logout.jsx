import {redirect} from "react-router-dom"
import axiosInstance from "../../Services/axiosInstance.js";
import {apiPath} from "../../util/api.jsx";

export function action() {
    axiosInstance.post(`${apiPath}/api/Account/logout`)
    localStorage.removeItem('token')
    return redirect('/')
}