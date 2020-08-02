using Unity.Entities;
using Unity.Collections;
using Hex;

namespace Game
{
    public class RemoveHighlightSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            HighlightCellPrefab highlightPrefab = GetSingleton<HighlightCellPrefab>();
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();
            NativeArray<Entity> highlightedCells = HighlightCell.List();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    in HexCoordinates coordinates,
                    in CommandRemoveHighlight commandRemoveHighlight
                ) => {
                    foreach(var highlightedCell in highlightedCells) {
                        HexCoordinates highlightedCoordinates = EntityManager.GetComponentData<HexCoordinates>(highlightedCell);

                        if (coordinates == highlightedCoordinates) {
                            ecb.DestroyEntity(highlightedCell);
                        }
                    }

                    ecb.DestroyEntity(entity);
            }).Run();

            highlightedCells.Dispose();
            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
