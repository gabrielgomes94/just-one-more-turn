using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public struct CreateUnitEventComponent : IComponentData
    {
        public float3 position;
    }
}
