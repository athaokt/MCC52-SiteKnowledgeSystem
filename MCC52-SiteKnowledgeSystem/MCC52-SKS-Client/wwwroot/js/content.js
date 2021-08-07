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
                data: "contentTitle"
            },
            {
                data: "contentDate",
                render: function (data, type, row, meta) {
                    tanggal = new Date(data).toLocaleDateString();
                    return tanggal;
                }
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
                    btn += '<a href="content/detail/?contentId=' + data + '" class="btn btn-outline-primary btn-sm btn-clean btn-icon" data-id="' + data + '">Open</a>';
                    
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
    let today = new Date();

    let dd = today.getDate();
    let mm = today.getMonth() + 1;
    let yyyy = today.getFullYear();

    let date = yyyy +"-"+ mm +"-"+ dd;

    obj.ContentTitle = $('#title').val();
    obj.ContentText = $('#message').val();
    obj.ContentDate = date;
    obj.ViewCounter = 0;
    obj.CategoryId = parseInt($('#category').val());

    $.ajax({
        url: "https://localhost:44393/content/insertcontent",
        type: "post",
        data: obj,
    }).done((result) => {
        Swal.fire(
            'Berhasil menambah konten',
            'Konten sudah di publish'
        )
        $('#contents').DataTable().ajax.reload()
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Gagal',
            text: 'Data gagal ditambah'
        })
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