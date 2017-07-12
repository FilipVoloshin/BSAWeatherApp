var firstValue = true;
$(document).ready(function () {
    $("#cityDropDown").select2({
        theme: "bootstrap"
    });
});
function changeSelectType() {
    var cityDropdownVal = $("#cityDropDown").val();
    if (cityDropdownVal !== "") {
        $("#customCity").attr('disabled', true);
        $("#customCity").val("");
    }
    else {
        $("#customCity").attr('disabled', false);
    }
}

$("#cityDropDown").change(function () {
    changeSelectType();
});

function weatherResultAppear(data) {

    if (firstValue) {
        firstValue = false;
        $("#weatherResult").hide().fadeIn(2000);
    }
    $("#weatherSmallText").show();
    $("#loadSpin").hide();
    $("#closeWeatherNow").click(function () {
        $("#weatherSmallText").fadeOut(1000);
    });
}
function startAjax() {
    $("#loadSpin").show();
}
