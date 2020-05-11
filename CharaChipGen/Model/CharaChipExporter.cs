using CGenImaging;
using CharaChipGen.Model.CharaChip;
using System;
using System.Drawing;

namespace CharaChipGen.Model
{
    /// <summary>
    /// キャラクターチップまたは顔データをファイルにエクスポートするクラス。
    /// </summary>
    public static class CharaChipExporter
    {
        /// <summary>
        /// キャラチップデータをエクスポートする
        /// </summary>
        public static void ExportCharaChip(GeneratorSetting setting)
        {
            if (string.IsNullOrEmpty(setting.ExportSetting.ExportFilePath))
            {
                throw new ArgumentException("ExportFilePath not specified.");
            }

            Size charaChipSize = setting.ExportSetting.CharaChipSize;

            int charaPlaneWidth = charaChipSize.Width * 3;
            int charaPlaneHeight = charaChipSize.Height * 4;

            int exportImageWidth = charaPlaneWidth * 4;
            int exportImageHeight = charaPlaneHeight * 2;

            ImageBuffer exportBuffer = ImageBuffer.Create(exportImageWidth, exportImageHeight);

            for (int charaY = 0; charaY < 2; charaY++)
            {
                for (int charaX = 0; charaX < 4; charaX++)
                {
                    try
                    {
                        // キャラクターをレンダリングする。
                        ImageBuffer charaChipImage = RenderCharaChip(setting.GetCharacter(charaY * 4 + charaX), charaChipSize);
                        // レンダリングした画像をエクスポートバッファにコピーする。
                        exportBuffer.WriteImage(charaChipImage, charaX * charaPlaneWidth, charaY * charaPlaneHeight);
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"キャラクター{(charaY * 4 + charaX + 1)}:{e.Message}");
                    }
                }
            }

            Image image = null;
            image = exportBuffer.GetImage();
            image.Save(setting.ExportSetting.ExportFilePath);
        }

        /// <summary>
        /// 1キャラクターのキャラチップをレンダリングする。
        /// </summary>
        /// <param name="model">レンダリング対象のキャラチップ</param>
        /// <param name="chipSize">キャラチップサイズ</param>
        /// <returns>レンダリングしたImageBufferが返る。</returns>
        private static ImageBuffer RenderCharaChip(Character model, Size chipSize)
        {
            CharaChipRenderData renderData = new CharaChipRenderData();
            model.CopyTo(renderData.Character);

            if (renderData.HasError)
            {
                throw new Exception($"書き出し時にエラーが発生しました。");
            }

            ImageBuffer imageBuffer = ImageBuffer.Create(chipSize.Width * 3, chipSize.Height * 4);
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    ImageBuffer buffer = ImageBuffer.Create(chipSize.Width, chipSize.Height);
                    CharaChipRenderer.Draw(renderData, buffer, x, y);
                    imageBuffer.WriteImage(buffer, x * chipSize.Width, y * chipSize.Height);
                }
            }

            return imageBuffer;
        }
    }
}
