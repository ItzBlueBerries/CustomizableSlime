using CustomizableSlime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

internal class OtherFunc
{
    public static Texture2D LoadImage(string filename) // thanks aidan or whoever created this at first- lol
    {
        var a = Assembly.GetExecutingAssembly();
        var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
        var rawData = new byte[spriteData.Length];
        spriteData.Read(rawData, 0, rawData.Length);
        var tex = new Texture2D(1, 1);
        tex.LoadImage(rawData);
        tex.filterMode = FilterMode.Bilinear;
        return tex;
    }
    public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);

    public static Texture2D LoadAsset(string imagePath)
    {
        byte[] byteArray = File.ReadAllBytes($"{Environment.CurrentDirectory}\\CustomizableSlime\\" + imagePath);
        Texture2D sampleTexture = new Texture2D(2, 2);
        sampleTexture.LoadImage(byteArray);
        return sampleTexture;
    }
}

internal class RandomFunc
{
    public static Color32 RandomColor32()
    {
        byte Red = Convert.ToByte(Randoms.SHARED.GetInRange(0, 255));
        byte Green = Convert.ToByte(Randoms.SHARED.GetInRange(0, 255));
        byte Blue = Convert.ToByte(Randoms.SHARED.GetInRange(0, 255));
        Color32 randomColor = new Color32(Red, Green, Blue, byte.MaxValue);
        return randomColor;
    }
}

/*internal class LargoGameFix
{

    public static bool MissingIdentifiable(ref string value)
    {
        List<Identifiable.Id> ids = new List<Identifiable.Id>()
        {
            LargoIds.CUSTOMIZABLE_PINK_LARGO,
            LargoIds.CUSTOMIZABLE_ROCK_LARGO,
            LargoIds.CUSTOMIZABLE_TABBY_LARGO
        };

        ShortcutLib.Debugging.Log("Missing identifiable: " + value, true);
        bool result = false;

        if (ids.Select(x => x.ToString()).Contains(value))
        {
            value = value.Replace("CUSTOMIZABLE_", string.Empty).Replace("_LARGO", "_SLIME");
            ShortcutLib.Debugging.Log(value);
            result = true;
        }

        return result;
    }
}*/