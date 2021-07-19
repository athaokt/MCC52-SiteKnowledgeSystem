$(document).ready(function () {
    $('#contents').DataTable({
        
        'ajax': {
            url: "employee/viewregistered",
            dataType: "json",
            dataSrc: ""
        },

        'columns': [
            {
                "data": "employeeId"
            },

            {
                "data": "fullName"
            },
            {
                "data": "email"
            },
                        
            {
                "data": "username"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    if (row["gender"] == 1) {
                        return "Pria";
                    } else {
                        return "Wanita";
                    }
                }
            },
            {
                "data": "siteName"
            },
            {
                "data": "roleName"
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return '<button class="btn btn-sm btn-primary edit"  data-id="' + row['employeeId'] + '" data-toggle="modal" data-target="#edit"><i class="fa fa-pencil-alt"></i> Edit</button>' + " " +
                        '<button class="btn btn-sm btn-danger hapus"  data-id="' + row['employeeId'] + '" data-toggle="modal" data-target="#hapus"><i class="fa fa-trash-alt"></i> Delete</button>';
                },
                searchable: false,
                orderable: false
            }
        ]
    });
});

const swalWithBootstrapButtons = Swal.mixin({
  customClass: {
    confirmButton: 'btn btn-success',
    cancelButton: 'btn btn-danger'
  },
  buttonsStyling: false
})

$(document).on("click", ".hapus", function () {
    var employeeId = $(this).data('id');

    swalWithBootstrapButtons.fire({
        title: 'Apakah anda ingin menghapus data ini?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Hapus',
        cancelButtonText: 'Batal',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Employee/Delete/" + employeeId,
                type: "DELETE"
            }).done((result) => {
                swalWithBootstrapButtons.fire(
                    'Berhasil terhapus!',
                    'Data sudah dihapus',
                    'success'
                )
                window.open("employee")
            })
        }
    })
})

function Insert() {
    let obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.EmployeeId = $("#employeeId").val();
    obj.FullName = $("#fullName").val();
    obj.Username = $("#username").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.PhoneNumber = $("#phoneNumber").val();
    obj.Gender = parseInt($("#gender").val());
    obj.SiteId = parseInt($("#siteName").val());
    const myJSON = JSON.stringify(obj);

    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44365/api/employees/register",
        type: "POST",
        contentType: "application/json",
        data: myJSON
    }).done((result) => {
        Swal.fire(
            'Data berhasil Ditambah!',
            'success'
        )
        window.location = "employee";
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        alert("Gagal menambah data");;
    })
}