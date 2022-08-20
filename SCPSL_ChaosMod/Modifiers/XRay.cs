using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
using Exiled.API.Enums;
public class XRay : Base
{
	private string name = "X-Ray";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.EnableEffect(EffectType.Visuals939, 60f);
		}
	}
	public override void RevertChanges()
	{
	}
}