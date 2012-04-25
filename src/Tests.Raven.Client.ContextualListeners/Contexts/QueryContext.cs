namespace Tests.Raven.Client.ContextualListeners.Contexts
{
	using global::Raven.Client;
	using global::Raven.Client.ContextualListeners;

	internal class QueryContext : AbstractDocumentQueryListenerContext
	{
		internal bool BeforeQueryExecutedCalled { get; private set; }

		protected override void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
		{
			BeforeQueryExecutedCalled = true;
		}
	}
}