using Raven.Client.ContextualListeners;
using Raven.Json.Linq;

namespace Tests.Raven.Client.ContextualListeners.Contexts
{
    internal class DeleteContext : AbstractDocumentDeleteListenerContext
    {
        internal bool BeforeDeleteCalled { get; private set; }

        protected override void BeforeDelete(string key, object entityInstance, RavenJObject metadata)
        {
            BeforeDeleteCalled = true;
        }
    }
}