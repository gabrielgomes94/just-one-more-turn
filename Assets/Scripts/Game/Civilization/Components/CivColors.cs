using UnityEngine;
using Unity.Entities;

namespace Game
{
    public struct CivColors : IComponentData
    {
        public Color main;
        public Color secondary;
    }
}
