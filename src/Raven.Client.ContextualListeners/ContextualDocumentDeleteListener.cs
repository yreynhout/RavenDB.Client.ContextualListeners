using System.Collections.Generic;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace Raven.Client.ContextualListeners
{
    public class ContextualDocumentDeleteListener<T> : IDocumentDeleteListener
        where T : AbstractDocumentDeleteListenerContext
    {
        public virtual void BeforeDelete(string key, object entityInstance, RavenJObject metadata)
        {
            Stack<object> context;
            if (CallContextLogicalStorage.GetContexts().TryGetValue(typeof(T), out context))
            {
                ((IDocumentDeleteListener) context.Peek()).BeforeDelete(key, entityInstance, metadata);
            }
        }
    }
}