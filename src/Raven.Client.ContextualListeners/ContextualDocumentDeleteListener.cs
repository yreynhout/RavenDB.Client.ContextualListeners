namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public class ContextualDocumentDeleteListener<T> : IDocumentDeleteListener
		where T : AbstractDocumentDeleteListenerContext
	{
		public virtual void BeforeDelete(string key, object entityInstance, RavenJObject metadata)
		{
			object context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentDeleteListener)context).BeforeDelete(key, entityInstance, metadata);
			}
		}
	}
}