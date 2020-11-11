function enableImageInputOnSelectChange(selectBox) {
    if (selectBox.value === "true") {
        document.getElementById("NewImageFile").disabled = false;
    } else {
        document.getElementById("NewImageFile").disabled = true;
    }
}

function submitProductsSortingForm() {
    $(".productsSortingForm").submit();
}