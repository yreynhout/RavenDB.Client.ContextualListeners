namespace Tests.Raven.Client.ContextualListeners.Contexts
{
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Json.Linq;

	internal class ConversionContext : AbstractDocumentConversionListenerContext
	{
		internal bool DocumentToEntityCalled { get; private set; }

		internal bool EntityToDocumentCalled { get; private set; }

		protected override void DocumentToEntity(object entity, RavenJObject document, RavenJObject metadata)
		{
			DocumentToEntityCalled = true;
		}

		protected override void EntityToDocument(object entity, RavenJObject document, RavenJObject metadata)
		{
			EntityToDocumentCalled = true;
		}
	}
}