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

            if (createQuery.CalculateEntityCount() > 0) {
                CityLabelService.CreateCityLabel(
                    createQuery,
                    cityPanelPrefab,
                    transform,
                    gridCanvas
                );
            }
        }
    }
}

