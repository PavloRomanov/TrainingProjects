function validateLogin() {
    var log = document.getElementById("Login").value;

    if (!log.lenght == "") {
        pattern = /^[A-Za-z0-9_]{3,8}$/;

        if (!pattern.test(log)) {
            document.getElementById("span1").innerText = "Login contains only alphabets and numbers no special characters except underscore('_') min 3 and max 8 characters. ";
        } else {
            document.getElementById("span1").innerText = "";
        }        
    }    
}

function validatePassword() {
    var pass = document.getElementById("Password").value;
    var errors = [];
    errors.push("Your password must ");

    if (pass.length < 3) {
        errors.push("be at least 3 characters");
    }
    if (pass.search(/[a-z]/i) < 0) {
        errors.push("contain at least one letter.");
    }
    if (pass.search(/[0-9]/) < 0) {
        errors.push("contain at least one digit.");
    }
    if (errors.length > 0) {
        document.getElementById("span2").innerText = errors.join(" ");
        return false;
    }
    return true;
}

function comparePassword() {

}

