using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSocket
{
    public class OPENHOLDING
    {
        public string Emsg { get; set; }
        public string stat { get; set; }
    }

    public class DAY
    {
        public string unrealisedprofitloss { get; set; }
        public string Fillsellqty { get; set; }
        public string PriceNumerator { get; set; }
        public string realisedprofitloss { get; set; }
        public string Type { get; set; }
        public string Fillbuyqty { get; set; }
        public int BLQty { get; set; }
        public string s_NetQtyPosConv { get; set; }
        public string Sellavgprc { get; set; }
        public string Exchangeseg { get; set; }
        public string Opttype { get; set; }
        public string Bqty { get; set; }
        public string Exchange { get; set; }
        public string Fillsellamt { get; set; }
        public string actid { get; set; }
        public string GeneralDenomenator { get; set; }
        public string discQty { get; set; }
        public string Instname { get; set; }
        public string Netqty { get; set; }
        public string sSqrflg { get; set; }
        public string LTP { get; set; }
        public string Tsym { get; set; }
        public string Expdate { get; set; }
        public string Buyavgprc { get; set; }
        public string Netamt { get; set; }
        public string Token { get; set; }
        public string GeneralNumerator { get; set; }
        public string companyname { get; set; }
        public string stat { get; set; }
        public string Sqty { get; set; }
        public string PriceDenomenator { get; set; }
        public string MtoM { get; set; }
        public string Symbol { get; set; }
        public string posflag { get; set; }
        public string Series { get; set; }
        public string BEP { get; set; }
        public string Stikeprc { get; set; }
        public string Pcode { get; set; }
        public string Fillbuyamt { get; set; }
    }

    public class NET
    {
        public string Fillsellqty { get; set; }
        public string realisedprofitloss { get; set; }
        public string NetSellavgprc { get; set; }
        public string Opttype { get; set; }
        public string Exchangeseg { get; set; }
        public string Netqty { get; set; }
        public string CFBuyavgprc { get; set; }
        public string sSqrflg { get; set; }
        public string netbuyamt { get; set; }
        public string Tsym { get; set; }
        public string Netamt { get; set; }
        public string netsellqty { get; set; }
        public string Sqty { get; set; }
        public string FillsellamtCF { get; set; }
        public string NetBuyavgprc { get; set; }
        public string MtoM { get; set; }
        public string Symbol { get; set; }
        public string posflag { get; set; }
        public string Series { get; set; }
        public string netSellamt { get; set; }
        public string Fillbuyamt { get; set; }
        public string unrealisedprofitloss { get; set; }
        public string PriceNumerator { get; set; }
        public string Type { get; set; }
        public string netbuyqty { get; set; }
        public int BLQty { get; set; }
        public string Fillbuyqty { get; set; }
        public string CFsellqty { get; set; }
        public string s_NetQtyPosConv { get; set; }
        public string CFbuyqty { get; set; }
        public string Sellavgprc { get; set; }
        public string Bqty { get; set; }
        public string Exchange { get; set; }
        public string CFSellavgprc { get; set; }
        public string Fillsellamt { get; set; }
        public string actid { get; set; }
        public string GeneralDenomenator { get; set; }
        public string Instname { get; set; }
        public string discQty { get; set; }
        public string Expdate { get; set; }
        public string LTP { get; set; }
        public string Buyavgprc { get; set; }
        public string Token { get; set; }
        public string GeneralNumerator { get; set; }
        public string companyname { get; set; }
        public string stat { get; set; }
        public string PriceDenomenator { get; set; }
        public string FillbuyamtCF { get; set; }
        public string Stikeprc { get; set; }
        public string BEP { get; set; }
        public string Pcode { get; set; }
    }

    public class OPENPOSITION
    {
        public List<DAY> DAY { get; set; }
        public List<NET> NET { get; set; }
    }

    public class TRADEHISTROY
    {
        public string series { get; set; }
        public string AvgPrice { get; set; }
        public string PriceNumerator { get; set; }
        public string accountId { get; set; }
        public string Custofrm { get; set; }
        public string Ordduration { get; set; }
        public string AlgoCategory { get; set; }
        public string Filltime { get; set; }
        public string BrokerClient { get; set; }
        public string expdate { get; set; }
        public string remarks { get; set; }
        public string symbolname { get; set; }
        public int Qty { get; set; }
        public string ReportType { get; set; }
        public string Exchange { get; set; }
        public string Time { get; set; }
        public string Prctype { get; set; }
        public string usecs { get; set; }
        public string Filldate { get; set; }
        public string NOReqID { get; set; }
        public string Exchtime { get; set; }
        public string optiontype { get; set; }
        public string GeneralDenomenator { get; set; }
        public string ordergenerationtype { get; set; }
        public string strikeprice { get; set; }
        public int FillLeg { get; set; }
        public int iSinceBOE { get; set; }
        public string Nstordno { get; set; }
        public string Tsym { get; set; }
        public string GeneralNumerator { get; set; }
        public string Expiry { get; set; }
        public string companyname { get; set; }
        public int bqty { get; set; }
        public string FillId { get; set; }
        public string stat { get; set; }
        public string PriceDenomenator { get; set; }
        public int Filledqty { get; set; }
        public string panNo { get; set; }
        public string Symbol { get; set; }
        public string Trantype { get; set; }
        public string posflag { get; set; }
        public string Price { get; set; }
        public string Exchseg { get; set; }
        public string ExchordID { get; set; }
        public string Pcode { get; set; }
        public int Minqty { get; set; }
        public string user { get; set; }
        public string AlgoID { get; set; }
        public int Fillqty { get; set; }
    }

    public class OPENORDER
    {
        public string OrderUserMessage { get; set; }
        public int Cancelqty { get; set; }
        public string AlgoCategory { get; set; }
        public string modifiedBy { get; set; }
        public int RefLmtPrice { get; set; }
        public string Mktpro { get; set; }
        public int Qty { get; set; }
        public string ExpSsbDate { get; set; }
        public string Trgprc { get; set; }
        public string ExchOrdID { get; set; }
        public int COPercentage { get; set; }
        public string exchangeuserinfo { get; set; }
        public string RequestID { get; set; }
        public string usecs { get; set; }
        public string orderentrytime { get; set; }
        public string Avgprc { get; set; }
        public int Fillshares { get; set; }
        public string optionType { get; set; }
        public string ordergenerationtype { get; set; }
        public int iSinceBOE { get; set; }
        public string InstName { get; set; }
        public string Nstordno { get; set; }
        public int Unfilledsize { get; set; }
        public string Usercomments { get; set; }
        public string mpro { get; set; }
        public string ticksize { get; set; }
        public string strikePrice { get; set; }
        public string OrderedTime { get; set; }
        public string panNo { get; set; }
        public string defmktproval { get; set; }
        public string ExchConfrmtime { get; set; }
        public int Minqty { get; set; }
        public string AlgoID { get; set; }
        public string ordersource { get; set; }
        public string sipindicator { get; set; }
        public string decprec { get; set; }
        public string series { get; set; }
        public string PriceNumerator { get; set; }
        public string Ordvaldate { get; set; }
        public string Trsym { get; set; }
        public string accountId { get; set; }
        public int Dscqty { get; set; }
        public string BrokerClient { get; set; }
        public string reporttype { get; set; }
        public string remarks { get; set; }
        public string Scripname { get; set; }
        public string Prc { get; set; }
        public string Exchange { get; set; }
        public string Sym { get; set; }
        public string token { get; set; }
        public string Prctype { get; set; }
        public string RejReason { get; set; }
        public string GeneralDenomenator { get; set; }
        public string Validity { get; set; }
        public string GeneralNumerator { get; set; }
        public string stat { get; set; }
        public string multiplier { get; set; }
        public string bqty { get; set; }
        public string noMktPro { get; set; }
        public string discQtyPerc { get; set; }
        public string Status { get; set; }
        public string PriceDenomenator { get; set; }
        public string SyomOrderId { get; set; }
        public string Trantype { get; set; }
        public string ExpDate { get; set; }
        public string marketprotectionpercentage { get; set; }
        public string Pcode { get; set; }
        public string Exseg { get; set; }
        public string user { get; set; }
    }

    public class MARGININFO2
    {
        public string OpeningBalance { get; set; }
        public string Netcashavailable { get; set; }
        public string grossexposurevalue { get; set; }
        public string segment { get; set; }
        public string cncrealizedmtomprsnt { get; set; }
        public string valueindelivery { get; set; }
        public string cncsellcreditpresent { get; set; }
        public string cncunrealizedmtomprsnt { get; set; }
        public string deliverymarginprsnt { get; set; }
        public string grossCollateral { get; set; }
        public string BuyPower { get; set; }
        public string PayoutAmt { get; set; }
        public string cncbrokerageprsnt { get; set; }
        public string turnover { get; set; }
        public string unrealisedmtom { get; set; }
        public string adhocscripmargin { get; set; }
        public string specialmarginprsnt { get; set; }
        public string BOmarginRequired { get; set; }
        public string losslimit { get; set; }
        public string IPOAmount { get; set; }
        public string elm { get; set; }
        public string viewrealizedmtom { get; set; }
        public string cdsspreadbenefit { get; set; }
        public string realisedmtom { get; set; }
        public string category { get; set; }
        public string nfospreadbenefit { get; set; }
        public string Utilizedamount { get; set; }
        public string exposuremargin { get; set; }
        public string Adhoc { get; set; }
        public string t1grossCollateral { get; set; }
        public string directcollateralvalue { get; set; }
        public string StockValuation { get; set; }
        public string viewunrealizedmtom { get; set; }
        public string lien { get; set; }
        public string credits { get; set; }
        public string branchadhoc { get; set; }
        public string adhocmargin { get; set; }
        public string additionalmarginprsnt { get; set; }
        public string spanmargin { get; set; }
        public string premiumpresent { get; set; }
        public string BookedPNL { get; set; }
        public string varmargin { get; set; }
        public string marginScripBasketCustomPresent { get; set; }
        public string financelimit { get; set; }
        public string tendermarginprsnt { get; set; }
        public string cncmarginused { get; set; }
        public string brokerageprsnt { get; set; }
        public string UnbookedPNL { get; set; }
        public string debits { get; set; }
        public string COMarginRequired { get; set; }
        public string multiplier { get; set; }
        public string stat { get; set; }
        public string mfamount { get; set; }
        public string scripbasketmargin { get; set; }
        public string buyExposurePrsnt { get; set; }
        public string elbamount { get; set; }
        public string notionalcash { get; set; }
        public string additionalpreexpirymarginprsnt { get; set; }
        public string cncMarginElmPrsnt { get; set; }
        public string PayinAmt { get; set; }
        public string cncMarginVarPrsnt { get; set; }
        public string mfssamountused { get; set; }
        public string sellExposurePrsnt { get; set; }
    }

    public class MARKETSTATU
    {
        public string exchfeedtime { get; set; }
        public string text { get; set; }
        public string Exchange { get; set; }
        public string exchsegment { get; set; }
        public string MarketMode { get; set; }
        public string MktStatus { get; set; }
    }

    public class MARGININFO
    {
        public MARGININFO2 MARGIN_INFO { get; set; }
        public List<MARKETSTATU> MARKET_STATUS { get; set; }
    }

    public class Data
    {
        public OPENHOLDING OPEN_HOLDING { get; set; }
        public OPENPOSITION OPEN_POSITION { get; set; }
        public List<TRADEHISTROY> TRADE_HISTROY { get; set; }
        public List<OPENORDER> OPEN_ORDERS { get; set; }
        public MARGININFO MARGIN_INFO { get; set; }
    }

    public class TradeDetails
    {
        public string info { get; set; }
        public string msg { get; set; }
        public Data data { get; set; }
        public List<object> errors { get; set; }
    }
}
