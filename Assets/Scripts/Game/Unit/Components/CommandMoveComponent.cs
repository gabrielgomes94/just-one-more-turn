using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public struct CommandMoveComponent : IComponentData
    {
        public int3 moveToCoordinates;

        public int3 moveFromCoordinates;
    }
}
