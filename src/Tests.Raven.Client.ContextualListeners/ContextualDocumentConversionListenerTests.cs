namespace Tests.Raven.Client.ContextualListeners
{
	using System;
	using Tests.Raven.Client.ContextualListeners.Contexts;
	using Tests.Raven.Client.ContextualListeners.HaackHttpSimulator;
	using Xunit;
	using global::Raven.Client;
	using global::Raven.Client.ContextualListeners;

	public class ContextualDocumentConversionListenerTests : AbstractContextualDocumentListenerTests
	{
		public ContextualDocumentConversionListenerTests()
		{
			DocumentStore.RegisterListener(new ContextualDocumentConversionListener<ConversionContext>());
		}

		[Fact]
		public void Should_use_context()
		{
			using(var context = new ConversionContext())
			{
				using(IDocumentSession session = DocumentStore.OpenSession())
				{
					var doc = new Doc {Id = "Doc"};
					session.Store(doc);
					session.SaveChanges();
					Assert.True(context.EntityToDocumentCalled);
				}
			}

			using(var context = new ConversionContext())
			{
				using(IDocumentSession session = DocumentStore.OpenSession())
				{
					session.Load<Doc>("Doc");
					Assert.True(context.DocumentToEntityCalled);
				}
			}
		}

		[Fact]
		public void When_have_duplicate_context_Then_should_not_throw()
		{
			using(new ConversionContext())
			{
				Assert.DoesNotThrow(() => new ConversionContext());
			}
		}
	}

	public class HttpContextContextualDocumentConversionListenerTests : ContextualDocumentConversionListenerTests
	{
		private readonly IDisposable _request;

		public HttpContextContextualDocumentConversionListenerTests()
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