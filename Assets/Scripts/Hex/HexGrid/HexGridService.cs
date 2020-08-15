using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;
using Hex.Cell;
using Hex.Coordinates;

namespace Hex.Grid
{
    public class HexGridService
    {
        EntityManager entityManager;

        public HexGridService()
        {
            this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        public void CreateCells(int width, int height)
        {
            int cellsCount = width * height;

            NativeArray<Entity> cellsArray = new NativeArray<Entity>(cellsCount, Allocator.Temp);
            EntityArchetype archetype = HexCellArchetype.GetArchetype();
            entityManager.CreateEntity(archetype, cellsArray);

            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    int elevation = UnityEngine.Random.Range(0, 6);

                    entityManager.SetComponentData(
                        cellsArray[i],
                        CoordinatesService.CreateFromOffset(x, z)
                    );

                    var pos = GetCellPosition(x, elevation, z);
                    entityManager.SetComponentData(
                        cellsArray[i],
                        new Translation {
                            Value = pos
                        }
                    );

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new ColorComponent { Value = HexColor.GetRandomColor() }
                    );

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new Elevation { Value = elevation }
                    );

                    i++;
                }
            }
        }

        private float3 GetCellPosition(int x, int y, int z)
        {
            Vector3 position;

            position.x = PositionCalculator.GetPositionX(x, z);
            position.y = PositionCalculator.GetPositionY(y);
            position.z = PositionCalculator.GetPositionZ(z);

            return new float3(position.x, position.y, position.z);
        }
    }
}