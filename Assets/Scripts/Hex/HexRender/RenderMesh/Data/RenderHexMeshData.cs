using System.Collections.Generic;
using UnityEngine;

namespace Hex.Render
{
    public class RenderHexMeshData
    {
        public List<int> triangles;
        public List<Vector3> vertices;
        public List<Color> colors;

        public RenderHexMeshData()
        {
            this.triangles = new List<int>();
            this.vertices = new List<Vector3>();
            this.colors = new List<Color>();
        }

        public void Clear()
        {
            triangles.Clear();
            vertices.Clear();
            colors.Clear();
        }
    }
}