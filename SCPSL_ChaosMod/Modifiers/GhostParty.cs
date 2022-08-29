using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
using Exiled.API.Enums;
public class GhostParty : Base
{
	private string name = "Ghost Party";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.EnableEffect(EffectType.Invisible, ChaosMod.ChaosMod.Instance.Config.delay);
		}
	}
	public override void RevertChanges()
	{
	}
}