namespace Raven.Client.ContextualListeners
{
	using System;
	using System.Collections.Generic;

	internal class ThreadLocalStorage : AbstractLocalStorage
	{
		[ThreadStatic]
		private static new Dictionary<Type, Stack<object>> ContextsThreadStatic;

		protected override Dictionary<Type, Stack<object>> GetContexts()
		{
			return ContextsThreadStatic ?? (ContextsThreadStatic = new Dictionary<Type,  Stack<object>>());
		}
	}
}