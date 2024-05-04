
using System.ComponentModel;
using System.Drawing.Printing;

namespace dataGridView
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView;
        private BindingList<Person> people;
        int count = 1;
        
        public Form1()
        {
            InitializeComponent();

            //DataGridViewButtonColumn
            //DataGridViewCheckBoxColumn
            //DataGridViewComboBoxColumn
            //DataGridViewImageColumn
            //DataGridViewLinkColumn
            //DataGridViewTextBoxCell

            dataGridView = new DataGridView();
            dataGridView.Columns.Add("Column1", "Id");
            dataGridView.Columns.Add("Column2", "Name");
            dataGridView.Columns.Add("Column3", "Age");


            DataGridViewTextBoxCell dataGridViewTextBoxCellCompany = new DataGridViewTextBoxCell();
            dataGridView.Columns.Add(new DataGridViewColumn(dataGridViewTextBoxCellCompany)
            {
                HeaderText = "Company",
                Name = "Column4"
            });

            DataGridViewTextBoxCell dataGridViewTextBoxCellHobby = new DataGridViewTextBoxCell();
            dataGridView.Columns.Insert(2, new DataGridViewColumn(dataGridViewTextBoxCellHobby)
            {
                HeaderText = "Hobby",
                Name = "Column5"
            });

            //********************************
            dataGridView.Dock = DockStyle.Fill;
            panel1.Controls.Add(dataGridView);
          
        }

        private void RemoveCellButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell?.ColumnIndex ?? -1;
            int columnsCount = dataGridView.Columns.Count;

            if ((columnsCount > 0) && (index >= 0) && (index < columnsCount))
            {
                dataGridView.Columns.RemoveAt(index);
            }
        }

  

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            
            dataGridView.Rows.Add(count, textBox1.Text.ToString(), textBox4.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString());
            count++;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            int rowsCount = dataGridView.Rows.Count;

            if ((rowsCount > 1) && (index >= 0) && (index < rowsCount))
            {
                dataGridView.Rows.RemoveAt(index);

            }
            count--;
        }

        private void SetDataSourceButton_Click(object sender, EventArgs e)
        {
            int index = dataGridView.CurrentCell.RowIndex;
            int rowsCount = dataGridView.Rows.Count;

            if ((rowsCount > 1) && (index >= 0) && (index < rowsCount))
            {
                dataGridView.CurrentCell.Value = ValueTextbox.Text;
            }
            
        }

       

      

      

     
    }

    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }

        public static BindingList<Person> GetData()
        {
            return new BindingList<Person>()
            {
                new Person{ Name = "Alex", Age = 32, Company = "WallMart"},
                new Person{ Name = "Jonh", Age = 16, Company = "Wendys"},
                new Person{ Name = "Kate", Age = 25, Company = "BestBuy"},
                new Person{ Name = "Sarah", Age = 41, Company = "WallMart"},
                new Person{ Name = "Smith", Age = 29, Company = "Aoc"}
            };
        }
    }
}
