using System.CodeDom.Compiler;

namespace IBKR.Api.V2.Generated.NSwag;

/// <summary>
///     Composite root interface providing access to all IBKR API services
/// </summary>
[GeneratedCode("NSwag", "14.0.3.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
public interface IIBKRClient
{
    /// <summary>Acesws service</summary>
    IAceswsService Acesws { get; }

    /// <summary>Fyi service</summary>
    IFyiService Fyi { get; }

    /// <summary>Gw service</summary>
    IGwService Gw { get; }

    /// <summary>Hmds service</summary>
    IHmdsService Hmds { get; }

    /// <summary>Iserver service</summary>
    IIserverService Iserver { get; }

    /// <summary>Logout service</summary>
    ILogoutService Logout { get; }

    /// <summary>Md service</summary>
    IMdService Md { get; }

    /// <summary>OAuth service</summary>
    IOAuthService OAuth { get; }

    /// <summary>Pa service</summary>
    IPaService Pa { get; }

    /// <summary>Portfolio service</summary>
    IPortfolioService Portfolio { get; }

    /// <summary>Sso service</summary>
    ISsoService Sso { get; }

    /// <summary>Tickle service</summary>
    ITickleService Tickle { get; }

    /// <summary>Trsrv service</summary>
    ITrsrvService Trsrv { get; }

    /// <summary>Ws service</summary>
    IWsService Ws { get; }
}