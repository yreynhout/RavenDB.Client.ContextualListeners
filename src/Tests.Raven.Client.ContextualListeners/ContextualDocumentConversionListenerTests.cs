using System;
using System.Threading.Tasks;
using Raven.Client.ContextualListeners;
using Tests.Raven.Client.ContextualListeners.Contexts;
using Xunit;

namespace Tests.Raven.Client.ContextualListeners
{
    public class ContextualDocumentConversionListenerTests : AbstractContextualDocumentListenerTests
    {
        public ContextualDocumentConversionListenerTests()
        {
            DocumentStore.RegisterListener(new ContextualDocumentConversionListener<ConversionContext>());
        }

        [Fact]
        public async Task Should_use_context_async()
        {
            using (var context = new ConversionContext())
            {
                using (var session = DocumentStore.OpenAsyncSession())
                {
                    var doc = new Doc {Id = "Doc"};
                    await session.StoreAsync(doc);
                    await session.SaveChangesAsync();
                    Assert.True(context.EntityToDocumentCalled);
                }
            }

            using (var context = new ConversionContext())
            {
                using (var session = DocumentStore.OpenAsyncSession())
                {
                    await session.LoadAsync<Doc>("Doc");
                    Assert.True(context.DocumentToEntityCalled);
                }
            }
        }

        [Fact]
        public void Should_use_context()
        {
            using (var context = new ConversionContext())
            {
                using (var session = DocumentStore.OpenSession())
                {
                    var doc = new Doc { Id = "Doc" };
                    session.Store(doc);
                    session.SaveChanges();
                    Assert.True(context.EntityToDocumentCalled);
                }
            }

            using (var context = new ConversionContext())
            {
                using (var session = DocumentStore.OpenSession())
                {
                    session.Load<Doc>("Doc");
                    Assert.True(context.DocumentToEntityCalled);
                }
            }
        }

        [Fact]
        public void When_have_duplicate_context_Then_should_not_throw()
        {
            using (new ConversionContext())
            {
                Assert.DoesNotThrow(() => new ConversionContext().Dispose());
            }
        }
    }
}