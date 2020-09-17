using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hex.Coordinates;

namespace GameUI.Input {
    public class CityData
    {
            public string name;
            public int population;
            private HexCoordinates hexCoordinates;

            public CityData(string name, int population, HexCoordinates hexCoordinates)
            {
                this.name = name;

                this.population = population;

                this.hexCoordinates = hexCoordinates;
            }
    }
}
