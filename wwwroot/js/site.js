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

document.getElementById('data').setAttribute('min', new Date().toISOString().split("T")[0]);

document.getElementById('agendarButton').addEventListener('click', function() {
    const selectedServices = document.querySelectorAll('.service-checkbox:checked');
    const selectedDate = document.getElementById('data').value;

    // Verificar se pelo menos um serviço foi selecionado e uma data foi escolhida
    if (selectedServices.length === 0) {
        alert('Por favor, selecione pelo menos um serviço.');
        return;
    }
    if (!selectedDate) {
        alert('Por favor, selecione uma data.');
        return;
    }

    // Exibir mensagem de sucesso
    document.getElementById('successMessage').style.display = 'block';

    // Ocultar a mensagem após 3 segundos
    setTimeout(() => {
        document.getElementById('successMessage').style.display = 'none';
    }, 3000);
});