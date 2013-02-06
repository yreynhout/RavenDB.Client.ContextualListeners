namespace Tests.Raven.Client.ContextualListeners
{
	using System;
	using System.Linq;
	using Tests.Raven.Client.ContextualListeners.Contexts;
	using Xunit;
	using global::Raven.Client;
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Client.Linq;

	public class ContextualDocumentQueryListenerTests : AbstractContextualDocumentListenerTests
	{
		public ContextualDocumentQueryListenerTests()
		{
			DocumentStore.RegisterListener(new ContextualDocumentQueryListener<QueryContext>());
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

			using (var context = new QueryContext())
			using (IDocumentSession session = DocumentStore.OpenSession())
			{
				session.Query<Doc>().Where(d => d.Name == "Name").Customize(c => c.WaitForNonStaleResultsAsOfLastWrite()).ToList();
				Assert.True(context.BeforeQueryExecutedCalled);
			}
		}

		[Fact]
		public void When_have_duplicate_context_Then_should_not_throw()
		{
			using (new QueryContext())
			{
				Assert.DoesNotThrow(() => new QueryContext());
			}
		}
	}

	public class HttpContextualDocumentQueryListenerTests : ContextualDocumentQueryListenerTests
	{
		private readonly IDisposable _request;

		public HttpContextualDocumentQueryListenerTests()
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