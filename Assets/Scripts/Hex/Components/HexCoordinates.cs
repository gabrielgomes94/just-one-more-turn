using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Hex {
    public struct HexCoordinates : IComponentData
    {
        public int X, Y, Z;
    }
}
