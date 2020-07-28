using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public struct CommandSelectCell : IComponentData
    {
        public bool select;
    }
}
