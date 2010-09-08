/**--------------------------
//* Validate Date Field script- By JavaScriptKit.com
//* For this script and 100s more, visit http://www.javascriptkit.com
//* This notice must stay intact for usage
---------------------------**/
var errorMessage = ''; //Các trường

function checkEmail(email) 
{
    // string pattern = @"^[a-z|A-Z][a-z|A-Z|0-9|]*\@[a-z|A-Z][a-z|A-Z|0-9|]*\.[a-z|A-Z][a-z|A-Z|0-9]*$";
    var isValidEmail = true;
    //var filter = /^[a-zA-Z0-9]+@[a-zA-Z0-9]+(.com|.mil|.org|.net)$/;
    var filter = /^[a-zA-Z][a-zA-Z0-9_.-]*@[a-zA-Z][a-zA-Z0-9_.-]*.([a-zA-Z][a-zA-Z0-9_.-]*)$/;
    if(!filter.test(email))
    {
        isValidEmail = false;
    }
    return isValidEmail;
}  
function isValidURL(url) {
    var isValidURL = true;
    if(url != '')
    {
	    var urlRegxp = /^(http:\/\/www.|https:\/\/www.|ftp:\/\/www.|www.){1}([\w]+)(.[\w]+){1,2}$/;
	    if (urlRegxp.test(url) != true) {
		    isValidURL = false;
	    } 
	}
	return isValidURL;
}
function isMyNumber(input)
{
    var isNumber = true;
    if(input != '')
    {
        if(isNaN(input))
        {
            isNumber = false;
        }
    }
    return isNumber;
}
function setErrorMessage(errorStr)
{
    if(errorMessage == '')
    {
        errorMessage = '- '+errorStr;
    }
    else
    {
        //errorMessage = errorMessage + '\n' + errorStr; //use for alert
        errorMessage =  errorMessage + '<br />' + '- '+ errorStr; // use for display in page
    }
}
function checkValidData()
{
    errorMessage = '';
    var isValidData = true;
    var passWord = document.getElementById("txtPassword");
    var passWordRepeat = document.getElementById("txtConfirmPassword");
    var fullName = document.getElementById("txtFullName");
    var email = document.getElementById("txtEmail");
    var telephoneNo = document.getElementById("txtTelephoneNo");
    var urlWebSite = document.getElementById("txtDiaChiWeb");
    if(passWord.value == '' || passWordRepeat.value == '' || fullName.value == '' || email.value == '')
    {
        setErrorMessage('Các trường có dấu (*) bắt buộc phải nhập');
        isValidData = false;
    }
    else
    {
        if(passWord.value != '')
        {
            if(passWord.value.length < 6)
            {
                setErrorMessage('Mật khẩu phải ít nhất 6 ký tự');
                isValidData = false;
            }
            if(passWord.value != passWordRepeat.value)
            {
                setErrorMessage('Mật khẩu và lặp lại mật khẩu không giống nhau');
                isValidData = false;
            }
           
            if(!checkEmail(email.value))
            {
                setErrorMessage('Địa chỉ email không hợp lệ');
                isValidData = false;
            }
           
            if(telephoneNo.value != '')
            {
                if(!isMyNumber(telephoneNo.value))
                {
                    setErrorMessage('Số điện thoại phải là số');
                    isValidData = false;
                }
                else
                {
                    if(telephoneNo.value.length < 6)
                    {
                        setErrorMessage('Số điện thoại phải có ít nhất 6 số');
                        isValidData = false;
                    }
                }
            }
            if(!isValidURL(urlWebSite.value))
            {
                setErrorMessage('Địa chỉ website không hợp lệ(định dạng : http://www.tenwebsite.tenmien)');
                isValidData = false;
            }
            
        }
    }
    if(isValidData == false)
    {
        if(errorMessage != '')
        {
            //alert(errorMessage);
            var divErrorMessage = document.getElementById("divError");
            divErrorMessage.innerHTML = "";
            divErrorMessage.innerHTML = errorMessage;
        }
    }
    //else
    //{
        //if(!checkBoxAgreeTerm.checked)
        //{
        //    setErrorMessage('Bạn phải kích chọn checkbox Tôi đồng ý..');
        //    isValidData = false;
        //}
    //}
    return isValidData;
}

