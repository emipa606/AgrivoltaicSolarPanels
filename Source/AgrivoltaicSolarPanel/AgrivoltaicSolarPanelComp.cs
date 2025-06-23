using RimWorld;
using UnityEngine;
using Verse;

namespace AgrivoltaicSolarPanel;

[StaticConstructorOnStartup]
public class AgrivoltaicSolarPanelComp : CompPowerPlant
{
    private const float MaxCapacity = 1700f;

    private static readonly Vector2 barSize = new(2.5f, 0.1f);

    private static readonly Material PowerPlantSolarBarFilledMat =
        SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.5f, 0.475f, 0.1f));

    private static readonly Material PowerPlantSolarBarUnfilledMat =
        SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.15f, 0.15f, 0.15f));

    private float PowerOutputD => Mathf.Lerp(0f, MaxCapacity, parent.Map.skyManager.CurSkyGlow);

    protected override float DesiredPowerOutput => PowerOutputD * RoofedPowerOutputFactor;

    private float RoofedPowerOutputFactor
    {
        get
        {
            if (parent?.Map == null)
            {
                return 1f;
            }

            var num = 0;
            var num2 = 0;

            foreach (var current in CellRect.CenteredOn(parent.Position, 5, 5))
            {
                if (!current.InBounds(parent.Map))
                {
                    continue;
                }

                num++;
                if (parent.Map.roofGrid.Roofed(current))
                {
                    num2++;
                }
            }

            return num == 0 ? 1f : (num - num2) / (float)num;
        }
    }

    public override void PostDraw()
    {
        base.PostDraw();
        var r = default(GenDraw.FillableBarRequest);
        r.center = parent.DrawPos + (Vector3.up * 0.01f);
        r.center.z -= 0.06f;
        r.size = barSize;
        r.fillPercent = PowerOutput / MaxCapacity;
        r.filledMat = PowerPlantSolarBarFilledMat;
        r.unfilledMat = PowerPlantSolarBarUnfilledMat;
        r.margin = 0.15f;
        var rotation = parent.Rotation;
        rotation.Rotate(RotationDirection.Clockwise);
        r.rotation = rotation;
        GenDraw.DrawFillableBar(r);
    }
}