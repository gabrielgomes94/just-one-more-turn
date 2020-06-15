using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Transforms;

namespace Hex
{
    public class HexCellEntity
    {
        EntityManager entityManager;

        public HexCellEntity()
        {
            this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }
        public void CreateCells(int width, int height)
        {
            int cellsCount = width * height;

            NativeArray<Entity> cellsArray = new NativeArray<Entity>(cellsCount, Allocator.Temp);
            EntityArchetype archetype = GetHexCellArchetype();
            entityManager.CreateEntity(archetype, cellsArray);

            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    int offSetX = CoordinatesCalculator.GetXFromOffset(x, z);
                    int elevation = UnityEngine.Random.Range(0, 6);

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new HexCoordinates {
                            Value = new int3(
                                offSetX,
                                -offSetX -z,
                                z
                            )

                        }
                    );

                    entityManager.SetComponentData(
                        cellsArray[i],
                        new Translation {
                            Value = GetCellPosition(x, elevation, z)
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

        private EntityArchetype GetHexCellArchetype()
        {
            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(HexCoordinates),
                typeof(Translation),
                typeof(LocalToWorld),
                typeof(ColorComponent),
                typeof(Elevation),
                typeof(HexCellTag)
            );

            return archetype;
        }
    }
}
