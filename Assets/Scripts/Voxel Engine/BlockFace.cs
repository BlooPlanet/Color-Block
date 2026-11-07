using UnityEngine;

namespace Voxel_Engine {
    public static class BlockFace {
        public static Vector3[] GetUpperVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(0, 1, 0) + blockPos, new Vector3(1, 1, 0) + blockPos,
                new Vector3(0, 1, 1) + blockPos, new Vector3(1, 1, 1) + blockPos,
            };
        }
        
        public static Vector3[] GetDownVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(0, 0, 1) + blockPos, new Vector3(1, 0, 1) + blockPos,
                new Vector3(0, 0, 0) + blockPos, new Vector3(1, 0, 0) + blockPos,
            };
        }
        
        public static Vector3[] GetRightVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(1, 0, 0) + blockPos, new Vector3(1, 0, 1) + blockPos,
                new Vector3(1, 1, 0) + blockPos, new Vector3(1, 1, 1) + blockPos,
            };
        }
        
        public static Vector3[] GetLeftVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(0, 1, 0) + blockPos, new Vector3(0, 1, 1) + blockPos,
                new Vector3(0, 0, 0) + blockPos, new Vector3(0, 0, 1) + blockPos,
            };
        }
        
        public static Vector3[] GetFrontVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(0, 1, 1) + blockPos, new Vector3(1, 1, 1) + blockPos,
                new Vector3(0, 0, 1) + blockPos, new Vector3(1, 0, 1) + blockPos,
            };
        }
        
        public static Vector3[] GetBackVertices(Vector3 blockPos) {
            return new[] {
                new Vector3(0, 0, 0) + blockPos, new Vector3(1, 0, 0) + blockPos,
                new Vector3(0, 1, 0) + blockPos, new Vector3(1, 1, 0) + blockPos,
            };
        }
        
        public static int[] GetTrisIndex(int v) {
            return new[] {
                2 + v, 1 + v, 0 + v,
                1 + v, 2 + v, 3 + v
            };
        }

        public static Vector3Int[] directions = new[] {
            Vector3Int.up,
            Vector3Int.down,
            Vector3Int.forward,
            Vector3Int.back,
            Vector3Int.right,
            Vector3Int.left
        };

        public static Vector3[] GetVertices(int i,Vector3 blockPos) {
            switch (i) {
                case 0:
                    return GetUpperVertices(blockPos);
                case 1:
                    return GetDownVertices(blockPos);
                case 2:
                    return GetFrontVertices(blockPos);  
                case 3:
                    return GetBackVertices(blockPos);
                case 4:
                    return GetRightVertices(blockPos);
                case 5:
                    return GetLeftVertices(blockPos);
                default:
                    return null;
            }
        }
    }
}