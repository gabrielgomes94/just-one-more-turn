using Hex.Coordinates;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;
using Unity.Mathematics;
using GameUI.Models;
using System;

namespace GameUI.View
{
    public class CityLabel
    {
        public string name;
        public string population;
        public HexCoordinates hexCoordinates;
        public GameObject label;

        public CityLabel(GameObject label, CityData cityData, HexCoordinates hexCoordinates)
        {
            this.label = label;
            this.name = cityData.name;
            this.population = cityData.population.ToString();
            this.hexCoordinates = hexCoordinates;
        }

        public void SetButton()
        {
            CityLabelButton cityLabelButton = this.label.GetComponentInChildren<CityLabelButton>();
            cityLabelButton.cityData = new CityData(name, Int32.Parse(population), hexCoordinates);
        }

        public void SetContent(GameObject label)
        {
            GameObject cityName = label.transform.Find("City Name").gameObject;
            GameObject cityPopulation = label.transform.Find("City Population").gameObject;

            cityName.GetComponent<Text>().text = name;
            cityPopulation.GetComponent<Text>().text = population.ToString();
        }
        public void SetPosition(Entity cityLabel, Canvas gridCanvas)
        {
            float3 pos = UICityLabel.GetWorldPosition(cityLabel);

            this.label.GetComponent<RectTransform>().SetParent(gridCanvas.transform, false);
            this.label.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y + 10f, pos.z - 5f);
        }
    }
}