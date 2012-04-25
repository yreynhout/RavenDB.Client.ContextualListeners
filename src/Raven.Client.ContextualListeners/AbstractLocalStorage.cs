namespace Raven.Client.ContextualListeners
{
	using System;
	using System.Collections.Generic;

	internal abstract class AbstractLocalStorage
	{
		public Dictionary<Type, object> Contexts
		{
			get
			{
				return GetContexts();
			}
		}

		protected abstract Dictionary<Type, object> GetContexts();
	}
}