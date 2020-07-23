using System.Collections;
using Unity.Entities;

namespace Hex
{
    [GenerateAuthoringComponent]
    public struct HighlightCellPrefab : IComponentData
    {
        public Entity Value;
    }
}
