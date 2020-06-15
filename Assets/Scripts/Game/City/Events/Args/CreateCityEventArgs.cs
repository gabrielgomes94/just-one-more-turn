using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Game
{
    public class CreateCityEventArgs : EventArgs
    {
        public int3 Coordinates;

        public int CivId;
    }
}
