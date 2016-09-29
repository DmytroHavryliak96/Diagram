using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h;
            double[] array;
            switch (comboBox1.Text)
            {
                case "Нормальний":
                    array = Distribution.RandomNormal(0, 8, 2000000);
                    break;
                case "Експотенційний":
                    array = Distribution.Exponential(0, 8, 1.0, 2000000);
                    break;
                default:
                    array = null;
                    break;
            }
     
            Array.Sort(array);
            h = Distribution.Interval(array);

            textBox1.Text = Convert.ToString(h);

            ArrayList pairs = new ArrayList();

            for (double curr = array.Min(); curr <= array.Max(); curr += h)
            {
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (curr <= array[j] && array[j] < curr + h)
                        count++;

                }
                Key obj = new Key();
                obj.key = curr;
                obj.count = count;
                pairs.Add(obj);
            }

            this.chart1.ChartAreas.Add("area");
            this.chart1.ChartAreas["area"].AxisX.Minimum = array.Min();
            this.chart1.ChartAreas["area"].AxisX.Maximum = array.Max();
            this.chart1.ChartAreas["area"].AxisX.Interval = 0.1;
            this.chart1.ChartAreas["area"].AxisY.Minimum = 0;
            this.chart1.ChartAreas["area"].AxisY.Maximum = array.Length;
            this.chart1.ChartAreas["area"].AxisY.Interval = 25000;

            for(int i = 0; i < pairs.Count; i++)
            {
                
                Key obj2 = (Key)pairs[i];
                double d = obj2.key + h;
                this.chart1.Series["Values"].Points.AddXY(Convert.ToString(obj2.key + "-" + d), obj2.count);
            }
            

        }

        
    }
}
