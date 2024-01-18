import {isDev} from "./development.jsx";

export const apiPath = isDev() ? "https://localhost:7024" : "https://groepf.azurewebsites.net";