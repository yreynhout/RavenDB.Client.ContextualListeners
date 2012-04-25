namespace Raven.Client.ContextualListeners
{
	using System;
	using System.Collections.Generic;

	internal class ThreadLocalStorage : AbstractLocalStorage
	{
		[ThreadStatic]
		private static Dictionary<Type, object> ContextsThreadStatic;

		protected override Dictionary<Type, object> GetContexts()
		{
			return ContextsThreadStatic ?? (ContextsThreadStatic = new Dictionary<Type, object>());
		}
	}
}