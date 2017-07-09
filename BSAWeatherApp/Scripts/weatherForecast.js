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

$(document).ready(function () {
    $("#uaFlagImg").fadeOut(10000);
})
