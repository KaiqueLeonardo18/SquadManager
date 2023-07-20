$('form').on('submit', function (event) {
    event.preventDefault();

    var formData = {
        email: $("#email").val(),
        password: $("#password").val(),
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=UTF-8",
        data: JSON.stringify(formData),
        url: "https://localhost:7229/api/user",
        success: function (result) {
            if (result.response == 'OK')
                alert("Logado")
            else
                alert("Credenciais inválidas")
        },
        error: function (error) {
            console.log(error);
        }
    })
});


//function login(event) {
//    event.preventDefault();

//    var formData = {
//        email: $("#email").val(),
//        password: $("#password").val()
//    }

//    $.ajax({
//        type: "POST",
//        dataType: "json",
//        contentType: "application/json; charset=UTF-8",
//        data: JSON.stringify(formData),
//        url: "https://localhost:7229/api/user",
//        sucess: function (result) {

//        },
//        error: function (error) {

//        }
//    })
//}