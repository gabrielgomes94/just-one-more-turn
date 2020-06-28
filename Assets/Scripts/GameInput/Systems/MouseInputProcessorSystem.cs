using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex;
using RaycastHit = Unity.Physics.RaycastHit;
using Unity.Physics;
using Unity.Physics.Systems;

namespace GameInput
{
    public class MoveInputProcessorSystem : SystemBase
    {
        private BuildPhysicsWorld buildPhysicsWorldSystem;
        Entity hexMeshEntity;
        protected override void OnStartRunning()
        {
            buildPhysicsWorldSystem = World.GetExistingSystem<BuildPhysicsWorld>();
        }

        protected override void OnCreate()
        {
        }


        protected override void OnUpdate()
        {
            Entity hitEntity;
            Entities
                .WithoutBurst()
                .WithStructuralChanges()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    ref MouseInput mouseInput
                ) => {
                    Vector3 position = new Vector3(
                        mouseInput.mousePosition.x,
                        mouseInput.mousePosition.y,
                        mouseInput.mousePosition.z
                    );

                    if (mouseInput.primaryAction == 0) return;

                    mouseInput.primaryAction = 0;

                    UnityEngine.Ray inputRay = Camera.main.ScreenPointToRay(position);

                    hitEntity = Raycast(
                        inputRay.origin,
                        inputRay.origin + inputRay.direction * 500f,
                        out RaycastHit hit
                    );

                    if (hitEntity == Entity.Null) return;

                    HexCoordinates coordinates = CoordinatesService.GetCoordinatesFromPosition(hit.Position);

                    Entity selectedEntity = HexCellEntity.GetByCoordinates(coordinates);

                    var color = EntityManager.GetComponentData<ColorComponent>(selectedEntity).Value;

                    EntityManager.SetComponentData<ColorComponent>(selectedEntity, new ColorComponent {
                        Value = Color.black
                    });

                    HexMeshRenderSystem.shouldRender = true;
                    NativeArray<Entity> array  = GetEntityQuery(ComponentType.ReadOnly<HexMeshTag>()).ToEntityArray(Allocator.TempJob);

                    hexMeshEntity = array[0];

                    array.Dispose();

                    EntityManager.AddComponent<RenderTag>(hexMeshEntity);

                })
                .Run();
        }

        public Entity Raycast(float3 RayFrom, float3 RayTo, out RaycastHit hit)
        {
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