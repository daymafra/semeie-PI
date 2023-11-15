window.addEventListener('scroll', function() {
    var navbar = document.querySelector('.nav');

    // Verifique a posição de rolagem da página
    if (window.scrollY > 0) {
        // Adicione a classe quando a página for rolada
        navbar.classList.add('nav-white-bg');
    } else {
        // Remova a classe quando a página estiver no topo
        navbar.classList.remove('nav-white-bg');
    }
});