using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Hex.Cell;
using Hex.Coordinates;
using GameUI.Models;
using GameUI.View;

namespace GameUI.Presenters
{
    public class CityLabelManager : MonoBehaviour
    {
        public GameObject cityPanelPrefab;
        Canvas gridCanvas;
        EntityManager entityManager;
        EntityQuery createQuery;

        void Awake()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            gridCanvas = GetComponentInParent<Canvas>();
        }

        void LateUpdate()
        {
            createQuery = UICityLabel.GetUICreateQuery();
            CreateCityLabel(createQuery);
        }

        private void CreateCityLabel(EntityQuery query)
        {
            if (query.CalculateEntityCount() == 0) {
                return;
            }

            NativeArray<Entity> labels = query.ToEntityArray(Allocator.TempJob);

            foreach(Entity createCityLabel in labels) {
                HexCoordinates hexCoordinates = entityManager.GetComponentData<HexCoordinates>(createCityLabel);
                GameObject label = Instantiate(cityPanelPrefab);
                CityData cityData = new CityData("Varginha", 10, hexCoordinates);
                CityLabel cityLabel = new CityLabel(label, cityData, hexCoordinates);

                cityLabel.SetPosition(createCityLabel, gridCanvas);
                cityLabel.SetContent(cityLabel.label);
                cityLabel.SetButton();

                entityManager.RemoveComponent<UICreate>(createCityLabel);
            }

            labels.Dispose();
        }
    }
}

