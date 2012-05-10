namespace Raven.Client.ContextualListeners
{
	using System;
	using System.Collections.Generic;

	public abstract class AbstractDocumentListenerContext : IDisposable
	{
		protected AbstractDocumentListenerContext()
		{
			var contexts = LocalStorageProvider.Get().Contexts;
			var type = GetType();
			if (!contexts.ContainsKey(type))
			{
				contexts.Add(type, new Stack<object>());
			}
			contexts[type].Push(this);
		}

		public void Dispose()
		{
			var contexts = LocalStorageProvider.Get().Contexts;
			var type = GetType();
			contexts[type].Pop();
			if(contexts[type].Count == 0)
			{
				contexts.Remove(type);
			}
		}
	}
}