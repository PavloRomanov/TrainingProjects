
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
            inputs.push(elements[i]);
    }

    var answer = true;
    if (inputs.length > 0) {
        for (i = 0; i < inputs.length; i++) {
            if (inputs[i].value == null || inputs[i].value == "") {
                var inputName = inputs[i].getAttribute("name");
                //inputs[i].setAttribute("style", "border: 1px solid red;");
                inputs[i].setAttribute("class", "error");
                document.getElementById("for" + inputName).innerHTML = "This input is required";
                answer = false;
            }
        }
    }
    return answer;
}

function InputIsValid(input) {

    var inputValue = input.value;
    var inputName = input.getAttribute("name");

    if (inputValue == null || inputValue == "") {
        input.setAttribute("class", "error");
        document.getElementById("for" + inputName).innerHTML = "This input is required";
    }
    else {
        input.removeAttribute("class");
        document.getElementById("for" + inputName).innerHTML = "";
    }
}






