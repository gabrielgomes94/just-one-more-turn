using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Hex {
    public struct HexCoordinatesComponent : IComponentData
    {
        public int X, Y, Z;
    }
}
