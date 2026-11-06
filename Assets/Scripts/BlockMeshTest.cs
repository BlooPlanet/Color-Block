using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxel_Engine;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class BlockMeshTest : MonoBehaviour {
    void Start() {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        Vector3 blockPos = new Vector3(0, 0, 0);
        
        // top
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetUpperVertices(blockPos));
        // down
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetDownVertices(blockPos));
        // right
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetRightVertices(blockPos));
        // left
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetLeftVertices(blockPos));
        // front
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetFrontVertices(blockPos));
        // back
        triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
        vertices.AddRange(BlockFace.GetBackVertices(blockPos));
        
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

    }
}
