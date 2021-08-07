$.ajax({
    url: "/Content/viewcontent/",
    type: "GET"
}).done((result) => {
    text = "";

    $.each(result, function (key, val) {
        tanggal = new Date(val.contentDate).toLocaleDateString();
        text += `<div class="post">
                                            <div class="user-block">
                                                <img class="img-circle img-bordered-sm" src="../../dist/img/user1-128x128.jpg" alt="user image">
                                                <span class="username">
                                                <a href="content/detail/?contentId=${val.contentId}">${val.contentTitle}</a></span>
                                                <span class="description float-right">${tanggal}</span>
                                                <span class="description">${val.fullName}</span>
                                            </div>
                                            <!-- /.user-block -->
                                            <p>
                                                ${val.contentText}
                                            </p>
                                        </div>`;
    });
    console.log(result);
    $("#activity").html(text);
}).fail((error) => {
    console.log(error);
});