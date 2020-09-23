using Unity.Entities;

namespace Game
{
    public struct CommandSelectUnit : IComponentData
    {
        public Entity entity;
    }
}
