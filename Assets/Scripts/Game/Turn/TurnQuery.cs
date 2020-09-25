
using Unity.Entities;

namespace Game.Turn
{
    public class TurnQuery
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static EntityQuery Get()
        {
            EntityQuery createUnit = entityManager.CreateEntityQuery(
                typeof(Turn)
            );

            return createUnit;
        }
    }
}
