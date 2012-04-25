namespace Raven.Client.ContextualListeners
{
	using Raven.Client.Listeners;

	public class ContextualDocumentQueryListener<T> : IDocumentQueryListener
		where T : AbstractDocumentQueryListenerContext
	{
		public virtual void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
		{
			object context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentQueryListener)context).BeforeQueryExecuted(queryCustomization);
			}
		}
	}
}