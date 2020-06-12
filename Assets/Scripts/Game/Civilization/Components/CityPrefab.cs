using System.Collections;
using Unity.Entities;

namespace Game
{
    [GenerateAuthoringComponent]
    public struct CityPrefab : IComponentData
    {
        public Entity Value;
    }
}
