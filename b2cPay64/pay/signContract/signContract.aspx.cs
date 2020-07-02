using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace b2cPay64.pay.signContract
{
    public partial class signContract : System.Web.UI.Page
    {
        protected string orderDate = "", merSignMsg = "", merCert = "", interfaceName = "ICBC_PERBANK_B2C", interfaceVersion = "1.0.0.11";
        protected string tranData = "";
        protected string certData = "";
        private Encoding encoding = Encoding.GetEncoding(936);
        protected string path = AppDomain.CurrentDomain.BaseDirectory;    //获取基目录，它由程序集冲突解决程序用来探测程序集。
        protected void Page_Load(object sender, EventArgs e)
        {
            v_1000();
        }
        private void v_1000()
        {
            string signTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            //interfaceVersion = "1.0.0.0";
            //orderDate = DateTime.Now.ToString("yyyyMMddHHmmss");
            interfaceName = "ICBC_PERBANK_EPaySign";      // 接口名称
            interfaceVersion = "1.0.0.0";   // 借口版本号
            string selserialNo = "BDP300383389";        // 协议编号
            string payNo = "aaa20200622jjj";              // 缴费编号
            string selpayType = "火鸟批扣个人测试项目";         // 缴费种类
            string selcorpId = "190190001488331";          // 企业编码
            string selaccountNo = "1901018609100152155";       // 企业收费账号
            string regDate = signTime.Substring(0, 8); ;           // 签约日期
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
            string merReference = "localhost";       // 商户reference

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
            tranData = objIcbc.base64enc(str);
            merSignMsg = objIcbc.sign(str, path + "testKey\\baoqian2020.key", "12345678");
            merCert = objIcbc.getPublicKey(path + "testKey\\baoqian2020.crt");
            string ty = str;
        }

    }
}