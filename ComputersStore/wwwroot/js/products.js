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

function resetProductsFilteringForm(e) {
    e.preventDefault();
    document.getElementById("ProductName").value = "";
    document.getElementById("ProductCategoryId").selectedIndex = 0;
    document.getElementById("IsRecommended").selectedIndex = 0;
}