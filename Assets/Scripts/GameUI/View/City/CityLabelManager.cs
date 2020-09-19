using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Hex.Cell;
using Hex.Coordinates;
using GameUI.Entities;
using GameUI.Input;

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

            // TODO: abstrair essa lógica pra outro local
            if (query.CalculateEntityCount() > 0) {
                NativeArray<Entity> labels = query.ToEntityArray(Allocator.TempJob);



                foreach(Entity cityLabel in labels) {
                    GameObject label = Instantiate(cityPanelPrefab);
                    float3 pos = CityLabel.GetWorldPosition(cityLabel);

                    label.GetComponent<RectTransform>().SetParent(gridCanvas.transform, false);
                    label.GetComponent<RectTransform>().position = new Vector3(pos.x, pos.y + 10f, pos.z - 5f);

                    string name = "Itajubá";
                    int population = 47;
                    HexCoordinates hexCoordinates = entityManager.GetComponentData<HexCoordinates>(cityLabel);

                    // City Label Button
                    CityLabelButton cityLabelButton = label.GetComponentInChildren<CityLabelButton>();

                    CityData cityData = new CityData(name, population, hexCoordinates);
                    cityLabelButton.cityData = cityData;

                    // City Name Text
                    GameObject cityName = label.transform.Find("City Name").gameObject;
                    cityName.GetComponent<Text>().text = cityLabelButton.cityData.name;

                    // City population Text
                    GameObject cityPopulation = label.transform.Find("City Population").gameObject;
                    cityPopulation.GetComponent<Text>().text = cityLabelButton.cityData.population.ToString();

                    entityManager.RemoveComponent<UICreate>(cityLabel);
                }

                labels.Dispose();
            }
        }
    }
}
