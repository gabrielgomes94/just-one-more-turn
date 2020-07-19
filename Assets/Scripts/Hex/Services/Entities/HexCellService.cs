using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class HexCellService
    {
        public static Entity FindBy(HexCoordinates targetHexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            NativeArray<Entity> hexCells = HexCellService.List(Allocator.TempJob);
            Entity neighborHexCell = Entity.Null;

            foreach(Entity hexCell in hexCells) {
                HexCoordinates hexCellCoordinates = entityManager.GetComponentData<HexCoordinates>(hexCell);

                if (targetHexCoordinates == hexCellCoordinates) {
                    neighborHexCell = hexCell;
                }
            }

            hexCells.Dispose();

            return neighborHexCell;
        }
        public static NativeArray<Entity> List(Allocator allocator = Allocator.TempJob)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            EntityQuery query = entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<ColorComponent>(),
                ComponentType.ReadOnly<HexCoordinates>(),
                ComponentType.ReadOnly<Elevation>(),
                ComponentType.ReadOnly<HexCellTag>()
            );

            return query.ToEntityArray(allocator);
        }


        public static float3 GetTranslationComponentByHexCoordinates(HexCoordinates hexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            Entity hexCell = HexCellService.FindBy(hexCoordinates);
            float3 translation = float3.zero;

            if (Entity.Null != hexCell) {
                translation = entityManager.GetComponentData<Translation>(hexCell).Value;
            }

            translation.y += 10f;

            return translation;
        }
    }
}
