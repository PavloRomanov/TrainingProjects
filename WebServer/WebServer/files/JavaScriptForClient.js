
window.onload = function Func() {

    //document.getElementById("ppp").innerHTML = "It works!!!!";   
   
}

function writeText() {
    document.getElementById("ppp").innerHTML = "It works!!!!";
}

function FormIsValid() {
    var elements = document.getElementsByTagName("input");

    var inputs = [];

    for (i = 0; i < elements.length; i++) {
        if (elements[i].getAttribute("required") != null)
            inputs.unshift(elements[i]);
    }

    if (inputs.length > 0) {
        for (i = 0; i < inputs.length; i++) {
            if (inputs[i].value == null || inputs[i].value == "") {
                inputs[i].setAttribute("style", "border: 1px solid red;");
                // inputs[i].setAttribute("class", "error");
                //inputs[i].class = "error";

                document.getElementById("s" + (i + 1)).innerHTML = "This input is required";
            }
        }
        return false
    }
    return true;
}
/*
function btnClick() {
    //if (FormIsValid())
        document.form.submit(FormIsValid());
}
*/




    /*var case1 = false; case2 = false; case3 = false; case4 = false;
    var name = document.forms['form']['name'].value;
    var surname = document.forms['form']['surname'].value;
    var address = document.forms['form']['address'].value;
    var phone = document.forms['form']['phone'].value;

    if (name == null || name == '')
    {
        document.getElementById('1').innerHTML = 'Name must be filled out ';        
    }
    else
    {
        document.getElementById('1').innerHTML = "";
        case1 = true;
    }
    if (surname == null || surname == '')
    {
        document.getElementById('2').innerHTML = 'SurName must be filled out ';
    }
    else {
        document.getElementById('2').innerHTML = "";
        case2 = true;
    }
    if (address == null || address == '')
    {
        document.getElementById('3').innerHTML = 'Address must be filled out ';
    }
    else {
        document.getElementById('3').innerHTML = "";
        case3 = true;
    }
    if (phone == null || phone == '')
    {
        document.getElementById('4').innerHTML = 'Phone must be filled out ';
    }
    else {
        document.getElementById('4').innerHTML = "";
        case4 = true;
    }
    return (case1 && case2 && case3 && case4);*/

