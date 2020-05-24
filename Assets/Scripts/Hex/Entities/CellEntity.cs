using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class CellEntity
    {
        public void CreateCells(int width, int height)
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            int cellsCount = width * height;

            NativeArray<Entity> cellsArray = new NativeArray<Entity>(cellsCount, Allocator.Temp);

            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(HexCoordinatesComponent),
                typeof(Translation),
                typeof(LocalToWorld),
                typeof(ColorComponent)
            );

            entityManager.CreateEntity(archetype, cellsArray);

            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    entityManager.SetComponentData(
                        cellsArray[i],
                        new HexCoordinatesComponent { X = x, Y = -x -z , Z = z }
                    );

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new Translation { Value = GetCellPosition(x, z) }
                    );

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new ColorComponent { Value = HexColor.GetRandomColor() }
                    );

                    i++;
                }
            }
        }

        private float3 GetCellPosition(int x, int z)
        {
            Vector3 position;

            position.x = (x + (z * 0.5f) - (z / 2)) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexMetrics.outerRadius * 1.5f);

            return new float3(position.x, position.y, position.z);
        }
    }
}
