namespace Tests.Raven.Client.ContextualListeners
{
	using System;
	using Tests.Raven.Client.ContextualListeners.Contexts;
	using Xunit;
	using global::Raven.Client;
	using global::Raven.Client.ContextualListeners;

	public class ContextualDocumentStoreListenerTests : AbstractContextualDocumentListenerTests
	{
		public ContextualDocumentStoreListenerTests()
		{
			DocumentStore.RegisterListener(new ContextualDocumentStoreListener<StoreContext>());
		}

		[Fact]
		public void Should_use_context()
		{
			using(var context = new StoreContext())
			using(IDocumentSession session = DocumentStore.OpenSession())
			{
				var doc = new Doc {Id = "Doc"};
				session.Store(doc);
				session.SaveChanges();
				Assert.True(context.BeforeStoreCalled);
				Assert.True(context.AfterStoreCalled);
			}
		}

		[Fact]
		public void When_have_duplicate_context_Then_should_throw()
		{
			using(new StoreContext())
			{
				Assert.Throws<ArgumentException>(() => new StoreContext());
			}
		}

		[Fact]
		public void When_no_context_Then_should_not_throw()
		{
			using (IDocumentSession session = DocumentStore.OpenSession())
			{
				var doc = new Doc { Id = "Doc" };
				session.Store(doc);
				Assert.DoesNotThrow(() => session.SaveChanges());
			}
		}
	}

	public class HttpContextualDocumentStoreListenerTests : ContextualDocumentStoreListenerTests
	{
		private readonly IDisposable _request;

		public HttpContextualDocumentStoreListenerTests()
		{
			_request = HttpContextHelper.SimulateRequest();
		}

		public override void Dispose()
		{
			_request.Dispose();
			base.Dispose();
		}
	}
}