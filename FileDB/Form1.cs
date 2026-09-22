using System;

namespace FileDB
{
    public partial class Form1 : Form
    {
        private string path;
        private string sourceFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void pathFileLabel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Виберіть ваш bin файл";
                ofd.Filter = "BIN files (*.bin)|*.bin|All files (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    sourceFilePath = ofd.FileName;
                    textBoxPath.Text = sourceFilePath;
                }
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            GeneretePathName();
            SaveFile();
        }
        private void GeneretePathName()
        {
            string file = null;
            string memory = null;

            string typeGearBox, fuelType, Turbo = null;

            string workType = "_" + string
                .Join("_", tableLayoutPanel1.Controls
                .OfType<CheckBox>()
                .Where(cb => cb.Checked)
                .Select(cb => cb.Text
                .Replace(" ", ""))) + "_";

            foreach (Control ctrl in tableLayoutPanel8.Controls)
            {
                if (ctrl is RadioButton rb && rb.Checked)
                {
                    file = rb.Text;
                    break;
                }
            }
            foreach (Control control in tableLayoutPanel10.Controls)
            {
                if (control is RadioButton rb && rb.Checked)
                {
                    memory = rb.Text;
                    break;
                }
            }
            typeGearBox = radioButton9.Checked ? "AT" : "Manual";
            fuelType = radioButton11.Checked ? "Petrol" : "Diesel";
            Turbo = radioButton8.Checked ? "_Turbo" : "";

            PathModel pathData = new()
            {
                FileType = file,
                MemoryType = memory,
                ReadedFileBy = ReadByComboBox.Text,
                WorkType = workType,
                Brand = BrandTextBox.Text,
                Model = ModelTextBox.Text,
                Year = YearTextBox.Text,
                CapacityEngine = EngineCapacityTextBox.Text,
                EngineCode = EngineCodeTextBox.Text,
                ModuleName = NameModuleTextBox.Text,
                ModuleNumber = ModuleNumberTextBox.Text,
                ModuleSoftNumber = SoftNumberTextBox.Text,
            };
            path = $"{pathData.Brand}_{pathData.Model}_{pathData.Year}_{pathData.CapacityEngine}_{pathData.EngineCode}_{typeGearBox}_{fuelType}{Turbo}" +
                $"_{pathData.ModuleName}({pathData.ModuleNumber})_SW({pathData.ModuleSoftNumber})_" +
                $"{pathData.MemoryType}_{pathData.ReadedFileBy}{pathData.WorkType}{pathData.FileType}.bin";
        }
        private void SaveFile()
        {
            if (string.IsNullOrEmpty(sourceFilePath))
            {
                MessageBox.Show("Файл не вибраний");
                return;
            }
            string targetDirectory = @"\FileDB\UserData"; // ← ТВОЯ папка
            Directory.CreateDirectory(targetDirectory);

            string targetPath = Path.Combine(targetDirectory, path);

            File.Copy(sourceFilePath, targetPath, overwrite: true);

            if (File.Exists(targetPath))
            {
                System.Diagnostics.Process.Start("explorer.exe",
       $"/select,\"{targetPath}\"");
                MessageBox.Show("Файл успішно збережено");
                return;
            }

        }

        private void radioButtonradioButtonOriginalFile_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonOriginalFile.Checked) return;

            foreach (CheckBox cb in tableLayoutPanel1.Controls.OfType<CheckBox>())
                cb.Checked = false;
            radioButtonOriginalFile.Checked = true;
        }

        private void pathFileLabel_MouseEnter(object sender, EventArgs e)
        {
            pathFileLabel.ForeColor = Color.Blue;
        }

        private void pathFileLabel_MouseLeave(object sender, EventArgs e)
        {
            pathFileLabel.ForeColor = Color.Black;
        }

        private void WorkType(object sender, EventArgs e)
        {
            radioButtonModified.Checked = true;
        }
    }
}