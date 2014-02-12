using Raven.Client.ContextualListeners;
using Raven.Json.Linq;

namespace Tests.Raven.Client.ContextualListeners.Contexts
{
    internal class ConversionContext : AbstractDocumentConversionListenerContext
    {
        internal bool DocumentToEntityCalled { get; private set; }

        internal bool EntityToDocumentCalled { get; private set; }

        protected override void DocumentToEntity(string key, object entity, RavenJObject document, RavenJObject metadata)
        {
            DocumentToEntityCalled = true;
        }

        protected override void EntityToDocument(string key, object entity, RavenJObject document, RavenJObject metadata)
        {
            EntityToDocumentCalled = true;
        }
    }
}