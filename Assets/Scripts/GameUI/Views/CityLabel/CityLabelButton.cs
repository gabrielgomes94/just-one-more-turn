using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI.Models;
using Game;

namespace GameUI.View
{
    public class CityLabelButton : MonoBehaviour
    {
        public CityData cityData;

        public void Execute()
        {
            SelectCommand.Create(cityData.hexCoordinates);
        }

        public void SelectCity()
        {
            SelectCommand.Create(cityData.hexCoordinates);
        }
    }
}
