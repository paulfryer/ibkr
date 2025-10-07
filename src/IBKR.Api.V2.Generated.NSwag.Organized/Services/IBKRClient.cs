using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Composite IBKR client providing access to all services
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public class IBKRClient : IIBKRClient
{
    private readonly Lazy<AceswsService> _acesws;

    private readonly Lazy<FyiService> _fyi;

    private readonly Lazy<GwService> _gw;

    private readonly Lazy<HmdsService> _hmds;
    private readonly HttpClient _httpClient;

    private readonly Lazy<IserverService> _iserver;

    private readonly Lazy<LogoutService> _logout;

    private readonly Lazy<MdService> _md;

    private readonly Lazy<OAuthService> _oAuth;

    private readonly Lazy<PaService> _pa;

    private readonly Lazy<PortfolioService> _portfolio;

    private readonly Lazy<SsoService> _sso;

    private readonly Lazy<TickleService> _tickle;

    private readonly Lazy<TrsrvService> _trsrv;

    private readonly Lazy<WsService> _ws;

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

    public IAceswsService Acesws => _acesws.Value;
    public IFyiService Fyi => _fyi.Value;
    public IGwService Gw => _gw.Value;
    public IHmdsService Hmds => _hmds.Value;
    public IIserverService Iserver => _iserver.Value;
    public ILogoutService Logout => _logout.Value;
    public IMdService Md => _md.Value;
    public IOAuthService OAuth => _oAuth.Value;
    public IPaService Pa => _pa.Value;
    public IPortfolioService Portfolio => _portfolio.Value;
    public ISsoService Sso => _sso.Value;
    public ITickleService Tickle => _tickle.Value;
    public ITrsrvService Trsrv => _trsrv.Value;
    public IWsService Ws => _ws.Value;
}