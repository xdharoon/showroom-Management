$(document).ready(function () {

    loadData()
});


//----------- Loaad Fata Form API 
function loadData() {
    $.ajax({

        url: APIURLS.department_GetDepartment,
        type: 'GET',
        data: null,
        success: function (resp) {
            var data = JSON.parse(resp)

            for (let item of data.Response) {
                $('#example1 tbody').append(`

         <tr> 
         <td>${item.Name}</td>
         <td>${item.Description}</td>
         </tr>               
`);
            }
            
                $(function () {
                    $("#example1").DataTable({
                        "responsive": true, "lengthChange": false, "autoWidth": false,
                        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
                    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
          
        });
           
        }

    });
}