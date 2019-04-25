
//$(document).ready(function () {
    $('#ShowInMenu').on("click",function () {
        //event.preventDefault();
        alert("Check_AS is checked");
        //var url = $(this).attr('href');
        //$('#ShowSelection').load(url);

       
        //if ($("#Check_AS").is(':checked')) {
        //    //alert("Check_AS is checked");
        //    $("#ShowSelection").css("display", "block"); $("#Menu_AS").css("display", "block");
        //    if ($("#Check_AM").is(':checked')) { $("#AM_AS").css("display", "block"); } else { $("#AM_AS").css("display", "none"); };
        //    if ($("#Check_AZ").is(':checked')) { $("#AZ_AS").css("display", "block"); } else { $("#AZ_AS").css("display", "none"); };
        //    if ($("#Check_GE").is(':checked')) { $("#GE_AS").css("display", "block"); } else { $("#GE_AS").css("display", "none"); };
        //    if ($("#Check_IR").is(':checked')) { $("#IR_AS").css("display", "block"); } else { $("#IR_AS").css("display", "none"); };
        //} else { $("#ShowSelection").css("display", "none"); };

        //if ($("#Check_MC").is(':checked')) {
        //    //alert("Check_MC is checked");
        //    $("#ShowSelection").css("display", "block"); $("#Menu_MC").css("display", "block");
        //    if ($("#Check_AM").is(':checked')) { $("#AM_MC").css("display", "block"); } else { $("#AM_MC").css("display", "none"); }
        //    if ($("#Check_AZ").is(':checked')) { $("#AZ_MC").css("display", "block"); } else { $("#AZ_MC").css("display", "none"); }
        //    if ($("#Check_GE").is(':checked')) { $("#GE_MC").css("display", "block"); } else { $("#GE_MC").css("display", "none"); }
        //    if ($("#Check_IR").is(':checked')) { $("#IR_MC").css("display", "block"); } else { $("#IR_MC").css("display", "none"); }
        //} else { $("#ShowSelection").css("display", "none"); };
        
    });
//    return false;
//}); 
$(document).ready(function () {
    $("#CloseMenu").click(function (event) {
        alert("HHHH");
        event.preventDefault();
        //$("#ShowSelection").find($("#Menu_AS")).css("display", "none");
        $("#ShowSelection").css("display", "none");
        return false;
    });
    return false;
}); 
$(document).ready(function () {

    $('#Check_A').click(function () {
        alert("Check_AS is checked");
        //event.preventDefault();
        //$("#Show_ALL").css("display", "block");
        if ($("#Check_A").is(':checked')) {

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
