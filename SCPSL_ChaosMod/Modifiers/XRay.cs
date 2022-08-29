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
			if (player.Role != RoleType.Scp93953 || player.Role != RoleType.Scp93989)
			{
				player.EnableEffect(EffectType.Visuals939, ChaosMod.ChaosMod.Instance.Config.delay);
			}
		}
	}
	public override void RevertChanges()
	{
	}
}