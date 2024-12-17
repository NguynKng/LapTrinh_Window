using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.MultiSelect = false;         // Single selection mode
            listView1.HideSelection = false;      // Keep selection visible
            listView1.FullRowSelect = true;       // Select the full row
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            // Check if there is a selected item
            if (listView1.SelectedItems.Count > 0)
            {
                // Confirm deletion (optional)
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete the selected item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Remove the selected item
                    listView1.Items.Remove(listView1.SelectedItems[0]);

                    // Optionally, clear textboxes after deletion
                    txtSTK.Clear();
                    txtName.Clear();
                    txtAdress.Clear();
                    txtMoney.Clear();
                }
            }
            else
            {
                // Notify the user if no item is selected
                MessageBox.Show("Please select an item to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertUpdate(int selectedRow)
        {
            // Update an existing row
            if (selectedRow >= 0 && selectedRow < listView1.Items.Count)
            {
                // Get the selected ListViewItem
                ListViewItem item = listView1.Items[selectedRow];

                // Update SubItems (columns) with the corresponding textbox values
                item.SubItems[1].Text = txtSTK.Text.Trim();       // Update column 1 (STK)
                item.SubItems[2].Text = txtName.Text.Trim();      // Update column 2 (Name)
                item.SubItems[3].Text = txtAdress.Text.Trim();    // Update column 3 (Address)
                item.SubItems[4].Text = txtMoney.Text.Trim();     // Update column 4 (Money)
            }
        }

        private void Edit_AddBtn_Click(object sender, EventArgs e)
        {
            string newSTK = txtSTK.Text.Trim();

            // Check if STK already exists in the ListView
            bool stkExists = listView1.Items.Cast<ListViewItem>()
                                             .Any(item => item.SubItems[1].Text.Equals(newSTK, StringComparison.OrdinalIgnoreCase));
            if (listView1.SelectedIndices.Count > 0)
            {
                // Update the selected row
                int selectedRow = listView1.SelectedIndices[0];
                insertUpdate(selectedRow);
                MessageBox.Show("Update data successfully.",
                               "Sucess",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtTotal.Text = CalculateTotal().ToString("N0");
            }
            else
            {
                if (stkExists)
                {
                    // Display a message box and prevent adding
                    MessageBox.Show("The STK value already exists. Please enter a unique value.",
                                    "Duplicate STK",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                // Add a new row
                int newIndex = listView1.Items.Count + 1;  // Calculate the new index

                // Create a new ListViewItem and set its columns
                ListViewItem newItem = new ListViewItem(newIndex.ToString()); // Column 0: Index
                newItem.SubItems.Add(txtSTK.Text.Trim());                    // Column 1: STK
                newItem.SubItems.Add(txtName.Text.Trim());                   // Column 2: Name
                newItem.SubItems.Add(txtAdress.Text.Trim());                 // Column 3: Address
                newItem.SubItems.Add(txtMoney.Text.Trim());                  // Column 4: Money

                // Add the new item to the ListView
                listView1.Items.Add(newItem);
                MessageBox.Show("Add new value successfully.",
                               "Success",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                txtTotal.Text = CalculateTotal().ToString("N0");
            }

            // Optionally clear the text boxes after adding/updating
            clearInputFields();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int selectedRow = listView1.SelectedIndices[0];
                ListViewItem item = listView1.Items[selectedRow];

                // Populate the text boxes with the selected row's data (skip index)
                txtSTK.Text = item.SubItems[1].Text;       // Column 1: STK
                txtName.Text = item.SubItems[2].Text;      // Column 2: Name
                txtAdress.Text = item.SubItems[3].Text;    // Column 3: Address
                txtMoney.Text = item.SubItems[4].Text;     // Column 4: Money
            }
        }

        private void clearInputFields()
        {
            txtSTK.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtMoney.Text = string.Empty;
        }

        private int CalculateTotal()
        {
            int total = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                // Try parsing the money value from the relevant column
                if (int.TryParse(item.SubItems[4].Text, out int money))
                {
                    total += money; // Add the money to the total
                }
                else
                {
                    // Handle invalid values (optional)
                    MessageBox.Show($"Invalid money value in row {item.Index + 1}. Skipping it.",
                                    "Invalid Value",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }

            return total;
        }
    }
}
