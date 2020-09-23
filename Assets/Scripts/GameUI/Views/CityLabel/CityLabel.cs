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
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;
        public CityData cityData;
        public GameObject label;
        public Canvas gridCanvas;
        public Entity createCityLabel;

        public CityLabel(Entity createCityLabel, GameObject label, Canvas gridCanvas)
        {
            HexCoordinates hexCoordinates = entityManager.GetComponentData<HexCoordinates>(createCityLabel);
            this.cityData = new CityData("Varginha", 10, hexCoordinates);
            this.label = label;
            this.createCityLabel = createCityLabel;
            this.gridCanvas = gridCanvas;
        }

        public void SetLabel()
        {
            this.SetPosition();
            this.SetContent(label);
            this.SetButton();
        }

        private void SetButton()
        {
            CityLabelButton cityLabelButton = this.label.GetComponentInChildren<CityLabelButton>();
            cityLabelButton.cityData = cityData;
        }

        private void SetContent(GameObject label)
        {
            GameObject cityName = label.transform.Find("City Name").gameObject;
            GameObject cityPopulation = label.transform.Find("City Population").gameObject;

            cityName.GetComponent<Text>().text = cityData.name;
            cityPopulation.GetComponent<Text>().text = cityData.population.ToString();
        }
        private void SetPosition()
        {
            float3 pos = UICityLabel.GetWorldPosition(createCityLabel);

            this.label.GetComponent<RectTransform>().SetParent(gridCanvas.transform, false);
            this.label.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y + 10f, pos.z - 5f);
        }
    }
}