using DocStats;
using DocStats.Persistence;

namespace DocuStatView
{
    public partial class DocuStatDialog : Form
    {

        private DocumentStatistics? _documentStatistics;

        public DocuStatDialog()
        {
            InitializeComponent();
            openFileMenuItem.Click += OpenDialog;
            countWordsMenuItem.Click += CountWords;
        }

        private void OpenDialog(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Text files (*.txt)|*.txt|PDF files (*.pdf)|*.pdf";
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        IFileManager? fileManager = FileManagerFactory.CreateForPath(openFileDialog.FileName);
                        if (fileManager == null)
                        {
                            MessageBox.Show("File reading is unsuccessful!\nUnsupported file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        _documentStatistics = new DocumentStatistics(fileManager);
                        _documentStatistics.FileContentReady += UpdateFileContent;
                        _documentStatistics.TextStatisticsReady += UpdateTextStatistics;
                        _documentStatistics.Load();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("File reading is unsuccessful!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void UpdateTextStatistics(object? sender, EventArgs e)
        {
            labelCharacters.Text = $"Character count: {_documentStatistics.CharacterCount}";
            labelSentences.Text = $"Sentence count: {_documentStatistics.SentenceCount} ";
            labelNonWhitespaceCharacters.Text = $"Non-whitespace characters: {_documentStatistics.NonWhiteSpaceCharacterCount}";
            labelProperNouns.Text = $"Proper noun count: {_documentStatistics.ProperNounCount}";
            labelColemanLieuIndex.Text = "Coleman Lieu Index: " + Math.Round(_documentStatistics.ColemanLieuIndex, 2);

        }

        private void UpdateFileContent(object? sender, EventArgs e)
        {
            if (_documentStatistics?.FileContent == textBox.Text)
            {
                return;
            }
            textBox.Text = _documentStatistics?.FileContent;
            listBoxCounter.Items.Clear();
        }

        private void CountWords(object? sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_documentStatistics.FileContent))
            {
                MessageBox.Show("File has not been opened yet! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            int minLength = Convert.ToInt32(spinBoxMinLength.Value);
            int minOccurrence = Convert.ToInt32(spinBoxMinOccurrence.Value);
            List<String> ignoredWords = new List<String>();
            ignoredWords = textBoxIgnoredWords.Text.Trim().Split(",").ToList();


            var pairs = _documentStatistics.DistinctWordCount
                .Where(p => p.Value >= minOccurrence)
                .Where(p => p.Key.Length >= minLength)
                .Where(p => !ignoredWords.Contains(p.Key))
                .OrderByDescending(p => p.Value);

            listBoxCounter.Items.Clear();
            listBoxCounter.BeginUpdate();
            foreach (var pair in pairs)
            {
                listBoxCounter.Items.Add(pair.Key + ": " + pair.Value);
            }
            listBoxCounter.EndUpdate();
        }
    }
}
