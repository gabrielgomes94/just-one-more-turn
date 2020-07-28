using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using Hex;

namespace Game
{
    public class SelectCommand
    {
        public static void Create(HexCoordinates coordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(CommandSelectCell)
            );

            Entity entity = entityManager.CreateEntity(archetype);

            entityManager.AddComponentData<CommandSelectCell>(entity, new CommandSelectCell {
                select = true
            });
            entityManager.AddComponentData<HexCoordinates>(entity, coordinates);
        }

        public static void Remove(HexCoordinates coordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(CommandSelectCell)
            );

            Entity entity = entityManager.CreateEntity(archetype);

            entityManager.AddComponentData<CommandSelectCell>(entity, new CommandSelectCell {
                select = false
            });
            entityManager.AddComponentData<HexCoordinates>(entity, coordinates);
        }
    }
}
