using System;
using Raven.Client;
using Raven.Client.Embedded;

namespace Tests.Raven.Client.ContextualListeners
{
    public abstract class AbstractContextualDocumentListenerTests : IDisposable
    {
        private readonly EmbeddableDocumentStore _documentStore;

        protected AbstractContextualDocumentListenerTests()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                RunInMemory = true,
                UseEmbeddedHttpServer = false
            };
            _documentStore.Initialize();
        }

        protected DocumentStoreBase DocumentStore
        {
            get { return _documentStore; }
        }

        public virtual void Dispose()
        {
            _documentStore.Dispose();
        }
    }
}