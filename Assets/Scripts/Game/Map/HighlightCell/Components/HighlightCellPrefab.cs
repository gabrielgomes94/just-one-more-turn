using Unity.Entities;

namespace Game
{
    [GenerateAuthoringComponent]
    public struct HighlightCellPrefab : IComponentData
    {
        public Entity Value;
    }
}
