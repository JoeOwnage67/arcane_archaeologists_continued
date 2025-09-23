using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace ThingColor;

[StaticConstructorOnStartup]
public static class ThingColorMod
{
	static ThingColorMod()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		new Harmony("ThingColorMod").PatchAll();
	}

	public static Color? GetColorFor(this Thing thing, List<StuffCategoryDef> colorStuff)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		ThingDef stuff = thing.Stuff;
		if (stuff.stuffProps?.categories != null)
		{
			foreach (StuffCategoryDef category in stuff.stuffProps.categories)
			{
				if (colorStuff.Contains(category))
				{
					return stuff.stuffProps.color;
				}
			}
		}
		if (thing.def.CostList != null)
		{
			foreach (ThingDefCountClass cost in thing.def.CostList)
			{
				if (cost.thingDef.stuffProps?.categories == null)
				{
					continue;
				}
				foreach (StuffCategoryDef category2 in cost.thingDef.stuffProps.categories)
				{
					if (colorStuff.Contains(category2))
					{
						return cost.thingDef.stuffProps.color;
					}
				}
			}
		}
		return null;
	}
}
