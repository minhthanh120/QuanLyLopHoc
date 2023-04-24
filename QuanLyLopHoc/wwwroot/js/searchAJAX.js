$(document).ready(function () {
    $("#loading").hide();
    $("#messageloading").show();
    $("#search").keyup(function () {
        $("#loading").show();
        if ($(this).val().length > 4) {
            $.ajax({
                type: "POST",
                url: "/User/Search",
                data: { search: $(this).val() },
                datatype: "html",
                success: function (data) {
                    $("#loading").hide();
                    $('#result').empty();
                    $('#result').html(data);
                }
            });
        };
    });
});