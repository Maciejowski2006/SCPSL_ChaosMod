namespace ChaosMod.Modifiers
{
	public abstract class Base
	{
		private string name;
		public virtual string GetName()
		{
			return name;
		}
		public abstract void Execute();
		public abstract void RevertChanges();
	}
}
