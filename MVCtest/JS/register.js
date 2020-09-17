function Submit(){
    var user=document.getElementsByName("user");
    var password=document.getElementsByName("pass");
    var passAgain=document.getElementsByName("passAgain");

    if(password[0].value!=""&&passAgain[0].value!=""&&user[0].value!="")
    {
    if(password[0].value==passAgain[0].value)
    {
        localStorage.clear();

        localStorage.setItem("user",JSON.stringify(user));  
        localStorage.setItem("password",password);
       // localStorage.setItem("password",JSON.stringify(password)); 
        var getEmail = JSON.parse(localStorage.getItem("user"));
        var getPass = localStorage.getItem("password");
    //var getPass = JSON.parse(localStorage.getItem("password"));
    //console.log(getEmail);
    //console.log( getPass);
        location.href="registe.cshtml";
        alert("注册成功!");
    }
    else
        alert("后两次密码输入不一致!请重新注册");
    }
    else
    {
        alert("用户名或密码不能为空")
}
}



