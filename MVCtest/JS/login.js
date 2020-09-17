
function loginSubmit(){
    /*var user=$("#user").val();
    var password=$("#pass").val();
    var infor={
        'myUser':user,
        'myPass':password
    }
    alert(infor);
    alert(user,password);
    $.ajax({
        type:"POST",
        url:"login.php",
        data:infor,
        dataType:"json",
        success:function(msg)
        {
         alert(msg.user);
        },
        error:function()
        {
            alert("请求？？？");
        }
    });*/
    var user=document.getElementsByName("user");
    var password=document.getElementsByName("pass");
    /*$.ajax(
        {
            
            type:'POST',
            url:'login.php',
            dataType:'json',
            data:{
            myUser:user[0].value,
            myPass:password[0].value
            },
            success:function(res)
            {
                console.log(res);
                alert(res);
            },
            error:function()
            {
                alert("请求失败");
            }
        });*/
    $.ajax({
            cache:false,
            type:"GET",
            url:'log.php?id=1&num=8',
           /* data:{
                myUser:$('#user')[0].value,
                myPass:$('#pass')[0].value
                },*/
            success:function(res)
            {
                alert("后台成功"+res);
                console.log(res);
                if(res=="8")
                {
                    alert("革命成功");
                }
                else
                {
                    alert("失败")
                }
                //location.href="shop.html";
            },
            error:function()
            {
                alert("请求失败");
            }
            
        });
        console.log("hello");
        //alert($('#user')[0].value);
    /*if(password[0].value!=""&&user[0].value!="")
    {
        //location.href="shop.html";
        alert("登录成功!");
    }
    else
    {
        alert("用户名或密码不能为空");
}*/
   return false;
}

function registSubmit(){

        location.href="register.html";
        alert("欢迎来到桃饱购物!");


}

/*var user=document.getElementsByName("user");
var password=document.getElementsByName("pass");
var $btns=$('button');
$btns.eq(0).click(function(){
    console.log(user[0].value);
$.ajax(
    {
        type:'post',
        url:'login.php',
        dataType:'json',
        data:{
        myUser:user[0].value,
        myPass:password[0].value
        },
        success:function(res)
        {
            console.log(res);
        }
    });

});*/