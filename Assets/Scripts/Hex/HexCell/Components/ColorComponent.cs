using Unity.Entities;
using UnityEngine;

namespace Hex {
    public struct ColorComponent : IComponentData
    {
        public Color Value;
    }
}
