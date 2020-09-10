using Hex.Coordinates;
using Unity.Entities;

namespace Game
{
    public class SettlerService
    {
        public static void Create(HexCoordinates hexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            Entity entity = entityManager.CreateEntity(GetArchetype());
            entityManager.SetComponentData(entity, hexCoordinates);
        }

        public static EntityArchetype GetArchetype()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype createUnit = entityManager.CreateArchetype(
                typeof(CommandCreateSettler),
                typeof(HexCoordinates)
            );

            return createUnit;
        }

        public static void AddCommandCreateCity(EntityManager entityManager, Entity entity)
        {
            if (entityManager.HasComponent<SettlerTag>(entity)) {
                entityManager.AddComponentData<CommandCreateCity>(
                    entity,
                    new CommandCreateCity {}
                );

                entityManager.AddSharedComponentData<CivIdSharedComponent>(
                    entity,
                    new CivIdSharedComponent {
                        Value = 1
                    }
                );
            }
        }
    }
}