import React from "react";
import { useQuery, QueryClient, QueryClientProvider } from "react-query";
import axios from 'axios';

const queryClient = new QueryClient();

const fetchCustomers = async () => {
    const result = await axios.get('http://localhost:5088/api/customer');
    return <result className="data"></result>
};

const Customer  = () => {
    const { isLoading, error, data } = useQuery('customers', fetchCustomers); 
    if (isLoading) return "Loading...";
    if (error) return 'There was an error! ${error}';

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

const QueryTesting = () => {
    return (
      <QueryClientProvider client={queryClient}>
        <Customer />
      </QueryClientProvider>
    );
  };
  
  export default QueryTesting;