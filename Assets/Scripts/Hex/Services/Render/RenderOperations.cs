using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Hex
{
    public class RenderOperations
    {
        RenderData renderData;
        RenderHexMeshData hexMeshData;

        public RenderOperations(RenderData renderData, RenderHexMeshData hexMeshData)
        {
            this.renderData = renderData;
            this.hexMeshData = hexMeshData;
        }

        public void CreateMainTriangle(Color color)
        {

            Vector3[] mainTriangleVertices = new Vector3[3] {
                renderData.centerPosition,
                renderData.vertex1,
                renderData.vertex2
            };

            Color[] mainTriangleColors = new Color[3] {
                color,
                color,
                color
            };


            AddTriangle(mainTriangleVertices, mainTriangleColors);
        }

        public void CreateEdgeQuad(Color color1, Color color2)
        {
            int vertexIndex = hexMeshData.vertices.Count;

            Vector3[] edgeQuadVertices = new Vector3[4] {
                    renderData.vertex1,
                    renderData.vertex2,
                    renderData.vertex3,
                    renderData.vertex4
            };

            Color[] edgeQuadColors = new Color[2] {
                    color1,
                    color2
            };

            AddEdgeQuad(
                vertexIndex,
                edgeQuadVertices,
                edgeQuadColors
            );
        }

        public void CreateCornerTriangle(Color color1, Color color2, Color color3, HexDirection direction)
        {
            Vector3 vertex5 = renderData.vertex2 + HexMetrics.GetBridge(direction);
            int elevation = renderData.neighborService.GetNeighborElevation(direction);
			vertex5.y = elevation * HexMetrics.elevationStep;

            Vector3[] edgeTriangleVertices = new Vector3[3] {
                renderData.vertex2,
                renderData.vertex4,
                vertex5
            };

            Color[] edgeTriangleColors = new Color[3] {
                color1,
                color2,
                color3
            };

            AddTriangle(
                edgeTriangleVertices,
                edgeTriangleColors
            );
        }

        private void AddTriangle(Vector3[] vertices, Color[] colors)
        {
            int vertexIndex = hexMeshData.vertices.Count;

            RenderTriangle renderTriangle = new RenderTriangle(
                vertexIndex,
                vertices,
                colors
            );

            hexMeshData.vertices = renderTriangle.AddVertices(hexMeshData.vertices);
            hexMeshData.triangles = renderTriangle.AddTriangles(hexMeshData.triangles);
            hexMeshData.colors = renderTriangle.AddColors(hexMeshData.colors);
        }

        private void AddEdgeQuad(
            int vertexIndex,
            Vector3[] vertices,
            Color[] colors
        )
        {
            RenderQuad renderQuad = new RenderQuad(
                vertexIndex,
                vertices,
                colors
            );

            hexMeshData.vertices = renderQuad.AddVertices(hexMeshData.vertices);
            hexMeshData.triangles = renderQuad.AddTriangles(hexMeshData.triangles);
            hexMeshData.colors = renderQuad.AddColors(hexMeshData.colors);
        }
    }
}