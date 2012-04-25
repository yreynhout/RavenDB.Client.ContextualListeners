namespace Raven.Client.ContextualListeners
{
	using System;
	using System.Collections.Generic;
	using System.Web;

	internal class HttpContextLocalStorage : AbstractLocalStorage
	{
		protected override Dictionary<Type, object> GetContexts()
		{
			const string key = "ContextualListenersContexts";
			if(HttpContext.Current.Items[key] == null)
			{
				HttpContext.Current.Items.Add(key, new Dictionary<Type, object>());
			}
			return (Dictionary<Type, object>)HttpContext.Current.Items[key];
		}
	}
}