using Hex.Coordinates;
using Unity.Entities;

namespace Game
{
    public class SettlerArchetype
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static EntityArchetype CreateSettler()
        {
            EntityArchetype createUnit = entityManager.CreateArchetype(
                typeof(CommandCreateSettler),
                typeof(HexCoordinates)
            );

            return createUnit;
        }

    }
}
