using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
public class SkinnyBois : Base
{
	private string name = "Who needs keycards anyway?";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.IsBypassModeEnabled = true;
		}
	}
	public override void RevertChanges()
	{
		foreach (var player in Player.List)
		{
			player.IsBypassModeEnabled = false;
		}
	}
}