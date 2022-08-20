using System;
using Player = Exiled.API.Features.Player;
using ChaosMod.Modifiers;
using CommandSystem.Commands.RemoteAdmin;
using Exiled.API.Enums;
using Exiled.API.Features.Items;
using InventorySystem.Items;
using InventorySystem.Items.Firearms;

public class Hitman : Base
{
	private string name = "Hitmen";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var player in Player.List)
		{
			ItemType com = ItemType.GunCOM15;
			Item.Create(com).Give(player);
		}
	}
	public override void RevertChanges()
	{
	}
}