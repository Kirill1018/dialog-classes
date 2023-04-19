using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dialog_classes
{
    public partial class Text_edit : Form
    {
        public Text_edit()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.ShowDialog();
            if (dialog.FileName == String.Empty) return;
            try
            {
                var читатель = new System.IO.StreamReader(dialog.FileName, Encoding.GetEncoding(1251));
                box.Text = читатель.ReadToEnd();
                читатель.Close();
            }
            catch (System.IO.FileNotFoundException ситуация)
            {
                MessageBox.Show(ситуация.Message + "\nошибка", "ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ситуация)
            {
                MessageBox.Show(ситуация.Message, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filedialog.FileName = dialog.FileName;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var писатель = new System.IO.StreamWriter(filedialog.FileName, false, System.Text.Encoding.GetEncoding(1251));
                    писатель.Write(box.Text);
                    писатель.Close();
                }
                catch (Exception ситуация)
                {
                    MessageBox.Show(ситуация.Message, "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Text_edit_Load(object sender, EventArgs e)
        {
            box.Clear();
            dialog.FileName = @"data\Text2.txt";
            dialog.Filter = "текстовые файлы (*.txt)|*.txt|all files (*.*)|*.*";
            filedialog.Filter = "текстовые файлы (*.txt)|*.txt|all files (*.*)|*.*";
        }
    }
}