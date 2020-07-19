using Unity.Entities;
using Unity.Transforms;

namespace Hex {
    public class HexCellArchetype
    {
        public static EntityArchetype GetArchetype()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(HexCoordinates),
                typeof(Translation),
                typeof(LocalToWorld),
                typeof(ColorComponent),
                typeof(Elevation),
                typeof(HexCellTag)
            );

            return archetype;
        }
    }
}
