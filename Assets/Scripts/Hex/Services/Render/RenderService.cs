using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Hex
{
    public class RenderService
    {
        Vector3 centerPosition;
        Color color;
        EntityManager entityManager;
        EntityQuery query;

        private NeighborCellService neighborService;

        private RenderHexMeshData hexMeshData;

        public RenderService(EntityQuery query)
        {
            this.entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            this.hexMeshData = new RenderHexMeshData();

            this.query = query;
        }

        public void Execute(
            Entity entity,
            Translation translation,
            ColorComponent colorComponent
        ) {
            neighborService = new NeighborCellService(
                entity,
                query
            );

            Color color = colorComponent.Value;
            this.centerPosition = centerPosition;

            for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++)
            {
                RenderData renderData = new RenderData(direction, translation, neighborService);

                RenderOperations renderOperations = new RenderOperations(renderData, this.hexMeshData);

                // Create Main Triangle
                renderOperations.CreateMainTriangle(color);

                // Create Edge Quad
                if (direction > HexDirection.SE) continue;
                if (!neighborService.HasNeighbor(direction)) continue;

                Color neighborColor = neighborService.GetNeighborColor(direction);
                Color nextNeighborColor = neighborService.GetNeighborColor(direction.Next());

                renderOperations.CreateEdgeQuad(color, neighborColor);

                // Create corner triangle
                if(direction > HexDirection.E || !neighborService.HasNeighbor(direction.Next())) continue;

                renderOperations.CreateCornerTriangle(color, neighborColor, nextNeighborColor, direction.Next());
            }

            neighborService.Dispose();
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
            return this.hexMeshData.vertices.ToArray();
        }

        public int[] GetTrianglesArray()
        {
            return this.hexMeshData.triangles.ToArray();
        }

        public Color[] GetColorsArray()
        {
            return this.hexMeshData.colors.ToArray();
        }
    }
}
