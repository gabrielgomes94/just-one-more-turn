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
    public class SettlerEntity
    {
        public static void Create(EntityCommandBuffer ecb, SettlerPrefab settlerPrefab, int3 coordinates)
        {
            Entity settler = ecb.Instantiate(settlerPrefab.Value);

            float3 position = HexCell.GetTranslationComponentByHexCoordinates(coordinates);

            BoxGeometry settlerGeometry = new BoxGeometry
            {
                Center = float3.zero,
                Orientation = quaternion.identity,
                Size = new float3(10f, 10f, 10f),
                BevelRadius = 0.05f
            };
            BlobAssetReference<Unity.Physics.Collider> collider = Unity.Physics.BoxCollider.Create(settlerGeometry);

            ecb.SetComponent<Translation>(settler, new Translation { Value = position });

            ecb.AddComponent<HexCoordinates>(settler, new HexCoordinates {
                X = coordinates.x,
                Y = coordinates.y,
                Z = coordinates.z
            });

            ecb.AddSharedComponent<CivIdSharedComponent>(settler, new CivIdSharedComponent { Value = 1} );
            ecb.AddComponent<PhysicsCollider>(settler, new PhysicsCollider { Value = collider });

            ecb.AddComponent<SettlerTag>(settler, new SettlerTag{});

            ecb.AddComponent<Selectable>(settler, new Selectable{});
        }

        public static Entity GetSelected(EntityManager entityManager)
        {
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>());

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
            Entity entity = entities[0];

            entities.Dispose();

            return entity;
        }

        public static void AddCommandCreateCity(EntityManager entityManager, Entity entity, CreateCityEventArgs createCityArgs)
        {
            if (entityManager.HasComponent<SettlerTag>(entity)) {
                entityManager.AddComponentData<CommandCreateCityComponent>(
                    entity,
                    new CommandCreateCityComponent {
                        Coordinates = createCityArgs.Coordinates
                    }
                );

                entityManager.AddSharedComponentData<CivIdSharedComponent>(
                    entity,
                    new CivIdSharedComponent {
                        Value = createCityArgs.CivId
                    }
                );
            }
        }
    }
}
