using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class HexCell
    {
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
            NativeArray<ColorComponent> colorComponentsArray = HexCell.GetColorsComponentsArray(query);
            Color color = colorComponentsArray[index].Value;

            colorComponentsArray.Dispose();

            return color;
        }

        public static int GetElevationByIndex(EntityQuery query, int index)
        {
            NativeArray<Elevation> elevationArray = HexCell.GetElevationArray(query);
            int elevation = elevationArray[index].Value;

            elevationArray.Dispose();

            return elevation;
        }

        public static float3 GetTranslationComponentByHexCoordinates(float3 hexCoordinates)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            EntityQuery m_Query = entityManager.CreateEntityQuery(typeof(HexCoordinates), ComponentType.ReadOnly<Translation>());

            var entityArray = m_Query.ToEntityArray(Allocator.TempJob);

            HexCoordinates hexCoordinatesZ = new HexCoordinates {
                X = (int) hexCoordinates.x,
                Y = (int) hexCoordinates.y,
                Z = (int) hexCoordinates.z
            };

            float3 translation = float3.zero;

            foreach(var entity in entityArray)
            {
                if (hexCoordinatesZ == entityManager.GetComponentData<HexCoordinates>(entity))
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
