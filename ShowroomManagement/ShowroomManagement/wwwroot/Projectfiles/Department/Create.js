
$(document).ready(function () {

    alert()
});

function validatecontrols() {

   var  isEmpty = false;
    var name = $('#txtName').val();


    if (name == '' || name == null) {
        isEmpty = true
        $('#spErrName').text("This is a Required field");
      
    }

}
$('#txtName').on('change', function () {
    var val = $(this).val();

    if (val == '' || val == null) {
        $('#spErrName').text("This is a Required field");
    }
    else {
        $('#spErrName').empty();
    }

});
$('#btnSubmit').on('click', function () {

    if (!validatecontrols()) {

        var name = $('#txtName').val();
        var description = $('#txtDescription').val();


        var obj = {

            name: name,
            description: description

        };

        $.ajax({
            url: APIURLS.department_AddDepatment,
            data: JSON.stringify(obj),
            contentType:"application/json",
            type: 'POST',
            success: function (resp) {
                console.log(resp)

            }
        });

    }

});