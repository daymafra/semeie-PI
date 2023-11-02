// registro
document.addEventListener('DOMContentLoaded', function () {
    var form = document.querySelector('.form-inputs');
    var inputs = form.querySelectorAll('input[required]');
    var typeUserCheckboxes = form.querySelectorAll('input[name^="type-"]');
    var termsCheckbox = document.querySelector('input[name="terms"]');

    document.querySelector('#btnCadastro').addEventListener('click', function (e) {
        e.preventDefault();
        
        // checkbox user
        var typeUserChecked = Array.from(typeUserCheckboxes).some(function (checkbox) {
            return checkbox.checked;
        });

         // checkbox terms
         var termsChecked = termsCheckbox.checked;

        // campos prenchidos
        inputs.forEach(function (input) {
            if (input.value.trim() === '') {
                input.style.borderColor = '#ff0000';
            }else{
                input.style.borderColor = '#4FBF26';
            }
        });

        if (!typeUserChecked) {
            alert('Escolha um tipo de usuario');
        }

    });

    inputs.forEach(function (input) {
        input.addEventListener('focus', function () {
            input.style.backgroundColor = '';
        });
    });
});


// login
document.addEventListener('DOMContentLoaded', function () {
    var form = document.querySelector('form');
    var inputs = form.querySelectorAll('input[required]');
    
    document.querySelector('#btnEntrar').addEventListener('click', function (e) {
        e.preventDefault();

        // campos prenchidos
        inputs.forEach(function (input) {
            if (input.value.trim() === '') {
                input.style.borderColor = '#ff0000';
            }else{
                input.style.borderColor = '#4FBF26';
            }
        });

        var emailInput = document.querySelector('input[name="email"]');
        var passwordInput = document.querySelector('input[name="psw"]');
        if (emailInput.value.trim() === '' || passwordInput.value.trim() === '') {
            alert('Por favor, preencha todos os campos obrigatórios.');
            e.preventDefault();
        }
    });
    inputs.forEach(function (input) {
        input.addEventListener('focus', function () {
            input.style.backgroundColor = '';
        });
    });
});