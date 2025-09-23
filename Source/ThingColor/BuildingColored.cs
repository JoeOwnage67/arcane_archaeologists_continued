using UnityEngine;
using Verse;

namespace ThingColor;

public class BuildingColored : Building
{
	public override Color DrawColor
	{
		get
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			ThingExtension modExtension = def.GetModExtension<ThingExtension>();
			Color? colorFor = this.GetColorFor(modExtension.colorOneStuff);
			if (colorFor.HasValue)
			{
				return colorFor.Value;
			}
			return base.DrawColor;
		}
	}

	public override Color DrawColorTwo
	{
		get
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			ThingExtension modExtension = def.GetModExtension<ThingExtension>();
			Color? colorFor = this.GetColorFor(modExtension.colorTwoStuff);
			if (colorFor.HasValue)
			{
				return colorFor.Value;
			}
			return base.DrawColorTwo;
		}
	}
}
