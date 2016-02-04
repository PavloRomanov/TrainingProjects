function ValidateForm() {

    var name = document.forms['form']['name'].value;
    var surname = document.forms['form']['surname'].value;
    var address = document.forms['form']['address'].value;
    var phone = document.forms['form']['phone'].value;
    var login = document.forms['form']['login'].value;
    var password = document.forms['form']['password'].value;

    if (name == null || name == "")
    { document.getElementById('1').innerHTML = 'Name must be filled out '; }

    if (surname == null || surname == "")
    { document.getElementById('2').innerHTML = 'SurName must be filled out '; }

    if (address == null || address == "")
    { document.getElementById('3').innerHTML = 'Address must be filled out '; }

    if (phone == null || phone == "")
    { document.getElementById('4').innerHTML = 'Phone must be filled out '; }

    if (login == null || login == "")
    { document.getElementById('5').innerHTML = 'Login must be filled out '; }

    if (password == null || password == "")
    { document.getElementById('6').innerHTML = 'Password must be filled out '; }


 

}

