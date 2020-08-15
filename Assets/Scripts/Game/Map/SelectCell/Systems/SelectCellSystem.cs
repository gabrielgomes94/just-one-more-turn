using Unity.Entities;
using Hex.Cell;
using Hex.Coordinates;

namespace Game
{
    public class SelectCellSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();

            EntityArchetype archetypeCreateHighlight = HighlightArchetype.GetCommandCreate();
            EntityArchetype archetypeRemoveHighlight = HighlightArchetype.GetCommandRemove();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    in CommandSelectCell commandSelectCell,
                    in HexCoordinates hexCoordinates
                ) => {
                    Entity selectedCell = HexCellService.FindBy(hexCoordinates);

                    if (commandSelectCell.select) {
                        CommandHighlight.Create(ecb, hexCoordinates, archetypeCreateHighlight);
                        ecb.AddComponent<Selected>(selectedCell, new Selected{});
                    } else {
                        CommandHighlight.Remove(ecb, hexCoordinates, archetypeRemoveHighlight);
                        ecb.RemoveComponent<Selected>(selectedCell);
                    }

                    ecb.DestroyEntity(entity);
            }).Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
