using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace GameInput
{
    public struct MouseInput : IComponentData
    {
        public int primaryAction;
        public int secondaryAction;
        public float3 mousePosition;
    }
}
