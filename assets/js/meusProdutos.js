// modal - cadastrar intem
var modalcadastroItem = document.getElementById("modal-cadItem");
var cadastrarProdBtn = document.getElementById("cadastrarProdBtn");
var closeCadItem = document.getElementsByClassName("close-modal-cadItem")[0];
cadastrarProdBtn.onclick = function() {
  modalcadastroItem.style.display = "block";
}
closeCadItem.onclick = function() {
  modalcadastroItem.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == modalcadastroItem) {
    modalcadastroItem.style.display = "none";
  }
}


/* modal de cadastro de item - form */

// passos barra de progresso
const stepMenuOne = document.querySelector('.formCad-stepsCad-steps-item1')
const stepMenuTwo = document.querySelector('.formCad-stepsCad-steps-item2')
const stepMenuThree = document.querySelector('.formCad-stepsCad-steps-item3')

// paginas do formulario
const stepOne = document.querySelector('.formCad-page-step-1')
const stepTwo = document.querySelector('.formCad-page-step-2')
const stepThree = document.querySelector('.formCad-page-step-3')
// enviar
const formSubmitBtn = document.querySelector('.formCad-btn')
// voltar 
const formBackBtn = document.querySelector('.formCad-back-btn')

// envio de formulario
formSubmitBtn.addEventListener("click", function(event){
  event.preventDefault()

  // verifica qual passo está ativo no momento
  if(stepMenuOne.className == 'formCad-stepsCad-steps-item1 active') {
      event.preventDefault()

     // atualiza a barra de progresso
      stepMenuOne.classList.remove('active')
      stepMenuTwo.classList.add('active')

      stepOne.classList.remove('active')
      stepTwo.classList.add('active')
      
      // ativa botão de voltar
      formBackBtn.classList.add('active')
      formBackBtn.addEventListener("click", function (event) {
        event.preventDefault()
         // reverte as mudanças se clicar em 'voltar'
        stepMenuOne.classList.add('active')
        stepMenuTwo.classList.remove('active')

        stepOne.classList.add('active')
        stepTwo.classList.remove('active')

        formBackBtn.classList.remove('active')

      })
    } else if(stepMenuTwo.className == 'formCad-stepsCad-steps-item2 active') {
      event.preventDefault()

      stepMenuTwo.classList.remove('active')
      stepMenuThree.classList.add('active')

      stepTwo.classList.remove('active')
      stepThree.classList.add('active')

      // desativa botão de voltar e atualiza o texto do botão
      formBackBtn.classList.remove('active')
      formSubmitBtn.textContent = 'Cadastrar'
    } else if(stepMenuThree.className == 'formCad-stepsCad-steps-item3 active') {
        // envia o formulario na terceita etapa
        document.querySelector('form').submit()
        const confirmationMessage = "Produto cadastrado com sucesso";
        alert(confirmationMessage);
    }
})
