using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

using Hex;

namespace Game
{
    public class CreateUnitSystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            EntityCommandBuffer ecb = barrier.CreateCommandBuffer();
            SettlerPrefab settlerPrefab = GetSingleton<SettlerPrefab>();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    in CommandCreateUnitComponent createUnitCommand,
                    in HexCoordinates coordinates
                ) => {
                    SettlerEntity.Create(ecb, settlerPrefab, coordinates);

                    ecb.DestroyEntity(entity);
                })
                .Run();

            barrier.AddJobHandleForProducer(this.Dependency);
        }
    }
}
