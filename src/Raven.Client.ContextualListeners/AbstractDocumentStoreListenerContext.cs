namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public abstract class AbstractDocumentStoreListenerContext : AbstractDocumentListenerContext, IDocumentStoreListener
	{
		bool IDocumentStoreListener.BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
		{
			return BeforeStore(key, entityInstance, metadata, original);
		}

		void IDocumentStoreListener.AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
			AfterStore(key, entityInstance, metadata);
		}

		protected abstract void AfterStore(string key, object entityInstance, RavenJObject metadata);

		protected abstract bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original);
	}
}