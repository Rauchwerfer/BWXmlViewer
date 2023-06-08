using System.Windows.Forms;

namespace BWXmlViewer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    BWPackedXmlReader.BWPackedXml packedXml = new BWPackedXmlReader.BWPackedXml(openFileDialog1.FileName);

                    richTextBox1.Text = packedXml.ToString();

                    toolStripStatusLabelFileName.Text = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;

            toolStripStatusLabelFileName.Text = string.Empty;
        }

        private void saveAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }
    }
}