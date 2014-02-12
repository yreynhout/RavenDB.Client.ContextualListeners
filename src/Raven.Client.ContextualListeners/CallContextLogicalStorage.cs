using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Raven.Client.ContextualListeners
{
    internal static class CallContextLogicalStorage
    {
        private const string Key = "Raven.Client.ContextualListeners";

        internal static Dictionary<Type, Stack<object>> GetContexts()
        {
            var contexts = CallContext.LogicalGetData(Key) as Dictionary<Type, Stack<object>>;
            if (CallContext.LogicalGetData(Key) != null) return contexts;
            contexts = new Dictionary<Type, Stack<object>>();
            CallContext.LogicalSetData(Key, contexts);
            return contexts;
        }
    }
}