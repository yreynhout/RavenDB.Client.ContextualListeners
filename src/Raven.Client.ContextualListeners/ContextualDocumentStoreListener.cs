﻿namespace Raven.Client.ContextualListeners
{
	using System.Collections.Generic;
	using Raven.Client.Listeners;
	using Raven.Json.Linq;

	public class ContextualDocumentStoreListener<T> : IDocumentStoreListener
		where T : AbstractDocumentStoreListenerContext
	{
		public virtual bool BeforeStore(string key, object entityInstance, RavenJObject metadata)
		{
			Stack<object> context;
			if(!LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				return false;
			}
			return ((IDocumentStoreListener)context.Peek()).BeforeStore(key, entityInstance, metadata);
		}

		public virtual void AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
			Stack<object> context;
			if(LocalStorageProvider.Get().Contexts.TryGetValue(typeof(T), out context))
			{
				((IDocumentStoreListener)context.Peek()).AfterStore(key, entityInstance, metadata);
			}
		}
	}
}