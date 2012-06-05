namespace Tests.Raven.Client.ContextualListeners
{
	using global::Raven.Client.ContextualListeners;
	using global::Raven.Client.Document;
	using global::Raven.Client.Embedded;
	using global::Raven.Json.Linq;

	public class Sample
	{
		public class UserNameContext : AbstractDocumentStoreListenerContext
		{
			private readonly string _userName;

			public UserNameContext(string userName)
			{
				_userName = userName;
			}

			protected override void AfterStore(string key, object entityInstance, RavenJObject metadata)
			{}

			protected override bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
			{
				metadata.Add("UserName", RavenJToken.FromObject(_userName));
				return false; //return true if you modify the entityInstance
			}
		}

		public class MyApp
		{
			public MyApp()
			{
				var documentStore = new DocumentStore()
				{
					Url = "http://server"
				};

				documentStore.RegisterListener(new ContextualDocumentStoreListener<UserNameContext>()); // can be called after .Initialize(), doesn't matter
				documentStore.Initialize();

				using(new UserNameContext("Damian Hickey"))
				using(var session = documentStore.OpenSession())
				{
					session.Store(new Doc());
					session.SaveChanges();
				}
			}
		}
	}
}