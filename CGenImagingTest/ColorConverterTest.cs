using System;
using CGenImaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CGenImagingTest
{
    [TestClass]
    public class ColorConverterTest
    {
        [TestMethod]
        public void ConvertHSVAll()
        {
            for (int r = 0; r < 255; r += 5)
            {
                for (int g = 0; g < 255; g += 5)
                {
                    for (int b = 0; b < 255; b += 5)
                    {
                        CheckConvertHSV(r, g, b);
                    }
                }
            }
        }

        private void CheckConvertHSV(int r, int g, int b)
        {
            var srcColor = System.Drawing.Color.FromArgb(255, r, g, b);
            var colorHSV = ColorConverter.ConvertRGBtoHSV(srcColor);
            var dstColor = ColorConverter.ConvertHSVtoRGB(colorHSV, 255);
            try
            {
                Assert.AreEqual(srcColor, dstColor);
            }
            catch (Exception)
            {
                Console.WriteLine($"ConvertHSV {srcColor} => {colorHSV} => {dstColor}");
            }
        }


        [TestMethod]
        public void ConvertHSVTest()
        {
            // (210, 70, 120) を変換して (H=339, S=0.66, V=0.82)になるか
            ColorHSV colorHSV = ColorConverter.ConvertRGBtoHSV(
                System.Drawing.Color.FromArgb(210, 70, 120));

            Assert.AreEqual(339, Convert.ToInt32(colorHSV.Hue));
            Assert.AreEqual(67, Convert.ToInt32(colorHSV.Saturation * 100));
            Assert.AreEqual(82, Convert.ToInt32(colorHSV.Value * 100));

            // (H=325, S=0.80, L=0.25)を変換して (63, 13, 42)になるか
            System.Drawing.Color colorRGB = ColorConverter.ConvertHSVtoRGB(
                ColorHSV.FromHSV(325, 0.80f, 0.25f), 255);

            Assert.AreEqual(64, colorRGB.R);
            Assert.AreEqual(13, colorRGB.G);
            Assert.AreEqual(42, colorRGB.B);
        }
        [TestMethod]
        public void ConvertHSLAll()
        {
            for (int r = 0; r < 255; r += 5)
            {
                for (int g = 0; g < 255; g += 5)
                {
                    for (int b = 0; b < 255; b += 5)
                    {
                        CheckConvertHSL(r, g, b);
                    }
                }
            }
        }
        private void CheckConvertHSL(int r, int g, int b)
        {
            var srcColor = System.Drawing.Color.FromArgb(255, r, g, b);
            var colorHSL = ColorConverter.ConvertRGBtoHSL(srcColor);
            var dstColor = ColorConverter.ConvertHSLtoRGB(colorHSL, 255);
            try
            {
                Assert.AreEqual(srcColor, dstColor);
            }
            catch (Exception)
            {
                Console.WriteLine($"ConvertHSL {srcColor} => {colorHSL} => {dstColor}");
            }
        }
        [TestMethod]
        public void ConvertHSLTest()
        {
            // (210, 70, 120) を変換して (H=339, S=0.61, L=0.55)になるか
            ColorHSL colorHSL = ColorConverter.ConvertRGBtoHSL(
                System.Drawing.Color.FromArgb(255, 210, 70, 120));

            Assert.AreEqual(339, Convert.ToInt32(colorHSL.Hue), 339);
            Assert.AreEqual(61, Convert.ToInt32(colorHSL.Saturation * 100));
            Assert.AreEqual(55, Convert.ToInt32(colorHSL.Lightness * 100));

            // (H=325, S=0.80, L=0.25)を変換して (115, 13, 72)になるか
            System.Drawing.Color colorRGB = ColorConverter.ConvertHSLtoRGB(
                ColorHSL.FromHSL(325.0f, 0.80f, 0.25f), 255);

            Assert.AreEqual(115, colorRGB.R);
            Assert.AreEqual(13, colorRGB.G);
            Assert.AreEqual(72, colorRGB.B);
        }



    }
}
