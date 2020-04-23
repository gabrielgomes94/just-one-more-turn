using System.Collections.Generic;
using UnityEngine;
using Input;

namespace Hex
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class HexMesh : MonoBehaviour, IInteractable
    {
        Mesh hexMesh;
        List<Vector3> vertices;
        List<int> triangles;

        MeshCollider meshCollider;

        void Awake()
        {
            GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
            meshCollider = gameObject.AddComponent<MeshCollider>();
            hexMesh.name = "Hex Mesh";

            vertices = new List<Vector3>();
            triangles = new List<int>();
        }

        public void Triangulate(HexCell[] cells)
        {
            ClearMesh();

            for (int i = 0; i < cells.Length; i++) {
                Triangulate(cells[i]);
            }

            hexMesh.vertices = vertices.ToArray();
            hexMesh.triangles = triangles.ToArray();
            hexMesh.RecalculateNormals();

            meshCollider.sharedMesh = hexMesh;
        }

        private void Triangulate(HexCell cell)
        {
            Vector3 center = cell.transform.localPosition;
            for (int i = 0; i < 6; i++) {
                AddTriangle(
                    center,
                    center + HexMetrics.corners[i],
                    center + HexMetrics.corners[i + 1]

                );
            }
        }

        void AddTriangle(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
        {
            int vertexIndex = vertices.Count;

            vertices.Add(vertex1);
            vertices.Add(vertex2);
            vertices.Add(vertex3);

            triangles.Add(vertexIndex);
            triangles.Add(vertexIndex + 1);
            triangles.Add(vertexIndex + 2);
        }

        private void ClearMesh()
        {
            hexMesh.Clear();
            vertices.Clear();
            triangles.Clear();
        }

        public bool isSelected { get; set; }
        public void Select()
        {
            Debug.Log("Mapa ==========|| interface");
        }
    }
}
