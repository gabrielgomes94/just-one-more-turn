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
using Game;
using GameUI;
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
                    if (mouseInput.primaryAction == 0) return;

                    hitEntity = RaycastUtils.Raycast(
                        mouseInput.mousePosition,
                        out RaycastHit hit,
                        buildPhysicsWorldSystem
                    );

                    if (hitEntity == Entity.Null) return;

                    HexCoordinates coordinates = CoordinatesService.GetCoordinatesFromPosition(hit.Position);
                    Entity selectedEntity = HexCellService.FindBy(coordinates);

                    if (EntityManager.HasComponent<Selected>(selectedEntity)) {
                        CommandSelectService.RemoveSelectionCommand(coordinates);
                    } else {
                        CommandSelectService.CreateSelectionCommand(coordinates);
                    }

                    mouseInput.primaryAction = 0;
                })
                .Run();
        }


    }
}