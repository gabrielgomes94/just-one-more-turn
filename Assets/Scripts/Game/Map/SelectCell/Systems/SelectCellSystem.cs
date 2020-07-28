using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex;

namespace Game
{
    public class SelectCellSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();

            EntityArchetype archetype = EntityManager.CreateArchetype(
                typeof(CommandCreateHighlight)
            );

            EntityArchetype archetypeRemoveHighlight = EntityManager.CreateArchetype(
                typeof(CommandRemoveHighlight)
            );

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    in CommandSelectCell commandSelectCell,
                    in HexCoordinates hexCoordinates
                ) => {
                    Entity selectedCell = HexCellService.FindBy(hexCoordinates);

                    if (commandSelectCell.select) {
                        CommandHighlight.Create(ecb, hexCoordinates, archetype);
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
