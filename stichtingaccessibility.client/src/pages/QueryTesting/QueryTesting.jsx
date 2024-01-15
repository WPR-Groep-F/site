import React from "react";
import axios from 'axios';

const baseURL = "http://localhost:5088/api/customer/1";

export default function QueryTesting() {
    const [customer, setCustomer] = React.useState(null);
  
    React.useEffect(() => {
      axios.get(baseURL).then((response) => {
        setCustomer(response.data);
      });
    }, []);
  
    if (!customer) return null;
  
    return (
      <div>
        <h1>{customer.customerId}</h1>
        <h1>{customer.firstName}</h1>
        <h1>{customer.lastName}</h1>
        <h1>{customer.email}</h1>
      </div>
    );
  }
