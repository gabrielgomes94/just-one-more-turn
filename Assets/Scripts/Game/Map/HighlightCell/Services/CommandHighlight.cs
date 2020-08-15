using Unity.Entities;
using Hex.Coordinates;

namespace Game
{
    public class CommandHighlight
    {
        public static void Create(EntityCommandBuffer ecb, HexCoordinates coordinates, EntityArchetype archetype)
        {
            Entity entity = ecb.CreateEntity(archetype);

            ecb.AddComponent<CommandCreateHighlight>(entity, new CommandCreateHighlight {});
            ecb.AddComponent<HexCoordinates>(entity, coordinates);
        }

        public static void Remove(EntityCommandBuffer ecb, HexCoordinates coordinates, EntityArchetype archetype)
        {
            Entity entity = ecb.CreateEntity(archetype);

            ecb.AddComponent<CommandRemoveHighlight>(entity, new CommandRemoveHighlight {});
            ecb.AddComponent<HexCoordinates>(entity, coordinates);
        }
    }
}
