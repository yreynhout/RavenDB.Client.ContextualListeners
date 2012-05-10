namespace Raven.Client.ContextualListeners
{
	using System.Collections.Generic;
	using Raven.Client.Listeners;

	public class ContextualDocumentQueryListener<T> : IDocumentQueryListener
		where T : AbstractDocumentQueryListenerContext
	{
		public virtual void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
		{
			Stack<object> context;
			if (LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentQueryListener)context.Peek()).BeforeQueryExecuted(queryCustomization);
			}
		}
	}
}