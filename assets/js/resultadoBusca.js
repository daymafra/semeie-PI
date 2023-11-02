
var filterDropdown = document.getElementById("myFilterDropdown");

function toggleDropdown(event) {
    event.stopPropagation();
    filterDropdown.classList.toggle("showFilterItens");
}

document.querySelector(".btn-filters").addEventListener("click", toggleDropdown);

document.addEventListener("click", function(event) {
    if (!event.target.closest(".btn-filters") && !event.target.closest("#myFilterDropdown")) {
        filterDropdown.classList.remove("showFilterItens");
    }
});







