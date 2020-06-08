using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;

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
                        Size = new float3(3.0f, 3.0f, 3.0f),
                        BevelRadius = 0.01f
                    };

                    BlobAssetReference<Unity.Physics.Collider> collider = Unity.Physics.BoxCollider.Create(settlerGeometry);

                    ecb.SetComponent<Translation>(settler, new Translation { Value = createUnitEvent.position });
                    ecb.AddSharedComponent<CivIdSharedComponent>(settler, new CivIdSharedComponent { Value = 1} );
                    ecb.AddComponent<PhysicsCollider>(settler, new PhysicsCollider { Value = collider });
                    ecb.DestroyEntity(entity);
                })
                .Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
