function resetOrdersFilteringForm(e) {
    e.preventDefault();
    document.getElementById("OrderId").value = null;
    document.getElementById("OrderStatusId").value = null;
    document.getElementById("PaymentTypeId").value = null;
    document.getElementById("ApplicationUserEmail").value = "";
}