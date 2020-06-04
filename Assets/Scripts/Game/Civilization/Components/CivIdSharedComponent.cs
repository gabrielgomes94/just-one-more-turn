using UnityEngine;
using Unity.Entities;

namespace Game
{
    public struct CivIdSharedComponent : ISharedComponentData
    {
        public int Value;
    }
}
