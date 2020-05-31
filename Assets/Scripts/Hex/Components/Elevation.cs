using Unity.Entities;
using UnityEngine;

namespace Hex {
    public struct Elevation : IComponentData
    {
        public int Value;

        public const float elevationStep = 5f;
    }
}
