using Unity.Entities;
using UnityEngine;

namespace Hex.Cell {
    public struct ColorComponent : IComponentData
    {
        public Color Value;
    }
}
