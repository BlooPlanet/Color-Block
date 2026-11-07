using System.Collections.Generic;
using UnityEngine;

namespace Voxel_Engine {
    [RequireComponent(typeof(MeshFilter),typeof(MeshRenderer),typeof(MeshCollider))]
    public class Chunk : MonoBehaviour {
        
        public const int Width = 16, Height = 64, Depth = 16;
        BlockState[,,] blocks = new BlockState[Width,Height,Depth];

        MeshCollider meshCollider;
        
        public void Init(BlockState initialBlock) {
            if (blocks == null) {
                blocks = new BlockState[Width, Height, Depth];
            }

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    for (int z = 0; z < Depth; z++) {
                        blocks[x, y, z] = initialBlock;
                    }
                }
            }

            meshCollider = GetComponent<MeshCollider>();
        }

        public void ConstructMesh() {
            Mesh mesh = new Mesh();
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            
            meshCollider.sharedMesh = null;
            
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    for (int z = 0; z < Depth; z++) {
                        BlockState block = blocks[x, y, z];
                        Vector3 blockPos = new Vector3(x, y, z);
                        if (block != BlockState.None) {
                            BlockState upBlock = blocks[x, y + 1, z];
                            if (upBlock == BlockState.None) {
                                triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
                                vertices.AddRange(BlockFace.GetUpperVertices(blockPos));
                            }
                        }
                    }
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            GetComponent<MeshFilter>().mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }

        public void Start() {
            Init(BlockState.None);
            blocks[15, 62, 15] = BlockState.Stone;
            blocks[0, 0, 0] = BlockState.Stone;
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    for (int z = 0; z < Depth; z++) {
                        Debug.Log("vec3(" + new Vector3(x,y,z) + ") block: " + blocks[x,y,z]);
                    }
                }
            }
            ConstructMesh();
        }
        
    }
}

