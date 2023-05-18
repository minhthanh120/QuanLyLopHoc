$(document).ready(function () {
    $("#loading").hide();
    $("#messageloading").show();
    $("#search").keyup(function () {
        $("#loading").show();
        if ($(this).val().length > 2) {
            $.ajax({
                type: "POST",
                url: "/User/SearchbyNameandEmail",
                data: { searchKey: $(this).val() },
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

function whensearch() {
    users = document.getElementById("users");
    users.classList.add("hidden");
    result = document.getElementById("result");
    result.classList.remove("hidden");
    backbutton = document.getElementById("back");
    backbutton.classList.remove("hidden");
}
function stopsearch() {
    users = document.getElementById("users");
    users.classList.remove("hidden");
    result = document.getElementById("result");
    result.classList.add("hidden");
    backbutton = document.getElementById("back");
    backbutton.classList.add("hidden");
}