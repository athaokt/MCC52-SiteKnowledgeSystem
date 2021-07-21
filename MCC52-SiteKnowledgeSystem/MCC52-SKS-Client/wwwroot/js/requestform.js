$.ajax({
    url: "requestform/viewrequest",
    type: "GET"
}).done((result) => {
    text = "";
    $.each(result, function (key, val) {
        text += `<div class="callout callout-danger">
                      <p>${val.message}</p>
                     <p>${val.requestDate}</p>
                        </div>`;
    });
    $("#request").html(text);
}).fail((error) => {
    console.log(error);
});

function Insert() {

    let dateObj = new Date();
    let month = dateObj.getUTCMonth() + 1; //months from 1-12
    let day = dateObj.getUTCDate();
    let year = dateObj.getUTCFullYear();

    newdate = year + "-" + month + "-" + day;
    let obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    //
    /*obj.Message = $("#message").val();
    obj.RequestDate = newdate;
    obj.EmployeeId = `@Context.Session.GetString("employeeId")`;
    const myJSON = JSON.stringify(obj);*/
    
    obj.Message = "tes";
    obj.RequestDate = "2021-12-12";
    obj.EmployeeId = "as";
    const myJSON = JSON.stringify(obj);

    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44365/API/RequestForms",
        type: "POST",
        contentType: "application/json",
        data: myJSON
    }).done((result) => {
        //buat alert pemberitahuan jika success
        alert("Data berhasil ditambahkan");
        window.location.href = "requestform";
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        alert("Gagal menambah data");;
    })
}

/*
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
}*/
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