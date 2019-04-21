
$(document).ready(function () {
    $('#ShowMenu').click(function (event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#ShowSelection').load(url);
       
                if ($("#Check_AS").is(':checked')) {
                    setTimeout(function () { $("#ShowSelection").css("display", "block") }, 1000); setTimeout(function () { $("#Menu_AS").css("display", "block") }, 1000); 
                    if ($("#Check_AM").is(':checked')) { setTimeout(function () { $("#AM_AS").css("display", "block"); }, 500); } else { $("#AM_AS").css("display", "none"); }
                    if ($("#Check_AZ").is(':checked')) { setTimeout(function () { $("#AZ_AS").css("display", "block"); }, 500); } else { $("#AZ_AS").css("display", "none"); }
                    if ($("#Check_GE").is(':checked')) { setTimeout(function () { $("#GE_AS").css("display", "block"); }, 500); } else { $("#GE_AS").css("display", "none"); }
                    if ($("#Check_IR").is(':checked')) { setTimeout(function () { $("#IR_AS").css("display", "block"); }, 500); } else { $("#IR_AS").css("display", "none"); }
                }

                else { setTimeout(function () { $("#ShowSelection").css("display", "block") }, 1000); };
           
    });
    return false;
}); 
$(document).ready(function () {
    $("#CloseMenu").click(function (event) {
        event.preventDefault();
        $("#ShowSelection").css("display", "none");
        return false;
    });
    return false;
}); 

