using System;
using System.Collections.Generic;

namespace Raven.Client.ContextualListeners
{
    public abstract class AbstractDocumentListenerContext : IDisposable
    {
        protected AbstractDocumentListenerContext()
        {
            Dictionary<Type, Stack<object>> contexts = CallContextLogicalStorage.GetContexts();
            Type type = GetType();
            if (!contexts.ContainsKey(type))
            {
                contexts.Add(type, new Stack<object>());
            }
            contexts[type].Push(this);
        }

        public void Dispose()
        {
            Dictionary<Type, Stack<object>> contexts = CallContextLogicalStorage.GetContexts();
            Type type = GetType();
            contexts[type].Pop();
            if (contexts[type].Count == 0)
            {
                contexts.Remove(type);
            }
        }
    }
}