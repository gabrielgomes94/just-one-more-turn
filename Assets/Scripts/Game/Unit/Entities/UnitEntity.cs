using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;
using Hex;

namespace Game
{
    public class UnitEntity
    {
        public static Entity GetSelected(EntityManager entityManager)
        {
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>());

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
            Entity entity = entities[0];

            entities.Dispose();

            return entity;
        }
    }
}