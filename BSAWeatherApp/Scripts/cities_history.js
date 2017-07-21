function deleteCity(id) {
    $.ajax({
        url: "/Settings/DeleteCity",
        type: "POST",
        data: { id: id },
        success: function () {
            $("#city_" + id).remove();
        }
    })
}