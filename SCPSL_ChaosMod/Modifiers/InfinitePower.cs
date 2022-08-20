using ChaosMod.Modifiers;

public class InfinitePower : Base
{
	private string name = "Infinite Power";

	public override string GetName()
	{
		return name;
	}

	public override void Execute()
	{
		foreach (var tesla in Exiled.API.Features.TeslaGate.List)
		{
			tesla.ActivationTime = 0f;
			tesla.CooldownTime = 0;
		}
	}
	public override void RevertChanges()
	{
		foreach (var tesla in Exiled.API.Features.TeslaGate.List)
		{
			tesla.ActivationTime = 1f;
			tesla.CooldownTime = 1f;
		}
	}
}