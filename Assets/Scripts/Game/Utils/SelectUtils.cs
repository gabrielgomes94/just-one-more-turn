using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;

namespace Game
{
    public class SelectUtils
    {
        public static void SelectEntity(Entity entity)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>());

            if (HasSelectedEntity(entityManager, query)) {
                entityManager.RemoveComponent(query, typeof(Selected));
            }

            if (entityManager.HasComponent<Selectable>(entity)) {
                entityManager.AddComponentData<Selected>(entity, new Selected{});
            }
        }

        public static Entity GetSelected(EntityManager entityManager)
        {
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>());

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
            Entity entity = entities[0];

            entities.Dispose();

            return entity;
        }

        public static bool HasSelectedEntity(EntityManager entityManager, EntityQuery query)
        {
            if (query.CalculateEntityCount() > 0 )  return true;

            return false;
        }
    }
}