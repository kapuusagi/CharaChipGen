namespace CharaChipGen.MaterialEditorForm
{
    partial class MaterialEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaterialName = new System.Windows.Forms.TextBox();
            this.buttonDelete2ndLayer = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.materialEditorLayerView2 = new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView();
            this.materialEditorLayerView1 = new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(632, 557);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButton_clicked);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(713, 557);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButton_clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "素材名";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaterialName.Location = new System.Drawing.Point(72, 9);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(701, 23);
            this.textBoxMaterialName.TabIndex = 5;
            // 
            // buttonDelete2ndLayer
            // 
            this.buttonDelete2ndLayer.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.buttonDelete2ndLayer.Location = new System.Drawing.Point(615, 39);
            this.buttonDelete2ndLayer.Name = "buttonDelete2ndLayer";
            this.buttonDelete2ndLayer.Size = new System.Drawing.Size(110, 23);
            this.buttonDelete2ndLayer.TabIndex = 8;
            this.buttonDelete2ndLayer.Text = "セカンダリレイヤーを削除";
            this.buttonDelete2ndLayer.UseVisualStyleBackColor = true;
            this.buttonDelete2ndLayer.Click += new System.EventHandler(this.OnDelete2ndLayerButton_clicked);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Location = new System.Drawing.Point(632, 378);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(141, 153);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPreview.TabIndex = 9;
            this.pictureBoxPreview.TabStop = false;
            // 
            // materialEditorLayerView2
            // 
            this.materialEditorLayerView2.Image = null;
            this.materialEditorLayerView2.LayerName = "セカンダリレイヤー";
            this.materialEditorLayerView2.Location = new System.Drawing.Point(296, 38);
            this.materialEditorLayerView2.Name = "materialEditorLayerView2";
            this.materialEditorLayerView2.Size = new System.Drawing.Size(312, 512);
            this.materialEditorLayerView2.TabIndex = 7;
            this.materialEditorLayerView2.ImageChange += new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView.MaterialImageChangeHandler(this.OnLayerView_imageChanged);
            // 
            // materialEditorLayerView1
            // 
            this.materialEditorLayerView1.Image = null;
            this.materialEditorLayerView1.LayerName = "プライマリレイヤー";
            this.materialEditorLayerView1.Location = new System.Drawing.Point(13, 38);
            this.materialEditorLayerView1.Name = "materialEditorLayerView1";
            this.materialEditorLayerView1.Size = new System.Drawing.Size(277, 512);
            this.materialEditorLayerView1.TabIndex = 6;
            this.materialEditorLayerView1.ImageChange += new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView.MaterialImageChangeHandler(this.OnLayerView_imageChanged);
            // 
            // MaterialEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.buttonDelete2ndLayer);
            this.Controls.Add(this.materialEditorLayerView2);
            this.Controls.Add(this.materialEditorLayerView1);
            this.Controls.Add(this.textBoxMaterialName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "MaterialEditorForm";
            this.Text = "素材エディタ";
            this.Shown += new System.EventHandler(this.OnForm_shown);
            this.Resize += new System.EventHandler(this.OnForm_resied);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private MaterialEditorLayerView materialEditorLayerView1;
        private MaterialEditorLayerView materialEditorLayerView2;
        private System.Windows.Forms.Button buttonDelete2ndLayer;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}