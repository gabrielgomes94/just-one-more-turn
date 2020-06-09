using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public class CreateUnitEventArgs : EventArgs
    {
        public float3 position { get; set; }
        public int3 Coordinates { get; set; }
    }
}
