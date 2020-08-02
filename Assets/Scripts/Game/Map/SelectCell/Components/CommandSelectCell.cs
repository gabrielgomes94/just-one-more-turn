using Unity.Entities;

namespace Game
{
    public struct CommandSelectCell : IComponentData
    {
        public bool select;
    }
}
