function userValid() {
   // alert($("#FirstName").val());
    var fname = $.trim($("#FirstName").val()); // trim removes leading and trailing whitespace
    if (!fname) {
        $("#FirstNameLbl").text("enter your first name");
        return false;
    }
    var lname = $.trim($("#LastName").val()); // trim removes leading and trailing whitespace
    if (!lname) {
        alert($("#LastName").val());
        $("#LastNameLbl").text("enter your last name");
        return false;
    }

    return true;
}