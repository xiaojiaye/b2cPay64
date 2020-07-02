using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2cPay64
{
    public partial class Icbc_Pay64 : System.Web.UI.Page
    {
        protected string orderDate = "", merSignMsg = "", merCert = "", interfaceName = "ICBC_PERBANK_B2C", interfaceVersion = "1.0.0.11";
        protected string tranData = "";
        protected string certData = "";
        private Encoding encoding = Encoding.GetEncoding(936);

        protected void Page_Load(object sender, EventArgs e)
        {
            //v_10014();
            //V_1007();
            //v_10011Product();
            // v_10011();
            v_1000();
            //v_B2B_验签();
            //v_10011_验签();
        }

        //private void wr()
        //{
        //    //https://b2c.icbc.com.cn/servlet/ICBCINBSEBusinessServlet  https://mybank3.dccnet.com.cn/servlet/ICBCINBSEBusinessServlet
        //    FileStream fs_返回 = new FileStream("D:/ty.txt", FileMode.Create, FileAccess.Write);
        //    StreamWriter sr_返回 = new StreamWriter(fs_返回, Encoding.GetEncoding(936));
        //    sr_返回.Write("ok");
        //    sr_返回.Flush();
        //    fs_返回.Close();
        //}

        //private void V_1007()
        //{
        //    interfaceVersion = "1.0.0.7";
        //    orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");

        //    //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;
        //    string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.7</interfaceVersion>";
        //    src = src + "<orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC20000846</merID><subOrderInfoList><subOrderInfo><orderid>" + orderDate + "</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007019200018155</merAcct><goodsID></goodsID><goodsName></goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
        //    src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://127.0.0.1/jsicbc/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
        //    ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
        //    int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "E:/各类资料/单位资料/海达/1872csb2c0202.crt", "E:/各类资料/单位资料/海达/1872csb2c0202.key", "12345678");
        //    //数字签名
        //    byte[] byte1 = encoding.GetBytes(src);
        //    tranData = Convert.ToBase64String(byte1, 0, byte1.Length);
        //    string merSignMsg1 = ICBC.signC(src, src.Length);
        //    merSignMsg = merSignMsg1;
        //    merCert = ICBC.getCert(1);
        //}

        //private void v_10014()
        //{
        //    interfaceVersion = "1.0.0.14";
        //    orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
        //    //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;localhost:1151
        //    string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.14</interfaceVersion>";
        //    src = src + "<orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC20000846</merID><subOrderInfoList><subOrderInfo><orderid>" + orderDate + "</orderid><amount>88</amount><installmentTimes>1</installmentTimes><merAcct>1901007019200018155</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>1</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
        //    src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language><HangSupportFlag>0</HangSupportFlag><HangTimeInterval></HangTimeInterval></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:2111</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://118.250.109.156/jsicbc/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
        //    //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507114052</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507114052</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
        //    //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507122252</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000602</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>快乐购订购</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>10.11.35.105</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php?app=balance&type=notify&bank_code=9010</merURL><merVAR></merVAR></message></B2CReq>";
        //    //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507144057</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507144057</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
        //    //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507143413</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000650</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>1</goodsID><goodsName>快乐购订购</goodsName><goodsNum>1</goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php</merURL><merVAR></merVAR></message></B2CReq>";
        //    //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>2011809076512300</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>账户自助充值</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>113.240.25.138</merReference><merCustomIp>试试</merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>湖南长沙</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://222.240.182.30/notity.php</merURL><merVAR>test</merVAR></message></B2CReq>";
        //    ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
        //    int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "E:/各类资料/单位资料/地球村/ty1105.crt", "E:/各类资料/单位资料/地球村/ty1105.key", "12345678");
        //    //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "H:/新建文件夹/key/CSWQTX.crt", "H:/新建文件夹/key/CSWQTX.key", "12345678");
        //    byte[] byte1 = encoding.GetBytes(src);
        //    int kk = src.Length;
        //    tranData = Convert.ToBase64String(byte1, 0, byte1.Length);
        //    string merSignMsg1 = ICBC.signC(src, src.Length);
        //    merSignMsg = merSignMsg1;
        //    merCert = ICBC.getCert(1);
        //}

        private void v_10011()
        {
            interfaceVersion = "1.0.0.11";
            orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;localhost:1151
            string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion>";
            src = src + "<orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC27254154</merID><subOrderInfoList><subOrderInfo><orderid>" + orderDate + "</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901018609100152155</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>1</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
            src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1599</merReference><merCustomIp></merCustomIp><goodsType>0</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://172.16.49.232:31021/bkg/icbc_pay_back.xhtml</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507114052</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507114052</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507122252</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000602</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>快乐购订购</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>10.11.35.105</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php?app=balance&type=notify&bank_code=9010</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507144057</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507144057</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507143413</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000650</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>1</goodsID><goodsName>快乐购订购</goodsName><goodsNum>1</goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>2011809076512300</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>账户自助充值</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>113.240.25.138</merReference><merCustomIp>试试</merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>湖南长沙</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://222.240.182.30/notity.php</merURL><merVAR>test</merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20130710103939</orderDate><curType>001</curType><merID>1901EC20000846</merID><subOrderInfoList><subOrderInfo><orderid>20130710103939</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901007019200018155</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>1</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1427</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://www.33229.cn/t_back.php</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "abcdefg";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();
            // ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
            //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "D:/baoqian/baoqian2020.crt", "D:/baoqian/baoqian2020.key", "12345678");
            //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "H:/新建文件夹/key/CSWQTX.crt", "H:/新建文件夹/key/CSWQTX.key", "12345678");

            //java的base64写法，很重要，指导客户的依据。
            //byte[] base64 = ReturnValue.base64enc(tranData.getBytes("GBK"));
            //tranDataBase64 = new String(base64);
            //tranData 就是字符串;
            merSignMsg = objIcbc.sign(src, "d:/b2cPay64/baoqian2020.key", "12345678");
            //merCert = "MIIDiDCCAnCgAwIBAgIKYULKEHrkAN04tzANBgkqhkiG9w0BAQsFADA2MR4wHAYDVQQDExVJQ0JDIENvcnBvcmF0ZSBTdWIgQ0ExFDASBgNVBAoTC2ljYmMuY29tLmNuMB4XDTE4MDMyMDA3MDg1MFoXDTE5MDMyMDA3MDg1MFowPzEYMBYGA1UEAwwPaG5zdzIwMTguZS4xOTAxMQ0wCwYDVQQLDAQxOTAxMRQwEgYDVQQKDAtpY2JjLmNvbS5jbjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAM6Xp5VUorPBZXpuks7bWolC5Bb/98jyOZIbTuP6NylGplGm64Xvqc4rwZRkjt70NguIZLi9jMCZWsmXOt1B/grOcKrt9rns/+WMmf1et6cCEtfQhA9P5JGuDjExc4Ezr/QRN7OkOIBlSDMLEJE84ir2hoZQYlZ1NZ5mYWERF2LKJQdPHQJ4DacAOr32xM5QUf78lRfYcd1LHhaeCqhk0n0+AV1Sj3n7mbnQFT/sP3/De0bJqetrqQLm7RSlrfSoDVrGTq+ZN5hyQcLNSqJsRgAn6NifznSa9Bja0L7RsitPV7OIxdY6ezSCYvjL5MOkWfqYvAsoeb9/V4k7qGs9Uq0CAwEAAaOBjjCBizAfBgNVHSMEGDAWgBT5yEXDU5MmNjGTL5QQ38hTPfZvnjBJBgNVHR8EQjBAMD6gPKA6pDgwNjEQMA4GA1UEAwwHY3JsMjkwMDEMMAoGA1UECwwDY3JsMRQwEgYDVQQKDAtpY2JjLmNvbS5jbjAdBgNVHQ4EFgQUTZYJYI4TXWyITM5RO/EIW3jdFZ8wDQYJKoZIhvcNAQELBQADggEBAD8g2K5cV8EhHq3WSRSZJDR9hiAML1wjFdmUeKHm/X0gyA9AFkGSVmp195GAXE7rMtPd0iqr5+95rXw7jDLEyNaNM6kgNFCwQHtAfADIdeTwLxaNxret+33xT4DqEMQ/DfZrazFSKfSAg6+WXoLYJDZuhPK0zLtsKlNO6dDva9gI64w/z7nwdY4ksomn79tn8/dcSbwwRl3THBtBmGW4V11Q5f7rTDN13+Qt7RZkLDqXyCdlLDd7GsTm4b4Q8RPaTKh5A12/ZwrN02HJHTn1kJSAFjVeIyW48gsfRvwW697MxfG/ZC86O6VPxaAjj0PhvOYhBI2Ar7DfbTiGRoEQvyU=";
            merCert = objIcbc.getPublicKey("d:/b2cPay64/baoqian2020.crt");
            tranData = objIcbc.base64enc(src);      

  
        }

        private void v_10011Product()
        {
            interfaceVersion = "1.0.0.11";
            orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            string merCustomIp = GetIP();
             
            string orderNO = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "11001100";
            //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;localhost:1151
            string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion>";
            src = src + "<orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EE21078015</merID><subOrderInfoList><subOrderInfo><orderid>" + orderNO + "</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901003219200017578</merAcct><goodsID>001</goodsID><goodsName>芬达矿泉水</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
            src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>0</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>三里屯465号</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://172.16.49.232:31021/bkg/icbc_pay_back.xhtml</merURL><merVAR>jk</merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507114052</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507114052</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507122252</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000602</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>快乐购订购</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>10.11.35.105</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php?app=balance&type=notify&bank_code=9010</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507144057</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>20110507144057</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>100</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp>118.129.236.111</merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://222.244.97.134/MyWeb/Default.aspx</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20110507143413</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>T201001280000000650</orderid><amount>100</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID>1</goodsID><goodsName>快乐购订购</goodsName><goodsNum>1</goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1151</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>1</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://10.11.35.105/hpo/index.php</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>" + orderDate + "</orderDate><curType>001</curType><merID>1901EC23766711</merID><subOrderInfoList><subOrderInfo><orderid>2011809076512300</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901007009200076130</merAcct><goodsID></goodsID><goodsName>账户自助充值</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>0</resultType><merReference>113.240.25.138</merReference><merCustomIp>试试</merCustomIp><goodsType>1</goodsType><merCustomID></merCustomID><merCustomPhone></merCustomPhone><goodsAddress>湖南长沙</goodsAddress><merOrderRemark></merOrderRemark><merHint></merHint><remark1></remark1><remark2></remark2><merURL>http://222.240.182.30/notity.php</merURL><merVAR>test</merVAR></message></B2CReq>";
            //src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion><orderInfo><orderDate>20130710103939</orderDate><curType>001</curType><merID>1901EC20000846</merID><subOrderInfoList><subOrderInfo><orderid>20130710103939</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901007019200018155</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>1</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo><custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1427</merReference><merCustomIp></merCustomIp><goodsType>1</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://www.33229.cn/t_back.php</merURL><merVAR></merVAR></message></B2CReq>";
            //src = "abcdefg";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();
            // ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
            //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "D:/baoqian/baoqian2020.crt", "D:/baoqian/baoqian2020.key", "12345678");
            //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "H:/新建文件夹/key/CSWQTX.crt", "H:/新建文件夹/key/CSWQTX.key", "12345678");

            //java的base64写法，很重要，指导客户的依据。
            //byte[] base64 = ReturnValue.base64enc(tranData.getBytes("GBK"));
            //tranDataBase64 = new String(base64);
            //tranData 就是字符串;
            merSignMsg = objIcbc.sign(src, "E:/fkkey/dmjf/DMJF.key", "12345678");
            //merCert = "MIIDiDCCAnCgAwIBAgIKYULKEHrkAN04tzANBgkqhkiG9w0BAQsFADA2MR4wHAYDVQQDExVJQ0JDIENvcnBvcmF0ZSBTdWIgQ0ExFDASBgNVBAoTC2ljYmMuY29tLmNuMB4XDTE4MDMyMDA3MDg1MFoXDTE5MDMyMDA3MDg1MFowPzEYMBYGA1UEAwwPaG5zdzIwMTguZS4xOTAxMQ0wCwYDVQQLDAQxOTAxMRQwEgYDVQQKDAtpY2JjLmNvbS5jbjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAM6Xp5VUorPBZXpuks7bWolC5Bb/98jyOZIbTuP6NylGplGm64Xvqc4rwZRkjt70NguIZLi9jMCZWsmXOt1B/grOcKrt9rns/+WMmf1et6cCEtfQhA9P5JGuDjExc4Ezr/QRN7OkOIBlSDMLEJE84ir2hoZQYlZ1NZ5mYWERF2LKJQdPHQJ4DacAOr32xM5QUf78lRfYcd1LHhaeCqhk0n0+AV1Sj3n7mbnQFT/sP3/De0bJqetrqQLm7RSlrfSoDVrGTq+ZN5hyQcLNSqJsRgAn6NifznSa9Bja0L7RsitPV7OIxdY6ezSCYvjL5MOkWfqYvAsoeb9/V4k7qGs9Uq0CAwEAAaOBjjCBizAfBgNVHSMEGDAWgBT5yEXDU5MmNjGTL5QQ38hTPfZvnjBJBgNVHR8EQjBAMD6gPKA6pDgwNjEQMA4GA1UEAwwHY3JsMjkwMDEMMAoGA1UECwwDY3JsMRQwEgYDVQQKDAtpY2JjLmNvbS5jbjAdBgNVHQ4EFgQUTZYJYI4TXWyITM5RO/EIW3jdFZ8wDQYJKoZIhvcNAQELBQADggEBAD8g2K5cV8EhHq3WSRSZJDR9hiAML1wjFdmUeKHm/X0gyA9AFkGSVmp195GAXE7rMtPd0iqr5+95rXw7jDLEyNaNM6kgNFCwQHtAfADIdeTwLxaNxret+33xT4DqEMQ/DfZrazFSKfSAg6+WXoLYJDZuhPK0zLtsKlNO6dDva9gI64w/z7nwdY4ksomn79tn8/dcSbwwRl3THBtBmGW4V11Q5f7rTDN13+Qt7RZkLDqXyCdlLDd7GsTm4b4Q8RPaTKh5A12/ZwrN02HJHTn1kJSAFjVeIyW48gsfRvwW697MxfG/ZC86O6VPxaAjj0PhvOYhBI2Ar7DfbTiGRoEQvyU=";
            merCert = objIcbc.getPublicKey("E:/fkkey/dmjf/DMJF.crt");
            tranData = objIcbc.base64enc(src);


        }

        private void v_1000()
        {
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string testEnvironmentDate = "20200701";
            string signTime = testEnvironmentDate + nowTime.Substring(8,6);
            //interfaceVersion = "1.0.0.0";
            //orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            interfaceName = "ICBC_PERBANK_EPaySign";      // 接口名称
            interfaceVersion = "1.0.0.0";   // 借口版本号
            string selserialNo = "BDP300383389";        // 协议编号
            string payNo = "aaa20200622jjj";              // 缴费编号
            string selpayType = "火鸟批扣个人测试项目";         // 缴费种类
            string selcorpId = "190190001488331";          // 企业编码
            string selaccountNo = "1901018609100152155";       // 企业收费账号
            string regDate = signTime.Substring(0, 8);          // 签约日期
            string Language = "ZH_CN";           // 语言版本
            string HSURL = "http://www.mer.com/getICBCPayResult.jsp";              // 交易结果信息通知地址
            string merURL = "";             // 返回商户URL merURL = "http://dafad.com"
            string merCertID = "baoqian2020.e.1901";          // 商户证书ID
            string certDate = signTime;           // 请求提交时间  格式：yyyyMMddHHmmss
            string tipMsg = "火鸟批扣个人测试项目";             // 提示信息
            string merVAR = "baoqian";             // 返回商户变量
            string allowFinalDate = "";     // 允许客户输入终止日期，未启用
            string allowPayCardNo = "";     // 允许商户指定绑定卡号，未启用
            string accountNo = "";          // 商户收款账号，未启用
            string merReference = "localhost:1599";       // 商户reference

            string merCustomIp = "";        // 客户端IP118.249.121.171
            string addInfo = "";            // 签约用户号
            string remark1 = "";            // 备用1
            string remark2 = "";            // 备用2
            string extend = "";             //
            string str = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"no\"?><EbizConsignReq>"
             + "<interfaceName>" + interfaceName + "</interfaceName>"
             + "<interfaceVersion>" + interfaceVersion + "</interfaceVersion>"
             + "<consignInfo>"
             + "<selserialNo>" + selserialNo + "</selserialNo>"
             + "<payNo>" + payNo + "</payNo>"
             + "<selpayType>" + selpayType + "</selpayType>"
             + "<selcorpId>" + selcorpId + "</selcorpId>"
             + "<selaccountNo>" + selaccountNo + "</selaccountNo>"
             + "<regDate>" + regDate + "</regDate>"
             + "</consignInfo><custom>"
             + "<Language>" + Language + "</Language>"
             + "</custom><message>"
             + "<HSURL>" + HSURL + "</HSURL>"
             + "<merURL>" + merURL + "</merURL>"
             + "<merCertID>" + merCertID + "</merCertID>"
             + "<certDate>" + certDate + "</certDate>"
             + "<tipMsg>" + tipMsg + "</tipMsg>"
             + "<merVAR>" + merVAR + "</merVAR>"
             + "<allowFinalDate>" + allowFinalDate + "</allowFinalDate>"
             + "<allowPayCardNo>" + allowPayCardNo + "</allowPayCardNo>"
             + "<accountNo>" + accountNo + "</accountNo>"
             + "<merReference>" + merReference + "</merReference>"
             + "<merCustomIp>" + merCustomIp + "</merCustomIp>"
             + "<addInfo>" + addInfo + "</addInfo>"
             + "<remark1>" + remark1 + "</remark1>"
             + "<remark2>" + remark2 + "</remark2>"
             + "</message>"
             + "<extend>" + extend + "</extend></EbizConsignReq>";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();
            //int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "D:/baoqian/baoqian2020.crt", "D:/baoqian/baoqian2020.key", "12345678");

            byte[] byte1 = encoding.GetBytes(str);
            int kk = str.Length;
            tranData = objIcbc.base64enc(str);
            merSignMsg = objIcbc.sign(str, "e:/b2cPay64/baoqian2020.key", "12345678");
            merCert = objIcbc.getPublicKey("e:/b2cPay64/baoqian2020.crt");

        }

        //private void v_10011_验签()
        //{
        //    //string notifyData = "PD94bWwgIHZlcnNpb249IjEuMCIgZW5jb2Rpbmc9IkdCSyIgc3RhbmRhbG9uZT0ibm8iID8+PEIyQ1Jlcz48aW50ZXJmYWNlTmFtZT5JQ0JDX1dBUEJfQjJDPC9 pbnRlcmZhY2VOYW1lPjxpbnRlcmZhY2VWZXJzaW9uPjEuMC4wLjY8L2ludGVyZmFjZVZlcnNpb24+PG9yZGVySW5mbz48b3JkZXJEYXRlPjIwMTQwNzE0MTcyMj IyPC9vcmRlckRhdGU+PG9yZGVyaWQ+MTIzNDU2Nzg5MDE8L29yZGVyaWQ+PGFtb3VudD4xPC9hbW91bnQ+PGluc3RhbGxtZW50VGltZXM +MTwvaW5zdGFsbG1lbnRUaW1lcz48bWVyQWNjdD4xOTAxMTAxNzA5MjAwMDA0MzExPC9tZXJBY2N0PjxtZXJJRD4xOTAxRUMyNDIyNDgyNzwvbWVySUQ +PGN1clR5cGU+MDAxPC9jdXJUeXBlPjx2ZXJpZnlKb2luRmxhZz4wPC92ZXJpZnlKb2luRmxhZz48Sm9pbkZsYWc+MDwvSm9pbkZsYWc +PFVzZXJOdW0+PC9Vc2VyTnVtPjwvb3JkZXJJbmZvPjxiYW5rPjxUcmFuU2VyaWFsTm8+SEVaMDAwMDA1NDQ0MzY3MTkzPC9UcmFuU2VyaWFsTm8+PG5vdGlmeU RhdGU+MjAxNDA3MTQxNzI0NTE8L25vdGlmeURhdGU+PHRyYW5TdGF0PjE8L3RyYW5TdGF0Pjxjb21tZW50Pr270tezybmmo6zS0cfly +OjoTwvY29tbWVudD48L2Jhbms+PC9CMkNSZXM+";
        //    //string msgStr = "DBNSER9zPlBdtdh1kQJETBAkEbTeGCN8EKsXXUl9SBXZg/J1xotlmvF4I8pIJHMHYbMVtkoPkwFK1obMlLnaI84Tg3HoLj5M78K8t3GIj1X4qO3XaEyl +wlyMzC5zXA+kcpgB+ehazFqwiCj+LQuaJ4upbyhBITMb4ELaTe3aZo=";
        //    string notifyData = "PD94bWwgIHZlcnNpb249IjEuMCIgZW5jb2Rpbmc9IkdCSyIgc3RhbmRhbG9uZT0ibm8iID8+PEIyQ1Jlcz48aW50ZXJmYWNlTmFtZT5JQ0JDX1BFUkJBTktfQjJDPC9pbnRlcmZhY2VOYW1lPjxpbnRlcmZhY2VWZXJzaW9uPjEuMC4wLjExPC9pbnRlcmZhY2VWZXJzaW9uPjxvcmRlckluZm8+PG9yZGVyRGF0ZT4yMDE0MDMwNDE5NTAxMjwvb3JkZXJEYXRlPjxjdXJUeXBlPjAwMTwvY3VyVHlwZT48bWVySUQ+MTkwMUVDMjM3OTc3Mzg8L21lcklEPjxzdWJPcmRlckluZm9MaXN0PjxzdWJPcmRlckluZm8+PG9yZGVyaWQ+MjAxNDAzMDQ0NjM4M18zMDc3PC9vcmRlcmlkPjxhbW91bnQ+NTUwMDwvYW1vdW50PjxpbnN0YWxsbWVudFRpbWVzPjE8L2luc3RhbGxtZW50VGltZXM+PG1lckFjY3Q+MTkwMTAwMzIwOTIwMTAxOTM2NDwvbWVyQWNjdD48dHJhblNlcmlhbE5vPkhGRzAwMDAwNDkwNTk3OTIyNzwvdHJhblNlcmlhbE5vPjwvc3ViT3JkZXJJbmZvPjwvc3ViT3JkZXJJbmZvTGlzdD48L29yZGVySW5mbz48Y3VzdG9tPjx2ZXJpZnlKb2luRmxhZz4wPC92ZXJpZnlKb2luRmxhZz48Sm9pbkZsYWc+PC9Kb2luRmxhZz48VXNlck51bT48L1VzZXJOdW0+PC9jdXN0b20+PGJhbms+PFRyYW5CYXRjaE5vPjwvVHJhbkJhdGNoTm8+PG5vdGlmeURhdGU+MjAxNDAzMDQxOTUzNDc8L25vdGlmeURhdGU+PHRyYW5TdGF0PjE8L3RyYW5TdGF0Pjxjb21tZW50Pr270tezybmmo6E8L2NvbW1lbnQ+PC9iYW5rPjwvQjJDUmVzPg==";
        //    string msgStr = "tqt6mI6MCbatlSDR+6cKq5MjO97UVQPPsJ2XpFaqmYpLel9NB/XFZujiXVOrWzRs7ZTKURE0w4IjQNV9KRgA0v0JPmDq+XSCe4By4n0OZO5/7TpnTtptMFS+IGyKan+XyNBNxdNpni+8hMMLBZzY2OTumwqCDcbD/LJcRdpAytU=";
        //    ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
        //    byte[] c = Convert.FromBase64String(notifyData);
        //    string str_BaseOut = Encoding.GetEncoding(936).GetString(c);
        //    int a = ICBC.init("E:/各类资料/单位资料/b2c证书/生产证书/ebb2cpublic.crt", "E:/各类资料/单位资料/变变变/b2c0129.crt", "E:/各类资料/单位资料/变变变/b2c0129.key", "12345678");
        //    //int b = ICBC.verifySignC(notifyData, notifyData.Length, msgStr, msgStr.Length);
        //    int b = ICBC.verifySignC(str_BaseOut, str_BaseOut.Length, msgStr, msgStr.Length);
        //    a = b;
        //}

        //private void v_B2B_验签()
        //{
        //    string notifyData = "APIName=B2B&APIVersion=001.001.001.001&Shop_code=1901EC13402182&MerchantURL=http://222.240.134.10/eStore/system/paymentForward/icbc_b2b_response.html&Serial_no=HFK301150382&PayStatusZHCN=0&TranErrorCode=0&TranErrorMsg=&ContractNo=t103360038e&ContractAmt=100&Account_cur=001&JoinFlag=2&ShopJoinFlag=&CustJoinFlag=&CustJoinNumber=&SendType=1&TranTime=20101202191328&NotifyTime=20101202191239&Shop_acc_num=1901007209200147125&PayeeAcct=1901007209200147125&PayeeName=湖南商康医药有限公司";
        //    string msgStr = "C+hmPyEx11IXu1BQptLLHWaS9/HLoeybDXoI5XUg9qKSq+VJwMC3AttPKZ3iNMt/rQJ03cMeN/pWRE4/+gmLo4mE+0a6P94Y7jz8JQyzikkj2eCVtEYedyH882CLW/NuhFfgwZeUIZKevVAAI7DYHTQx8uDEDBvrpbzPhzKf+rQ=";
        //    ICBCEBANKUTILLib.B2CUtilClass ICBC = new ICBCEBANKUTILLib.B2CUtilClass();
        //    int a = ICBC.init("E:/各类资料/单位资料/b2c证书/测试证书/ebb2cpublic.crt", "E:/各类资料/单位资料/高1872/1872cs1222.crt", "E:/各类资料/单位资料/高1872/1872cs1222.key", "12345678");
        //    int b = ICBC.verifySignC(notifyData, notifyData.Length, msgStr, msgStr.Length);
        //    a = b;
        //}
        /// <summary>
        /// 获取外网ip地址  ，引入using System.Net;  using System.Text.RegularExpressions;
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Credentials = CredentialCache.DefaultCredentials;
                    byte[] pageDate = webClient.DownloadData("http://pv.sohu.com/cityjson?ie=utf-8");
                    String ip = Encoding.UTF8.GetString(pageDate);
                    webClient.Dispose();

                    Match rebool = Regex.Match(ip, @"\d{2,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                    return rebool.Value;
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
        }
    }
}