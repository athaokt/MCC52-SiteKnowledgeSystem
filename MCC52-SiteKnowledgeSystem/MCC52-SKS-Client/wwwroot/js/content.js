﻿$(document).ready(function () {
    $('#contents').DataTable({
        
        'ajax': {
            url: "https://localhost:44365/API/contents/getalldata",
            dataType: "json",
            dataSrc: ""
        },

        'columns': [
            {
                "data": "categoryName"
            },

            {
                "data": "contentTitle"
            },
            {
                "data": "contentDate"
            },
                        
            {
                "data": "fullName"
            },

        ]
    });
});


$.ajax({
    url: "https://localhost:44365/API/categories"
}).done((result) => {
    text = "";
    $.each(result, function (key, val) {
        text +=
            `<ul class="nav nav-pills flex-column">
                                <li class="nav-item active">
                                    <a href="#" class="nav-link">
                                        ${val.categoryName}                                        
                                    </a>
                                </li>
                                `
    });
    $("#categories").html(text);
}).fail((error) => {
    console.log(error);
});

$.ajax({
    url: "https://localhost:44365/API/contents/getalldata"
}).done((result) => {
    text = "";
    $.each(result, function (key, val) {
        text +=
  `
                                  <tr>
                  
                 <td class="mailbox-star" id="id">${val.categoryName}</td>
                 <td class="mailbox-subject" id="text"><a href="">${val.contentTitle}</a></td>
                 <td class="mailbox-date" id="date">${val.contentDate}</td>
                 <td class="mailbox-date" id="date">${val.fullName}</td>
                </tr>
             </tbody>`
        
    });
    $("#table").html(text);
}).fail((error) => {
    console.log(error);
});

function detail(contentId) {
    $.ajax({
        url: "https://localhost:44365/API/Accounts/getdatalogin" + "contentId",
        success: function (result) {
            employeeId = result.EmployeeId;
            Insert(employeeId);
        }
    })

}

$(document).on("click", ".open", function () {
    var nik = $(this).data('id');
    $.ajax({
        url: "/Employee/GetRegistrasiView/" + nik
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
            $("#uniD").html(val.universityName);
        })
    }).fail((error) => {
        console.log(error);
    });
})


$.ajax({
    url: "https://localhost:44365/API/RequestForms/"
}).done((result) => {
    console.log(result);
}).fail((error) => {
    console.log(error);
});

function RequestForm() {
    $.ajax({
        url: "https://localhost:44365/API/Accounts/getdatalogin",
        success: function (result) {
            employeeId = result.EmployeeId;
            Insert(employeeId);
        }
    })

}


function Insert(employeeId) {
    let obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    
    obj.Message = $("#message").val();
    obj.RequestDate = new Date().toLocaleDateString();
    obj.EmployeeId = employeeId;
    
    const myJSON = JSON.stringify(obj);

    
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44393/API/RequestForms",
        type: "POST",
        contentType: "application/json",
            data: myJSON
}).done((result) => {
    //buat alert pemberitahuan jika success
    alert("Data berhasil ditambahkan");
    window.location.href = "ajax";
}).fail((error) => {
    //alert pemberitahuan jika gagal
    alert("Gagal menambah data");;
})
}
/*function Insert() {
    let obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.NIK = $("#nik").val();
    obj.FirstName = $("#firstName").val();
    obj.LastName = $("#lastName").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.Salary = parseInt($("#salary").val());
    obj.PhoneNumber = $("#phoneNumber").val();
    obj.Gender = parseInt($("#gender").val());
    obj.BirthDate = $("#birthDate").val();
    obj.UniversityId = parseInt($("#universities").val());
    obj.Degree = $("#degree").val();
    obj.GPA = $("#gpa").val();
    const myJSON = JSON.stringify(obj);


    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44368/API/Employees/Register",
        type: "POST",
        contentType: "application/json",
        data: myJSON
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil ditambahkan");
        window.location.href = "ajax";
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        alert("Gagal menambah data");;
    })
}*/