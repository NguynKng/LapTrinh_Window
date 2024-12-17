using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2280601411_NguyenKhang
{
    public partial class Bai2 : Form
    {
        private string currentFilePath = null;
        InstalledFontCollection fonts = new InstalledFontCollection();
        public Bai2()
        {
            InitializeComponent();
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.ShowEffects = true;
            fontDialog.ShowHelp = true;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                // Apply the selected font and color to the RichTextBox
                richTextBox1.ForeColor = fontDialog.Color;
                richTextBox1.Font = fontDialog.Font;

                // Synchronize the font name and size in the ComboBoxes
                fontComboBox1.SelectedItem = fontDialog.Font.FontFamily.Name;

                // Ensure the font size exists in the sizeComboBox2 before selecting it
                int fontSize = (int)fontDialog.Font.Size;
                if (sizeComboBox2.Items.Contains(fontSize.ToString()))
                {
                    sizeComboBox2.SelectedItem = fontSize.ToString();
                }
                else
                {
                    // Optionally handle a font size that isn't in the predefined list
                    sizeComboBox2.Text = fontSize.ToString();
                }
            }
        }

        private void setFontList()
        {
            foreach(FontFamily font in fonts.Families)
            {
                fontComboBox1.Items.Add(font.Name);
            }
        }

        private void setSizeList()
        {
            string[] fontSize = { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };
            sizeComboBox2.Items.AddRange(fontSize);
        }

        private void Bai2_Load(object sender, EventArgs e)
        {
            setFontList();
            setSizeList();
            fontComboBox1.SelectedItem = "Tahoma";
            sizeComboBox2.SelectedItem = "14";
        }

        private void resetRichTextBox()
        {
            fontComboBox1.SelectedItem = "Tahoma";
            sizeComboBox2.SelectedItem = "14";
            UpdateRichTextBoxFont();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            resetRichTextBox();
            currentFilePath = null;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = dlg.FileName; // Store the file path

                if (Path.GetExtension(currentFilePath).ToLower() == ".rtf")
                {
                    // Load .rtf file into the RichTextBox
                    richTextBox1.LoadFile(currentFilePath, RichTextBoxStreamType.RichText);
                }
                else if (Path.GetExtension(currentFilePath).ToLower() == ".txt")
                {
                    // Load .txt file into the RichTextBox
                    string textContent = File.ReadAllText(currentFilePath);
                    richTextBox1.Text = textContent;
                }
                else
                {
                    MessageBox.Show("Unsupported file type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fontComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRichTextBoxFont();
        }

        private void sizeComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRichTextBoxFont();
        }

        private void UpdateRichTextBoxFont()
        {
            string selectedFont = fontComboBox1.SelectedItem?.ToString() ?? richTextBox1.Font.FontFamily.Name;
            string selectedSize = sizeComboBox2.SelectedItem?.ToString() ?? richTextBox1.Font.Size.ToString();
            float newSize;

            // Parse the selected size
            if (float.TryParse(selectedSize, out newSize))
            {
                // Check if there is a selection or not
                if (richTextBox1.SelectionFont != null)
                {
                    // Preserve the current bold, italic, and underline settings
                    bool isBold = richTextBox1.SelectionFont.Bold;
                    bool isItalic = richTextBox1.SelectionFont.Italic;
                    bool isUnderline = richTextBox1.SelectionFont.Underline;

                    // Create a new Font with the selected font family and size, but keep the bold/italic/underline states
                    richTextBox1.SelectionFont = new Font(selectedFont, newSize,
                        (isBold ? FontStyle.Bold : FontStyle.Regular) |
                        (isItalic ? FontStyle.Italic : FontStyle.Regular) |
                        (isUnderline ? FontStyle.Underline : FontStyle.Regular));
                }
                else
                {
                    // If no text is selected, apply the font and size to the whole text area
                    richTextBox1.Font = new Font(selectedFont, newSize);
                }
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileClick();
        }

        private void SaveFile(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".rtf")
            {
                // Save as .rtf
                richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
            }
            else if (Path.GetExtension(filePath).ToLower() == ".txt")
            {
                // Save as .txt
                File.WriteAllText(filePath, richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Unsupported file type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFileClick()
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // If no file is currently open, prompt the user to save using SaveFileDialog
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveDlg.FileName;
                    SaveFile(currentFilePath);
                }
            }
            else
            {
                // Save directly to the current file
                SaveFile(currentFilePath);
                MessageBox.Show("Luu thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BoldtoolStripButton3_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void ItalictoolStripButton4_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void UnderlinetoolStripButton5_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void saveFiletoolStripButton2_Click(object sender, EventArgs e)
        {
            saveFileClick();
        }

        private void newFiletoolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            resetRichTextBox();
            currentFilePath = null;
        }

        private void ToggleFontStyle(FontStyle style)
        {
            // Check if there is any selected text
            if (richTextBox1.SelectionFont != null)
            {
                // Get the current font style
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                // Toggle the specific style (add or remove it)
                if (currentFont.Style.HasFlag(style))
                {
                    // Remove the style
                    newFontStyle = currentFont.Style & ~style;
                }
                else
                {
                    // Add the style
                    newFontStyle = currentFont.Style | style;
                }

                // Apply the new font style to the selected text
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
            else
            {
                MessageBox.Show("Please select text to apply the formatting.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateBorderButton()
        {
            // Check if the SelectionFont is not null before accessing its properties
            bool isBold = richTextBox1.SelectionFont?.Bold ?? false;
            bool isItalic = richTextBox1.SelectionFont?.Italic ?? false;
            bool isUnderline = richTextBox1.SelectionFont?.Underline ?? false;

            // Update the appearance of the ToolStripButton
            BoldtoolStripButton3.Checked = isBold;  // Set the 'Checked' property for bold button
            ItalictoolStripButton4.Checked = isItalic;  // Set the 'Checked' property for italic button
            UnderlinetoolStripButton5.Checked = isUnderline;  // Set the 'Checked' property for underline button

            // Optional: Change the ForeColor for active buttons
            if (isBold || isItalic || isUnderline)
            {
                // Set the color of the ToolStripButton if the style is applied
                BoldtoolStripButton3.ForeColor = Color.Blue;  // You can change to any color you like
                ItalictoolStripButton4.ForeColor = Color.Blue;
                UnderlinetoolStripButton5.ForeColor = Color.Blue;
            }
            else
            {
                // Reset the color if none of the styles are applied
                BoldtoolStripButton3.ForeColor = SystemColors.ControlText;  // Default color
                ItalictoolStripButton4.ForeColor = SystemColors.ControlText;
                UnderlinetoolStripButton5.ForeColor = SystemColors.ControlText;
            }
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            //updateBorderButton();
            //updateToolStrip();
            UpdateToolbar();
        }

        private void updateToolStrip()
        {
            // Ensure SelectionFont is not null before accessing properties
            if (richTextBox1.SelectionFont != null)
            {
                // Get the selected font family and size
                string fontName = richTextBox1.SelectionFont.FontFamily.Name;
                float fontSize = richTextBox1.SelectionFont.Size;

                // Update the font comboBox to reflect the selected font
                if (fontComboBox1.Items.Contains(fontName))
                {
                    fontComboBox1.SelectedItem = fontName;
                }

                // Update the font size comboBox to reflect the selected font size
                sizeComboBox2.SelectedItem = fontSize.ToString();

                // Check if the selected text is bold, italic, or underlined and update the buttons accordingly
                bool isBold = richTextBox1.SelectionFont.Bold;
                bool isItalic = richTextBox1.SelectionFont.Italic;
                bool isUnderline = richTextBox1.SelectionFont.Underline;

                BoldtoolStripButton3.Checked = isBold;
                ItalictoolStripButton4.Checked = isItalic;
                UnderlinetoolStripButton5.Checked = isUnderline;

                // Optional: Update button colors based on style
                if (isBold || isItalic || isUnderline)
                {
                    BoldtoolStripButton3.ForeColor = Color.Blue;
                    ItalictoolStripButton4.ForeColor = Color.Blue;
                    UnderlinetoolStripButton5.ForeColor = Color.Blue;
                }
                else
                {
                    BoldtoolStripButton3.ForeColor = SystemColors.ControlText;
                    ItalictoolStripButton4.ForeColor = SystemColors.ControlText;
                    UnderlinetoolStripButton5.ForeColor = SystemColors.ControlText;
                }
            }
            else
            {
                // If no selection, reset the comboboxes and buttons
                fontComboBox1.SelectedItem = null;
                sizeComboBox2.SelectedItem = null;

                BoldtoolStripButton3.Checked = false;
                ItalictoolStripButton4.Checked = false;
                UnderlinetoolStripButton5.Checked = false;

                BoldtoolStripButton3.ForeColor = SystemColors.ControlText;
                ItalictoolStripButton4.ForeColor = SystemColors.ControlText;
                UnderlinetoolStripButton5.ForeColor = SystemColors.ControlText;
            }
        }
        private void UpdateToolbar()
        {
            // Check if the SelectionFont is not null
            if (richTextBox1.SelectionFont != null)
            {
                // Get the selected font family and size
                string fontName = richTextBox1.SelectionFont.FontFamily.Name;
                float fontSize = richTextBox1.SelectionFont.Size;

                // Update the font comboBox to reflect the selected font
                if (fontComboBox1.Items.Contains(fontName))
                {
                    fontComboBox1.SelectedItem = fontName;
                }

                // Update the font size comboBox to reflect the selected font size
                sizeComboBox2.SelectedItem = fontSize.ToString();

                // Check if the selected text is bold, italic, or underlined
                bool isBold = richTextBox1.SelectionFont.Bold;
                bool isItalic = richTextBox1.SelectionFont.Italic;
                bool isUnderline = richTextBox1.SelectionFont.Underline;

                // Update the ToolStrip buttons for Bold, Italic, and Underline
                BoldtoolStripButton3.Checked = isBold;
                ItalictoolStripButton4.Checked = isItalic;
                UnderlinetoolStripButton5.Checked = isUnderline;

                // Optional: Update button colors based on style
                Color buttonColor = (isBold || isItalic || isUnderline) ? Color.Blue : SystemColors.ControlText;
                BoldtoolStripButton3.ForeColor = buttonColor;
                ItalictoolStripButton4.ForeColor = buttonColor;
                UnderlinetoolStripButton5.ForeColor = buttonColor;
            }
            else
            {
                // If no selection, reset the comboboxes and buttons
                fontComboBox1.SelectedItem = null;
                sizeComboBox2.SelectedItem = null;

                BoldtoolStripButton3.Checked = false;
                ItalictoolStripButton4.Checked = false;
                UnderlinetoolStripButton5.Checked = false;

                BoldtoolStripButton3.ForeColor = SystemColors.ControlText;
                ItalictoolStripButton4.ForeColor = SystemColors.ControlText;
                UnderlinetoolStripButton5.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
