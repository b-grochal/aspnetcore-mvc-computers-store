function resetApplicationUsersFilteringForm(e) {
    e.preventDefault();
    document.getElementById("FirstName").value = "";
    document.getElementById("LastName").value = "";
    document.getElementById("Email").value = "";
    document.getElementById("PhoneNumber").value = "";
}