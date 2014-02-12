using Raven.Client;
using Raven.Client.ContextualListeners;

namespace Tests.Raven.Client.ContextualListeners.Contexts
{
    internal class QueryContext : AbstractDocumentQueryListenerContext
    {
        internal bool BeforeQueryExecutedCalled { get; private set; }

        protected override void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
        {
            BeforeQueryExecutedCalled = true;
        }
    }
}