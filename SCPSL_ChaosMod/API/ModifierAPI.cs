using System.Collections.Generic;
using ChaosMod.Modifiers;
using Exiled.API.Features;
using UnityEngine;

namespace ChaosMod.API
{
	public class ModifierAPI
	{
		#region Singleton
		
		private static ModifierAPI instance;
		private static readonly object _lock = new object();

		public static ModifierAPI Instance()
		{
			if (instance == null)
			{
				lock (_lock)
				{
					if (instance == null)
					{
						instance = new ModifierAPI();
					}
				}
			}
			return instance;
		}
		
		#endregion
		private List<Base> modifiers = new List<Base>();
		private Base oldModifier;
		public int forceNextModifier = -1;
		
		public ModifierAPI()
		{
			BypassForAll bypassForAll = new BypassForAll();
			Hitman hitman = new Hitman();
			SkinnyBois skinnyBois = new SkinnyBois();
			XRay xRay = new XRay();
			GhostParty ghostParty = new GhostParty();
			IAmSpeed iAmSpeed = new IAmSpeed();
			InfinitePower infinitePower = new InfinitePower();
			NinetyFourInSix ninetyFourInSix = new NinetyFourInSix();
			
			modifiers.Add(bypassForAll);
			modifiers.Add(hitman);
			modifiers.Add(skinnyBois);
			modifiers.Add(xRay);
			modifiers.Add(ghostParty);
			modifiers.Add(iAmSpeed);
			modifiers.Add(infinitePower);
			modifiers.Add(ninetyFourInSix);
		}
		private Base RollModifier()
		{
			// Roll new modifier
			int modifierIndex = Random.Range(0, modifiers.Count);
			Base currentModifier;
			
			// Check if forcemod is set to any number apart from -1
			if (forceNextModifier != -1)
			{
				currentModifier = modifiers[forceNextModifier];
				forceNextModifier = -1;
			}
			else if (ChaosMod.Instance.Config.forceMod != -1)
			{
				// Force a modifier with number from config
				currentModifier = modifiers[ChaosMod.Instance.Config.forceMod];
			}
			else
			{
				// Set a modifier rolled beforehand
				currentModifier = modifiers[modifierIndex];
			}
			
			oldModifier = currentModifier;

			return currentModifier;
		}
		public void NewModifier()
		{
			RemoveModifier();

			Base modifier = RollModifier();

			modifier.Execute();
			AnnounceNewModifier(modifier);
		}
		private void AnnounceNewModifier(Base modifier)
		{
			Log.Info($"New modifier: {modifier.GetName()}");
			Map.Broadcast(5, $"New modifier: {modifier.GetName()}");
		}
		public void RemoveModifier()
		{
			if (oldModifier != null)
			{
				oldModifier.RevertChanges();
			}
		}
	}
}