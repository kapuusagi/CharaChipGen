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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialEditorForm));
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImageBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.OnSaveButtonClicked);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBoxMaterialName
            // 
            resources.ApplyResources(this.textBoxMaterialName, "textBoxMaterialName");
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            // 
            // buttonDeleteLayer
            // 
            resources.ApplyResources(this.buttonDeleteLayer, "buttonDeleteLayer");
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.OnDeleteLayerButtonClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMaterialName);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.buttonAddLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonRenameLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonDeleteLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonUpLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonDownLayer);
            this.flowLayoutPanel2.Controls.Add(this.buttonPreview);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // buttonAddLayer
            // 
            resources.ApplyResources(this.buttonAddLayer, "buttonAddLayer");
            this.buttonAddLayer.Name = "buttonAddLayer";
            this.buttonAddLayer.UseVisualStyleBackColor = true;
            this.buttonAddLayer.Click += new System.EventHandler(this.OnButtonAddLayerClick);
            // 
            // buttonRenameLayer
            // 
            resources.ApplyResources(this.buttonRenameLayer, "buttonRenameLayer");
            this.buttonRenameLayer.Name = "buttonRenameLayer";
            this.buttonRenameLayer.UseVisualStyleBackColor = true;
            this.buttonRenameLayer.Click += new System.EventHandler(this.OnButtonRenameLayerClick);
            // 
            // buttonUpLayer
            // 
            resources.ApplyResources(this.buttonUpLayer, "buttonUpLayer");
            this.buttonUpLayer.Name = "buttonUpLayer";
            this.buttonUpLayer.UseVisualStyleBackColor = true;
            this.buttonUpLayer.Click += new System.EventHandler(this.OnButtonUpLayerClick);
            // 
            // buttonDownLayer
            // 
            resources.ApplyResources(this.buttonDownLayer, "buttonDownLayer");
            this.buttonDownLayer.Name = "buttonDownLayer";
            this.buttonDownLayer.UseVisualStyleBackColor = true;
            this.buttonDownLayer.Click += new System.EventHandler(this.OnButtonDownLayerClick);
            // 
            // buttonPreview
            // 
            resources.ApplyResources(this.buttonPreview, "buttonPreview");
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.OnButtonPreviewClick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.materialEditorLayerView, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxLayers);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // listBoxLayers
            // 
            this.listBoxLayers.AllowDrop = true;
            resources.ApplyResources(this.listBoxLayers, "listBoxLayers");
            this.listBoxLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxLayers.FormattingEnabled = true;
            this.listBoxLayers.Name = "listBoxLayers";
            this.listBoxLayers.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnListBoxLayersDrawItem);
            this.listBoxLayers.SelectedValueChanged += new System.EventHandler(this.OnListBoxLayersSelectedValueChanged);
            this.listBoxLayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnListBoxLayersDragDrop);
            this.listBoxLayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnListBoxLayersDragEnter);
            this.listBoxLayers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnListBoxLayersKeyDown);
            // 
            // materialEditorLayerView
            // 
            resources.ApplyResources(this.materialEditorLayerView, "materialEditorLayerView");
            this.materialEditorLayerView.ImageBackground = System.Drawing.SystemColors.Control;
            this.materialEditorLayerView.Name = "materialEditorLayerView";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImageBackground});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            // 
            // menuItemImageBackground
            // 
            this.menuItemImageBackground.Name = "menuItemImageBackground";
            resources.ApplyResources(this.menuItemImageBackground, "menuItemImageBackground");
            this.menuItemImageBackground.Click += new System.EventHandler(this.OnMenuItemImageBackgroundClick);
            // 
            // MaterialEditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MaterialEditorForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnFormKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemImageBackground;
    }
}