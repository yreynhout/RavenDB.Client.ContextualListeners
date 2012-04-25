namespace Tests.Raven.Client.ContextualListeners
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Doc
	{
		[DataMember]
		public string Id { get; set; }
	}
}