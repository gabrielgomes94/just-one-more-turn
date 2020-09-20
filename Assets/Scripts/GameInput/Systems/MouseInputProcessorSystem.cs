using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex.Cell;
using Hex.Coordinates;
using RaycastHit = Unity.Physics.RaycastHit;
using Unity.Physics;
using Unity.Physics.Systems;
using Game;

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

                    if (EntityManager.HasComponent<SettlerTag>(hitEntity)) {

                        SelectUnit.Create(hitEntity);

                        EntityManager.AddComponentData<Selected>(hitEntity, new Selected {});

                        // TODO: lógica pra ativar o painel
                        /**
                            - Adiciona componente de Seleção
                            - Sistema de seleção:
                                - Cria entidade com dados pra criar o painel:
                                    - coordenadas
                                    - UIEvents:
                            - UIComponents:
                                - CityLabel
                                    - : Monobehaviour
                                    - update: query nas UIEntities
                                        - Create label
                                        - Destroy label

                        */

                        mouseInput.primaryAction = 0;
                        return;
                    }

                    HexCoordinates coordinates = CoordinatesService.GetCoordinatesFromPosition(hit.Position);
                    Entity selectedEntity = HexCellService.FindBy(coordinates);

                    if (EntityManager.HasComponent<Selected>(selectedEntity)) {
                        SelectCommand.Remove(coordinates);
                    } else {
                        SelectCommand.Create(coordinates);
                    }

                    mouseInput.primaryAction = 0;
                })
                .Run();
        }


    }
}