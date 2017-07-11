// -----  City adding ----- //

function addRowToCityTable(id, name, description) {
    if (description === null) {
        description = "";
    }
    $("#tableWithCity > tbody:last-child").append('<tr id="tableRow_' + id + '">' +
        '<td><input id="city_' + id + '" class="form-control" data-val="true" data-val-length="Name should be minimum 3 characters and a maximum of 50 characters" data-val-length-max="100" data-val-length-min="3" data-val-required="The Name field is required." id="city_Name" name="city_Name" type="text" value="' + name + '" onchange = "changeEnabled(' + id + ')" /></td>' +
        '<td><input id="description_' + id + '" class="form-control" id="city.Description" name="city_Description" onchange = "changeEnabled(' + id + ')" type="text" value="' + description + '"/></td>' +
        '<td><button class="btn btn-success" id="update_' + id + '" onclick="updateCity(' + id + ')" disabled><span class="fa fa-refresh"></span></button>' +
        ' <button class="btn btn-danger" onclick="deleteCity(' + id + ')"><span class="fa fa-trash"></span></button></td></tr>');
}
function updateSettings(data) {
    $("#name").val("");
    $("#description").val("");
    if (data.Success) {
        var id = data.City.Id;
        var name = data.City.Name;
        var description = data.City.Description;
        addRowToCityTable(id, name, description);
        $("#addedCity").show();
        $("#addedCity").hide(3000);
    }
}

// ------ delete row ------
function deleteCity(id) {
    var confirmDelete = confirm("Delete city?");
    if (confirmDelete) {
        $.ajax({
            url: "/Weather/DeleteCity",
            type: "POST",
            data: { id: id },
            success: function () {
                $('#tableRow_' + id).remove();
            }
        });
    }
}

// ------ update row ------
function changeEnabled(id) {
    $("#update_" + id).removeAttr('disabled');
}

function updateCity(id) {
    var name = $("#city_" + id).val();
    var description = $("#description_" + id).val();
    $.ajax({
        url: "/Weather/UpdateCity",
        type: "POST",
        data: {
            id: id,
            name: name,
            description: description
        },
        success: function () {
            $("#update_" + id).attr('disabled', 'disabled');
        }
    });
}
