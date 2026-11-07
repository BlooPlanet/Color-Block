using System.Collections.Generic;
using UnityEngine;

namespace Voxel_Engine {
    [RequireComponent(typeof(MeshFilter),typeof(MeshRenderer),typeof(MeshCollider))]
    public class Chunk : MonoBehaviour {
        
        public const int Width = 16, Height = 64, Depth = 16;
        BlockState[,,] blocks = new BlockState[Width,Height,Depth];

        MeshCollider meshCollider;
        MeshFilter meshFilter;
        public Material mat;
        
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
            meshFilter = GetComponent<MeshFilter>();
        }

        public void SetBlock(Vector3Int blockCoord, BlockState blockState) {
            if (InBound(blockCoord.x, blockCoord.y, blockCoord.z)) {
                blocks[blockCoord.x, blockCoord.y, blockCoord.z] = blockState;
            }
        }

        public bool InBound(int x, int y, int z) {
            return x >= 0 && x < Width && y >= 0 && y < Height && z >= 0 && z < Depth;
        }

        public BlockState GetBlock(int x, int y, int z) {
            if (InBound(x, y, z)) {
                return blocks[x, y, z];
            }

            return BlockState.None;
        }

        public BlockState GetBlock(Vector3Int blockPos) {
            return GetBlock(blockPos.x, blockPos.y, blockPos.z);
        }
        
        public void ConstructMesh() {
            Mesh mesh = new Mesh();
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Color> colors = new List<Color>();
            
            meshCollider.sharedMesh = null;
            
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    for (int z = 0; z < Depth; z++) {
                        BlockState block = blocks[x, y, z];
                        Vector3Int blockPos = new Vector3Int(x, y, z);
                        Color blockColor = BlockStateColor.GetColor(block);
                        if (block != BlockState.None) {
                            
                            for (int i = 0; i < BlockFace.directions.Length; i++) {
                                Vector3Int direction = BlockFace.directions[i];
                                if (GetBlock(blockPos + direction) == BlockState.None) {
                                    triangles.AddRange(BlockFace.GetTrisIndex(vertices.Count));
                                    vertices.AddRange(BlockFace.GetVertices(i,blockPos));
                                    for (int j = 0; j < 4; j++) {
                                        colors.Add(blockColor);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.colors = colors.ToArray();
            mesh.RecalculateNormals();
            
            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
        }

        public void Start() {
            Init(BlockState.None);
            GenerateBlocks();
            ConstructMesh();
        }

        public void GenerateBlocks() {
            for (int x = 0; x < Width; x++) {
                for (int z = 0; z < Depth; z++) {
                    for (int y = 0; y < 4; y++) {
                        blocks[x, y, z] = (BlockState)Random.Range(1,4);
                    }
                }
            }
        }
        
    }
}

