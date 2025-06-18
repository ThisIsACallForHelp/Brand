document.addEventListener("DOMContentLoaded", function () {
    const submitButton = document.querySelector("button");
    submitButton.addEventListener("click", function () {
        const numberInputs = [
            document.getElementById("NumberOne"),
            document.getElementById("NumberTwo"),
            document.getElementById("NumberThree"),
            document.getElementById("NumberFour"),
        ];
        const date = document.getElementById("Date").value.trim();
        const cvv = document.getElementById("CVV").value.trim();
        const name = document.getElementById("OwnerName").value.trim();

        let isValid = true;
        let message = "";

        numberInputs.forEach((input, index) => {
            if (!/^\d{4}$/.test(input.value)) {
                isValid = false;
                message += `Card block ${index + 1} must be 4 digits.\n`;
            }
        });

        if (!/^(0[1-9]|1[0-2])\/\d{2}$/.test(date)) {
            isValid = false;
            message += "Date must be in MM/YY format.\n";
        }

        if (!/^\d{3,4}$/.test(cvv)) {
            isValid = false;
            message += "CVV must be 3 or 4 digits.\n";
        }

        if (!/^[A-Za-z ]{2,}$/.test(name)) {
            isValid = false;
            message += "Name must contain only letters and be at least 2 characters long.\n";
        }

        if (isValid) {
            alert("Form is valid. Submitting...");
        } else {
            event.preventDefault();
            alert(" Validation failed - " + message);
        }
    });
});

