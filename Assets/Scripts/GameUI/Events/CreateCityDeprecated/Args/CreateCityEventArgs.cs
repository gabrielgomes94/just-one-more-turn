using System;
using Unity.Entities;
using Unity.Mathematics;

namespace GameUI
{
    public class CreateCityEventArgs : EventArgs
    {
        public int3 Coordinates;

        public int CivId;
    }
}
