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
$(document).ready(function () {
    $("#history-table").DataTable({
        "info": false,
        "lengthChange": false,
        "order": [[1, 'desc']],
        "dom": '<"row view-filter"<"col-sm-12"<"pull-left"l><"pull-right"f><"clearfix">>>t<"row view-pager"<"col-sm-12"<"text-center"ip>>>'
    });
});