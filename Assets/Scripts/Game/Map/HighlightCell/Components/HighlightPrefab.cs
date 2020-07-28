using System.Collections;
using Unity.Entities;

namespace Game
{
    [GenerateAuthoringComponent]
    public struct HighlightPrefab : IComponentData
    {
        public Entity Value;
    }
}
