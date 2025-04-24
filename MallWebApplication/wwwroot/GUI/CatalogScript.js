const openBtn = document.getElementById("OpenModal");
const closeBtn = document.getElementById("CloseModal");
const modal = document.getElementById("Modal");

openBtn.addEventListener("click", () => {
    modal.classList.add("open");
})
closeBtn.addEventListener("click", () => {
    modal.classList.remove("open");
})