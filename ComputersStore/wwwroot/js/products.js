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