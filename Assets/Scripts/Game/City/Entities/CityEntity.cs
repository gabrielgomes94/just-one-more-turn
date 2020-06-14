
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Physics;
using Hex;

namespace Game
{
    public class CityEntity
    {
        public static void Create(EntityCommandBuffer ecb, CityPrefab cityPrefab, Entity settlerEntity, int3 coordinates)
        {
            Entity city = ecb.Instantiate(cityPrefab.Value);
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            HexCoordinates settlerHexCoordinates = entityManager.GetComponentData<HexCoordinates>(settlerEntity);

            CivIdSharedComponent settlerCivId = entityManager.GetSharedComponentData<CivIdSharedComponent>(settlerEntity);

            float3 position = HexCell.GetTranslationComponentByHexCoordinates(settlerHexCoordinates);

            ecb.SetComponent<Translation>(
                city,
                new Translation { Value = position }
            );

            ecb.AddSharedComponent<CivIdSharedComponent>(
                city,
                new CivIdSharedComponent { Value = settlerCivId.Value }
            );

            ecb.DestroyEntity(settlerEntity);
        }
    }
}
