import React from "react";
import axios from 'axios';
import axiosInstance from "../../Services/axiosInstance.js";
import {apiPath} from "../../util/api.jsx";

export default function QueryTesting() {
    const [customer, setCustomer] = React.useState(null);
  
    React.useEffect(() => {
        axiosInstance.get(apiPath + "/api/Customer/1").then((response) => {
        setCustomer(response.data);
        console.log(response.data)
      });
    }, []);
  
    if (!customer){
        return null
    };
  
    return (
      <div>
        <h1>{customer.customerId}</h1>
        <h1>{customer.firstName}</h1>
        <h1>{customer.lastName}</h1>
        <h1>{customer.email}</h1>
      </div>
    );
  }
