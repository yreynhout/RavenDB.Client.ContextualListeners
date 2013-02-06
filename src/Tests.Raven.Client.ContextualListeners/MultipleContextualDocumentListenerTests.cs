namespace Tests.Raven.Client.ContextualListeners
{
	using System.Linq;
	using Tests.Raven.Client.ContextualListeners.Contexts;
	using Xunit;
	using global::Raven.Client;
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Client.Linq;

	public class MultipleContextualDocumentListenerTests : AbstractContextualDocumentListenerTests
	{
		public MultipleContextualDocumentListenerTests()
		{
			DocumentStore.RegisterListener(new ContextualDocumentDeleteListener<DeleteContext>());
			DocumentStore.RegisterListener(new ContextualDocumentStoreListener<StoreContext>());
			DocumentStore.RegisterListener(new ContextualDocumentQueryListener<QueryContext>());
			DocumentStore.RegisterListener(new ContextualDocumentConversionListener<ConversionContext>());
		}

		[Fact]
		public void Should_use_context()
		{
			using (IDocumentSession session = DocumentStore.OpenSession())
			{
				var doc = new Doc { Id = "Doc", Name = "Name"};
				session.Store(doc);
				session.SaveChanges();
			}

			using (var storeContext = new StoreContext())
			using (var deleteContext = new DeleteContext())
			using (var queryContext = new QueryContext())
			using (var conversionContext = new ConversionContext())
			using (IDocumentSession session = DocumentStore.OpenSession())
			{
				var doc1 = new Doc { Id = "Doc1" };
				session.Store(doc1);
				var doc2 = session.Query<Doc>().Where(d => d.Name == "Name").Customize(c => c.WaitForNonStaleResults()).Single();
				session.Delete(doc2);
				session.SaveChanges();
				Assert.True(storeContext.AfterStoreCalled);
				Assert.True(storeContext.BeforeStoreCalled);
				Assert.True(deleteContext.BeforeDeleteCalled);
				Assert.True(queryContext.BeforeQueryExecutedCalled);
				Assert.True(conversionContext.DocumentToEntityCalled);
				Assert.True(conversionContext.EntityToDocumentCalled);
			}
		}
	}
}