namespace Raven.Client.ContextualListeners
{
    using Json.Linq;
    using Listeners;

    public abstract class AbstractDocumentConversionListenerContext : AbstractDocumentListenerContext,
                                                                      IDocumentConversionListener
    {
        void IDocumentConversionListener.EntityToDocument(string key, object entity, RavenJObject document,
                                                          RavenJObject metadata)
        {
            EntityToDocument(key, entity, document, metadata);
        }

        void IDocumentConversionListener.DocumentToEntity(string key, object entity, RavenJObject document,
                                                          RavenJObject metadata)
        {
            DocumentToEntity(key, entity, document, metadata);
        }

        protected abstract void EntityToDocument(string key, object entity, RavenJObject document, RavenJObject metadata);

        protected abstract void DocumentToEntity(string key, object entity, RavenJObject document, RavenJObject metadata);
    }
}