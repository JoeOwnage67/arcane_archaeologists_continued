using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ThingColor;

[HarmonyPatch(typeof(ApparelGraphicRecordGetter), "TryGetGraphicApparel")]
public static class ApparelGraphicRecordGetter_TryGetGraphicApparel_Patch
{
    public static bool Prefix(ref bool __result, Apparel apparel, BodyTypeDef bodyType, ref ApparelGraphicRecord rec)
    {
        //IL_0001: Unknown result type (might be due to invalid IL or missing references)
        //IL_0006: Unknown result type (might be due to invalid IL or missing references)
        if (apparel.DrawColorTwo != Color.white)
        {
            __result = TryGetGraphicApparel(apparel, bodyType, ref rec);
            return false;
        }
        return true;
    }

    public static bool TryGetGraphicApparel(Apparel apparel, BodyTypeDef bodyType, ref ApparelGraphicRecord rec)
    {
        //IL_00d2: Unknown result type (might be due to invalid IL or missing references)
        //IL_00d8: Unknown result type (might be due to invalid IL or missing references)
        //IL_00de: Unknown result type (might be due to invalid IL or missing references)
        if (bodyType == null)
        {
            Log.Error("Getting apparel graphic with undefined body type.");
            bodyType = BodyTypeDefOf.Male;
        }
        if (apparel.WornGraphicPath.NullOrEmpty())
        {
            rec = new ApparelGraphicRecord(null, null);
            return false;
        }
        string path = ((apparel.def.apparel.LastLayer != ApparelLayerDefOf.Overhead && apparel.def.apparel.LastLayer != ApparelLayerDefOf.EyeCover && !apparel.RenderAsPack() && !(apparel.WornGraphicPath == BaseContent.PlaceholderImagePath) && !(apparel.WornGraphicPath == BaseContent.PlaceholderGearImagePath)) ? (apparel.WornGraphicPath + "_" + bodyType.defName) : apparel.WornGraphicPath);
        Shader shader = ShaderDatabase.Cutout;
        if (apparel.def.apparel.useWornGraphicMask)
        {
            shader = ShaderDatabase.CutoutComplex;
        }
        Graphic graphic = GraphicDatabase.Get<Graphic_Multi>(path, shader, apparel.def.graphicData.drawSize, apparel.DrawColor, apparel.DrawColorTwo);
        rec = new ApparelGraphicRecord(graphic, apparel);
        return true;
    }
}
