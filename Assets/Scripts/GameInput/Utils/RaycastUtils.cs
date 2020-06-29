using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using RaycastHit = Unity.Physics.RaycastHit;

namespace GameInput
{
    public class RaycastUtils
    {
        public static Entity Raycast(Vector3 mousePosition, out RaycastHit hit, BuildPhysicsWorld buildPhysicsWorldSystem)
        {
            UnityEngine.Ray inputRay = Camera.main.ScreenPointToRay(mousePosition);

            float3 RayFrom = inputRay.origin;
            float3 RayTo = inputRay.origin + inputRay.direction * 500f;

            var collisionWorld = buildPhysicsWorldSystem.PhysicsWorld.CollisionWorld;

            RaycastInput input = new RaycastInput()
            {
                Start = RayFrom,
                End = RayTo,
                Filter = CollisionFilter.Default
            };

            bool haveHit = collisionWorld.CastRay(input, out hit);
            if (haveHit)
            {
                Entity e = buildPhysicsWorldSystem.PhysicsWorld.Bodies[hit.RigidBodyIndex].Entity;
                return e;
            }

            return Entity.Null;
        }
    }
}