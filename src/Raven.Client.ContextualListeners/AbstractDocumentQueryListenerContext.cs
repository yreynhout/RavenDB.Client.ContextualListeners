namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;

	public abstract class AbstractDocumentQueryListenerContext : AbstractDocumentListenerContext, IDocumentQueryListener
	{
		void IDocumentQueryListener.BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
		{
			BeforeQueryExecuted(queryCustomization);
		}

		protected abstract void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization);
	}
}