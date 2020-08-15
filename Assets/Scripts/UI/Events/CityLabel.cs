using Unity.Entities;
using UnityEngine;

namespace GameUI.Entities
{
    public class CityLabel {
        public static void Create(Entity city)
        {
            Debug.Log(city);
        }
    }
}