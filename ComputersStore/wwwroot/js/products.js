function enableImageInputOnSelectChange(selectBox) {
    if (selectBox.value === "true") {
        document.getElementById("imageInput").disabled = false;
    } else {
        document.getElementById("imageInput").disabled = true;
    }
}