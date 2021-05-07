namespace CharaChipGen.GeneratorForm
{
    partial class CharaChipGeneratorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharaChipGeneratorForm));
            this.panelCharaChipParts = new System.Windows.Forms.Panel();
            this.partsViewHeadAccessory2 = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewHeadAccessory1 = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewAccessory3 = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewAccessory2 = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewAccessory1 = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewBody = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewEye = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewHairStyle = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.partsViewHead = new CharaChipGen.GeneratorForm.CharaChipGeneratorPartsView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.charaChipView = new CharaChipGen.GeneratorForm.CharaChipView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadFromTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImageBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panelCharaChipParts.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCharaChipParts
            // 
            this.panelCharaChipParts.Controls.Add(this.partsViewHeadAccessory2);
            this.panelCharaChipParts.Controls.Add(this.partsViewHeadAccessory1);
            this.panelCharaChipParts.Controls.Add(this.partsViewAccessory3);
            this.panelCharaChipParts.Controls.Add(this.partsViewAccessory2);
            this.panelCharaChipParts.Controls.Add(this.partsViewAccessory1);
            this.panelCharaChipParts.Controls.Add(this.partsViewBody);
            this.panelCharaChipParts.Controls.Add(this.partsViewEye);
            this.panelCharaChipParts.Controls.Add(this.partsViewHairStyle);
            this.panelCharaChipParts.Controls.Add(this.partsViewHead);
            resources.ApplyResources(this.panelCharaChipParts, "panelCharaChipParts");
            this.panelCharaChipParts.Name = "panelCharaChipParts";
            // 
            // partsViewHeadAccessory2
            // 
            resources.ApplyResources(this.partsViewHeadAccessory2, "partsViewHeadAccessory2");
            this.partsViewHeadAccessory2.EditHSV = true;
            this.partsViewHeadAccessory2.EditYOffset = true;
            this.partsViewHeadAccessory2.Name = "partsViewHeadAccessory2";
            this.partsViewHeadAccessory2.PartsName = "HeadAccessory2";
            // 
            // partsViewHeadAccessory1
            // 
            resources.ApplyResources(this.partsViewHeadAccessory1, "partsViewHeadAccessory1");
            this.partsViewHeadAccessory1.EditHSV = true;
            this.partsViewHeadAccessory1.EditYOffset = true;
            this.partsViewHeadAccessory1.Name = "partsViewHeadAccessory1";
            this.partsViewHeadAccessory1.PartsName = "HeadAccessory1";
            // 
            // partsViewAccessory3
            // 
            resources.ApplyResources(this.partsViewAccessory3, "partsViewAccessory3");
            this.partsViewAccessory3.EditHSV = true;
            this.partsViewAccessory3.EditYOffset = true;
            this.partsViewAccessory3.Name = "partsViewAccessory3";
            this.partsViewAccessory3.PartsName = "Accessory3";
            // 
            // partsViewAccessory2
            // 
            resources.ApplyResources(this.partsViewAccessory2, "partsViewAccessory2");
            this.partsViewAccessory2.EditHSV = true;
            this.partsViewAccessory2.EditYOffset = true;
            this.partsViewAccessory2.Name = "partsViewAccessory2";
            this.partsViewAccessory2.PartsName = "Accessory2";
            // 
            // partsViewAccessory1
            // 
            resources.ApplyResources(this.partsViewAccessory1, "partsViewAccessory1");
            this.partsViewAccessory1.EditHSV = true;
            this.partsViewAccessory1.EditYOffset = true;
            this.partsViewAccessory1.Name = "partsViewAccessory1";
            this.partsViewAccessory1.PartsName = "Accessory1";
            // 
            // partsViewBody
            // 
            resources.ApplyResources(this.partsViewBody, "partsViewBody");
            this.partsViewBody.EditHSV = true;
            this.partsViewBody.EditYOffset = true;
            this.partsViewBody.Name = "partsViewBody";
            this.partsViewBody.PartsName = "Body";
            // 
            // partsViewEye
            // 
            resources.ApplyResources(this.partsViewEye, "partsViewEye");
            this.partsViewEye.EditHSV = true;
            this.partsViewEye.EditYOffset = true;
            this.partsViewEye.Name = "partsViewEye";
            this.partsViewEye.PartsName = "Eye";
            // 
            // partsViewHairStyle
            // 
            resources.ApplyResources(this.partsViewHairStyle, "partsViewHairStyle");
            this.partsViewHairStyle.EditHSV = true;
            this.partsViewHairStyle.EditYOffset = true;
            this.partsViewHairStyle.Name = "partsViewHairStyle";
            this.partsViewHairStyle.PartsName = "HairStyle";
            // 
            // partsViewHead
            // 
            resources.ApplyResources(this.partsViewHead, "partsViewHead");
            this.partsViewHead.EditHSV = true;
            this.partsViewHead.EditYOffset = true;
            this.partsViewHead.Name = "partsViewHead";
            this.partsViewHead.PartsName = "Head";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKButtonClicked);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.OnTimerEvent);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.charaChipView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCharaChipParts, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // charaChipView
            // 
            resources.ApplyResources(this.charaChipView, "charaChipView");
            this.charaChipView.ImageBackground = System.Drawing.SystemColors.Control;
            this.charaChipView.Name = "charaChipView";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuItemOption});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveAsTemplate,
            this.menuItemLoadFromTemplate,
            this.menuItemExport});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // menuItemSaveAsTemplate
            // 
            this.menuItemSaveAsTemplate.Name = "menuItemSaveAsTemplate";
            resources.ApplyResources(this.menuItemSaveAsTemplate, "menuItemSaveAsTemplate");
            this.menuItemSaveAsTemplate.Click += new System.EventHandler(this.OnMenuItemSaveAsTemplateClick);
            // 
            // menuItemLoadFromTemplate
            // 
            this.menuItemLoadFromTemplate.Name = "menuItemLoadFromTemplate";
            resources.ApplyResources(this.menuItemLoadFromTemplate, "menuItemLoadFromTemplate");
            this.menuItemLoadFromTemplate.Click += new System.EventHandler(this.OnMenuItemLoadFromTemplateClick);
            // 
            // menuItemExport
            // 
            this.menuItemExport.Name = "menuItemExport";
            resources.ApplyResources(this.menuItemExport, "menuItemExport");
            this.menuItemExport.Click += new System.EventHandler(this.OnMenuItemExportClick);
            // 
            // menuItemOption
            // 
            this.menuItemOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImageBackground});
            this.menuItemOption.Name = "menuItemOption";
            resources.ApplyResources(this.menuItemOption, "menuItemOption");
            // 
            // menuItemImageBackground
            // 
            this.menuItemImageBackground.Name = "menuItemImageBackground";
            resources.ApplyResources(this.menuItemImageBackground, "menuItemImageBackground");
            this.menuItemImageBackground.Click += new System.EventHandler(this.OnMenuItemImageBackgroundClick);
            // 
            // saveFileDialog
            // 
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // CharaChipGeneratorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharaChipGeneratorForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.panelCharaChipParts.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CharaChipGeneratorPartsView partsViewHead;
        private CharaChipGeneratorPartsView partsViewEye;
        private CharaChipGeneratorPartsView partsViewHairStyle;
        private CharaChipGeneratorPartsView partsViewBody;
        private CharaChipGeneratorPartsView partsViewAccessory1;
        private CharaChipGeneratorPartsView partsViewAccessory2;
        private CharaChipGeneratorPartsView partsViewAccessory3;
        private CharaChipGeneratorPartsView partsViewHeadAccessory1;
        private CharaChipGeneratorPartsView partsViewHeadAccessory2;
        private System.Windows.Forms.Panel panelCharaChipParts;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private GeneratorForm.CharaChipView charaChipView;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadFromTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuItemOption;
        private System.Windows.Forms.ToolStripMenuItem menuItemImageBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}