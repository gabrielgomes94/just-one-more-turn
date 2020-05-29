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

        public void Execute(
            Vector3 centerPosition,
            HexCoordinates hexCoordinates,
            ColorComponent colorComponent,
            EntityQuery query
        ) {
            NeighborService neighborService = new NeighborService(
                hexCoordinates,
                colorComponent,
                query
            );

            Color color = colorComponent.Value;

            for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++)
            {
                Vector3 bridge = HexMetrics.GetBridge(direction);

                Vector3 vertex1 = centerPosition + HexMetrics.GetFirstSolidCorner(direction);
                Vector3 vertex2 = centerPosition + HexMetrics.GetSecondSolidCorner(direction);
                Vector3 vertex3 = vertex1 + bridge;
                Vector3 vertex4 = vertex2 + bridge;

                // Add Main Triangle
                NativeArray<Vector3> mainTriangleVertices = new NativeArray<Vector3>(new Vector3[] {
                        centerPosition,
                        vertex1,
                        vertex2,
                    }, Allocator.TempJob);

                NativeArray<Color> mainTriangleColors = new NativeArray<Color>(new Color[] {
                        color,
                        color,
                        color
                    }, Allocator.TempJob);

                AddTriangle(mainTriangleVertices, mainTriangleColors);

                mainTriangleVertices.Dispose();
                mainTriangleColors.Dispose();

                // AddEdgeQuad
                if (direction <= HexDirection.SE) {
                    int index = neighborService.GetNeighborIndex(direction);
                    if (index < 0 ) continue;

                    Color neighborColor = neighborService.GetNeighborColor(direction);
                    int nextNeighborIndex = neighborService.GetNeighborIndex(direction.Next());
                    Color nextNeighborColor = neighborService.GetNeighborColor(direction.Next());
                    int vertexIndex = vertices.Length;

                    NativeArray<Vector3> edgeQuadVertices = new NativeArray<Vector3>(
                        new Vector3[] {
                            vertex1,
                            vertex2,
                            vertex3,
                            vertex4,
                        },
                        Allocator.TempJob
                    );

                    NativeArray<Color> edgeQuadColors = new NativeArray<Color>(
                        new Color[] {
                            color,
                            neighborColor
                        },
                        Allocator.TempJob
                    );

                    AddEdgeQuad(
                        vertexIndex,
                        edgeQuadVertices,
                        edgeQuadColors
                    );

                    edgeQuadVertices.Dispose();
                    edgeQuadColors.Dispose();

                    // Minor triangle optimized
                    if (direction <= HexDirection.E && nextNeighborIndex >= 0) {
                        NativeArray<Vector3> edgeTriangleVertices = new NativeArray<Vector3>(new Vector3[] {
                            vertex2,
                            vertex4,
                            vertex2 + HexMetrics.GetBridge(direction.Next()),
                        }, Allocator.TempJob);

                        NativeArray<Color> edgeTriangleColors = new NativeArray<Color>(new Color[] {
                            color,
                            neighborColor,
                            nextNeighborColor
                        }, Allocator.TempJob);

                        AddTriangle(
                            edgeTriangleVertices,
                            edgeTriangleColors
                        );

                        edgeTriangleVertices.Dispose();
                        edgeTriangleColors.Dispose();
                    }
                }
            }

            neighborService.Dispose();
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

        private void AddEdgeQuad(
            int vertexIndex,
            NativeArray<Vector3> vertices,
            NativeArray<Color> colors
        )
        {
            RenderQuad renderQuad = new RenderQuad(
                vertexIndex,
                vertices,
                colors
            );

            this.vertices = renderQuad.AddVertices(this.vertices);

            this.triangles = renderQuad.AddTriangles(this.triangles);

            this.colors = renderQuad.AddColors(this.colors);
        }

        private void AddTriangle(NativeArray<Vector3> vertices, NativeArray<Color> colors)
        {
            int vertexIndex = this.vertices.Length;

            RenderTriangle renderTriangle = new RenderTriangle(
                vertexIndex,
                vertices,
                colors
            );

            this.vertices = renderTriangle.AddVertices(this.vertices);

            this.triangles = renderTriangle.AddTriangles(this.triangles);

            this.colors = renderTriangle.AddColors(this.colors);
        }
    }
}
