using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TGS.Utility
{
    public class SpriteDivide
    {
        /// <summary>
        /// 画像を分割 (UNITY_EDITOR)
        /// </summary>
        /// <param name="spritePath">画像のパス</param>
        /// <param name="horizontalNum">横方向の分割数</param>
        /// <param name="verticalNum">縦方向の分割数</param>
        public static void Divide(string spritePath, int horizontalNum, int verticalNum)
        {
#if UNITY_EDITOR

            //画像ファイルの読み込み
            TextureImporter importer = TextureImporter.GetAtPath(spritePath) as TextureImporter;

            //画像ファイルの設定
            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Multiple;

            //設定の適用
            EditorUtility.SetDirty(importer);
            AssetDatabase.ImportAsset(spritePath, ImportAssetOptions.ForceUpdate);

            //画像ファイルをTextureとして読み込む
            Texture texture = AssetDatabase.LoadAssetAtPath(spritePath, typeof(Texture)) as Texture;

            //分割後のサイズを指定
            importer.spritePixelsPerUnit = Mathf.Max(texture.width / horizontalNum, texture.height / verticalNum);

            //画像の分割
            float width = texture.width / horizontalNum;
            float height = texture.height / verticalNum;
            
            importer.spritesheet = Enumerable
                .Range(0, horizontalNum * verticalNum)
                .Select(index =>
                {
                    int x = index % horizontalNum;
                    int y = index / horizontalNum;

                    return new SpriteMetaData
                    {
                        name = string.Format("{0}_{1}", texture.name, index),
                        rect = new Rect(width * x, texture.height - height * (y + 1), width, height)
                    };
                }).ToArray();

            //分割の適用
            EditorUtility.SetDirty(importer);
            AssetDatabase.ImportAsset(spritePath, ImportAssetOptions.ForceUpdate);

#endif
        }
    }
}