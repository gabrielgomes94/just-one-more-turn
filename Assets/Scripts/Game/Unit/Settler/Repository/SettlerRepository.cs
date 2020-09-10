using Hex.Cell;
using Hex.Coordinates;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Game
{
    public class SettlerRepository
    {
        public static void Create(EntityCommandBuffer ecb, SettlerPrefab settlerPrefab, HexCoordinates coordinates)
        {
            Entity settler = ecb.Instantiate(settlerPrefab.Value);

            float3 position = HexCellService.GetTranslationComponentByHexCoordinates(coordinates);
            position.y += 10f;

            BlobAssetReference<Unity.Physics.Collider> collider = Unity.Physics.BoxCollider.Create(
                new BoxGeometry
                {
                    Center = float3.zero,
                    Orientation = quaternion.identity,
                    Size = new float3(10f, 10f, 10f),
                    BevelRadius = 0.05f
                }
            );

            ecb.AddComponent<HexCoordinates>(settler, coordinates);
            ecb.AddComponent<PhysicsCollider>(settler, new PhysicsCollider { Value = collider });
            ecb.AddComponent<SettlerTag>(settler, new SettlerTag{});
            ecb.AddComponent<Selectable>(settler, new Selectable{});
            ecb.SetComponent<Translation>(settler, new Translation { Value = position });
            ecb.AddSharedComponent<CivIdSharedComponent>(settler, new CivIdSharedComponent { Value = 1} );
        }

        public static Entity GetSelected(EntityManager entityManager)
        {
            var query = entityManager.CreateEntityQuery(ComponentType.ReadOnly<Selected>(), ComponentType.ReadOnly<SettlerTag>());

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.TempJob);
            Entity entity = entities[0];

            entities.Dispose();

            return entity;
        }
    }
}