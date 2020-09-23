using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using GameUI.Models;
using GameUI.View;

namespace GameUI.Presenters
{
    public class CityLabelService
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static void CreateCityLabel(EntityQuery query, GameObject cityPanelPrefab, Transform transform, Canvas gridCanvas)
        {
            NativeArray<Entity> labels = query.ToEntityArray(Allocator.TempJob);

            foreach(Entity createCityLabel in labels) {
                GameObject label = GameObject.Instantiate(cityPanelPrefab, transform.position, Quaternion.identity);
                CityLabel cityLabel = new CityLabel(createCityLabel, label, gridCanvas);
                cityLabel.SetLabel();
                entityManager.RemoveComponent<UICreate>(createCityLabel);
            }

            labels.Dispose();
        }
    }
}
