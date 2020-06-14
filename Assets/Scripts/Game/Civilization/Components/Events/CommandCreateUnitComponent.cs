using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public struct CommandCreateUnitComponent : IComponentData
    {
        public int3 Coordinates;
    }
}