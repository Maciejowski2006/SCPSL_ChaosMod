using System.Collections.Generic;
using ChaosMod.Modifiers;
using Exiled.API.Features;
using UnityEngine;

namespace ChaosMod.API
{
	public class ModifierAPI
	{
		public List<Base> modifiers = new List<Base>();
		private Base oldModifier = null;
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
		public void GenerateNewModifier()
		{
			RemoveModifier();
			
			// Roll new modifier
			int modifierIndex = Random.Range(0, modifiers.Count);
			Base currentModifier;
			
			// Check if forcemod is set to any number apart from -1
			if (ChaosMod.Instance.Config.forceMod != -1)
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
			
			currentModifier.Execute();
			AnnounceNewModifier(currentModifier);
		}
		public void AnnounceNewModifier(Base modifier)
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