namespace Raven.Client.ContextualListeners
{
	using System.Collections.Generic;
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public class ContextualDocumentConversionListener<T> : IDocumentConversionListener
		where T : AbstractDocumentConversionListenerContext
	{
		public virtual void EntityToDocument(object entity, RavenJObject document, RavenJObject metadata)
		{
			Stack<object> context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentConversionListener)context.Peek()).EntityToDocument(entity, document, metadata);
			}
		}

		public virtual void DocumentToEntity(object entity, RavenJObject document, RavenJObject metadata)
		{
			Stack<object> context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentConversionListener)context.Peek()).DocumentToEntity(entity, document, metadata);
			}
		}
	}
}