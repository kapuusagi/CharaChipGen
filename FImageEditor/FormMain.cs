﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGenImaging;

namespace FImageEditor
{
    /// <summary>
    /// FormMain
    /// 
    /// メイン画面
    /// </summary>
    public partial class FormMain : Form
    {
        private FaceImageSet faceImageEntrySet;
        /// <summary>
        /// FormMainを構築する。
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            faceImageEntrySet = new FaceImageSet();
            faceViewControl1.FaceImageEntry = faceImageEntrySet.GetEntry(0);
            faceViewControl2.FaceImageEntry = faceImageEntrySet.GetEntry(1);
            faceViewControl3.FaceImageEntry = faceImageEntrySet.GetEntry(2);
            faceViewControl4.FaceImageEntry = faceImageEntrySet.GetEntry(3);
            faceViewControl5.FaceImageEntry = faceImageEntrySet.GetEntry(4);
            faceViewControl6.FaceImageEntry = faceImageEntrySet.GetEntry(5);
            faceViewControl7.FaceImageEntry = faceImageEntrySet.GetEntry(6);
            faceViewControl8.FaceImageEntry = faceImageEntrySet.GetEntry(7);
        }
        /// <summary>
        /// Exitボタンが押されたときの処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonExitClick(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// フォームがクローズされようとしているときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }


        /// <summary>
        /// 生成ボタンがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnButtonGenerateClick(object sender, EventArgs e)
        {
            try
            {
                ExportProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// 生成ボタンがクリックされた時の処理を行う。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemGenerateClick(object sender, EventArgs e)
        {
            try
            {
                ExportProc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// エクスポート処理
        /// </summary>
        private void ExportProc()
        {
            var lastFileName = Properties.Settings.Default.LastExportPath;
            if (System.IO.File.Exists(lastFileName))
            {
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastFileName);
                saveFileDialog.FileName = System.IO.Path.GetDirectoryName(lastFileName);
            }
            saveFileDialog.Filter = Properties.Resources.FILEFILTER_IMAGE;
            saveFileDialog.FilterIndex = 0;
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            Properties.Settings.Default.LastExportPath = saveFileDialog.FileName;
            var exportFileName = saveFileDialog.FileName;

            // サクッと生成する。
            ImageBuffer imageBuffer = ImageBuffer.Create(faceImageEntrySet.ExportWidth, faceImageEntrySet.ExportHeight);

            for (int i = 0; i < faceImageEntrySet.EntryCount; i++)
            {
                var entry = faceImageEntrySet.GetEntry(i);
                if (!string.IsNullOrEmpty(entry.FileName))
                {
                    using (var srcImage = Image.FromFile(entry.FileName))
                    {
                        var writeImage = ImageBuffer.CreateFrom(srcImage);
                        int dstXOffs = entry.Width * (i % faceImageEntrySet.HorizontalEntryCount);
                        int dstYOffs = entry.Height * (i / faceImageEntrySet.HorizontalEntryCount);
                        imageBuffer.WriteImage(writeImage, entry.X, entry.Y, dstXOffs, dstYOffs, entry.Width, entry.Height);
                    }
                }
            }

            using (var image = imageBuffer.GetImage())
            {
                image.Save(exportFileName);
            }
        }

        /// <summary>
        /// Newメニュー項目がクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemNewClick(object sender, EventArgs e)
        {
            faceImageEntrySet.Clear();
            Properties.Settings.Default.LastSaveSettingPath = string.Empty;
        }

        /// <summary>
        /// 新規保存メニューがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemSaveNewClick(object sender, EventArgs e)
        {
            try
            {
                ProcSaveNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void ProcSaveNew()
        {
            // 最後の編集ファイルに合わせ、ファイル選択ダイアログを設定
            var lastFileName = Properties.Settings.Default.LastSaveSettingPath;
            if (System.IO.File.Exists(lastFileName))
            {
                saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastFileName);
                saveFileDialog.FileName = System.IO.Path.GetDirectoryName(lastFileName);
            }
            saveFileDialog.Filter = Properties.Resources.FILEFILTER_SETTING;
            saveFileDialog.FilterIndex = 0;

            // ファイル選択する
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            // 保存処理する。
            Properties.Settings.Default.LastSaveSettingPath = saveFileDialog.FileName;
            faceImageEntrySet.SaveTo(saveFileDialog.FileName);
        }
        /// <summary>
        /// 保存メニューがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemSaveClick(object sender, EventArgs e)
        {
            try
            {
                var lastSaveSettingPath = Properties.Settings.Default.LastSaveSettingPath;
                if (string.IsNullOrEmpty(lastSaveSettingPath))
                {
                    ProcSaveNew();
                }
                else
                {
                    faceImageEntrySet.SaveTo(lastSaveSettingPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// 開くメニューがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemOpenClick(object sender, EventArgs e)
        {
            try
            {
                var lastFileName = Properties.Settings.Default.LastSaveSettingPath;
                if (System.IO.File.Exists(lastFileName))
                {
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(lastFileName);
                    openFileDialog.FileName = System.IO.Path.GetDirectoryName(lastFileName);
                }
                openFileDialog.Filter = Properties.Resources.FILEFILTER_SETTING;
                openFileDialog.FilterIndex = 0;
                if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                Properties.Settings.Default.LastSaveSettingPath = openFileDialog.FileName;

                faceImageEntrySet.LoadFrom(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }


    }
}
