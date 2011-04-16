using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public class Utility
{
    public Utility()
    {
    }
    public static bool CheckValidVNDate(string strInput)
    {
        //ValidationExpression="\d{2}\/\d{2}\/\d{4}"
        string pattern = @"^\d{2}\/\d{2}\/\d{4}$";
        Match match = Regex.Match(strInput, pattern, RegexOptions.IgnoreCase);
        if (match.Success) return true;
        else return false;
    }
    public static bool CheckEmailAddress(string strInput)
    {
        string pattern = @"^[a-z|A-Z]([a-z|A-Z|0-9|_|.|-])*\@[a-z|A-Z]([a-z|A-Z|0-9|_|.|-])*\.[a-z|A-Z]([a-z|A-Z|0-9])*$";
        Match match = Regex.Match(strInput, pattern, RegexOptions.IgnoreCase);
        if (match.Success) return true;
        else return false;
    }
    public static bool CheckUrlWebSite(string strInput)
    {
        //var urlRegxp = /^(http:\/\/www.|https:\/\/www.|ftp:\/\/www.|www.){1}([\w]+)(.[\w]+){1,2}$/;
        //string pattern = "^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
        string pattern = @"^(ht|f)tp\:\/\/www\.\w+\.\w+$";
        Match match = Regex.Match(strInput, pattern, RegexOptions.IgnoreCase);
        if (match.Success) return true;
        else return false;
    }
    public static bool IsNumber(string strInput)
    {
        bool isNumber = true;
        for (int i = 0; i < strInput.Length; i++)
        {
            if (!Char.IsNumber(strInput, i))
            {
                isNumber = false;
                break;
            }
        }
        return isNumber;
    }
    public static DateTime ConvertDDMMFormatToMMDDFormat(string ddMMFormat)
    {
        //Conver format dd/MM/yyyy to default format MM/dd/year to save into database
        DateTime dtMMDDFormat = DateTime.Now;
        try
        {
            char[] ch = { '/' };
            string[] strArrDDMMFormat = ddMMFormat.Split(ch);
            string day = strArrDDMMFormat[0].ToString();
            string month = strArrDDMMFormat[1].ToString();
            string year = strArrDDMMFormat[2].ToString();
            string defaultFormatDate = month + "/" + day + "/" + year;
            dtMMDDFormat = DateTime.Parse(defaultFormatDate);
        }
        catch
        {
            dtMMDDFormat = DateTime.Now;
        }
        return dtMMDDFormat;
    }
}
