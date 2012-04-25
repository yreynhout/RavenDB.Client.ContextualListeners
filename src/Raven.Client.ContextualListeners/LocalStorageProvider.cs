namespace Raven.Client.ContextualListeners
{
	using System.Web;

	internal static class LocalStorageProvider
	{
		public static AbstractLocalStorage Get()
		{
			if(HttpContext.Current != null)
			{
				return new HttpContextLocalStorage();
			}
			return new ThreadLocalStorage();
		}
	}
}