window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
});

const functionApi = "http://localhost:7071/api/GetVisitorCounter";

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