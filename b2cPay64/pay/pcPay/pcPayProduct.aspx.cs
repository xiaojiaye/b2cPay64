using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2cPay64.pay.pcPay
{
    public partial class pcPayProduct : System.Web.UI.Page
    {
        protected string orderDate = "", merSignMsg = "", merCert = "", interfaceName = "ICBC_PERBANK_B2C", interfaceVersion = "1.0.0.11";
        protected string tranData = "";
        protected string certData = "";        
        protected string nowTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        private Encoding encoding = Encoding.GetEncoding(936);
        protected string path = AppDomain.CurrentDomain.BaseDirectory;    //获取基目录，它由程序集冲突解决程序用来探测程序集。

        protected void Page_Load(object sender, EventArgs e)
        {
            v_10011();
        }

        private void v_10011()
        {            
            interfaceVersion = "1.0.0.11";
            //string src = interfaceName + interfaceVersion + merID + merAcct + merURL + notifyType + orderid + amount + curType + resultType + orderDate + verifyJoinFlag;localhost:1151
            string src = "<?xml version='1.0' encoding='GBK' standalone='no'?><B2CReq><interfaceName>ICBC_PERBANK_B2C</interfaceName><interfaceVersion>1.0.0.11</interfaceVersion>";
            src = src + "<orderInfo><orderDate>" + nowTime + "</orderDate><curType>001</curType><merID>1901EE21078015</merID><subOrderInfoList><subOrderInfo><orderid>" + nowTime + "</orderid><amount>1</amount><installmentTimes>1</installmentTimes><merAcct>1901003219200017578</merAcct><goodsID>001</goodsID><goodsName>威尼熊</goodsName><goodsNum>1</goodsNum><carriageAmt>1</carriageAmt></subOrderInfo></subOrderInfoList></orderInfo>";
            src = src + "<custom><verifyJoinFlag>0</verifyJoinFlag><Language>ZH_CN</Language></custom><message><creditType>2</creditType><notifyType>HS</notifyType><resultType>1</resultType><merReference>localhost:1599</merReference><merCustomIp></merCustomIp><goodsType>0</goodsType><merCustomID>123456</merCustomID><merCustomPhone>13466780886</merCustomPhone><goodsAddress>三里屯</goodsAddress><merOrderRemark>防欺诈接口专用</merOrderRemark><merHint>Test</merHint><remark1></remark1><remark2></remark2><merURL>http://172.16.49.232:31021/bkg/icbc_pay_back.xhtml</merURL><merVAR></merVAR></message></B2CReq>";
            infosecapiLib.infosec objIcbc = new infosecapiLib.infosec();

            tranData = objIcbc.base64enc(src);
            merSignMsg = objIcbc.sign(src, path + "productKey\\DMJF.key", "12345678");
            merCert = objIcbc.getPublicKey(path + "productKey\\DMJF.crt");
            string j = src;
        }
    }
}