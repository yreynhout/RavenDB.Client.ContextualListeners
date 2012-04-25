namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public abstract class AbstractDocumentConversionListenerContext : AbstractDocumentListenerContext, IDocumentConversionListener
	{
		void IDocumentConversionListener.EntityToDocument(object entity, RavenJObject document, RavenJObject metadata)
		{
			EntityToDocument(entity, document, metadata);
		}

		void IDocumentConversionListener.DocumentToEntity(object entity, RavenJObject document, RavenJObject metadata)
		{
			DocumentToEntity(entity, document, metadata);
		}

		protected abstract void EntityToDocument(object entity, RavenJObject document, RavenJObject metadata);

		protected abstract void DocumentToEntity(object entity, RavenJObject document, RavenJObject metadata);
	}
}