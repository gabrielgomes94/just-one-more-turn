using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Collections;
using System;
using Game;

namespace GameInput
{
    public class PrimaryActionHandler
    {
        public void handle(Vector3 position)
        {
            UnityEngine.Ray inputRay = Camera.main.ScreenPointToRay(position);

            var entityRaycasted = Raycast(inputRay.origin, inputRay.direction * 200f);

            if (entityRaycasted == Entity.Null) return;

            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>());

            if (query.CalculateEntityCount() > 0 )
            {
                entityManager.RemoveComponent(query, typeof(Selected));
            }

            entityManager.AddComponentData<Selected>(entityRaycasted, new Selected{});
        }

        public Entity Raycast(float3 RayFrom, float3 RayTo)
        {
            BuildPhysicsWorld physicsWorldSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystem<Unity.Physics.Systems.BuildPhysicsWorld>();
            var collisionWorld = physicsWorldSystem.PhysicsWorld.CollisionWorld;

            RaycastInput input = new RaycastInput()
            {
                Start = RayFrom,
                End = RayTo,
                Filter = new CollisionFilter()
                {
                    BelongsTo = ~0u,
                    CollidesWith = ~0u,
                    GroupIndex = 0
                }
            };

            Unity.Physics.RaycastHit hit = new Unity.Physics.RaycastHit();
            bool haveHit = collisionWorld.CastRay(input, out hit);
            if (haveHit)
            {
                Entity e = physicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
                return e;
            }
            return Entity.Null;
        }
    }
}

