function resetNewslettersFilteringForm(e) {
    e.preventDefault();
    document.getElementById("NewsletterId").value = null;
    document.getElementById("NewsletterEmail").value = "";
}