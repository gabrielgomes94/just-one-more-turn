using Unity.Entities;
using Unity.Mathematics;
using Hex.Cell;
using Hex.Coordinates;

namespace GameUI.Models
{
    public class CityLabelECS
    {
        public static void Create(EntityCommandBuffer ecb, EntityArchetype archetype, HexCoordinates hexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            Entity cityLabel = ecb.CreateEntity(archetype);

            ecb.SetComponent<CityLabelTag>(cityLabel, new CityLabelTag {});
            ecb.SetComponent<HexCoordinates>(cityLabel, hexCoordinates);
            ecb.SetComponent<UI>(cityLabel, new UI {});
            ecb.SetComponent<UICreate>(cityLabel, new UICreate {});
        }

        public static EntityArchetype GetCreateArchetype()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(CityLabelTag),
                typeof(HexCoordinates),
                typeof(UI),
                typeof(UICreate)
            );

            return archetype;
        }

        public static EntityQuery GetUICreateQuery()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityQuery query = entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<CityLabelTag>(),
                ComponentType.ReadOnly<HexCoordinates>(),
                ComponentType.ReadOnly<UI>(),
                ComponentType.ReadOnly<UICreate>()
            );

            return query;
        }

        public static float3 GetWorldPosition(Entity cityLabel)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            HexCoordinates hexCoordinates = entityManager.GetComponentData<HexCoordinates>(cityLabel);
            float3 pos = HexCellService.GetTranslationComponentByHexCoordinates(hexCoordinates);

            return pos;
        }

    }
}
