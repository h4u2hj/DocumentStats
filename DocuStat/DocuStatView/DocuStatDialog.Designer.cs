namespace DocuStatView
{
    partial class DocuStatDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            openFileMenuItem = new ToolStripMenuItem();
            countWordsMenuItem = new ToolStripMenuItem();
            textBox = new TextBox();
            listBoxCounter = new ListBox();
            labelCharacters = new Label();
            labelNonWhitespaceCharacters = new Label();
            labelSentences = new Label();
            labelProperNouns = new Label();
            labelColemanLieuIndex = new Label();
            labelFleschReadingEase = new Label();
            labelMinimumWord = new Label();
            labelMinimumOccurence = new Label();
            labelIgnoredWords = new Label();
            spinBoxMinLength = new NumericUpDown();
            spinBoxMinOccurrence = new NumericUpDown();
            textBoxIgnoredWords = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinOccurrence).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { openFileMenuItem, countWordsMenuItem });
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "File";
            // 
            // openFileMenuItem
            // 
            openFileMenuItem.Name = "openFileMenuItem";
            openFileMenuItem.Size = new Size(142, 22);
            openFileMenuItem.Text = "Open file";
            // 
            // countWordsMenuItem
            // 
            countWordsMenuItem.Name = "countWordsMenuItem";
            countWordsMenuItem.Size = new Size(142, 22);
            countWordsMenuItem.Text = "Count words";
            // 
            // textBox
            // 
            textBox.Location = new Point(13, 28);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Size = new Size(384, 274);
            textBox.TabIndex = 1;
            // 
            // listBoxCounter
            // 
            listBoxCounter.FormattingEnabled = true;
            listBoxCounter.ItemHeight = 15;
            listBoxCounter.Location = new Point(403, 28);
            listBoxCounter.Name = "listBoxCounter";
            listBoxCounter.Size = new Size(385, 274);
            listBoxCounter.TabIndex = 2;
            // 
            // labelCharacters
            // 
            labelCharacters.AutoSize = true;
            labelCharacters.Location = new Point(13, 327);
            labelCharacters.Name = "labelCharacters";
            labelCharacters.Size = new Size(95, 15);
            labelCharacters.TabIndex = 3;
            labelCharacters.Text = "Character count:";
            // 
            // labelNonWhitespaceCharacters
            // 
            labelNonWhitespaceCharacters.AutoSize = true;
            labelNonWhitespaceCharacters.Location = new Point(13, 372);
            labelNonWhitespaceCharacters.Name = "labelNonWhitespaceCharacters";
            labelNonWhitespaceCharacters.Size = new Size(154, 15);
            labelNonWhitespaceCharacters.TabIndex = 4;
            labelNonWhitespaceCharacters.Text = "Non-whitespace characters:";
            // 
            // labelSentences
            // 
            labelSentences.AutoSize = true;
            labelSentences.Location = new Point(13, 415);
            labelSentences.Name = "labelSentences";
            labelSentences.Size = new Size(92, 15);
            labelSentences.TabIndex = 5;
            labelSentences.Text = "Sentence count:";
            // 
            // labelProperNouns
            // 
            labelProperNouns.AutoSize = true;
            labelProperNouns.Location = new Point(256, 327);
            labelProperNouns.Name = "labelProperNouns";
            labelProperNouns.Size = new Size(110, 15);
            labelProperNouns.TabIndex = 6;
            labelProperNouns.Text = "Proper noun count:";
            // 
            // labelColemanLieuIndex
            // 
            labelColemanLieuIndex.AutoSize = true;
            labelColemanLieuIndex.Location = new Point(256, 372);
            labelColemanLieuIndex.Name = "labelColemanLieuIndex";
            labelColemanLieuIndex.Size = new Size(115, 15);
            labelColemanLieuIndex.TabIndex = 7;
            labelColemanLieuIndex.Text = "Coleman Lieu Index:";
            // 
            // labelFleschReadingEase
            // 
            labelFleschReadingEase.AutoSize = true;
            labelFleschReadingEase.Location = new Point(256, 415);
            labelFleschReadingEase.Name = "labelFleschReadingEase";
            labelFleschReadingEase.Size = new Size(115, 15);
            labelFleschReadingEase.TabIndex = 8;
            labelFleschReadingEase.Text = "Flesch Reading Ease:";
            // 
            // labelMinimumWord
            // 
            labelMinimumWord.AutoSize = true;
            labelMinimumWord.Location = new Point(453, 325);
            labelMinimumWord.Name = "labelMinimumWord";
            labelMinimumWord.Size = new Size(130, 15);
            labelMinimumWord.TabIndex = 9;
            labelMinimumWord.Text = "Minimum word length:";
            // 
            // labelMinimumOccurence
            // 
            labelMinimumOccurence.AutoSize = true;
            labelMinimumOccurence.Location = new Point(453, 370);
            labelMinimumOccurence.Name = "labelMinimumOccurence";
            labelMinimumOccurence.Size = new Size(156, 15);
            labelMinimumOccurence.TabIndex = 10;
            labelMinimumOccurence.Text = "Minimum words occurence:";
            // 
            // labelIgnoredWords
            // 
            labelIgnoredWords.AutoSize = true;
            labelIgnoredWords.Location = new Point(453, 413);
            labelIgnoredWords.Name = "labelIgnoredWords";
            labelIgnoredWords.Size = new Size(86, 15);
            labelIgnoredWords.TabIndex = 11;
            labelIgnoredWords.Text = "Ignored words:";
            // 
            // spinBoxMinLength
            // 
            spinBoxMinLength.Location = new Point(633, 325);
            spinBoxMinLength.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            spinBoxMinLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            spinBoxMinLength.Name = "spinBoxMinLength";
            spinBoxMinLength.Size = new Size(155, 23);
            spinBoxMinLength.TabIndex = 12;
            spinBoxMinLength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // spinBoxMinOccurrence
            // 
            spinBoxMinOccurrence.Location = new Point(633, 370);
            spinBoxMinOccurrence.Name = "spinBoxMinOccurrence";
            spinBoxMinOccurrence.Size = new Size(155, 23);
            spinBoxMinOccurrence.TabIndex = 13;
            // 
            // textBoxIgnoredWords
            // 
            textBoxIgnoredWords.Location = new Point(633, 410);
            textBoxIgnoredWords.Name = "textBoxIgnoredWords";
            textBoxIgnoredWords.Size = new Size(155, 23);
            textBoxIgnoredWords.TabIndex = 14;
            // 
            // DocuStatDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxIgnoredWords);
            Controls.Add(spinBoxMinOccurrence);
            Controls.Add(spinBoxMinLength);
            Controls.Add(labelIgnoredWords);
            Controls.Add(labelMinimumOccurence);
            Controls.Add(labelMinimumWord);
            Controls.Add(labelFleschReadingEase);
            Controls.Add(labelColemanLieuIndex);
            Controls.Add(labelProperNouns);
            Controls.Add(labelSentences);
            Controls.Add(labelNonWhitespaceCharacters);
            Controls.Add(labelCharacters);
            Controls.Add(listBoxCounter);
            Controls.Add(textBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "DocuStatDialog";
            Text = "Document statistics";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)spinBoxMinOccurrence).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripMenuItem countWordsMenuItem;
        private TextBox textBox;
        private ListBox listBoxCounter;
        private Label labelCharacters;
        private Label labelNonWhitespaceCharacters;
        private Label labelSentences;
        private Label labelProperNouns;
        private Label labelColemanLieuIndex;
        private Label labelFleschReadingEase;
        private Label labelMinimumWord;
        private Label labelMinimumOccurence;
        private Label labelIgnoredWords;
        private NumericUpDown spinBoxMinLength;
        private NumericUpDown spinBoxMinOccurrence;
        private TextBox textBoxIgnoredWords;
    }
}
