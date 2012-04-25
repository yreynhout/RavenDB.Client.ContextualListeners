namespace Tests.Raven.Client.ContextualListeners.Contexts
{
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Json.Linq;

	internal class DeleteContext : AbstractDocumentDeleteListenerContext
	{
		internal bool BeforeDeleteCalled { get; private set; }

		protected override void BeforeDelete(string key, object entityInstance, RavenJObject metadata)
		{
			BeforeDeleteCalled = true;
		}
	}
}