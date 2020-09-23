using Hex.Coordinates;
using Unity.Entities;

namespace Game
{
    public class SettlerActions
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static void AddCommandCreateCity(Entity entity)
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