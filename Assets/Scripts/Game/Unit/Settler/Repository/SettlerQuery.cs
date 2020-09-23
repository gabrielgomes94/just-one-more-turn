using Unity.Entities;

namespace Game
{
    public class SettlerQuery
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static EntityQuery Selected()
        {
            return entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<Selected>(),
                ComponentType.ReadOnly<SettlerTag>()
            );
        }
    }
}