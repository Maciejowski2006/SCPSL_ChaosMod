using System;
using System.Globalization;
using ChaosMod.API;
using CommandSystem;
using Exiled.Events.Handlers;
using Server = Exiled.API.Features.Server;
namespace ChaosMod.Commands
{
	[CommandHandler(typeof(RemoteAdminCommandHandler))]
	public class ForceNextModifier : ICommand
	{
		public string Command { get; } = "forcenextmodifier";
		public string[] Aliases { get; } = { "forcenextmod", "fnm", "forcemod", "forcenext", "nextmod", "next" };
		public string Description { get; } = "Forces a specified modifier next time it's rolled. Usage: \"forcenextmodifier <modifier-id>\" where <modifier-id> is an index of a modifier. Indexes of modifiers can be found in EXILED config.";

		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			string arg = arguments.Array[1];
			int modID;
			
			if (!int.TryParse(arg, out modID))
			{
				response = "Provided argument(modifier-id) is not a number";
				return false;
			}
			if (arguments.Count != 1)
			{
				response = "This command requires one argument(modifier-id)";
				return false;
			}
			if (modID <= -1 || modID >= 8)
			{
				response = "Argument not in range (pick from 0 to 8)";
				return false;
			}

			ModifierAPI modifierAPI = ModifierAPI.Instance();
			modifierAPI.forceNextModifier = modID;
			response = $"Modifier with ID {modID} will be a next modifier";
			
			return true;
		}
	}
}
