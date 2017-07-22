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