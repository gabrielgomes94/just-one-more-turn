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
    public class CreateCitySystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            CityPrefab cityPrefab = GetSingleton<CityPrefab>();
            var ecb = barrier.CreateCommandBuffer();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    in SettlerTag settlerTag,
                    in CommandCreateCityComponent cmdCreateCity
                ) => {
                    CityEntity.Create(ecb, cityPrefab, entity);
                }
            ).Run();
        }
    }
}