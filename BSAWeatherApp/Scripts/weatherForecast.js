function changeSelectType() {
    var cityDropdownVal = $("#cities").val();
    if (cityDropdownVal !== "") {
        $("#customCity").attr('disabled', true);
        $("#customCity").val("");
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
        url: "Weather/GetForecastBySettings",
        type: "POST",
        data: {
            city: selectedCityVal,
            customCity: customCityVal,
            period: periods
        }
    })
});