<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wapPayProduct.aspx.cs" Inherits="b2cPay64.pay.wapPay.wapPayProduct" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
</head>
<body>
<FORM name=order action=https://mywap2.icbc.com.cn/ICBCWAPBank/servlet/ICBCWAPEBizServlet method=post>
<INPUT type=text value="<%=merSignMsg%>" name=merSignMsg>
<INPUT type=submit value=" 提 交 订 单 ">&nbsp;
<INPUT type=text value="<%=interfaceVersion%>" name=interfaceVersion> 
<INPUT type=text value="<%=interfaceName%>" name=interfaceName> 
<INPUT type=text value="<%=tranData%>" name=tranData>
<INPUT type=text value="<%=merCert%>" name=merCert>
<INPUT type=text value="<%=clientType%>" name=clientType>
</form>
</body>
</html>
