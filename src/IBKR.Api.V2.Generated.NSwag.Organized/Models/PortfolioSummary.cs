using System.CodeDom.Compiler;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IBKR.Api.V2.Generated.NSwag.Models;

[GeneratedCode("NJsonSchema", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class PortfolioSummary
{
	private IDictionary<string, object>? _additionalProperties;

	[JsonProperty("accountcode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Accountcode Accountcode { get; set; } = null;

	[JsonProperty("accountready", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Accountready Accountready { get; set; } = null;

	[JsonProperty("accounttype", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccountType? Accounttype { get; set; } = null;

	[JsonProperty("accruedcash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Accruedcash Accruedcash { get; set; } = null;

	[JsonProperty("accruedcash-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccruedcashC AccruedcashC { get; set; } = null;

	[JsonProperty("accruedcash-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccruedcashS AccruedcashS { get; set; } = null;

	[JsonProperty("accrueddividend", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Accrueddividend Accrueddividend { get; set; } = null;

	[JsonProperty("accrueddividend-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccrueddividendC AccrueddividendC { get; set; } = null;

	[JsonProperty("accrueddividend-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AccrueddividendS AccrueddividendS { get; set; } = null;

	[JsonProperty("availablefunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Availablefunds Availablefunds { get; set; } = null;

	[JsonProperty("availablefunds-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailablefundsC AvailablefundsC { get; set; } = null;

	[JsonProperty("availablefunds-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailablefundsS AvailablefundsS { get; set; } = null;

	[JsonProperty("availabletotrade", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Availabletotrade Availabletotrade { get; set; } = null;

	[JsonProperty("availabletotrade-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailabletotradeC AvailabletotradeC { get; set; } = null;

	[JsonProperty("availabletotrade-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailabletotradeS AvailabletotradeS { get; set; } = null;

	[JsonProperty("availabletowithdraw", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Availabletowithdraw Availabletowithdraw { get; set; } = null;

	[JsonProperty("availabletowithdraw-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailabletowithdrawC AvailabletowithdrawC { get; set; } = null;

	[JsonProperty("availabletowithdraw-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public AvailabletowithdrawS AvailabletowithdrawS { get; set; } = null;

	[JsonProperty("billable", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Billable Billable { get; set; } = null;

	[JsonProperty("billable-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public BillableC BillableC { get; set; } = null;

	[JsonProperty("billable-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public BillableS BillableS { get; set; } = null;

	[JsonProperty("buyingpower", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Buyingpower Buyingpower { get; set; } = null;

	[JsonProperty("columnprio-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ColumnprioC ColumnprioC { get; set; } = null;

	[JsonProperty("columnprio-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ColumnprioS ColumnprioS { get; set; } = null;

	[JsonProperty("cushion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Cushion Cushion { get; set; } = null;

	[JsonProperty("daytradesremaining", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Daytradesremaining Daytradesremaining { get; set; } = null;

	[JsonProperty("daytradesremainingt+1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Daytradesremainingtplus1 Daytradesremainingtplus1 { get; set; } = null;

	[JsonProperty("daytradesremainingt+2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Daytradesremainingtplus2 Daytradesremainingtplus2 { get; set; } = null;

	[JsonProperty("daytradesremainingt+3", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Daytradesremainingtplus3 Daytradesremainingtplus3 { get; set; } = null;

	[JsonProperty("daytradesremainingt+4", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Daytradesremainingtplus4 Daytradesremainingtplus4 { get; set; } = null;

	[JsonProperty("daytradingstatus-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public DaytradingstatusS DaytradingstatusS { get; set; } = null;

	[JsonProperty("depositoncredithold", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Depositoncredithold Depositoncredithold { get; set; } = null;

	[JsonProperty("equitywithloanvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Equitywithloanvalue Equitywithloanvalue { get; set; } = null;

	[JsonProperty("equitywithloanvalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EquitywithloanvalueC EquitywithloanvalueC { get; set; } = null;

	[JsonProperty("equitywithloanvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public EquitywithloanvalueS EquitywithloanvalueS { get; set; } = null;

	[JsonProperty("excessliquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Excessliquidity Excessliquidity { get; set; } = null;

	[JsonProperty("excessliquidity-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ExcessliquidityC ExcessliquidityC { get; set; } = null;

	[JsonProperty("excessliquidity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public ExcessliquidityS ExcessliquidityS { get; set; } = null;

	[JsonProperty("fullavailablefunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Fullavailablefunds Fullavailablefunds { get; set; } = null;

	[JsonProperty("fullavailablefunds-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullavailablefundsC FullavailablefundsC { get; set; } = null;

	[JsonProperty("fullavailablefunds-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullavailablefundsS FullavailablefundsS { get; set; } = null;

	[JsonProperty("fullexcessliquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Fullexcessliquidity Fullexcessliquidity { get; set; } = null;

	[JsonProperty("fullexcessliquidity-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullexcessliquidityC FullexcessliquidityC { get; set; } = null;

	[JsonProperty("fullexcessliquidity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullexcessliquidityS FullexcessliquidityS { get; set; } = null;

	[JsonProperty("fullinitmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Fullinitmarginreq Fullinitmarginreq { get; set; } = null;

	[JsonProperty("fullinitmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullinitmarginreqC FullinitmarginreqC { get; set; } = null;

	[JsonProperty("fullinitmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullinitmarginreqS FullinitmarginreqS { get; set; } = null;

	[JsonProperty("fullmaintmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Fullmaintmarginreq Fullmaintmarginreq { get; set; } = null;

	[JsonProperty("fullmaintmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullmaintmarginreqC FullmaintmarginreqC { get; set; } = null;

	[JsonProperty("fullmaintmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public FullmaintmarginreqS FullmaintmarginreqS { get; set; } = null;

	[JsonProperty("grosspositionvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Grosspositionvalue Grosspositionvalue { get; set; } = null;

	[JsonProperty("grosspositionvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public GrosspositionvalueS GrosspositionvalueS { get; set; } = null;

	[JsonProperty("guarantee", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Guarantee Guarantee { get; set; } = null;

	[JsonProperty("guarantee-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public GuaranteeC GuaranteeC { get; set; } = null;

	[JsonProperty("guarantee-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public GuaranteeS GuaranteeS { get; set; } = null;

	[JsonProperty("highestseverity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Highestseverity Highestseverity { get; set; } = null;

	[JsonProperty("indianstockhaircut", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Indianstockhaircut Indianstockhaircut { get; set; } = null;

	[JsonProperty("indianstockhaircut-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndianstockhaircutC IndianstockhaircutC { get; set; } = null;

	[JsonProperty("indianstockhaircut-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public IndianstockhaircutS IndianstockhaircutS { get; set; } = null;

	[JsonProperty("initmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Initmarginreq Initmarginreq { get; set; } = null;

	[JsonProperty("initmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public InitmarginreqC InitmarginreqC { get; set; } = null;

	[JsonProperty("initmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public InitmarginreqS InitmarginreqS { get; set; } = null;

	[JsonProperty("leverage-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LeverageS LeverageS { get; set; } = null;

	[JsonProperty("lookaheadavailablefunds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Lookaheadavailablefunds Lookaheadavailablefunds { get; set; } = null;

	[JsonProperty("lookaheadavailablefunds-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadavailablefundsC LookaheadavailablefundsC { get; set; } = null;

	[JsonProperty("lookaheadavailablefunds-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadavailablefundsS LookaheadavailablefundsS { get; set; } = null;

	[JsonProperty("lookaheadexcessliquidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Lookaheadexcessliquidity Lookaheadexcessliquidity { get; set; } = null;

	[JsonProperty("lookaheadexcessliquidity-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadexcessliquidityC LookaheadexcessliquidityC { get; set; } = null;

	[JsonProperty("lookaheadexcessliquidity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadexcessliquidityS LookaheadexcessliquidityS { get; set; } = null;

	[JsonProperty("lookaheadinitmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Lookaheadinitmarginreq Lookaheadinitmarginreq { get; set; } = null;

	[JsonProperty("lookaheadinitmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadinitmarginreqC LookaheadinitmarginreqC { get; set; } = null;

	[JsonProperty("lookaheadinitmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadinitmarginreqS LookaheadinitmarginreqS { get; set; } = null;

	[JsonProperty("lookaheadmaintmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Lookaheadmaintmarginreq Lookaheadmaintmarginreq { get; set; } = null;

	[JsonProperty("lookaheadmaintmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadmaintmarginreqC LookaheadmaintmarginreqC { get; set; } = null;

	[JsonProperty("lookaheadmaintmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public LookaheadmaintmarginreqS LookaheadmaintmarginreqS { get; set; } = null;

	[JsonProperty("lookaheadnextchange", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Lookaheadnextchange Lookaheadnextchange { get; set; } = null;

	[JsonProperty("maintmarginreq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Maintmarginreq Maintmarginreq { get; set; } = null;

	[JsonProperty("maintmarginreq-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public MaintmarginreqC MaintmarginreqC { get; set; } = null;

	[JsonProperty("maintmarginreq-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public MaintmarginreqS MaintmarginreqS { get; set; } = null;

	[JsonProperty("netliquidation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Netliquidation Netliquidation { get; set; } = null;

	[JsonProperty("netliquidation-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public NetliquidationC NetliquidationC { get; set; } = null;

	[JsonProperty("netliquidation-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public NetliquidationS NetliquidationS { get; set; } = null;

	[JsonProperty("netliquidationuncertainty", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Netliquidationuncertainty Netliquidationuncertainty { get; set; } = null;

	[JsonProperty("nlvandmargininreview", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Nlvandmargininreview Nlvandmargininreview { get; set; } = null;

	[JsonProperty("pasharesvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Pasharesvalue Pasharesvalue { get; set; } = null;

	[JsonProperty("pasharesvalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PasharesvalueC PasharesvalueC { get; set; } = null;

	[JsonProperty("pasharesvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PasharesvalueS PasharesvalueS { get; set; } = null;

	[JsonProperty("physicalcertificatevalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Physicalcertificatevalue Physicalcertificatevalue { get; set; } = null;

	[JsonProperty("physicalcertificatevalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PhysicalcertificatevalueC PhysicalcertificatevalueC { get; set; } = null;

	[JsonProperty("physicalcertificatevalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PhysicalcertificatevalueS PhysicalcertificatevalueS { get; set; } = null;

	[JsonProperty("postexpirationexcess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Postexpirationexcess Postexpirationexcess { get; set; } = null;

	[JsonProperty("postexpirationexcess-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PostexpirationexcessC PostexpirationexcessC { get; set; } = null;

	[JsonProperty("postexpirationexcess-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PostexpirationexcessS PostexpirationexcessS { get; set; } = null;

	[JsonProperty("postexpirationmargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Postexpirationmargin Postexpirationmargin { get; set; } = null;

	[JsonProperty("postexpirationmargin-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PostexpirationmarginC PostexpirationmarginC { get; set; } = null;

	[JsonProperty("postexpirationmargin-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PostexpirationmarginS PostexpirationmarginS { get; set; } = null;

	[JsonProperty("previousdayequitywithloanvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Previousdayequitywithloanvalue Previousdayequitywithloanvalue { get; set; } = null;

	[JsonProperty("previousdayequitywithloanvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public PreviousdayequitywithloanvalueS PreviousdayequitywithloanvalueS { get; set; } = null;

	[JsonProperty("regtequity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Regtequity Regtequity { get; set; } = null;

	[JsonProperty("regtequity-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public RegtequityS RegtequityS { get; set; } = null;

	[JsonProperty("regtmargin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Regtmargin Regtmargin { get; set; } = null;

	[JsonProperty("regtmargin-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public RegtmarginS RegtmarginS { get; set; } = null;

	[JsonProperty("segmenttitle-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SegmenttitleC SegmenttitleC { get; set; } = null;

	[JsonProperty("segmenttitle-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SegmenttitleS SegmenttitleS { get; set; } = null;

	[JsonProperty("sma", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Sma Sma { get; set; } = null;

	[JsonProperty("sma-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public SmaS SmaS { get; set; } = null;

	[JsonProperty("totalcashvalue", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Totalcashvalue Totalcashvalue { get; set; } = null;

	[JsonProperty("totalcashvalue-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TotalcashvalueC TotalcashvalueC { get; set; } = null;

	[JsonProperty("totalcashvalue-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TotalcashvalueS TotalcashvalueS { get; set; } = null;

	[JsonProperty("totaldebitcardpendingcharges", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Totaldebitcardpendingcharges Totaldebitcardpendingcharges { get; set; } = null;

	[JsonProperty("totaldebitcardpendingcharges-c", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TotaldebitcardpendingchargesC TotaldebitcardpendingchargesC { get; set; } = null;

	[JsonProperty("totaldebitcardpendingcharges-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TotaldebitcardpendingchargesS TotaldebitcardpendingchargesS { get; set; } = null;

	[JsonProperty("tradingtype-s", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public TradingtypeS TradingtypeS { get; set; } = null;

	[JsonProperty("whatifpmenabled", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
	public Whatifpmenabled Whatifpmenabled { get; set; } = null;

	[JsonExtensionData]
	public IDictionary<string, object> AdditionalProperties
	{
		get
		{
			return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>());
		}
		set
		{
			_additionalProperties = value;
		}
	}
}
