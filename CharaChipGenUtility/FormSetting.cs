using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharaChipGenUtility
{
    public partial class FormSetting : Form
    {
        private FolderSelectDialog folderSelectDialog = null;

        public FormSetting()
        {
            InitializeComponent();
        }

        private void OnButtonOKClick(object sender, EventArgs evt)
        {
            try
            {
                Properties.Settings settings = Properties.Settings.Default;
                settings.SaveDirectory = textBoxSaveFolder.Text;


                settings.Save();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnButtonCancelClick(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnFormShown(object sender, EventArgs e)
        {
            Properties.Settings settings = Properties.Settings.Default;

            textBoxSaveFolder.Text = settings.SaveDirectory;
        }

        private void OnButtonSelectFolderClick(object sender, EventArgs evt)
        {
            try
            {
                if (folderSelectDialog == null)
                {
                    folderSelectDialog = new FolderSelectDialog();
                    folderSelectDialog.Title = "フォルダ選択";
                }

                folderSelectDialog.Path = textBoxSaveFolder.Text;
                DialogResult res = folderSelectDialog.ShowDialog(this);
                if (res != DialogResult.OK)
                {
                    return;
                }

                textBoxSaveFolder.Text = folderSelectDialog.Path;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "エラー");
            }
        }
    }
}
