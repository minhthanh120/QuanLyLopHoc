// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function chatwith(elem) {
    var id = $(elem).attr("id");
    console.log(id);
    $("#messageloading").show();
    $.ajax({
        type: "GET",
        url: "PartialChatting",
        dataType: "html",
        data: userId = "userId="+id,
        success: function (data) {
            $('#PartialChatting').empty();
            $('#PartialChatting').html(data);
        }
    });
}