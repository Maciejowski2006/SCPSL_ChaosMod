using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ChaosMod
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		
		[Description("This sets the wait time between new modifiers")]
		public float delay { get; set; } = 60f;

		[Description("Force a selected modification to always be rolled:\n" +
		             " #  -1 - don't force\n" +
		             " #   0 - Who needs keycards anyway\n" +
		             " #   1 - Hitmen\n" +
		             " #   2 - Skinny Bois\n" +
		             " #   3 - X-Ray\n" +
		             " #   4 - Ghost Party\n" +
		             " #   5 - I am speed\n" +
		             " #   6 - Infinite power\n" +
		             " #   7 - 94 in 6")]
		public int forceMod { get; set; } = -1;
	}
}
