using UnityEngine;

namespace Voxel_Engine {
    public enum BlockState : byte {
        None,
        Stone_light,
        Stone_mid,
        Stone_dark
    }

    public static class BlockStateColor {
        public static Color GetColor(BlockState blockState) {
            switch (blockState) {
                case BlockState.None:
                    return Color.black;
                case BlockState.Stone_light:
                    return new Color(0.6f,0.6f,0.6f);
                case BlockState.Stone_mid:
                    return new Color(0.58f, 0.58f, 0.58f);
                case BlockState.Stone_dark:
                    return new Color(0.55f, 0.55f, 0.55f);
                default:
                    return Color.black;
            }
            
        }
    }
}