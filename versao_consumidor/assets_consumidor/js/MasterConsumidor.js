// * navbar 
const btnMenu = document.getElementById('btn-menu');
const navbar = document.querySelector('.navbar');
const navLinks = document.querySelectorAll('.navbar a');

btnMenu.addEventListener('click', () => {
    navbar.classList.toggle('active');
});

document.addEventListener('click', (event) => {
    if (!event.target.closest('.navbar') && !event.target.closest('#btn-menu')) {
        navbar.classList.remove('active');
    }
});

// ********
// * dropdown cart
var dropdown = document.getElementById("myDropdown");
var cartCloseButton = document.getElementById("cartClose");

// abre o dropdwon
function toggleDropdown(event) {
    event.stopPropagation();
    dropdown.classList.toggle("show");
}

document.querySelector(".cart-icon").addEventListener("click", toggleDropdown);

// fecha o dropdown
cartCloseButton.addEventListener("click", function (event) {
    event.stopPropagation();
    dropdown.classList.remove("show");
});

window.addEventListener("scroll", function () {
    dropdown.classList.remove("show");
});

// não deixa fechar se clicar dentro
dropdown.addEventListener("click", function (event) {
    event.stopPropagation();
});

// ********
// * exluir item do carrinho
var deleteButtons = document.querySelectorAll("#btnDelItem");

deleteButtons.forEach(function (button) {
    button.addEventListener("click", function (event) {
        event.stopPropagation();
        var cartItem = event.target.closest(".order-item");
        if (cartItem) {
            cartItem.remove();
            updateCartAndSellerInfo();
        }
    });
});

function updateCartAndSellerInfo() {
    var cartContent = document.querySelector(".cart-order");
    var cartEndContent = document.querySelector(".cart-end-order");
    var cartItems = document.querySelectorAll(".order-item");

    if (cartItems.length === 0) {
        cartContent.style.display = "none";
        cartEndContent.style.display = "none";
    } else {
        cartContent.style.display = "block";
        cartEndContent.style.display = "block";
    }
}


/////////////////////

