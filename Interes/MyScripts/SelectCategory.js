$(document).ready(function () {
    $('#Expand').click(function (event) {
        event.preventDefault();
        if ($("#Check_AS").is(':checked')) { $("#Show_AS").css("display", "block"); } else { $("#Show_AS").css("display", "none"); };
        if ($("#Check_MC").is(':checked')) { $("#Show_MC").css("display", "block"); } else { $("#Show_MC").css("display", "none"); };
        if ($("#Check_SP").is(':checked')) { $("#Show_SP").css("display", "block"); } else { $("#Show_SP").css("display", "none"); };
        if ($("#Check_DS").is(':checked')) { $("#Show_DS").css("display", "block"); } else { $("#Show_DS").css("display", "none"); };
        if ($("#Check_BG").is(':checked')) { $("#Show_BG").css("display", "block"); } else { $("#Show_BG").css("display", "none"); };
        if ($("#Check_BR").is(':checked')) { $("#Show_BR").css("display", "block"); } else { $("#Show_BR").css("display", "none"); };
        //var url = $(this).attr('href');
        //$('#privacy').load(url);
    });
});
$(document).ready(function () {
    $('#Close').click(function (event) {
        event.preventDefault();
        $("#Show_AS").css("display", "none");
        $("#Show_MC").css("display", "none"); 
        $("#Show_SP").css("display", "none"); 
        $("#Show_DS").css("display", "none"); 
        $("#Show_BG").css("display", "none"); 
        $("#Show_BR").css("display", "none");
    });
});
$(document).ready(function () {

    $('#Check_ALL').click(function () {
        //event.preventDefault();
        //$("#Show_ALL").css("display", "block");
        if ($("#Check_ALL").is(':checked')) {
           
            $("#Check_AS").prop('checked', true);
            $('#Check_MC').prop('checked', true);
            $('#Check_SP').prop('checked', true);
            $('#Check_DS').prop('checked', true);
            $('#Check_BG').prop('checked', true);
            $('#Check_BR').prop('checked', true);
        } else {
           
            $("#Check_AS").prop('checked', false);
            $("#Check_MC").prop('checked', false);
            $("#Check_SP").prop('checked', false);
            $("#Check_DS").prop('checked', false);
            $("#Check_BG").prop('checked', false);
            $("#Check_BR").prop('checked', false);
        }

    });

    return false;
});
//document.addEventListener("DOMContentLoaded", Checkboxes);
//function Checkboxes() {
//    if ($("#Check_AS").is(':checked')) { $("#Show_AS").css("display", "block"); } else { $("#Show_AS").css("display", "none"); };
//    if ($("#Check_MC").is(':checked')) { $("#Show_MC").css("display", "block"); } else { $("#Show_MC").css("display", "none"); };
//    if ($("#Check_SP").is(':checked')) { $("#Show_SP").css("display", "block"); } else { $("#Show_SP").css("display", "none"); };
//    if ($("#Check_DS").is(':checked')) { $("#Show_DS").css("display", "block"); } else { $("#Show_DS").css("display", "none"); };
//    if ($("#Check_BG").is(':checked')) { $("#Show_BG").css("display", "block"); } else { $("#Show_BG").css("display", "none"); };
//    if ($("#Check_BR").is(':checked')) { $("#Show_BR").css("display", "block"); } else { $("#Show_BR").css("display", "none"); };
//}
