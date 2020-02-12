function userValid() {
    var FirstName, EmailId, emailExp, contact, contactExp;
    FirstName = document.getElementById("FirstName").value;
    EmailId = document.getElementById("Email").value;
    contact = document.getElementById("ContactNumber").value;
    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id  
    contactExp = /^[0-9]{10}$/;
    if ((FirstName=='')||(EmailId=='')||(contact==0)) {
        alert("Enter All Required Fields");
        return false;
    }
    if (FirstName == '') {
        alert("Please Enter First Name");
        return false;
    }
    
    if (contact == 0) {
        alert("Please Enter contact number");
        return false;
    }
    
    if (EmailId == '') {
        alert("Email Id Is Required");
        return false;
    }
    if (EmailId!= '') {
        if (!EmailId.match(emailExp))  
        {
            alert("Invalid Email Id");
            return false;
        }
    }
    if (contact != 0) {
        if (!contact.match(contactExp)) 
        {
            alert("Invalid contact number");
            return false;
        }
    }    
    return true;
} 
