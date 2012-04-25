namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public class ContextualDocumentConversionListener<T> : IDocumentConversionListener
		where T : AbstractDocumentConversionListenerContext
	{
		public virtual void EntityToDocument(object entity, RavenJObject document, RavenJObject metadata)
		{
			object context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentConversionListener)context).EntityToDocument(entity, document, metadata);
			}
		}

		public virtual void DocumentToEntity(object entity, RavenJObject document, RavenJObject metadata)
		{
			object context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentConversionListener)context).DocumentToEntity(entity, document, metadata);
			}
		}
	}
}