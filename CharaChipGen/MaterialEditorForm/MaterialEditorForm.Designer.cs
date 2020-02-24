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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialEditorLayerView2 = new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView();
            this.materialEditorLayerView1 = new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(669, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(750, 9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "素材名";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMaterialName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaterialName.Location = new System.Drawing.Point(64, 8);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(768, 23);
            this.textBoxMaterialName.TabIndex = 5;
            // 
            // buttonDelete2ndLayer
            // 
            this.buttonDelete2ndLayer.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.buttonDelete2ndLayer.Location = new System.Drawing.Point(9, 9);
            this.buttonDelete2ndLayer.Name = "buttonDelete2ndLayer";
            this.buttonDelete2ndLayer.Size = new System.Drawing.Size(110, 23);
            this.buttonDelete2ndLayer.TabIndex = 8;
            this.buttonDelete2ndLayer.Text = "セカンダリレイヤーを削除";
            this.buttonDelete2ndLayer.UseVisualStyleBackColor = true;
            this.buttonDelete2ndLayer.Click += new System.EventHandler(this.OnDelete2ndLayerButtonClicked);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPreview.Location = new System.Drawing.Point(9, 351);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(141, 153);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPreview.TabIndex = 9;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMaterialName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(840, 41);
            this.panel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 551);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(840, 41);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.pictureBoxPreview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(669, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 510);
            this.panel2.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonDelete2ndLayer);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 41);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.materialEditorLayerView2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialEditorLayerView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 510);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // materialEditorLayerView2
            // 
            this.materialEditorLayerView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialEditorLayerView2.Image = null;
            this.materialEditorLayerView2.LayerName = "セカンダリレイヤー";
            this.materialEditorLayerView2.Location = new System.Drawing.Point(337, 3);
            this.materialEditorLayerView2.Name = "materialEditorLayerView2";
            this.materialEditorLayerView2.Size = new System.Drawing.Size(329, 504);
            this.materialEditorLayerView2.TabIndex = 7;
            this.materialEditorLayerView2.ImageChange += new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView.MaterialImageChangeHandler(this.OnLayerViewImageChanged);
            // 
            // materialEditorLayerView1
            // 
            this.materialEditorLayerView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialEditorLayerView1.Image = null;
            this.materialEditorLayerView1.LayerName = "プライマリレイヤー";
            this.materialEditorLayerView1.Location = new System.Drawing.Point(3, 3);
            this.materialEditorLayerView1.Name = "materialEditorLayerView1";
            this.materialEditorLayerView1.Size = new System.Drawing.Size(328, 504);
            this.materialEditorLayerView1.TabIndex = 6;
            this.materialEditorLayerView1.ImageChange += new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView.MaterialImageChangeHandler(this.OnLayerViewImageChanged);
            // 
            // MaterialEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 592);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "MaterialEditorForm";
            this.Text = "素材エディタ";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.Resize += new System.EventHandler(this.OnForm_resied);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}