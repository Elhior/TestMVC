function autoFocus(modal, field) {
    $(modal).on('shown.bs.modal', function () {
        $(field).focus();
    });
}

function validate(validatedField) {
    var validLogin = document.getElementById(vLogin);
    var validEmail = document.getElementById(vEmail);
    if (validLogin.checkValidity() == false) {
        alert('Login must be 5-25 characters.');
        return false;
    }
    if (validEmail.checkValidity() == true) {
        return true;
    }
    else {
        alert('Invalid email.');
        return false;
    }
}

function uniquenessValidation(validatedField) {
    var validatedValue = document.getElementById(validatedField).value;

    $.ajax({
        type: "GET",
        url: "/User/UniquenessValidation?validatedValue=" + validatedValue,
        dataType: "json",
        success: function (response) {
            if (response == false)
                document.getElementById(validatedField + "_validation_message").innerHTML = "Already exists!";
            else
                document.getElementById(validatedField + "_validation_message").innerHTML = "Free.";
        }
    });
}

function addUser() {
    var login = $("#login").val();
    var firstName = $("#first-name").val();
    var lastName = $("#last-name").val();
    var phoneNumber = $("#phone-number").val();
    var email = $("#email").val();
    var address = $("#home-address").val();
    var password = $("#password").val();

    var person = {
        Login: login,
        FirstName: firstName,
        LastName: lastName,
        Phone: phoneNumber,
        Email: email,
        Address: address,
        Password: password
    };

    $.ajax({
        type: "POST",
        url: "/User/AddUsers",
        data: person,
        dataType: "json",
        success: function (msg) {
            if (msg.isValid == true && msg.isUnique == true) {
                $('#AddUserWindow').modal('toggle');
                alert("Added successful.");
                location.reload();
            }
            if (msg.isValid == false) {
                if (msg.LoginException != null)
                    document.getElementById("login_validation_message").innerHTML = msg.LoginException;
                if (msg.EmailException != null)
                    document.getElementById("email_validation_message").innerHTML = msg.EmailException;
                if (msg.PasswordException != null)
                    document.getElementById("password_validation_message").innerHTML = msg.PasswordException;
            }
            if (msg.isUnique == false) {
                alert("User with such login or email already exists.");
            }
        },
        error: function (msg) {
        }
    });
}

function removeUser() {
    $.ajax({
        type: "POST",
        url: "/User/RemoveUser",
        data: { login: $("#login_remove").val(), pasword: $("#password_remove").val() },
        success: function (msg) {
            if (msg == "Removed.") {
                $('#RemoveUserWindow').modal('toggle');
                location.reload();
            }
            alert(msg);
        },
        error: function (msg) {
        }
    });
}

function editUser(id) {
    $('#EditUserWindow').modal('show');
    autoFocus('#EditUserWindow', '#edit_login');
    document.getElementById("edit_header").innerHTML = "Edit ID:" + id;

    $.ajax({
        type: "GET",
        url: "/User/GetUser?id=" + id,
        dataType: "json",

        success: function (response) {
            $("#edit_login").val(response.Login);
            $("#edit_first_name").val(response.FirstName);
            $("#edit_last_name").val(response.LastName);
            $("#edit_phone_number").val(response.Phone);
            $("#edit_email").val(response.Email);
            $("#edit_home_address").val(response.Address);
        }
    });
}

function updateUser() {
    var id = document.getElementById("edit_header").innerHTML.split(':')[1];
    var login = $("#edit_login").val();
    var firstName = $("#edit_first_name").val();
    var lastName = $("#edit_last_name").val();
    var phoneNumber = $("#edit_phone_number").val();
    var email = $("#edit_email").val();
    var address = $("#edit_home_address").val();
    var password = $("#edit_password").val();

    var person = {
        ID: id,
        Login: login,
        FirstName: firstName,
        LastName: lastName,
        Phone: phoneNumber,
        Email: email,
        Address: address,
        Password: password
    };
    $.ajax({
        type: "POST",
        url: "/User/UpdateUsers",
        data: person,
        success: function (msg) {
            if (msg == "Updated.") {
                $('#EditUserWindow').modal('toggle');
                alert(msg);
                location.reload();
            }
            alert(msg);
        },
        error: function (msg) {
            alert(msg);
        }
    });
}

