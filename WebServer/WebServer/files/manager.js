function FormIsValidManager() {
    var elements = document.getElementsByTagName("input");

    var inputs = [];

    for (i = 0; i < elements.length; i++) {
        if (elements[i].getAttribute("required") != null)
            inputs.unshift(elements[i]);
    }
    var error = true;
    if (inputs.length > 0) {
        for (i = 0; i < inputs.length; i++) {
            if (inputs[i].value == null || inputs[i].value == "")
            {
                var inputName = inputs[i].getAttribute("name");
                inputs[i].setAttribute("class", "error");
                document.getElementById("for" + inputName).innerHTML = "This input is required";
                error = false;
            }
        }
    }
    return error;
}

window.onload =  function Error ()
{
  document.getElementById("error").style.border = "1px solid red;";
}
