namespace bai_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);
            }
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                listBox1.Items.Add(listBox2.SelectedItems[i]);
            }
            for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Remove(listBox2.SelectedItems[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = listBox1.Items.Count;
            for (int i = 0; i <= n - 1; i++)
                listBox2.Items.Add(listBox1.Items[i].ToString());
            for (int j = n - 1; j >= 0; j--)
                listBox1.Items.RemoveAt(j);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = listBox2.Items.Count;
            for (int i = 0; i <= n - 1; i++)
                listBox1.Items.Add(listBox2.Items[i].ToString());
            for (int j = n - 1; j >= 0; j--)
                listBox2.Items.RemoveAt(j);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Focus();
        }
    }
}


