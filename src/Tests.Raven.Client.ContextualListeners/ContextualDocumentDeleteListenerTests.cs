using System;
using Raven.Client;
using Raven.Client.ContextualListeners;
using Tests.Raven.Client.ContextualListeners.Contexts;
using Xunit;

namespace Tests.Raven.Client.ContextualListeners
{
    public class ContextualDocumentDeleteListenerTests : AbstractContextualDocumentListenerTests
    {
        public ContextualDocumentDeleteListenerTests()
        {
            DocumentStore.RegisterListener(new ContextualDocumentDeleteListener<DeleteContext>());
        }

        [Fact]
        public void Should_use_context()
        {
            using (IDocumentSession session = DocumentStore.OpenSession())
            {
                var doc = new Doc {Id = "Doc"};
                session.Store(doc);
                session.SaveChanges();
            }

            using (var context = new DeleteContext())
            using (IDocumentSession session = DocumentStore.OpenSession())
            {
                var doc = session.Load<Doc>("Doc");
                session.Delete(doc);
                session.SaveChanges();
                Assert.True(context.BeforeDeleteCalled);
            }
        }

        [Fact]
        public void When_have_duplicate_context_Then_should_not_throw()
        {
            using (new DeleteContext())
            {
                Assert.DoesNotThrow(() => new DeleteContext().Dispose());
            }
        }
    }
}