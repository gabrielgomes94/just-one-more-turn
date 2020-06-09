using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;
using Hex;

namespace Game
{
    public class CreateUnitSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            var ecb = barrier.CreateCommandBuffer();
            SettlerPrefab settlerPrefab = GetSingleton<SettlerPrefab>();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    ref CreateUnitEventComponent createUnitEvent
                ) => {
                    Entity settler = ecb.Instantiate(settlerPrefab.Value);

                    BoxGeometry settlerGeometry = new BoxGeometry
                    {
                        Center = float3.zero,
                        Orientation = quaternion.identity,
                        Size = new float3(7.5f, 5.5f, 7.5f),
                        BevelRadius = 0.05f
                    };
                    BlobAssetReference<Unity.Physics.Collider> collider = Unity.Physics.BoxCollider.Create(settlerGeometry);

                    float3 position = HexCell.GetTranslationComponentByHexCoordinates(createUnitEvent.Coordinates);

                    ecb.SetComponent<Translation>(settler, new Translation { Value = position });
                    ecb.AddSharedComponent<CivIdSharedComponent>(settler, new CivIdSharedComponent { Value = 1} );
                    ecb.AddComponent<PhysicsCollider>(settler, new PhysicsCollider { Value = collider });

                    ecb.DestroyEntity(entity);
                })
                .Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
