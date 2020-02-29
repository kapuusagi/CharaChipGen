using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CGenImaging;
using CharaChipGen.Model.CharaChip;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクターチップまたは顔データをファイルにエクスポートするクラス。
    /// </summary>
    public class CharaChipExporter
    {
        private CharaChipExporter()
        {

        }

        /// <summary>
        /// キャラチップデータをエクスポートする
        /// </summary>
        /// <param name="filePath"></param>
        public static void ExportCharaChip(string filePath)
        {
            AppData appData = AppData.Instance;
            Size charaChipSize = appData.ExportSetting.CharaChipSize;

            int charaPlaneWidth = charaChipSize.Width * 3;
            int charaPlaneHeight = charaChipSize.Height * 4;

            int exportImageWidth = charaPlaneWidth * 4;
            int exportImageHeight = charaPlaneHeight * 2;

            ImageBuffer exportBuffer = ImageBuffer.Create(exportImageWidth, exportImageHeight);

            for (int charaY = 0; charaY < 2; charaY++)
            {
                for (int charaX = 0; charaX < 4; charaX++)
                {
                    // キャラクターをレンダリングする。
                    ImageBuffer charaChipImage = RenderCharaChip(appData.GetCharaChipData(charaY * 4 + charaX), charaChipSize);
                    // レンダリングした画像をエクスポートバッファにコピーする。
                    exportBuffer.WriteImage(charaChipImage, charaX * charaPlaneWidth, charaY * charaPlaneHeight);
                }
            }

            Image image = null;
            if (appData.ExportSetting.IsRenderTwice) {
                ImageBuffer twiceImage = ImageProcessor.ExpansionX2(exportBuffer);
                image = twiceImage.GetImage();
            } else {
                image = exportBuffer.GetImage();
            }
            image.Save(filePath);
        }

        /// <summary>
        /// 1キャラクターのキャラチップをレンダリングする。
        /// </summary>
        /// <param name="model">レンダリング対象のキャラチップ</param>
        /// <param name="chipSize">キャラチップサイズ</param>
        /// <returns>レンダリングしたImageBufferが返る。</returns>
        private static ImageBuffer RenderCharaChip(Charactor model, Size chipSize)
        {
            CharaChipRenderModel renderModel = new CharaChipRenderModel();
            model.CopyTo(renderModel.CharaChipDataModel);

            ImageBuffer imageBuffer = ImageBuffer.Create(chipSize.Width * 3, chipSize.Height * 4);
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    ImageBuffer buffer = ImageBuffer.Create(chipSize.Width, chipSize.Height);
                    CharaChipGenerator.Draw(renderModel, buffer, x, y);
                    imageBuffer.WriteImage(buffer, x * chipSize.Width, y * chipSize.Height);
                }
            }

            return imageBuffer;
        }


    }
}
