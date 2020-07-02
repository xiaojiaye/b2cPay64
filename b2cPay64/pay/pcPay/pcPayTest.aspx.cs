using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2cPay64.pay.pcPay
{
    public partial class pcPayTest : System.Web.UI.Page
    {
        protected string orderDate = "", merSignMsg = "", merCert = "", interfaceName = "ICBC_PERBANK_B2C", interfaceVersion = "1.0.0.11";
        protected string tranData = "";
        protected string certData = "";
        protected string testEnvironmentDate = "20200701";
        protected string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        private Encoding encoding = Encoding.GetEncoding(936);
        protected string path = AppDomain.CurrentDomain.BaseDirectory;    //获取基目录，它由程序集冲突解决程序用来探测程序集。

        protected void Page_Load(object sender, EventArgs e)
        {
            v_10011();
        }

        private void v_10011()
        {
            string signTime = testEnvironmentDate + nowTime.Substring(8, 6);
            interfaceVersion = "1.0.0.11";
            //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;localhost:1151
            string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion>";
            src = src + "<orderInfo><orderDate>" + signTime + "</orderDate><curType>001</curType><merID>1901EC27254154</merID><subOrderInfoList><subOrderInfo><orderid>" + signTime + "aaaaaaaaaaa</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901018609100152155</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt></carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
            src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>*.jiakin.cn</merReference><merCustomIp></merCustomIp><goodsType>0</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>测试接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2>111</remark2><merURL>http://jiakin.cn/pay/pcPayProduct.aspx</merURL><merVAR></merVAR></message></B2CReq>";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();            
            tranData = objIcbc.base64enc(src);
            merSignMsg = objIcbc.sign(src, path + "testKey\\baoqian2020.key", "12345678");
            merCert = objIcbc.getPublicKey(path + "testKey\\baoqian2020.crt");
            string j = src;
        }
    }
}