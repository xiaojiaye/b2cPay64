<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signContract.aspx.cs" Inherits="b2cPay64.pay.signContract.signContract" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>个人签约页面</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>

</head>
<body>
<%--<FORM name=order action=https://b2c.icbc.com.cn/servlet/ICBCINBSEBusinessServlet method=post>--%>
<%--<FORM name=order action=https://122.19.141.83/servlet/EBConsignPayServlet method=post>--%>
<FORM name=order action=https://b2c3.dccnet.com.cn/servlet/EBConsignPayServlet method=post>
<%--<FORM name=order action=https://mybank3.dccnet.com.cn/servlet/ICBCINBSEBusinessServlet method=post>--%>
<%--<FORM name=order action=https://mywap2.dccnet.com.cn:447/ICBCWAPBank/servlet/ICBCWAPEBizServlet method=post>--%>
<INPUT type=text value="<%=merSignMsg%>" name=merSignMsg>

<%--<input type=text value="<%=certData%>" name=certData>--%>
<%--<input type=text value="<%=certData%>" name=certData>--%>
<INPUT type=submit value=" 提 交 订 单 ">&nbsp;
<INPUT type=text value="<%=interfaceVersion%>" name=interfaceVersion> 
<INPUT type=text value="<%=interfaceName%>" name=interfaceName> 
<INPUT type=text value="<%=tranData%>" name=tranData>
<INPUT type=text value="<%=merCert%>" name=merCert>
</form>
	</body>
</html>
