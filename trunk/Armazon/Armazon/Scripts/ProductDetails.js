$(function() {
    $('.commentExcced').slideUp();
    $('#formComments').hide();
    $('#commentJson').hide();
    $('#formComments').corner();
    $('#buyBlock').corner();
    $('.commentBlock').corner();
    $('#imglist li img').hover(function() {
        $('#PImg').attr("src", this.src);
    },
        function() {
        });
    $('#btnComment').click(comment);
});

function comment() {
    var commnet_text = $("#comment_text").val();
    var rating = $("input[name='commentRating']:checked").val();
    var productID = $("input[name='productID']").val();
    if (rating == null) {
        alert("Es necesario que asigne un puntaje!");
    } else {
        $('#linkAddCommnet').fadeOut();
        $('#formComments').fadeOut();
        $('#commentJson').append("<div style='width:100%;height:100%' align='center' id='ajax-loader'><img src='/Content/ajax-loader.gif'/></div>");
        $('#commentJson').addClass('commentBlock');
        $('#commentJson').corner();
        $('#commentJson').fadeIn();
        var url = "/Producto/AgregarComentario?productoID="+productID+"&rating="+rating+"&comentario="+commnet_text;
        $.getJSON(url, commented);
    }
}

function commented(json) {
    if (json != null) {
        $('#ajax-loader').hide();
        $('#commentJson').uncorner();
        $('#commentJson').append("<img src='/Content/comment.png' class='imageMiddle'/>");
        $('#commentJson').append("<span class='by'>Por <a href='#'>"+json.Username+"</a></span><br>");
        for (var i = 1; i < 6; i++){
            if (i == json.Rating){ 
                 $('#commentJson').append("<input name='starCommentXX' type='radio' class='star' disabled='disabled' checked='checked'/>");
            }else{ 
                 $('#commentJson').append("<input name='starCommentXX' type='radio' class='star' disabled='disabled'/>");
            }
        }
        $('input[name=starCommentXX]').rating();
        $('#commentJson').append("<br><br><span class='comment'>" + json.Comment + "</span>");
        $('#commentJson').corner();
        //setTimeout(function() {
        //    $('#commentJson').fadeIn();
        //}, 3000);
    }
}