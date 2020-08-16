using Unity.Entities;
using UnityEngine;

namespace GameUI.Events
{
    public class CityLabel {
        public static void Create(Entity city)
        {
            Debug.Log(city);
        }
    }
}