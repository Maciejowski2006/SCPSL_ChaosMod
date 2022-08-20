using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
using UnityEngine;
public class SkinnyBois : Base
{
	private string name = "Skinny bois";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			player.Scale = new Vector3(.25f, 1, .25f);
		}
	}
	public override void RevertChanges()
	{
		foreach (var player in Player.List)
		{
			player.Scale = new Vector3(1f, 1, 1f);
		}
	}
}