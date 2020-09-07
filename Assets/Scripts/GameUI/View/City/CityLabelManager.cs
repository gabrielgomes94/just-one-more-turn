using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Hex.Cell;
using Hex.Coordinates;
using GameUI.Entities;

namespace GameUI.View
{
    public class CityLabelManager : MonoBehaviour
    {
        public GameObject cityPanelPrefab;
        Canvas gridCanvas;
        EntityManager entityManager;
        EntityQuery query;

        void Awake()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            gridCanvas = GetComponentInParent<Canvas>();
        }

        void LateUpdate()
        {
            query = CityLabel.GetQuery();

            if (query.CalculateEntityCount() > 0) {
                NativeArray<Entity> labels = query.ToEntityArray(Allocator.TempJob);

                foreach(Entity cityLabel in labels) {
                    GameObject label = Instantiate(cityPanelPrefab);
                    float3 pos = CityLabel.GetWorldPosition(cityLabel);

                    label.GetComponent<RectTransform>().SetParent(gridCanvas.transform, false);
                    label.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y + 10f, pos.z - 5f);

                    entityManager.RemoveComponent<UICreate>(cityLabel);
                }

                labels.Dispose();
            }
        }
    }
}
