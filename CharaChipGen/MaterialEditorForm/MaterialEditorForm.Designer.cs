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
            this.buttonDeleteLayer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddLayer = new System.Windows.Forms.Button();
            this.buttonRenameLayer = new System.Windows.Forms.Button();
            this.buttonUpLayer = new System.Windows.Forms.Button();
            this.buttonDownLayer = new System.Windows.Forms.Button();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxLayers = new System.Windows.Forms.ListBox();
            this.materialEditorLayerView = new CharaChipGen.MaterialEditorForm.MaterialEditorLayerView();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(333, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(414, 9);
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
            this.label1.TabIndex = 0;
            this.label1.Text = "素材名";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMaterialName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxMaterialName.Location = new System.Drawing.Point(64, 8);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(432, 23);
            this.textBoxMaterialName.TabIndex = 1;
            // 
            // buttonDeleteLayer
            // 
            this.buttonDeleteLayer.Location = new System.Drawing.Point(9, 67);
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.Size = new System.Drawing.Size(110, 23);
            this.buttonDeleteLayer.TabIndex = 2;
            this.buttonDeleteLayer.Text = "レイヤーを削除";
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.OnDeleteLayerButtonClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMaterialName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(504, 41);
            this.panel1.TabIndex = 0;
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(504, 41);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.buttonAddLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonRenameLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonDeleteLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonUpLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonDownLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonPreview);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 201);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(174, 303);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // buttonAddLayer
            // 
            this.buttonAddLayer.Location = new System.Drawing.Point(9, 9);
            this.buttonAddLayer.Name = "buttonAddLayer";
            this.buttonAddLayer.Size = new System.Drawing.Size(110, 23);
            this.buttonAddLayer.TabIndex = 0;
            this.buttonAddLayer.Text = "レイヤーを追加";
            this.buttonAddLayer.UseVisualStyleBackColor = true;
            this.buttonAddLayer.Click += new System.EventHandler(this.OnButtonAddLayerClick);
            // 
            // buttonRenameLayer
            // 
            this.buttonRenameLayer.Location = new System.Drawing.Point(9, 38);
            this.buttonRenameLayer.Name = "buttonRenameLayer";
            this.buttonRenameLayer.Size = new System.Drawing.Size(110, 23);
            this.buttonRenameLayer.TabIndex = 1;
            this.buttonRenameLayer.Text = "レイヤー名を変更";
            this.buttonRenameLayer.UseVisualStyleBackColor = true;
            this.buttonRenameLayer.Click += new System.EventHandler(this.OnButtonRenameLayerClick);
            // 
            // buttonUpLayer
            // 
            this.buttonUpLayer.Location = new System.Drawing.Point(9, 96);
            this.buttonUpLayer.Name = "buttonUpLayer";
            this.buttonUpLayer.Size = new System.Drawing.Size(75, 23);
            this.buttonUpLayer.TabIndex = 3;
            this.buttonUpLayer.Text = "上へ移動";
            this.buttonUpLayer.UseVisualStyleBackColor = true;
            this.buttonUpLayer.Click += new System.EventHandler(this.OnButtonUpLayerClick);
            // 
            // buttonDownLayer
            // 
            this.buttonDownLayer.Location = new System.Drawing.Point(90, 96);
            this.buttonDownLayer.Name = "buttonDownLayer";
            this.buttonDownLayer.Size = new System.Drawing.Size(75, 23);
            this.buttonDownLayer.TabIndex = 4;
            this.buttonDownLayer.Text = "下へ移動";
            this.buttonDownLayer.UseVisualStyleBackColor = true;
            this.buttonDownLayer.Click += new System.EventHandler(this.OnButtonDownLayerClick);
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(9, 125);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(110, 23);
            this.buttonPreview.TabIndex = 5;
            this.buttonPreview.Text = "プレビュー";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.OnButtonPreviewClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialEditorLayerView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 510);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(174, 504);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxLayers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 201);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "レイヤー一覧";
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Location = new System.Drawing.Point(3, 15);
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.Size = new System.Drawing.Size(168, 183);
            this.listBoxLayers.TabIndex = 0;
            this.listBoxLayers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnListBoxLayersDrawItem);
            this.listBoxLayers.SelectedValueChanged += new System.EventHandler(this.OnListBoxLayersSelectedValueChanged);
            this.listBoxLayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnListBoxLayersKeyDown);
            // 
            // materialEditorLayerView
            // 
            this.materialEditorLayerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialEditorLayerView.Enabled = false;
            this.materialEditorLayerView.Location = new System.Drawing.Point(183, 3);
            this.materialEditorLayerView.Name = "materialEditorLayerView";
            this.materialEditorLayerView.Size = new System.Drawing.Size(318, 504);
            this.materialEditorLayerView.TabIndex = 0;
            // 
            // MaterialEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 592);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "MaterialEditorForm";
            this.Text = "素材エディタ";
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private System.Windows.Forms.Button buttonDeleteLayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxLayers;
        private System.Windows.Forms.Button buttonAddLayer;
        private MaterialEditorLayerView materialEditorLayerView;
        private System.Windows.Forms.Button buttonRenameLayer;
        private System.Windows.Forms.Button buttonUpLayer;
        private System.Windows.Forms.Button buttonDownLayer;
        private System.Windows.Forms.Button buttonPreview;
    }
}