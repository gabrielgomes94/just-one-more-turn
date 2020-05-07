using System.Collections.Generic;
using UnityEngine;
using GameInput;

namespace Hex
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class HexMesh : MonoBehaviour, IInteractable
    {
        Mesh hexMesh;
        List<Vector3> vertices;
        List<int> triangles;

        MeshCollider meshCollider;

        List<Color> colors;

        void Awake()
        {
            GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
            meshCollider = gameObject.AddComponent<MeshCollider>();
            hexMesh.name = "Hex Mesh";

            vertices = new List<Vector3>();
            triangles = new List<int>();
            colors = new List<Color>();
        }

        public void Triangulate(HexCell[] cells)
        {
            ClearMesh();

            for (int i = 0; i < cells.Length; i++) {
                Triangulate(cells[i]);
            }

            hexMesh.vertices = vertices.ToArray();
            hexMesh.colors = colors.ToArray();
            hexMesh.triangles = triangles.ToArray();
            hexMesh.RecalculateNormals();

            meshCollider.sharedMesh = hexMesh;
        }

        private void Triangulate(HexCell cell)
        {
            Vector3 center = cell.transform.localPosition;

            for (int i = 0; i < 6; i++) {
                int vertexIndex = vertices.Count;
                AddTriangles(vertexIndex);

                AddVertices(
                    center,
                    center + HexMetrics.corners[i],
                    center + HexMetrics.corners[i + 1]
                );

                AddColor(cell.color);
            }
        }

        void AddVertices(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
        {
            vertices.Add(vertex1);
            vertices.Add(vertex2);
            vertices.Add(vertex3);
        }

        void AddTriangles(int vertexIndex)
        {
            for(int i = 0; i < 3; i++)
            {
                triangles.Add(vertexIndex + i);
            }
        }

        void AddColor(Color color)
        {
            for(int i = 0; i < 3; i++)
            {
                colors.Add(color);
            }
        }

        private void ClearMesh()
        {
            hexMesh.Clear();
            vertices.Clear();
            triangles.Clear();
            colors.Clear();
        }

        public bool isSelected { get; set; }
        public void Select()
        {
            Debug.Log("Mapa ==========|| interface");
        }
    }
}
