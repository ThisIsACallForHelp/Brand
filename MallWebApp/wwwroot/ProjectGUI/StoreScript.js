const OpenButton = document.getElementById("OpenModal");
const CloseButton = document.getElementById("CloseModal");
const Modal = document.getElementById("Modal");

OpenButton.addEventListener("click", () => {
    Modal.classList.add("open")
})

CloseButton.addEventListener("click", () => {
    Modal.classList.remove("open")
})