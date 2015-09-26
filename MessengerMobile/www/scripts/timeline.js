(function () {
    var username = getCookie('userName');
    var profpicsrc=getCookie('profpic');
    console.log(username)
    document.getElementById('timeline_username').innerText = username;
    document.getElementById('timeline_picture').src = profpicsrc;
})();