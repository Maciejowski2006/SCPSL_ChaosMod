using System.Collections.Generic;
using ChaosMod.API;
using Exiled.Events.EventArgs;
using MEC;

namespace ChaosMod.Handlers
{
	public class Server
	{
		private bool didRoundEnded;
		public void OnRoundStarted()
		{
			Timing.RunCoroutine(ChaosLoop());
		}
		public void OnRoundEnded()
		{
			didRoundEnded = true;
		}
		public IEnumerator<float> ChaosLoop()
		{
			
			ModifierAPI modifierAPI = new ModifierAPI();

			while (!didRoundEnded)
			{
				yield return Timing.WaitForSeconds(ChaosMod.Instance.Config.delay);
				
				modifierAPI.NewModifier();
			}
			modifierAPI.RemoveModifier();
			didRoundEnded = false;
		}
	}
}
