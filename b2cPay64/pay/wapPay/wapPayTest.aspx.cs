using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2cPay64.pay.wapPay
{
    public partial class wapPayTest : System.Web.UI.Page
    {
        // https://mywap2.dccnet.com.cn:447/ICBCWAPBank/servlet/ICBCWAPEBizServlet  
        // https://mywap2.icbc.com.cn/ICBCWAPBank/servlet/ICBCWAPEBizServlet
        protected string orderDate = "", merSignMsg = "", merCert = "", interfaceName = "ICBC_WAPB_B2C", interfaceVersion = "1.0.0.6";
        protected string tranData = "", clientType = "0";
        protected string testEnvironmentDate = "20200701";
        protected string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");        
        protected Encoding encoding = Encoding.GetEncoding(936);
        protected string path = AppDomain.CurrentDomain.BaseDirectory;    //获取基目录，它由程序集冲突解决程序用来探测程序集。

        protected void Page_Load(object sender, EventArgs e)
        {
            test_wap1006();
        }
        private void test_wap1006()
        {
            string signTime = testEnvironmentDate + nowTime.Substring(8, 6);
            interfaceVersion = "1.0.0.6";            
            string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_WAPB_B2C</interfaceName><interfaceVersion>1.0.0.6</interfaceVersion>";
            src = src + "<orderInfo><orderDate>" + signTime + "</orderDate><orderid>" + nowTime + "0000000000" + "</orderid><amount>1000</amount><installmentTimes>1</installmentTimes><curType>001</curType><merID>1901EC27254154</merID><merAcct>1901018609100152155</merAcct></orderInfo>";
            src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><goodsID>001</goodsID><goodsName>农夫山城矿泉水</goodsName><goodsNum></goodsNum><carriageAmt></carriageAmt><merHint>达漫金服测试</merHint><remark1></remark1><remark2>remark</remark2><merURL>http://113.247.250.221/pay-web/icbc/notifyPaid.do</merURL><merVAR>baoqiantest</merVAR><notifyType>HS</notifyType><resultType>1</resultType><backup1></backup1><backup2></backup2><backup3></backup3><backup4></backup4></message></B2CReq>";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();

            tranData = objIcbc.base64enc(src);
            merSignMsg = objIcbc.sign(src, path + "testKey\\baoqian2020.key", "12345678");
            merCert = objIcbc.getPublicKey(path + "testKey\\baoqian2020.crt");

        }
    }
}