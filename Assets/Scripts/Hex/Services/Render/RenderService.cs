using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Hex
{
    public class RenderService : IRenderService
    {
        Vector3 centerPosition;
        Color color;
        EntityManager entityManager;
        EntityQuery query;

        private NeighborCellService neighborCell;

        private RenderHexMeshData hexMeshData;

        public RenderService(EntityQuery query)
        {
            this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            this.hexMeshData = new RenderHexMeshData();

            this.query = query;
        }

        public void Execute(
            Entity entity,
            ColorComponent colorComponent
        ) {
            neighborCell = new NeighborCellService(entity);
            Color color = colorComponent.Value;

            for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++)
            {
                RenderData renderData = new RenderData(direction, entity, neighborCell.GetElevation(direction));
                RenderOperations renderOperations = new RenderOperations(renderData, this.hexMeshData);

                renderOperations.CreateMainTriangle(color);

                if (!HasEdgeQuad(direction, neighborCell.Exists(direction))) {
                    continue;
                }

                Color neighborColor = neighborCell.GetColor(direction);
                renderOperations.CreateEdgeQuad(color, neighborColor);

                if (!HasCornerTriangle(direction, neighborCell.Exists(direction.Next()))) {
                    continue;
                }

                Color nextNeighborColor = neighborCell.GetColor(direction.Next());
                int nexNeighborElevation = neighborCell.GetElevation(direction.Next());
                renderOperations.CreateCornerTriangle(
                    direction.Next(),
                    nexNeighborElevation,
                    color,
                    neighborColor,
                    nextNeighborColor
                );
            }
        }

        private bool HasEdgeQuad(HexDirection direction, bool hasNeighborInDirection)
        {
            return direction <= HexDirection.SE && hasNeighborInDirection;
        }

        private bool HasCornerTriangle(HexDirection direction, bool hasNeighborInDirection)
        {
            return direction <= HexDirection.E && hasNeighborInDirection;
        }

        public float3[] GetVerticesArrayFloat3()
        {
            float3[] verticesArray = new float3[this.hexMeshData.vertices.Count];

            for(int i = 0; i < this.hexMeshData.vertices.Count; i++) {
                verticesArray[i] = new float3(
                    this.hexMeshData.vertices[i].x,
                    this.hexMeshData.vertices[i].y,
                    this.hexMeshData.vertices[i].z
                );
            }

            return verticesArray;
        }

        public int3[] GetTrianglesArrayInt3()
        {
            int size = this.hexMeshData.triangles.Count / 3;

            int3[] trianglesArray = new int3[size];

            for(int j = 0, i = 0; j < size; j++)
            {
                trianglesArray[j] = new int3(
                    GetTrianglesArray()[i++],
                    GetTrianglesArray()[i++],
                    GetTrianglesArray()[i++]
                );
            }

            return trianglesArray;
        }

        public Vector3[] GetVerticesArray()
        {
            return hexMeshData.vertices.ToArray();
        }

        public int[] GetTrianglesArray()
        {
            return hexMeshData.triangles.ToArray();
        }

        public Color[] GetColorsArray()
        {
            return hexMeshData.colors.ToArray();
        }

        public void Clear()
        {
            hexMeshData.Clear();
        }
    }
}
