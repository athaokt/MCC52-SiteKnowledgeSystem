$(document).ready(function () {
    $('#contents').DataTable({
        
        'ajax': {
            url: "Content/viewcontent",
            dataType: "json",
            dataSrc: ""
        },

        'columns': [
            {
                "data": "categoryName"
            },

            {
                data: "contentTitle",
                render: function (data, type, row, meta) {
                    return data = '<a href="">' + data + '</a>';
                }
            },
            {
                "data": "contentDate"
            },                        
            {
                "data": "fullName"
            },
            {
                "data": "contentId"
            }

        ],
        columnDefs: [
            
            {
                targets: -1,
                responsivePriority: 1,
                searchable: false,
                orderable: false,
                width: '75px',
                render: function (data, type, full, meta) {
                    var btn = "";
                    btn += '<a href="content/' + data + '" class="btn btn-sm btn-clean btn-icon" data-id="' + data + '"><i class="nav-icon fas fa-tachometer-alt"></i></a>';
                    
                    return (
                        btn
                    );
                },
            },
        ]
    });
});

$(document).on("click", ".open", function () {
    var nik = $(this).data('id');
    $.ajax({
        url: "/content/viewcontent/" + nik
    }).done((result) => {
        //console.log(result);
        text = "";
        no = 1;
        $.each(result, function (key, val) {
            $("#judulD").html("Detail " + val.firstName + " " + val.lastName);
            $("#nikD").html(val.nik);
            $("#nameD").html(val.firstName + " " + val.lastName);
            $("#emailD").html(val.email);
            $("#salaryD").html(formatRupiah('' + val.salary, ''));
            $("#phoneD").html(formatTelfon(val.phoneNumber, ""));
            $("#dateD").html(val.birthDate);
            $("#genderD").html((val.gender == 0) ? "Laki-Laki" : "Perempuan");
            $("#roleD").html(val.roleName);
            $("#degreeD").html(val.degree);
            $("#gpaD").html(val.gpa);
            $("#title").html(val.contentTitle);
        })
    }).fail((error) => {
        console.log(error);
    });
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