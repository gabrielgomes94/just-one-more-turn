using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Hex
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