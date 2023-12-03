// Navbar
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

// Dropdown do Usuário
function myDropNav() {
    document.getElementById("myDropdownNav").classList.toggle("show");
}

window.onclick = function (event) {
    if (!event.target.matches('.dropbtn-usericon')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

// Modal de Confirmação Logout
var modalLogout = document.getElementById("modal-logout");
var btnUserLogout = document.getElementById("userLogout");
var closeModalogout = document.getElementsByClassName("close-modal-logout")[0];

btnUserLogout.onclick = function () {
    modalLogout.style.display = "block";
}

closeModaLogout.onclick = function () {
    modalLogout.style.display = "none";
}

// Fechar modal se clicar fora
window.onclick = function (event) {
    if (event.target == modalLogout) {
        modalLogout.style.display = "none";
    }
}
