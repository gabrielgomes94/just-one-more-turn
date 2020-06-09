using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public class CreateUnitEventArgs : EventArgs
    {
        public int3 Coordinates { get; set; }
    }
}
