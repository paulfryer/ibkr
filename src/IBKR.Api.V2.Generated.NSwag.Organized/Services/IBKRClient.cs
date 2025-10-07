using System;
using System.CodeDom.Compiler;
using System.Net.Http;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
/// Composite IBKR client providing access to all services
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IBKRClient : IIBKRClient
{
	private readonly HttpClient _httpClient;

	private readonly Lazy<AceswsService> _acesws;
	public IAceswsService Acesws => _acesws.Value;

	private readonly Lazy<FyiService> _fyi;
	public IFyiService Fyi => _fyi.Value;

	private readonly Lazy<GwService> _gw;
	public IGwService Gw => _gw.Value;

	private readonly Lazy<HmdsService> _hmds;
	public IHmdsService Hmds => _hmds.Value;

	private readonly Lazy<IserverService> _iserver;
	public IIserverService Iserver => _iserver.Value;

	private readonly Lazy<LogoutService> _logout;
	public ILogoutService Logout => _logout.Value;

	private readonly Lazy<MdService> _md;
	public IMdService Md => _md.Value;

	private readonly Lazy<OAuthService> _oAuth;
	public IOAuthService OAuth => _oAuth.Value;

	private readonly Lazy<PaService> _pa;
	public IPaService Pa => _pa.Value;

	private readonly Lazy<PortfolioService> _portfolio;
	public IPortfolioService Portfolio => _portfolio.Value;

	private readonly Lazy<SsoService> _sso;
	public ISsoService Sso => _sso.Value;

	private readonly Lazy<TickleService> _tickle;
	public ITickleService Tickle => _tickle.Value;

	private readonly Lazy<TrsrvService> _trsrv;
	public ITrsrvService Trsrv => _trsrv.Value;

	private readonly Lazy<WsService> _ws;
	public IWsService Ws => _ws.Value;

	public IBKRClient(HttpClient httpClient)
	{
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

		_acesws = new Lazy<AceswsService>(() => new AceswsService(_httpClient));
		_fyi = new Lazy<FyiService>(() => new FyiService(_httpClient));
		_gw = new Lazy<GwService>(() => new GwService(_httpClient));
		_hmds = new Lazy<HmdsService>(() => new HmdsService(_httpClient));
		_iserver = new Lazy<IserverService>(() => new IserverService(_httpClient));
		_logout = new Lazy<LogoutService>(() => new LogoutService(_httpClient));
		_md = new Lazy<MdService>(() => new MdService(_httpClient));
		_oAuth = new Lazy<OAuthService>(() => new OAuthService(_httpClient));
		_pa = new Lazy<PaService>(() => new PaService(_httpClient));
		_portfolio = new Lazy<PortfolioService>(() => new PortfolioService(_httpClient));
		_sso = new Lazy<SsoService>(() => new SsoService(_httpClient));
		_tickle = new Lazy<TickleService>(() => new TickleService(_httpClient));
		_trsrv = new Lazy<TrsrvService>(() => new TrsrvService(_httpClient));
		_ws = new Lazy<WsService>(() => new WsService(_httpClient));
	}
}
