(function () {
    var username = getCookie('userName');
    var profPicSrc = getCookie('profpic');
    var userId = getCookie('userid');
    var name = getCookie('name');
    var surname = getCookie('surname');

    console.log(username)

    document.getElementById('profile_picture').src = profPicSrc;
    document.getElementById('profile_username').value = username;
    document.getElementById('name').value = name
    document.getElementById('surname').value = surname

})();

function updateUserClick() {

    var password = document.getElementById('password').value;
    var confirmpassword = document.getElementById('confirmpassword').value;

    if (password == confirmpassword) {

        var userId = getCookie('userid');
        var nameEdited = document.getElementById('name').value;
        var usernameEdited = document.getElementById('profile_username').value;
        var surnameEdited = document.getElementById('surname').value;
        var passwordEdited = document.getElementById('profile_password').value;
        var profPicSrc = document.getElementById('profile_picture').src;

        var user = { Id: userId, UserName: usernameEdited, Name: nameEdited, SurName: surnameEdited, Password: passwordEdited, ProfilePicture: profPicSrc };

        $.ajax({
            url: "http://localhost:11909/api/Users/Register",
            type: "POST",
            data: user,
            dataType: "application/json",
            success: function () {
                alert('success');
            },
            error: function (data) {
                alert(data.statusText);
            }
        });

    }
    else {
        alert('Passwords does not meet.');
    }
}

function userNameExistsAction() {
    var usernameEdited = document.getElementById('profile_username').value;
    var url = "http://localhost:11909/api/Users/UserNameExists?username=" + usernameEdited;
    $.getJSON(url, {
        tags: "mount rainier",
        tagmode: "any",
        format: "application/json"
    })
       .error(function (data) {
           if (data.status == 404) {
               var usernameExistsDiv = document.getElementById('profile_username_exists');
               usernameExistsDiv.innerText = 'Username is available.';
           }
       })
           .done(function (data) {
               var usernameExistsDiv = document.getElementById('profile_username_exists');
               usernameExistsDiv.innerText = 'Username exists.';
           });

}