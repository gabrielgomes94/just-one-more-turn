using Unity.Entities;
using Hex.Cell;
using Hex.Coordinates;
using GameUI.Entities;

namespace Game
{
    public class SelectUnitSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();
            EntityArchetype archetype = UISettlerPanel.GetArchetype();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    in CommandSelectUnit commandSelectUnit,
                    in HexCoordinates hexCoordinates
                ) => {
                    Entity selectedCell = HexCellService.FindBy(hexCoordinates);

                    UISettlerPanel.Show(ecb, archetype, hexCoordinates);

                    ecb.DestroyEntity(entity);
            }).Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
