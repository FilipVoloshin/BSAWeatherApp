var firstValue = true;
$(document).ready(function () {
    $(".cityDropDown").select2();
});
function changeSelectType() {
    var cityDropdownVal = $("#defaultCity").val();
    if (cityDropdownVal !== "") {
        $("#customCity").attr('disabled', true);
        $("#customCity").val("");
    }
    else {
        $("#customCity").attr('disabled', false);
    }
}

$("#defaultCity").change(function () {
    changeSelectType();
});

function weatherResultAppear() {

    if (firstValue) {
        firstValue = false;
        $("#weatherResult").hide().fadeIn(2000);
    }
    $("#loadSpin").hide();
}
function startAjax() {
    $("#loadSpin").show();
}
