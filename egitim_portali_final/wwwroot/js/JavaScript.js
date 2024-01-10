$(document).ready(function () {
    loadUser();

    function loadUser() {
        $.ajax({
            url: "UserListAjax",
            type: "Get",
            success: function (data) {
                if (data && data.length > 0) {
                    var i = 1;
                    $.each(data, function (_index, item) {
                        var tr = $('<tr id="' + item.id + '"></tr>');
                        tr.append('<td>' + i + '</td>');
                        tr.append('<td>' + item.fullName + '</td>');
                        tr.append('<td>' + item.userName + '</td>');
                        tr.append('<td>' + item.email + '</td>');

                        $("#tbuser tbody").append(tr);
                        i++;

                    });
                }

            }
        });
    }
});