
namespace SkySeekers.AbilitySystem
{
    public abstract class ModHandler
    {
        public abstract void AddTo(EventHandlerObject handler);

        public abstract void RemoveFrom(EventHandlerObject handler);
    }
}
