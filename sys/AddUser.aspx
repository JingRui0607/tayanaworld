<%@ Page Title="" Language="C#" MasterPageFile="~/sys/RocketMaster.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="TayanaProject.sys.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMaster" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>新增帳號</h1>
    
    姓名<asp:TextBox ID="Addname" runat="server"  required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('記得打姓名ㄛ')"></asp:TextBox>
    <br>
    帳號<asp:TextBox ID="Addusername" runat="server" ClientIDMode="Static"  required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('記得打帳號ㄛ')" ></asp:TextBox>
    <input id="CheckUser" type="button" value="檢查帳號" /><span id="message" ></span>
   <br/>
    密碼<asp:TextBox ID="Addpassword"  runat="server" TextMode="Password" ClientIDMode="Static" required="" aria-required="true" oninput="setCustomValidity('');" oninvalid="setCustomValidity('記得打密碼ㄛ')" ></asp:TextBox>
    <br/>
    確認密碼<asp:TextBox ID="Addrepassword" TextMode="Password"  runat="server"   ClientIDMode="Static" oninput="check(this)"></asp:TextBox>
    <asp:Label ID="tishi" runat="server" Text="" ></asp:Label>
    <br/>
    信箱<asp:TextBox ID="Addmail" TextMode="Email" runat="server"></asp:TextBox>
    <br/>
    照片<asp:FileUpload ID="AddFileUpload" runat="server" />
    <asp:Label ID="Message" runat="server" Text="Label"></asp:Label>
    
    <br/>
    <asp:CheckBox ID="AllChecked" ClientIDMode="Static" runat="server" />全選
    <asp:CheckBoxList ID="Addpermission" runat="server" >
        <asp:ListItem Value="001" class="permission">使用者資訊</asp:ListItem>
        <asp:ListItem Value="002" class="permission">第二號權限</asp:ListItem>
        <asp:ListItem Value="003" class="permission">第三號權限</asp:ListItem>
        <asp:ListItem Value="004" class="permission">第四號權限</asp:ListItem>
        <asp:ListItem Value="005" class="permission">第五號權限</asp:ListItem>
       

    </asp:CheckBoxList>
    
    

    
    <asp:Button ID="Button2" runat="server" Text="確認送出" OnClick="Button2_Click"  />
    <input id="Reset1" type="reset" value="重新填寫" />
    <asp:Button ID="Button3" runat="server" Text="取消"  />
    
    
    
<script language='javascript' type='text/javascript'>

    //確認重複密碼是否一致

    //function validate() {

    //    var pwd1 = document.getElementById("Addpassword").value;

    //    var pwd2 = document.getElementById("Addrepassword").value;

 

   

    //    if (pwd1 == pwd2) {

    //        document.getElementById("tishi").innerHTML = "<font color='green'>確認密碼一致</font>";

    //        document.getElementById("button").disabled = false;

    //    }

    //    else {

    //        document.getElementById("tishi").innerHTML = "<font color='red'>確認密碼不一致</font>";

    //        document.getElementById("button").disabled = true;

    //    }

    //}


    //確認重複密碼是否一致
    
    function check(input) {
        if (input.value != document.getElementById('Addpassword').value) {
            input.setCustomValidity('Password Must be Matching.');
        } else {
            // input is valid -- reset the error message
            input.setCustomValidity('');
        }
    }
    //全選
    var all = document.querySelector('#AllChecked');
    var content = document.querySelectorAll('.permission')

    all.addEventListener("click",
        function() {
            if (all.checked == true) {
                for (let i = 0; i < content.length; i++) {
                    content[i].firstElementChild.checked = true;
                }

            } else if (all.checked == false) {
                for (let i = 0; i < content.length; i++) {
                    content[i].firstElementChild.checked = false;
                }
            }
        });


    //檢查帳號是否重複
    var checkbtn = document.getElementById("CheckUser");

    checkbtn.addEventListener("click",
        function () {
            var username = document.getElementById("Addusername").value;
            console.log(username);
            var xhr = new XMLHttpRequest();
            xhr.open("GET", 'https://localhost:44329/sys/checkusername.ashx?username=' + username);
            xhr.setRequestHeader("Accept", "application/text");
            xhr.send();

            xhr.onload = function () {
                console.log(xhr);
                var data = xhr.responseText;
                console.log(data);

                if (data == "這個帳號可以使用") {
                    console.log(document.getElementById("message").style.color);
                    document.getElementById("message").style.color = 'green';
                    let message = document.getElementById("message");
                    message.innerText = data;
                } else {
                    document.getElementById("message").style.color = 'red';
                    let message = document.getElementById("message");
                    message.innerText = data;
                }
            }

        });




</script>

    </asp:Content>
