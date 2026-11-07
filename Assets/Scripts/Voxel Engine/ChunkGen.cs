using UnityEngine;

namespace Voxel_Engine {
    public class ChunkGen : MonoBehaviour {
        public Material mat;
        public void Start() {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    Vector3 chunkCoord = new Vector3(x * 16, 0, z * 16);
                    GameObject chunkObj = new GameObject("Chunk " + chunkCoord);
                    chunkObj.transform.position = chunkCoord;
                    Chunk chunk = chunkObj.AddComponent<Chunk>();
                    chunk.mat = mat;
                    chunk.Init(BlockState.None);
                    chunk.GenerateBlocks();
                    chunk.ConstructMesh();
                }
            }
        }
    }
}
