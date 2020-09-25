using Unity.Entities;
using Unity.Jobs;

namespace Game.Turn
{
    public class UpdateTurnSystem : SystemBase
    {
        EntityQuery turnQuery;
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnCreate()
        {
        }

        protected override void OnUpdate()
        {
            turnQuery = GetEntityQuery(typeof(Turn));
            var ecb = barrier.CreateCommandBuffer();

            Entities
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    ref Turn turn,
                    in NextTurn nextTurn
                ) => {
                    turn.current++;

                    ecb.RemoveComponent<NextTurn>(entity);
                })
                .Schedule();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
