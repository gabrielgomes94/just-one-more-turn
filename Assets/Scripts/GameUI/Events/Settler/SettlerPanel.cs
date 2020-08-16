using Unity.Entities;
using Hex.Coordinates;

namespace GameUI.Events
{
    public class SettlerPanel
    {
        public static void Create(EntityCommandBuffer ecb, EntityArchetype archetype, HexCoordinates coordinates)
        {
            Entity panelEntity = ecb.CreateEntity(archetype);

            ecb.AddComponent<SettlerPanelTag>(panelEntity, new SettlerPanelTag {});
            ecb.AddComponent<HexCoordinates>(panelEntity, coordinates);
        }
    }
}