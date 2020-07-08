function deleteNewsletter(newsletterId) {
    $.ajax({
        type: "POST",
        url: "Newsletters/Delete",
        data: {
            id: newsletterId
        },
        success: function () {
            $('#modal-placeholder').find('.modal').modal('hide');
        }
    })
}