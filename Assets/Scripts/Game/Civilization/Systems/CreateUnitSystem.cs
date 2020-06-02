using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

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
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    ref CreateUnitEventComponent createUnitEvent
                ) => {
                    Entity settler = ecb.Instantiate(settlerPrefab.Value);

                    ecb.SetComponent<Translation>(settler, new Translation { Value = createUnitEvent.position });

                    ecb.DestroyEntity(entity);
                })
                .Schedule();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}