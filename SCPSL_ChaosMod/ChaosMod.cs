using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace ChaosMod
{
	public class ChaosMod : Plugin<Config>
	{
		private static readonly Lazy<ChaosMod> LazyInstance = new Lazy<ChaosMod>(() => new ChaosMod());
		public static ChaosMod Instance => LazyInstance.Value;
		private ChaosMod() {}
		public override PluginPriority Priority { get; } = PluginPriority.Medium;

		private Handlers.Player player;
		private Handlers.Server server;

		public override void OnEnabled() => RegisterEvents();
		public override void OnDisabled() => UnregisterEvents();


		public void RegisterEvents()
		{
			player = new Handlers.Player();
			server = new Handlers.Server();

			Server.RoundStarted += server.OnRoundStarted;
			Server.RestartingRound += server.OnRoundEnded;
		}
		public void UnregisterEvents()
		{
			Server.RoundStarted -= server.OnRoundStarted;

			player = null;
			server = null;
		}
	}
}
