using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
public class NinetyFourInSix : Base
{
	private string name = "94 in 6...";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.Health = 1;
			player.ArtificialHealth = 0;
		}
	}
	public override void RevertChanges()
	{
		foreach (var player in Player.List)
		{
			player.Health = player.MaxHealth;
		}
	}
}