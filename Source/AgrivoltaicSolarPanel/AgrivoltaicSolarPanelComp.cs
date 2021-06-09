using RimWorld;
using UnityEngine;
using Verse;

namespace AgrivoltaicSolarPanel
{
    [StaticConstructorOnStartup]
    public class AgrivoltaicSolarPanelComp : CompPowerPlant
    {
        private const float MaxCapacity = 1700f;

        private static readonly Vector2 BarSize = new Vector2(2.5f, 0.1f);

        private static readonly Material PowerPlantSolarBarFilledMat =
            SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.5f, 0.475f, 0.1f));

        private static readonly Material PowerPlantSolarBarUnfilledMat =
            SolidColorMaterials.SimpleSolidColorMaterial(new Color(0.15f, 0.15f, 0.15f));

        public CellRect OccupiedCells => CellRect.CenteredOn(parent.Position, 5, 5);

        private float PowerOutputD => Mathf.Lerp(0f, MaxCapacity, parent.Map.skyManager.CurSkyGlow);

        protected override float DesiredPowerOutput => PowerOutputD * RoofedPowerOutputFactor;

        private float RoofedPowerOutputFactor
        {
            get
            {
                var num = 0;
                var num2 = 0;

                foreach (var current in CellRect.CenteredOn(parent.Position, 5, 5))
                {
                    num++;
                    if (parent.Map.roofGrid.Roofed(current))
                    {
                        num2++;
                    }
                }

                return (num - num2) / (float) num;
            }
        }

        public override void PostDraw()
        {
            base.PostDraw();
            var r = default(GenDraw.FillableBarRequest);
            r.center = parent.DrawPos + (Vector3.up * 0.01f);
            r.center.z -= 0.06f;
            r.size = BarSize;
            r.fillPercent = PowerOutput / MaxCapacity;
            r.filledMat = PowerPlantSolarBarFilledMat;
            r.unfilledMat = PowerPlantSolarBarUnfilledMat;
            r.margin = 0.15f;
            var rotation = parent.Rotation;
            rotation.Rotate(RotationDirection.Clockwise);
            r.rotation = rotation;
            GenDraw.DrawFillableBar(r);
        }

        private static void DrawCircle(Vector3 center, Vector2 size, Material colorMaterial)
        {
            var matrix = default(Matrix4x4);
            var lineWidth = 0.02f;
            var frameHorizontalSize = new Vector3(size.x / 2, 1f, size.y);
            var frameVerticalSize = new Vector3(size.x, 1f, size.y / 2);
            var framePosition = center + (Vector3.up * 0.01f);
            var frameMaterial = SolidColorMaterials.SimpleSolidColorMaterial(Color.black);
            var colorHorizontalSize = new Vector3(size.x - lineWidth, 1f, (size.y - lineWidth) / 2);
            var colorVerticalSize = new Vector3((size.x - lineWidth) / 2, 1f, size.y - lineWidth);
            var colorPosition = center + (Vector3.up * 0.02f);

            matrix.SetTRS(framePosition, new Quaternion(), frameHorizontalSize);
            Graphics.DrawMesh(MeshPool.plane10, matrix, frameMaterial, 0);
            matrix.SetTRS(framePosition, new Quaternion(), frameVerticalSize);
            Graphics.DrawMesh(MeshPool.plane10, matrix, frameMaterial, 0);
            matrix.SetTRS(colorPosition, new Quaternion(), colorHorizontalSize);
            Graphics.DrawMesh(MeshPool.plane10, matrix, colorMaterial, 0);
            matrix.SetTRS(colorPosition, new Quaternion(), colorVerticalSize);
            Graphics.DrawMesh(MeshPool.plane10, matrix, colorMaterial, 0);
        }
    }
}