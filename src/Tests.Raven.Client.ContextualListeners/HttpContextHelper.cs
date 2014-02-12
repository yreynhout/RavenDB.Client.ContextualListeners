using System;
using Tests.Raven.Client.ContextualListeners.HaackHttpSimulator;

namespace Tests.Raven.Client.ContextualListeners
{
    internal static class HttpContextHelper
    {
        internal static IDisposable SimulateRequest()
        {
            var httpSimulator = new HttpSimulator("/webapp", "c:\\inetpub\\wwwroot\\webapp\\");
            httpSimulator.SimulateRequest(new Uri("http://localhost/default.aspx"));
            return httpSimulator;
        }
    }
}