var firstValue = true;

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
function addRowToCityTable(name, description) {
    if (description === null) {
        description = "";
    }
    $("#tableWithCity > tbody:last-child").append('<tr>'+
        '<td><input class="form-control" data-val="true" data-val-length="Name should be minimum 3 characters and a maximum of 50 characters" data-val-length-max="100" data-val-length-min="3" data-val-required="The Name field is required." id="city_Name" name="city_Name" type="text" value="' + name + '" /></td>' +
        '<td><input class="form-control" id="city_Description" name="city.Description" type="text" value="' + description + '" /></td>' +
        '<td><button class="btn btn-success"><span class="fa fa-refresh"></span></button>' +
        ' <button class="btn btn-danger"><span class="fa fa-trash"></span></button></td></tr>');
}
function updateSettings(data) {
    $("#name").val("");
    $("#description").val("");
    if (data.Success) {
        var name = data.City.Name;
        var description = data.City.Description;
        addRowToCityTable(name, description);
        $("#addedCity").show();
        $("#addedCity").hide(3000);
    }

}

