using UnityEngine;

namespace Voxel_Engine {
    public enum BlockState : byte {
        None,
        Stone
    }

    public static class BlockStateColor {
        public static Color GetColor(BlockState blockState) {
            switch (blockState) {
                case BlockState.None:
                    return Color.black;
                case BlockState.Stone:
                    return Color.grey;
                default:
                    return Color.black;
            }
            
        }
    }
}