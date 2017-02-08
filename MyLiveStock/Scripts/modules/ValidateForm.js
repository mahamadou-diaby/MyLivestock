$(document).ready(function () {

    
    $("#CreateBirthRabbitForm").validate();
    $("#CreatePalpateForm").validate();
    $("#CreateRabbitForm").validate();
    $("#CreateJutForm").validate();

    $("#palpateDate").datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
    });
    $("#birthDate").datepicker({
        autoclose: true,
    });
    $("#procurementDate").datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
    });
    $(".date#jutDate").datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
    });
    
});