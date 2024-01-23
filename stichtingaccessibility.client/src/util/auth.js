export function getAuthToken() {
    const tokenObject = JSON.parse(localStorage.getItem('token'));
    const tokenValue = tokenObject.token;
    return tokenValue;
}