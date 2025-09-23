using RimWorld;
using UnityEngine;
using Verse;

namespace ThingColor;

public class ApparelColored : Apparel
{
	public override Color DrawColor
	{
		get
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			CompColorable comp = GetComp<CompColorable>();
			if (comp != null && comp.Active)
			{
				return comp.Color;
			}
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
