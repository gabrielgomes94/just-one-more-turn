using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class HexCellService
    {
        EntityManager entityManager;
        public HexCellService()
        {
            this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

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

        public static Entity GetByCoordinates(HexCoordinates coordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var query = entityManager.CreateEntityQuery(typeof(HexCellTag));

            NativeArray<Entity> hexCells =  query.ToEntityArray(Allocator.TempJob);
            Entity hexCell = Entity.Null;

            foreach(Entity hexCellEntity in hexCells)
            {
                HexCoordinates hexCellCoordinates = entityManager.GetComponentData<HexCoordinates>(hexCellEntity);

                if (hexCellCoordinates == coordinates) {
                    hexCell = hexCellEntity;
                    break;
                }
            }

            hexCells.Dispose();

            return hexCell;
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

        public static NativeArray<ColorComponent> GetColorsComponentsArray(EntityQuery query)
        {
            return query.ToComponentDataArray<ColorComponent>(Allocator.Temp);
        }

        public static NativeArray<HexCoordinates> GetHexCoordinatesArray(EntityQuery query)
        {
            return query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);
        }

        public static NativeArray<Elevation> GetElevationArray(EntityQuery query)
        {
            return query.ToComponentDataArray<Elevation>(Allocator.Temp);
        }


        public static Color GetColorByIndex(EntityQuery query, int index)
        {
            NativeArray<ColorComponent> colorComponentsArray = HexCellService.GetColorsComponentsArray(query);
            Color color = colorComponentsArray[index].Value;

            colorComponentsArray.Dispose();

            return color;
        }

        public static int GetElevationByIndex(EntityQuery query, int index)
        {
            NativeArray<Elevation> elevationArray = HexCellService.GetElevationArray(query);
            int elevation = elevationArray[index].Value;

            elevationArray.Dispose();

            return elevation;
        }

        public static float3 GetTranslationComponentByHexCoordinates(HexCoordinates hexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            EntityQuery query = entityManager.CreateEntityQuery(typeof(HexCoordinates), ComponentType.ReadOnly<Translation>());

            var entityArray = query.ToEntityArray(Allocator.TempJob);

            float3 translation = float3.zero;

            foreach(var entity in entityArray)
            {
                if (hexCoordinates == entityManager.GetComponentData<HexCoordinates>(entity))
                {
                    translation = entityManager.GetComponentData<Translation>(entity).Value;
                    break;
                }
            }

            translation.y += 10f;

            entityArray.Dispose();

            return translation;
        }


    }
}
