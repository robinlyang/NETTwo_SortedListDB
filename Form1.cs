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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NETTwo_SortedListDB
{
    public partial class Form1 : Form
    {
        //SortedList<string, person> database = new SortedList<string, person>(); 
        db d = new db();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists(@"C:\Users\ryang\Desktop\db.dat"))
            {
                d = d.load();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {//add button
            person record = new person();
            record.name = name.Text;
            record.phone = Convert.ToInt64(phone.Text);
            d.database[id.Text] = record;
            message.Text = "Added";
        }

        private void change_Click(object sender, EventArgs e)
        {//change button
            person record = new person();
            record.name = name.Text;
            record.phone = Convert.ToInt64(phone.Text);
            d.database[id.Text] = record;
            message.Text = "Changed";
        }

        private void delete_Click(object sender, EventArgs e)
        {//delete button
            d.database.Remove(id.Text);
            message.Text = "Deleted";
            id.Text = "";
            name.Text = "";
            phone.Text = "";
        }

        private void read_Click(object sender, EventArgs e)
        {//read button
            if(d.database.ContainsKey(id.Text))
            {
                name.Text = d.database[id.Text].name;
                phone.Text = d.database[id.Text].phone.ToString();
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            d.save();
        }
    }

    //have a class for every table
    [Serializable]
    class person
    {
        public string name;
        public long phone;
    }

    //one class to persist
    [Serializable]
    class db
    {
        //each sorted list within the persist class for each table
        public SortedList<string, person> database = new SortedList<string, person>();
        public void save()
        {
            BinaryFormatter b = new BinaryFormatter();
            FileStream f = new FileStream(@"C:\Users\ryang\Desktop\db.dat", FileMode.Create);
            b.Serialize(f, this);
            f.Close();

        }
        public db load()
        {
            BinaryFormatter b = new BinaryFormatter();
            using (FileStream f = new FileStream(@"C:\Users\ryang\Desktop\db.dat", FileMode.Open))
            {
                return (db)b.Deserialize(f);
            }
        }
    }

}
