namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public abstract class AbstractDocumentStoreListenerContext : AbstractDocumentListenerContext, IDocumentStoreListener
	{
		bool IDocumentStoreListener.BeforeStore(string key, object entityInstance, RavenJObject metadata)
		{
			return BeforeStore(key, entityInstance, metadata);
		}

		void IDocumentStoreListener.AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
			AfterStore(key, entityInstance, metadata);
		}

		protected abstract void AfterStore(string key, object entityInstance, RavenJObject metadata);

		protected abstract bool BeforeStore(string key, object entityInstance, RavenJObject metadata);
	}
}