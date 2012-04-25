namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public abstract class AbstractDocumentDeleteListenerContext : AbstractDocumentListenerContext, IDocumentDeleteListener
	{
		void IDocumentDeleteListener.BeforeDelete(string key, object entityInstance, RavenJObject metadata)
		{
			BeforeDelete(key, entityInstance, metadata);
		}

		protected abstract void BeforeDelete(string key, object entityInstance, RavenJObject metadata);
	}
}