namespace Tests.Raven.Client.ContextualListeners.Contexts
{
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Json.Linq;

	internal class StoreContext : AbstractDocumentStoreListenerContext
	{
		internal bool BeforeStoreCalled { get; private set; }

		internal bool AfterStoreCalled { get; private set; }

		protected override bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
		{
			BeforeStoreCalled = true;
			return false;
		}

		protected override void AfterStore(string key, object entityInstance, RavenJObject metadata)
		{
			AfterStoreCalled = true;
		}
	}
}