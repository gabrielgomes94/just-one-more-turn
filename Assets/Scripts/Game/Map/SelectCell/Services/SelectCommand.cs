using Unity.Entities;
using Hex;

namespace Game
{
    public class SelectCommand
    {
        public static void Create(HexCoordinates coordinates)
        {
            SelectCommand.CreateCommand(coordinates, true);
        }

        public static void Remove(HexCoordinates coordinates)
        {
            SelectCommand.CreateCommand(coordinates, false);
        }

        private static void CreateCommand(HexCoordinates coordinates, bool select)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(CommandSelectCell)
            );

            Entity entity = entityManager.CreateEntity(archetype);

            entityManager.AddComponentData<CommandSelectCell>(entity, new CommandSelectCell {
                select = select
            });
            entityManager.AddComponentData<HexCoordinates>(entity, coordinates);
        }
    }
}
