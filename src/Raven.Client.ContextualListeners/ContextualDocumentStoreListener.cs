namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public class ContextualDocumentStoreListener<T> : IDocumentStoreListener
		where T : AbstractDocumentStoreListenerContext
	{
		public virtual bool BeforeStore(string key, object entityInstance, RavenJObject metadata)
		{
			object context;
			if(!LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				return false;
			}
			return ((IDocumentStoreListener)context).BeforeStore(key, entityInstance, metadata);
		}

		public virtual void AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
			object context;
			if(LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentStoreListener)context).AfterStore(key, entityInstance, metadata);
			}
		}
	}
}