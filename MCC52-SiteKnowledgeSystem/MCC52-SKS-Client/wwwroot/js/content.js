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
                    btn += '<a href="content/detail/?contentId=' + data + '" class="btn btn-sm btn-clean btn-icon" data-id="' + data + '"><i class="nav-icon fas fa-tachometer-alt"></i></a>';
                    
                    return (
                        btn
                    );
                },
            },
        ]
    });
});


function InsertContent() {

    let obj = new Object();
    var waktu = new Date();
    obj.ContentTitle = $('#title').val();
    obj.ContentText = $('#message').val();
    obj.ContenttDate = formatDate(waktu);
    obj.ViewCounter = 0;
    obj.CategoryId = parseInt($('#category').val());

    $.ajax({
        url: "https://localhost:44393/content/insertcontent",
        type: "post",
        data: obj,
    }).done((result) => {
        Swal.fire(
            'Data berhasil Ditambah!',
            'success'
        )
        $('#contents').DataTable().ajax.reload()
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