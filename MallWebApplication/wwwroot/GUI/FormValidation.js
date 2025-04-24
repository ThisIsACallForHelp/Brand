document.querySelector("form").addEventListener("submit", function (event) {
    let firstName = document.getElementById("FirstName").value.trim();
    let lastName = document.getElementById("LastName").value.trim();
    let email = document.getElementById("Email").value.trim();
    let phone = document.getElementById("PhoneNumber").value.trim();
    let password = document.getElementById("Password").value.trim();
    let image = document.getElementById("Image").files.length;
    let errorDiv = document.getElementById("ErrorDiv");

    if (!firstName || !lastName || !email || !phone || !password || image === 0) {
        errorDiv.style.opacity = 1;
        event.preventDefault();
        return;
    }

    if (!email.endsWith("@gmail.com")) {
        errorDiv.style.opacity = 1;
        event.preventDefault();
        return;
    }

    if (!/^05[1-9][0-9]{7}$/.test(phone)) {
        errorDiv.style.opacity = 1;
        event.preventDefault();
        return;
    }

    errorDiv.innerText = ""; // לנקות את השדה אם הערכים נכונים 
});
