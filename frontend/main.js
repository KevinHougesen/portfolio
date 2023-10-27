window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
});

const localFunctionApi = "http://localhost:7071/api/GetVisitorCounter";
const functionApi = "https://getvisitorcounts.azurewebsites.net/api/GetVisitorCounter?code=VxoYUXJZbov3lxNG0g-vOzjPs0tZXxJBTgAIAmWe_FN2AzFu0QLWtw=="

const getVisitCount = () => {
    fetch(functionApi)
      .then(response => {
        return response.json()
      })
      .then(response => {
        let count = response.count;
        console.log(response);
        console.log("Hello 👋, you are visitor number - " + response.count);
        document.getElementById('counter').innerText = count;
      }).catch(function (error) {
        console.log(error);
      });
    return count;
}