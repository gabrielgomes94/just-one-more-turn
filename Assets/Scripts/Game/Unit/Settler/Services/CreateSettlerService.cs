using Hex.Coordinates;
using Unity.Entities;

namespace Game
{
    public class CreateSettlerService
    {
        static EntityManager entityManager => World.DefaultGameObjectInjectionWorld.EntityManager;

        public static Entity Execute(HexCoordinates hexCoordinates)
        {
            Entity entity = entityManager.CreateEntity(SettlerArchetype.CreateSettler());
            entityManager.SetComponentData(entity, hexCoordinates);

            return entity;
        }
    }
}