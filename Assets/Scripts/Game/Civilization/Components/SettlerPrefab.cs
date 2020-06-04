using System.Collections;
using Unity.Entities;

namespace Game
{
    [GenerateAuthoringComponent]
    public struct SettlerPrefab : IComponentData
    {
        public Entity Value;
    }
}
