function calculateTotal() {
    let total = 0;
    const checkboxes = document.querySelectorAll('.service-checkbox'); // Seleciona todos os checkboxes
    
    checkboxes.forEach(checkbox => {
        if (checkbox.checked) { // Verifica se o checkbox está selecionado
            total += parseFloat(checkbox.getAttribute('data-price')); // Adiciona o preço ao total
        }
    });
    
    document.getElementById('totalPrice').innerText = total.toFixed(2);
}