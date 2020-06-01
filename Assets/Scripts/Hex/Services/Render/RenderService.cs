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

        private Vector3 bridge;
        private Vector3 vertex1;
        private Vector3 vertex2;
        private Vector3 vertex3;
        private Vector3 vertex4;

        private NeighborService neighborService;

        public RenderService()
        {
            this.triangles = new NativeList<int>(Allocator.TempJob);
            this.vertices = new NativeList<Vector3>(Allocator.TempJob);
            this.colors = new NativeList<Color>(Allocator.TempJob);
        }

        public void Execute(
            Entity entity,
            Vector3 centerPosition,
            HexCoordinates hexCoordinates,
            ColorComponent colorComponent,
            EntityQuery query
        ) {
            neighborService = new NeighborService(
                entity,
                query
            );

            Color color = colorComponent.Value;
            this.centerPosition = centerPosition;

            for (HexDirection direction = HexDirection.NE; direction <= HexDirection.NW; direction++)
            {
                this.bridge = HexMetrics.GetBridge(direction);
                this.vertex1 = centerPosition + HexMetrics.GetFirstSolidCorner(direction);
                this.vertex2 = centerPosition + HexMetrics.GetSecondSolidCorner(direction);
                this.vertex3 = vertex1 + bridge;
                this.vertex4 = vertex2 + bridge;
                vertex3.y = vertex4.y = neighborService.GetNeighborElevation(direction) * HexMetrics.elevationStep;

                // Create Main Triangle
                CreateMainTriangle(color);

                // Create Edge Quad
                if (direction > HexDirection.SE) continue;
                if (!neighborService.HasNeighbor(direction)) continue;

                Color neighborColor = neighborService.GetNeighborColor(direction);
                Color nextNeighborColor = neighborService.GetNeighborColor(direction.Next());

                CreateEdgeQuad(color, neighborColor);

                // Create corner triangle
                if(direction > HexDirection.E || !neighborService.HasNeighbor(direction.Next())) continue;

                CreateCornerTriangle(color, neighborColor, nextNeighborColor, direction.Next());
            }

            neighborService.Dispose();
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

        public void Dispose()
        {
            this.triangles.Dispose();
            this.vertices.Dispose();
            this.colors.Dispose();
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

        private void CreateMainTriangle(Color color)
        {
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
        }

        private void CreateEdgeQuad(Color color1, Color color2)
        {

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
                    color1,
                    color2
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
        }

        private void CreateCornerTriangle(Color color1, Color color2, Color color3, HexDirection direction)
        {
            // Vector3 bridge = ;
            Vector3 vertex5 = vertex2 + HexMetrics.GetBridge(direction);
            int elevation = neighborService.GetNeighborElevation(direction);
			vertex5.y = elevation * HexMetrics.elevationStep;
			// AddTriangle(v2, v4, v5);

            NativeArray<Vector3> edgeTriangleVertices = new NativeArray<Vector3>(new Vector3[] {
                vertex2,
                vertex4,
                vertex5
            }, Allocator.TempJob);

            NativeArray<Color> edgeTriangleColors = new NativeArray<Color>(new Color[] {
                color1,
                color2,
                color3,
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
