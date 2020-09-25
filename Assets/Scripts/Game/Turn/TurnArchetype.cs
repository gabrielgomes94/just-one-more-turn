using Unity.Entities;

namespace Game.Turn
{
    public class TurnArchetype
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static EntityArchetype NextTurn()
        {
            EntityArchetype nextTurn = entityManager.CreateArchetype(
                typeof(Turn),
                typeof(NextTurn)
            );

            return nextTurn;
        }
    }
}

