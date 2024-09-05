$(document).ready(function () {
    var successMessage = $('.alert-success').text().trim();
    if (successMessage) {
        // Muestra la alerta y luego la oculta después de 3 segundos
        $('.alert-success').fadeIn('slow');
        setTimeout(function () {
            $('.alert-success').fadeOut('slow');
        }, 3000);
    }
});
