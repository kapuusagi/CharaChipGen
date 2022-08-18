using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGenImaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CGenImagingTest
{
    [TestClass]
    public class GradiationTest
    {
        [TestMethod]
        public void GetColorTest()
        {
            var left = new GradiationEntry(0.0f, System.Drawing.Color.Black);
            var right = new GradiationEntry(1.0f, System.Drawing.Color.White);

            const int resolution = 256;

            for (int i = 0; i < resolution; i++)
            {
                float position = (float)(i) / (float)(resolution - 1);
                var c = Gradiation.GetColor(left, right, position);
                Assert.AreEqual(c.R, i);
                Assert.AreEqual(c.G, i);
                Assert.AreEqual(c.B, i);
            }
        }


        [TestMethod]
        public void LutTest()
        {
            var gradiationEntries = new GradiationEntry[]
            {
                new GradiationEntry(0.0f, System.Drawing.Color.Black),
                new GradiationEntry(0.25f, System.Drawing.Color.Red),
                new GradiationEntry(0.50f, System.Drawing.Color.Green),
                new GradiationEntry(0.75f, System.Drawing.Color.Blue),
                new GradiationEntry(1.0f, System.Drawing.Color.White)
            };
            var gradiation = new Gradiation(gradiationEntries);
            var lut = GradiationLut.CreateFrom(gradiation);

            {
                var refColor = gradiationEntries[0].Color;
                var testColor = lut[0];
                Assert.AreEqual(refColor.ToArgb(), testColor.ToArgb());
            }
            {
                var refColor = gradiationEntries[gradiationEntries.Length - 1].Color;
                var testColor = lut[lut.Resolution - 1];
                Assert.AreEqual(refColor.ToArgb(), testColor.ToArgb());
            }
        }
    }
}
