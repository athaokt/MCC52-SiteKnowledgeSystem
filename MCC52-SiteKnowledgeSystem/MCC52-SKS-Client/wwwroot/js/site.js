$.ajax({
    url: "/Content/viewcontent/",
    type: "GET"
}).done((result) => {
    text = "";

    $.each(result, function (key, val) {
        text += `<div class="post">
                                            <div class="user-block">
                                                <img class="img-circle img-bordered-sm" src="../../dist/img/user1-128x128.jpg" alt="user image">
                                                <span class="username">${val.contentTitle}</span>
                                                <span class="description">${val.contentDate}</span>
                                                <span class="description">${val.fullName}</span>
                                            </div>
                                            <!-- /.user-block -->
                                            <p>
                                                ${val.contentText}
                                            </p>

                                            <input class="form-control form-control-sm" type="text" placeholder="Type a comment">
                                        </div>`;
    });
    console.log(result);
    $("#activity").html(text);
}).fail((error) => {
    console.log(error);
});