using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace NETTwo_SortedListDB
{
    public partial class Form1 : Form
    {
        SortedList<string, person> database = new SortedList<string, person>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {//add button
            person record = new person();
            record.name = name.Text;
            record.phone = Convert.ToInt64(phone.Text);
            database[id.Text] = record;
            message.Text = "Added";
        }

        private void change_Click(object sender, EventArgs e)
        {//change button
            person record = new person();
            record.name = name.Text;
            record.phone = Convert.ToInt64(phone.Text);
            database[id.Text] = record;
            message.Text = "Changed";
        }

        private void delete_Click(object sender, EventArgs e)
        {//delete button
            database.Remove(id.Text);
            message.Text = "Deleted";
            id.Text = "";
            name.Text = "";
            phone.Text = "";
        }

        private void read_Click(object sender, EventArgs e)
        {//read button
            if(database.ContainsKey(id.Text))
            {
                name.Text = database[id.Text].name;
                phone.Text = database[id.Text].phone.ToString();
                message.Text = "";
            }
            else
            {
                message.Text = "Cannot find";
                id.Text = "";
                name.Text = "";
                phone.Text = "";
            }
        }
    }
    class person
    {
        public string name;
        public long phone;
    }
}
