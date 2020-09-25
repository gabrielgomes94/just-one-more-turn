using Unity.Collections;
using Unity.Entities;

namespace Game.Turn
{
    public class TurnService
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;
        public static void Init()
        {
            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(Turn)
            );

            Entity turn = entityManager.CreateEntity(archetype);

            entityManager.SetComponentData<Turn>(turn, new Turn{current = 0});
        }
        public static void Next()
        {
            // cria um nextTurn entity
            // cria um turnManager entity
            // cria um sistema que processa next turn entities
            EntityQuery turnQuery = TurnQuery.Get();

            // turnQuery = entityManager.CreateEntityQuery(
            //     ComponentType.ReadOnly<Turn>()
            // );

            NativeArray<Entity> turns = turnQuery.ToEntityArray(Allocator.TempJob);

            Entity turn = turns[0];

            turns.Dispose();

            entityManager.AddComponentData<NextTurn>(turn, new NextTurn{});
        }
    }
}
