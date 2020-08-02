using Unity.Entities;
using Hex;

namespace Game
{
    public class CreateHighlightSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            HighlightCellPrefab highlightPrefab = GetSingleton<HighlightCellPrefab>();
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    in CommandCreateHighlight commandCreateHighlight,
                    in HexCoordinates coordinates
                ) => {
                    HighlightCell.Create(ecb, highlightPrefab, coordinates);

                    ecb.DestroyEntity(entity);
            }).Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
