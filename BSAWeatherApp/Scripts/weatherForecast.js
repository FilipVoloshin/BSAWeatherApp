function changeSelectType() {
    var cityDropdownVal = $("#cities").val();
    if (cityDropdownVal != "") {
        $("#customCity").attr('disabled', true);
    }
    else {
        $("#customCity").attr('disabled', false);
    }
}

$("#cities").change(function () {
    changeSelectType();
});

$("#weatherBtn").click(function () {
    var selectedCityVal = $("#cities").val();
    var customCityVal = $("#customCity").val();
    var periods = $("#periods").val();
    $.ajax({

    })
});