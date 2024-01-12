import React from "react";
import { useQuery } from "react-query";
import axios from 'axios';

const fetchCustomers = async () => {
    const result = await axios.get('http://localhost:5088/api/customer');
    return <result className="data"></result>
};

const QueryTesting = () => {
    const { isLoading, error, data } = useQuery('customers', fetchCustomers); 
    if (isLoading) return "Loading...";
    if (error) return "There was an error! ${error}";


    return (
        <div>
        <h1>Query GET</h1>        
            <div>
                { data.map((customer) => {
                    <p key={customer} > {customer.FirstName} </p>
                    })
                }
                </div>
        </div>
        
    )
};


export default QueryTesting;
  