using System.CodeDom.Compiler;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PortfolioSummary
{
    private IDictionary<string, object>? _additionalProperties;

    [JsonProperty("accountcode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Accountcode Accountcode { get; set; }

    [JsonProperty("accountready", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Accountready Accountready { get; set; }

    [JsonProperty("accounttype", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccountType? Accounttype { get; set; }

    [JsonProperty("accruedcash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Accruedcash Accruedcash { get; set; }

    [JsonProperty("accruedcash-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccruedcashC AccruedcashC { get; set; }

    [JsonProperty("accruedcash-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccruedcashS AccruedcashS { get; set; }

    [JsonProperty("accrueddividend", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Accrueddividend Accrueddividend { get; set; }

    [JsonProperty("accrueddividend-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccrueddividendC AccrueddividendC { get; set; }

    [JsonProperty("accrueddividend-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AccrueddividendS AccrueddividendS { get; set; }

    [JsonProperty("availablefunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Availablefunds Availablefunds { get; set; }

    [JsonProperty("availablefunds-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AvailablefundsC AvailablefundsC { get; set; }

    [JsonProperty("availablefunds-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AvailablefundsS AvailablefundsS { get; set; }

    [JsonProperty("availabletotrade", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Availabletotrade Availabletotrade { get; set; }

    [JsonProperty("availabletotrade-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AvailabletotradeC AvailabletotradeC { get; set; }

    [JsonProperty("availabletotrade-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public AvailabletotradeS AvailabletotradeS { get; set; }

    [JsonProperty("availabletowithdraw", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Availabletowithdraw Availabletowithdraw { get; set; }

    [JsonProperty("availabletowithdraw-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AvailabletowithdrawC AvailabletowithdrawC { get; set; }

    [JsonProperty("availabletowithdraw-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public AvailabletowithdrawS AvailabletowithdrawS { get; set; }

    [JsonProperty("billable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Billable Billable { get; set; }

    [JsonProperty("billable-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public BillableC BillableC { get; set; }

    [JsonProperty("billable-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public BillableS BillableS { get; set; }

    [JsonProperty("buyingpower", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Buyingpower Buyingpower { get; set; }

    [JsonProperty("columnprio-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ColumnprioC ColumnprioC { get; set; }

    [JsonProperty("columnprio-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ColumnprioS ColumnprioS { get; set; }

    [JsonProperty("cushion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Cushion Cushion { get; set; }

    [JsonProperty("daytradesremaining", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Daytradesremaining Daytradesremaining { get; set; }

    [JsonProperty("daytradesremainingt+1", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Daytradesremainingtplus1 Daytradesremainingtplus1 { get; set; }

    [JsonProperty("daytradesremainingt+2", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Daytradesremainingtplus2 Daytradesremainingtplus2 { get; set; }

    [JsonProperty("daytradesremainingt+3", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Daytradesremainingtplus3 Daytradesremainingtplus3 { get; set; }

    [JsonProperty("daytradesremainingt+4", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Daytradesremainingtplus4 Daytradesremainingtplus4 { get; set; }

    [JsonProperty("daytradingstatus-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public DaytradingstatusS DaytradingstatusS { get; set; }

    [JsonProperty("depositoncredithold", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Depositoncredithold Depositoncredithold { get; set; }

    [JsonProperty("equitywithloanvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Equitywithloanvalue Equitywithloanvalue { get; set; }

    [JsonProperty("equitywithloanvalue-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public EquitywithloanvalueC EquitywithloanvalueC { get; set; }

    [JsonProperty("equitywithloanvalue-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public EquitywithloanvalueS EquitywithloanvalueS { get; set; }

    [JsonProperty("excessliquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Excessliquidity Excessliquidity { get; set; }

    [JsonProperty("excessliquidity-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ExcessliquidityC ExcessliquidityC { get; set; }

    [JsonProperty("excessliquidity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public ExcessliquidityS ExcessliquidityS { get; set; }

    [JsonProperty("fullavailablefunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Fullavailablefunds Fullavailablefunds { get; set; }

    [JsonProperty("fullavailablefunds-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullavailablefundsC FullavailablefundsC { get; set; }

    [JsonProperty("fullavailablefunds-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullavailablefundsS FullavailablefundsS { get; set; }

    [JsonProperty("fullexcessliquidity", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Fullexcessliquidity Fullexcessliquidity { get; set; }

    [JsonProperty("fullexcessliquidity-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullexcessliquidityC FullexcessliquidityC { get; set; }

    [JsonProperty("fullexcessliquidity-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullexcessliquidityS FullexcessliquidityS { get; set; }

    [JsonProperty("fullinitmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Fullinitmarginreq Fullinitmarginreq { get; set; }

    [JsonProperty("fullinitmarginreq-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullinitmarginreqC FullinitmarginreqC { get; set; }

    [JsonProperty("fullinitmarginreq-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullinitmarginreqS FullinitmarginreqS { get; set; }

    [JsonProperty("fullmaintmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Fullmaintmarginreq Fullmaintmarginreq { get; set; }

    [JsonProperty("fullmaintmarginreq-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullmaintmarginreqC FullmaintmarginreqC { get; set; }

    [JsonProperty("fullmaintmarginreq-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public FullmaintmarginreqS FullmaintmarginreqS { get; set; }

    [JsonProperty("grosspositionvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Grosspositionvalue Grosspositionvalue { get; set; }

    [JsonProperty("grosspositionvalue-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public GrosspositionvalueS GrosspositionvalueS { get; set; }

    [JsonProperty("guarantee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Guarantee Guarantee { get; set; }

    [JsonProperty("guarantee-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public GuaranteeC GuaranteeC { get; set; }

    [JsonProperty("guarantee-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public GuaranteeS GuaranteeS { get; set; }

    [JsonProperty("highestseverity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Highestseverity Highestseverity { get; set; }

    [JsonProperty("indianstockhaircut", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Indianstockhaircut Indianstockhaircut { get; set; }

    [JsonProperty("indianstockhaircut-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IndianstockhaircutC IndianstockhaircutC { get; set; }

    [JsonProperty("indianstockhaircut-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public IndianstockhaircutS IndianstockhaircutS { get; set; }

    [JsonProperty("initmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Initmarginreq Initmarginreq { get; set; }

    [JsonProperty("initmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public InitmarginreqC InitmarginreqC { get; set; }

    [JsonProperty("initmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public InitmarginreqS InitmarginreqS { get; set; }

    [JsonProperty("leverage-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public LeverageS LeverageS { get; set; }

    [JsonProperty("lookaheadavailablefunds", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Lookaheadavailablefunds Lookaheadavailablefunds { get; set; }

    [JsonProperty("lookaheadavailablefunds-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadavailablefundsC LookaheadavailablefundsC { get; set; }

    [JsonProperty("lookaheadavailablefunds-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadavailablefundsS LookaheadavailablefundsS { get; set; }

    [JsonProperty("lookaheadexcessliquidity", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Lookaheadexcessliquidity Lookaheadexcessliquidity { get; set; }

    [JsonProperty("lookaheadexcessliquidity-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadexcessliquidityC LookaheadexcessliquidityC { get; set; }

    [JsonProperty("lookaheadexcessliquidity-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadexcessliquidityS LookaheadexcessliquidityS { get; set; }

    [JsonProperty("lookaheadinitmarginreq", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Lookaheadinitmarginreq Lookaheadinitmarginreq { get; set; }

    [JsonProperty("lookaheadinitmarginreq-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadinitmarginreqC LookaheadinitmarginreqC { get; set; }

    [JsonProperty("lookaheadinitmarginreq-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadinitmarginreqS LookaheadinitmarginreqS { get; set; }

    [JsonProperty("lookaheadmaintmarginreq", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Lookaheadmaintmarginreq Lookaheadmaintmarginreq { get; set; }

    [JsonProperty("lookaheadmaintmarginreq-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadmaintmarginreqC LookaheadmaintmarginreqC { get; set; }

    [JsonProperty("lookaheadmaintmarginreq-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public LookaheadmaintmarginreqS LookaheadmaintmarginreqS { get; set; }

    [JsonProperty("lookaheadnextchange", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Lookaheadnextchange Lookaheadnextchange { get; set; }

    [JsonProperty("maintmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Maintmarginreq Maintmarginreq { get; set; }

    [JsonProperty("maintmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public MaintmarginreqC MaintmarginreqC { get; set; }

    [JsonProperty("maintmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public MaintmarginreqS MaintmarginreqS { get; set; }

    [JsonProperty("netliquidation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Netliquidation Netliquidation { get; set; }

    [JsonProperty("netliquidation-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public NetliquidationC NetliquidationC { get; set; }

    [JsonProperty("netliquidation-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public NetliquidationS NetliquidationS { get; set; }

    [JsonProperty("netliquidationuncertainty", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Netliquidationuncertainty Netliquidationuncertainty { get; set; }

    [JsonProperty("nlvandmargininreview", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Nlvandmargininreview Nlvandmargininreview { get; set; }

    [JsonProperty("pasharesvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Pasharesvalue Pasharesvalue { get; set; }

    [JsonProperty("pasharesvalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public PasharesvalueC PasharesvalueC { get; set; }

    [JsonProperty("pasharesvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public PasharesvalueS PasharesvalueS { get; set; }

    [JsonProperty("physicalcertificatevalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Physicalcertificatevalue Physicalcertificatevalue { get; set; }

    [JsonProperty("physicalcertificatevalue-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PhysicalcertificatevalueC PhysicalcertificatevalueC { get; set; }

    [JsonProperty("physicalcertificatevalue-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PhysicalcertificatevalueS PhysicalcertificatevalueS { get; set; }

    [JsonProperty("postexpirationexcess", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Postexpirationexcess Postexpirationexcess { get; set; }

    [JsonProperty("postexpirationexcess-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PostexpirationexcessC PostexpirationexcessC { get; set; }

    [JsonProperty("postexpirationexcess-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PostexpirationexcessS PostexpirationexcessS { get; set; }

    [JsonProperty("postexpirationmargin", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Postexpirationmargin Postexpirationmargin { get; set; }

    [JsonProperty("postexpirationmargin-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PostexpirationmarginC PostexpirationmarginC { get; set; }

    [JsonProperty("postexpirationmargin-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PostexpirationmarginS PostexpirationmarginS { get; set; }

    [JsonProperty("previousdayequitywithloanvalue", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Previousdayequitywithloanvalue Previousdayequitywithloanvalue { get; set; }

    [JsonProperty("previousdayequitywithloanvalue-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public PreviousdayequitywithloanvalueS PreviousdayequitywithloanvalueS { get; set; }

    [JsonProperty("regtequity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Regtequity Regtequity { get; set; }

    [JsonProperty("regtequity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public RegtequityS RegtequityS { get; set; }

    [JsonProperty("regtmargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Regtmargin Regtmargin { get; set; }

    [JsonProperty("regtmargin-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public RegtmarginS RegtmarginS { get; set; }

    [JsonProperty("segmenttitle-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public SegmenttitleC SegmenttitleC { get; set; }

    [JsonProperty("segmenttitle-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public SegmenttitleS SegmenttitleS { get; set; }

    [JsonProperty("sma", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Sma Sma { get; set; }

    [JsonProperty("sma-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public SmaS SmaS { get; set; }

    [JsonProperty("totalcashvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Totalcashvalue Totalcashvalue { get; set; }

    [JsonProperty("totalcashvalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TotalcashvalueC TotalcashvalueC { get; set; }

    [JsonProperty("totalcashvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TotalcashvalueS TotalcashvalueS { get; set; }

    [JsonProperty("totaldebitcardpendingcharges", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public Totaldebitcardpendingcharges Totaldebitcardpendingcharges { get; set; }

    [JsonProperty("totaldebitcardpendingcharges-c", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public TotaldebitcardpendingchargesC TotaldebitcardpendingchargesC { get; set; }

    [JsonProperty("totaldebitcardpendingcharges-s", Required = Required.DisallowNull,
        NullValueHandling = NullValueHandling.Ignore)]
    public TotaldebitcardpendingchargesS TotaldebitcardpendingchargesS { get; set; }

    [JsonProperty("tradingtype-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public TradingtypeS TradingtypeS { get; set; }

    [JsonProperty("whatifpmenabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
    public Whatifpmenabled Whatifpmenabled { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
        set => _additionalProperties = value;
    }
}