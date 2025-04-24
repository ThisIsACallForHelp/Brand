document.querySelector("form").addEventListener("submit", function (event) {
    //get the form as soon as the user clicks on the submit button
    let firstName = document.getElementById("FirstName").value.trim(); //get the value
    let lastName = document.getElementById("LastName").value.trim(); //get the value
    let password = document.getElementById("Password").value.trim(); //get the value
    let errorDiv = document.querySelector(".error"); //the error div 

    if (!firstName || !lastName || !password) { //check if everything is good
        errorDiv.style.opacity = 1; //if not, remove the transparency
        event.preventDefault(); //prevent the user from submitting a wrong form 
    } else {
        errorDiv.style.display = "none"; //if everything is fine - its fine, dont show the message
    }
});
