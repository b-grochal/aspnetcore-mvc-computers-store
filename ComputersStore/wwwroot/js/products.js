$(function () {
    let modalPlaceholder = $('#modalPlaceholder');
    var test = $('[data-toggle="ajax-modal"]');
    $('.modalButton').click(function (event) {
        const url = $(this).data('url');
        $.get(url).done(function (data) {
            modalPlaceholder.html(data);
            modalPlaceholder.find('.modal').modal('show');
        })
    })

    modalPlaceholder.on('click', '[data-save="modal"]', function (event) {
        const form = $(this).parents('.modal').find('form');
        const type = $(this).parents('.modal');
        const actionUrl = form.attr('action');
        const formData = form.serialize();
        $.post(actionUrl, formData).done(function (data) {
            modalPlaceholder.find('.modal').modal('hide');
        })
    })
})

function enableImageInputOnSelectChange(selectBox) {
    if (selectBox.value === "true") {
        document.getElementById("ImageFile").disabled = false;
    } else {
        document.getElementById("ImageFile").disabled = true;
    }
}

function submitProductsSortingForm() {
    $(".productsSortingForm").submit();
}