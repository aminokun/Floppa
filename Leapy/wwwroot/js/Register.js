function validateForm() {
    var password = document.getElementsByName("password")[0].value;
    var confirmPassword = document.getElementsByName("confirmPassword")[0].value;
    if (password !== confirmPassword) {
        document.getElementById("password-match-message").style.display = "block";
        document.getElementById("password-match-message").innerHTML = "Passwords do not match";
        document.getElementById("password-match-message").classList.add("alert", "alert-danger");
        return false;
    }
    return true;
}