using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
using Exiled.API.Enums;
public class IAmSpeed : Base
{
	private string name = "I am speed";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.EnableEffect(EffectType.Scp207, ChaosMod.ChaosMod.Instance.Config.delay);
		}
	}
	public override void RevertChanges()
	{
		foreach (var player in Player.List)
		{
			player.DisableEffect(EffectType.Scp207);
		}
	}
}