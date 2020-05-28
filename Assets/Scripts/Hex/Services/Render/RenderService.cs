using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;


namespace Hex
{
    public class RenderService
    {
        public NativeList<int> triangles;
        public NativeList<Vector3> vertices;
        public NativeList<Color> colors;

        Vector3 centerPosition;
        Color color;
        EntityQuery query;

        public RenderService()
        {
            this.triangles = new NativeList<int>(Allocator.TempJob);
            this.vertices = new NativeList<Vector3>(Allocator.TempJob);
            this.colors = new NativeList<Color>(Allocator.TempJob);
        }

        public void Execute(Color color, Vector3 centerPosition, NeighborService neighborService)
        {
            for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++)
            {
                Vector3 bridge = HexMetrics.GetBridge(direction);

                Vector3 vertex1 = centerPosition + HexMetrics.GetFirstSolidCorner(direction);
                Vector3 vertex2 = centerPosition + HexMetrics.GetSecondSolidCorner(direction);
                Vector3 vertex3 = vertex1 + bridge;
                Vector3 vertex4 = vertex2 + bridge;

                // AddMainTriangle();
                AddMainTriangle(centerPosition, vertex1, vertex2, color);

                // AddEdgeQuad
                if (direction <= HexDirection.SE) {
                    int index = neighborService.GetNeighborIndex(direction);
                    if (index < 0 ) continue;

                    Color neighborColor = neighborService.GetNeighborColor(direction);
                    int nextNeighborIndex = neighborService.GetNeighborIndex(direction.Next());
                    Color nextNeighborColor = neighborService.GetNeighborColor(direction.Next());
                    int vertexIndex = vertices.Length;

                    AddEdgeQuad(
                        vertexIndex,
                        vertex1,
                        vertex2,
                        vertex3,
                        vertex4,
                        color,
                        neighborColor
                    );

                    // Minor triangle optimized
                    if (direction <= HexDirection.E && nextNeighborIndex >= 0) {
                        AddEdgeTriangle(vertex2, vertex4, vertex2 + HexMetrics.GetBridge(direction.Next()), color, neighborColor, nextNeighborColor);
                    }
                }
            }
        }

        public void Dispose()
        {
            this.triangles.Dispose();
            this.vertices.Dispose();
            this.colors.Dispose();
        }

        public Vector3[] GetVerticesArray()
        {
            return this.vertices.ToArray();
        }

        public int[] GetTrianglesArray()
        {
            return this.triangles.ToArray();
        }
        public Color[] GetColorsArray()
        {
            return this.colors.ToArray();
        }

        private void AddMainTriangle(Vector3 centerPosition, Vector3 vertex1, Vector3 vertex2, Color color)
        {
            int vertexIndex = this.vertices.Length;

            RenderTriangle renderTriangle = new RenderTriangle(
                vertexIndex,
                centerPosition,
                vertex1,
                vertex2,
                color,
                color,
                color
            );
            this.vertices = renderTriangle.AddVertices(this.vertices);

            this.triangles = renderTriangle.AddTriangles(this.triangles);

            this.colors = renderTriangle.AddColors(this.colors);
        }

        private void AddEdgeQuad(
            int vertexIndex,
            Vector3 vertex1,
            Vector3 vertex2,
            Vector3 vertex3,
            Vector3 vertex4,
            Color color1,
            Color color2
        )
        {
            RenderQuad renderQuad = new RenderQuad(
                vertexIndex,
                vertex1,
                vertex2,
                vertex3,
                vertex4,
                color1,
                color2
            );

            this.vertices = renderQuad.AddVertices(this.vertices);

            this.triangles = renderQuad.AddTriangles(this.triangles);

            this.colors = renderQuad.AddColors(this.colors);
        }

        private void AddEdgeTriangle(Vector3 centerPosition, Vector3 vertex1, Vector3 vertex2, Color color1, Color color2, Color color3)
        {
            int vertexIndex = this.vertices.Length;

            RenderTriangle renderTriangle = new RenderTriangle(
                vertexIndex,
                centerPosition,
                vertex1,
                vertex2,
                color1,
                color2,
                color3
            );

            this.vertices = renderTriangle.AddVertices(this.vertices);

            this.triangles = renderTriangle.AddTriangles(this.triangles);

            this.colors = renderTriangle.AddColors(this.colors);
        }
    }
}
