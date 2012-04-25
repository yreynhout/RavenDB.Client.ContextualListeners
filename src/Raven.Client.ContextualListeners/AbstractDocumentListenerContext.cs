namespace Raven.Client.ContextualListeners
{
	using System;

	public abstract class AbstractDocumentListenerContext : IDisposable
	{
		protected AbstractDocumentListenerContext()
		{
			LocalStorageProvider.Get().Contexts.Add(GetType(), this);
		}

		public void Dispose()
		{
			LocalStorageProvider.Get().Contexts.Remove(GetType());
		}
	}
}