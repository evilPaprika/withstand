using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class MenuItems : MonoBehaviour
{

    [MenuItem("Sprites/Make spreadsheeats")]
    static void SetPivots()
    {

        Object[] textures = GetSelectedTextures();

        Selection.objects = new Object[0];
        foreach (Texture2D texture in textures)
        {
            string path = AssetDatabase.GetAssetPath(texture);
            TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
//            ti.isReadable = true;
            ti.spritePivot = Vector2.zero;
            ti.spriteImportMode = SpriteImportMode.Multiple;
            List<SpriteMetaData> newData = new List<SpriteMetaData>();
            int SliceWidth = 100000;
            print(texture.name);
            if (texture.name.EndsWith("leaves"))
                 SliceWidth = (int)(texture.width / 3f);
            else if (texture.name.EndsWith("trunk"))
            {
                SliceWidth = (int) (texture.width / 5f);
            }
            else
            {
                print("WTF?");
                continue;
            }
            print("test");
            int SliceHeight = texture.height;
            int n = 0;
            for (int i = 0; i < texture.width; i += SliceWidth)
            {

                for (int j = texture.height; j > 0; j -= SliceHeight)
                {
                    SpriteMetaData smd = new SpriteMetaData();
                    smd.pivot = Vector2.zero; 
                    smd.alignment = 1;
                    smd.name = n.ToString();
                    smd.rect = new Rect(i, j - SliceHeight, SliceWidth, SliceHeight);

                    newData.Add(smd);
                }
                n++;
            }
            ti.spritesheet = newData.ToArray();
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
        }
    }

    static Object[] GetSelectedTextures()
    {
        return Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
    }
}