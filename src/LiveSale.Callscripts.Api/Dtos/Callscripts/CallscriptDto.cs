namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class CallscriptDto : CallscriptShared
	{
		public string Id { get; init; } = null!;

		public bool IsDeleted { get; set; }

		public State State { get; set; } = State.Draft;
	}
}