﻿using CharaChipGen.Model.CharaChip;
using System;
using System.Windows.Forms;

namespace CharaChipGen.GeneratorForm
{
    /// <summary>
    /// キャラチップ生成フォーム
    /// </summary>
    public partial class CharaChipGeneratorForm : Form
    {
        private Character character; // キャラクターチップデータモデル

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharaChipGeneratorForm()
        {
            character = new Character();
            InitializeComponent();
            InitializeComboBoxItems();

            charaChipView.SetCharacter(character);

            partsViewHead.Parts = character.Head;
            partsViewEye.Parts = character.Eye;
            partsViewHairStyle.Parts = character.Hair;
            partsViewBody.Parts = character.Body;
            partsViewAccessory1.Parts = character.Accessory1;
            partsViewAccessory2.Parts = character.Accessory2;
            partsViewAccessory3.Parts = character.Accessory3;
            partsViewHeadAccessory1.Parts = character.HeadAccessory1;
            partsViewHeadAccessory2.Parts = character.HeadAccessory2;
        }

        /// <summary>
        /// データモデル
        /// </summary>
        public Character Character {
            get { return character; }
            set { value.CopyTo(character); }
        }

        /// <summary>
        /// コンボボックスの項目を初期化する。
        /// </summary>
        private void InitializeComboBoxItems()
        {
            AppData data = AppData.Instance;
            partsViewHead.SetMaterialList(data.Heads);
            partsViewEye.SetMaterialList(data.Eyes);
            partsViewHairStyle.SetMaterialList(data.HairStyles);
            partsViewBody.SetMaterialList(data.Bodies);
            partsViewAccessory1.SetMaterialList(data.Accessories);
            partsViewAccessory2.SetMaterialList(data.Accessories);
            partsViewAccessory3.SetMaterialList(data.Accessories);
            partsViewHeadAccessory1.SetMaterialList(data.HeadAccessories);
            partsViewHeadAccessory2.SetMaterialList(data.HeadAccessories);
        }

        /// <summary>
        /// タイマーイベントの通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnTimerEvent(object sender, EventArgs e)
        {
            charaChipView.UpdateTick();
        }

        /// <summary>
        /// フォームが最初に表示された時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormShown(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// フォームが閉じられた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// キャンセルボタンがクリックされたときに通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// OKボタンがクリックされた時に通知を受け取る。
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnOKButtonClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// テンプレートとして保存がクリックされた
        /// </summary>
        /// <param name="sender"><送信元オブジェクト/param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemSaveAsTemplateClick(object sender, EventArgs e)
        {
            string defaultName = GenerateDefaultTemplateName();
            string templateName = InputForm.InputForm.ShowDialog(this,
                "テンプレート名を入力", "入力", defaultName);
            if (templateName == null)
            {
                return;
            }

            try
            {
                CheckTemplateName(templateName);

                // テンプレート保存
                string templateDir = System.IO.Path.Combine(
                    AppData.Instance.MaterialDirectory, "Template");
                if (!System.IO.Directory.Exists(templateDir))
                {
                    System.IO.Directory.CreateDirectory(templateDir);
                }

                CharacterWriter writer = new CharacterWriter();
                string path = System.IO.Path.Combine(templateDir, $"{templateName}.ccgtemplate");
                writer.Write(path, character);

                // テンプレートリストに追加
                CharacterReader reader = new CharacterReader();
                Character readCharacter = reader.Read(path);
                AppData.Instance.CharacterTemplates.Add(templateName, readCharacter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }
        }

        /// <summary>
        /// デフォルトテンプレート名を生成する
        /// </summary>
        /// <returns>テンプレート名</returns>
        private string GenerateDefaultTemplateName()
        {
            string templateDir = System.IO.Path.Combine(AppData.Instance.MaterialDirectory, "Template");
            if (templateDir == null)
            {
                return "template000";
            }

            for (int i = 0; i < 1000; i++)
            {
                string name = $"template{i.ToString("000")}";
                string path = System.IO.Path.Combine(templateDir, name);
                if (!System.IO.File.Exists(path))
                {
                    return name;
                }
            }
            return "template";
        }

        /// <summary>
        /// テンプレート名をチェックする。
        /// </summary>
        /// <param name="name">テンプレート名</param>
        private void CheckTemplateName(string name)
        {
            if (name.Length == 0)
            {
                throw new Exception("テンプレート名が入力されていません");
            }
            char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) >= 0)
            {
                throw new Exception("テンプレート名に使用できない文字列が使われています。");
            }
        }

        /// <summary>
        /// テンプレートから読み出すがクリックされた
        /// </summary>
        /// <param name="sender">送信元オブジェクト</param>
        /// <param name="e">イベントオブジェクト</param>
        private void OnMenuItemLoadFromTemplateClick(object sender, EventArgs e)
        {
            // コンボボックスをポップアップして選択してもらう。
            TemplateSelectForm form = new TemplateSelectForm();
            if (form.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                Character template = AppData.Instance.CharacterTemplates[form.TemplateName];
                template.CopyTo(character);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー");
            }

        }
    }
}
