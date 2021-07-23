$.ajax({
    url: "requestform/viewrequest",
    type: "GET"
}).done((result) => {
    text = "";
    
    $.each(result, function (key, val) {
        tanggal = new Date(val.requestDate).toLocaleDateString();
        text += `<div class="callout callout-danger">
                      <p>${val.message}</p>
                     <p>${tanggal}</p>
                        </div>`;
    });
    $("#request").html(text);
}).fail((error) => {
    console.log(error);
});

function InsertForm() {

    let tanggal = new Date().toLocaleString();
    let obj = new Object();
    var waktu = new Date();
    obj.Message = $('#message').val();
    obj.RequestDate = formatDate(waktu);

    $.ajax({
        url: "https://localhost:44393/requestform/InsertRequest",
        type: "post",
        data: obj,
    }).done((result) => {
        Swal.fire({
            title: 'Data berhasil Ditambah!',
            text: 'success'
        }).then( function () {
            location.reload();
        })
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        console.log(error);
        //alert("Gagal menambah data");;
    })
}

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}