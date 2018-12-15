
namespace SkySeekers.AbilitySystem
{
    public abstract class ModHandler
    {
        public abstract void AddTo(EventHandler handler);

        public abstract void RemoveFrom(EventHandler handler);
    }
}
