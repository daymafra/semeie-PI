//// modal ver pedido
var modalViewOrder = document.getElementById("modal-viewOrder");
var btnOrder = document.getElementById("verOrderDetails");
var btnCloseVOrder = document.getElementsByClassName("close-modal");
btnOrder.onclick = function () {
    modalViewOrder.style.display = "block";
}
btnCloseVOrder .onclick = function () {
    modalViewOrder.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modalViewOrder) {
        modalViewOrder.style.display = "none";
    }
}

//// verificação, confirmação do pedido
document.getElementById("verOrderDetails").addEventListener("click", openModal);
document.querySelector(".close-modal").addEventListener("click", closeModal);
document.getElementById("confirmOrder").addEventListener("click", confirmOrder);
document.getElementById("rejectOrder").addEventListener("click", rejectOrder);
document.getElementById("endOrder").addEventListener("click", endOrder);

var orderStatus = document.querySelector(".order-status");
var statusIcon = document.getElementById("statusIcon");
var statusMsg = document.getElementById("statusMsg");
var orderCard = document.querySelector(".order-card");

function openModal() {
    var modalViewOrder = document.getElementById("modal-viewOrder");
    modalViewOrder.style.display = "block";
}

function closeModal() {
    var modalViewOrder = document.getElementById("modal-viewOrder");
    modalViewOrder.style.display = "none";
}

function confirmOrder() {
    if (orderStatus.textContent.trim().toLowerCase() === "rejeitado") {
        alert("Este pedido já foi rejeitado e não pode ser confirmado.");
    } else {
        var confirmResult = window.confirm("Deseja confirmar o pedido? Esta ação não pode ser desfeita");

        if (confirmResult) {
            closeModal();
            orderStatus.style.color = "#00B860";
            orderCard.style.border = "1px solid #00B860";
            orderStatus.textContent = "Confirmado";

            document.getElementById("confirmOrder").style.display = "none";
            document.getElementById("rejectOrder").style.display = "none";
            document.getElementById("endOrder").style.display = "block";
        }
    }
}

function rejectOrder() {
    if (orderStatus.textContent.trim().toLowerCase() === "confirmado") {
        alert("Este pedido já foi confirmado e não pode ser rejeitado.");
    } else {
        var confirmResult = window.confirm("Deseja rejeitar o pedido? Esta ação não pode ser desfeita");

        if (confirmResult) {
            closeModal();
            orderStatus.style.color = "#EB4747";
            orderCard.style.border = "1px solid #EB4747";
            orderStatus.textContent = "Rejeitado";

            document.getElementById("confirmOrder").style.display = "none";
            document.getElementById("rejectOrder").style.display = "none";
            document.getElementById("endOrder").style.display = "block";
        }
    }
}

function endOrder() {
    var confirmResult = window.confirm("Tem certeza que quer finalizar o pedido?");

    if (confirmResult) {
        alert("Pedido finalizado com sucesso!");

        closeModal();
        orderCard.style.display = "none";
    }
}


///***************/
//// modal all orders
var modalAll = document.getElementById("modalAllOrders");
var btnAllOrder = document.getElementById("allOrders");
var span = document.getElementsByClassName("close-modal-all")[0];
btnAllOrder.onclick = function () {
    modalAll.style.display = "block";
}
span.onclick = function () {
    modalAll.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modalAll) {
        modalAll.style.display = "none";
    }
}

//tab all orders
function openTabFilter(evt, orderTabFilter) {
    var i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(orderTabFilter).style.display = "block";
    evt.currentTarget.className += " active";
}
document.getElementById("defaultOpen").click();