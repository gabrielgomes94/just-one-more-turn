using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;
using Hex;
using GameUI.Models;
using Hex.Coordinates;

namespace Game
{
    public class CreateCitySystem : SystemBase
    {
        EndSimulationEntityCommandBufferSystem barrier => World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();

        protected override void OnUpdate()
        {
            CityPrefab cityPrefab = GetSingleton<CityPrefab>();
            var ecb = barrier.CreateCommandBuffer();
            var archetype = UICityLabel.GetCreateArchetype();

            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    in SettlerTag settlerTag,
                    in CommandCreateCity cmdCreateCity,
                    in HexCoordinates hexCoordinates
                ) => {
                    Entity city = CityEntity.Create(ecb, cityPrefab, entity);

                    UICityLabel.Create(ecb, archetype, hexCoordinates);
                }
            ).Run();
        }
    }
}