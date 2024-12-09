using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using System.Collections.Specialized;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
      
        #region Constructors
        public Form1()
        {
            InitializeComponent();
            populateGridView();
            
        }

        ~Form1()
        {
            
        }
        #endregion
                          
        #region FileReadWrite
        private void populateGridView()
        {
            string[] row0 = { "11/22/1968",     "29", "Revolution 9",                       "Beatles",          "The Beatles [White Album]" };
            string[] row1 = { "1960",           "6",  "Fools Rush In",                      "Frank Sinatra",    "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971",     "1",  "One of These Days",                  "Pink Floyd",       "Meddle" };
            string[] row3 = { "1988",           "7",  "Where Is My Mind?",                  "Pixies",           "Surfer Rosa" };
            string[] row4 = { "5/1981",         "9",  "Can't Find My Mind",                 "Cramps",           "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003",      "13", "Scatterbrain. (As Dead As Leaves.)", "Radiohead",        "Hail to the Thief" };
            string[] row6 = { "6/30/1992",      "3",  "Dress",                              "P J Harvey",       "Dry" };

            dataGridView1.ColumnCount       = 5;
            dataGridView1.Columns[0].Name   = "Release Date";
            dataGridView1.Columns[1].Name   = "Track";
            dataGridView1.Columns[2].Name   = "Title";
            dataGridView1.Columns[3].Name   = "Artist";
            dataGridView1.Columns[4].Name   = "Album";

            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);
            dataGridView1.Rows.Add(row5);
            dataGridView1.Rows.Add(row6);

            dataGridView1.Columns[0].DisplayIndex = 3;
            dataGridView1.Columns[1].DisplayIndex = 4;
            dataGridView1.Columns[2].DisplayIndex = 0;
            dataGridView1.Columns[3].DisplayIndex = 1;
            dataGridView1.Columns[4].DisplayIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)  // ZAPISZ
        {
            StreamWriter myStream;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
           
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    myStream = new StreamWriter(saveFileDialog1.FileName,false);
                    
                    myStream.Write(textBox2.Text);
                    myStream.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)  // WCZYTAJ 
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string[] buffer;
            string[] fields;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {

                    buffer = File.ReadAllLines(openFileDialog1.FileName);
                    textBox2.Clear();
                    foreach (string line in buffer)
                        textBox2.AppendText(line + "\r\n");
                    
                    dataGridView1.Columns.Clear();
                    dataGridView1.ColumnCount = 3;
                    dataGridView1.Columns[0].Name = "Text_col1";
                    dataGridView1.Columns[1].Name = "Text_col2";
                    dataGridView1.Columns[2].Name = "Text_col3";

                    foreach (string line in buffer)
                    {
                        fields = line.Split('\t');
                        dataGridView1.Rows.Add(fields);
                    }

                }
            }


        }
        #endregion
    }
}
