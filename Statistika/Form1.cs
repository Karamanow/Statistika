using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Statistika
{
    public partial class Form1 : Form
    {
        double[] numbers;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string[] parts = txtNumbers.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
            {
                MessageBox.Show("Моля, въведете числа!");
                return;
            }

            numbers = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                numbers[i] = double.Parse(parts[i]);
            }
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            double average = sum / numbers.Length;
            lblAverage.Text = "Средно аритметично: " + Math.Round(average, 2);
            double[] sorted = (double[])numbers.Clone();
            Array.Sort(sorted);
            double median;
            int n = sorted.Length;
            if (n % 2 == 1)
            {
                median = sorted[n / 2];
            }
            else
            {
                median = (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
            }
            lblMedian.Text = "Медиана: " + Math.Round(median, 2);
            double mode = numbers[0];
            int maxCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentCount = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        currentCount++;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    mode = numbers[i];
                }
            }
            lblMode.Text = "Мода: " + mode;

            DrawChart(SeriesChartType.Column);
        }

        private void DrawChart(SeriesChartType type)
        {
            if (numbers == null) return;

            chart1.Series.Clear();
            Series s = new Series("Числа");
            s.ChartType = type;

            double[] sorted = (double[])numbers.Clone();
            Array.Sort(sorted);

            for (int i = 0; i < sorted.Length; i++)
            {
                int count = 1;
                while (i + 1 < sorted.Length && sorted[i] == sorted[i + 1])
                {
                    count++;
                    i++;
                }
                s.Points.AddXY(sorted[i], count);
            }

            chart1.Series.Add(s);
        }
        private void InitializeComponent()
        {
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            txtNumbers = new TextBox();
            button1 = new Button();
            chart1 = new Chart();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            lblAverage = new Label();
            lblMedian = new Label();
            lblMode = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // txtNumbers
            // 
            txtNumbers.Location = new Point(2, 29);
            txtNumbers.Name = "txtNumbers";
            txtNumbers.Size = new Size(505, 23);
            txtNumbers.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(522, 12);
            button1.Name = "button1";
            button1.Size = new Size(108, 47);
            button1.TabIndex = 1;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(2, 165);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(439, 297);
            chart1.TabIndex = 2;
            chart1.Text = "chart1";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(483, 130);
            button2.Name = "button2";
            button2.Size = new Size(147, 78);
            button2.TabIndex = 3;
            button2.Text = "Column";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(483, 231);
            button3.Name = "button3";
            button3.Size = new Size(147, 78);
            button3.TabIndex = 4;
            button3.Text = "Pie Chart";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(483, 333);
            button4.Name = "button4";
            button4.Size = new Size(147, 78);
            button4.TabIndex = 5;
            button4.Text = "Line";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // lblAverage
            // 
            lblAverage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblAverage.Location = new Point(2, 55);
            lblAverage.Name = "lblAverage";
            lblAverage.Size = new Size(149, 49);
            lblAverage.TabIndex = 6;
            lblAverage.Text = "Средно аритметично";
            // 
            // lblMedian
            // 
            lblMedian.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMedian.Location = new Point(2, 113);
            lblMedian.Name = "lblMedian";
            lblMedian.Size = new Size(143, 49);
            lblMedian.TabIndex = 7;
            lblMedian.Text = "Медиана";
            // 
            // lblMode
            // 
            lblMode.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMode.Location = new Point(288, 75);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(143, 49);
            lblMode.TabIndex = 8;
            lblMode.Text = "Мода";
            // 
            // Form1
            // 
            ClientSize = new Size(642, 459);
            Controls.Add(lblMode);
            Controls.Add(lblMedian);
            Controls.Add(lblAverage);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(chart1);
            Controls.Add(button1);
            Controls.Add(txtNumbers);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            DrawChart(SeriesChartType.Line);
        }

        private TextBox txtNumbers;
        private Button button1;
        private Chart chart1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label lblAverage;
        private Label lblMedian;
        private Label lblMode;

        private void button1_Click(object sender, EventArgs e)
        {
            string[] parts = txtNumbers.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                MessageBox.Show("Моля, въведете числа!");
                return;
            }
            numbers = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                numbers[i] = double.Parse(parts[i]);
            }
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            double average = sum / numbers.Length;
            lblAverage.Text = "Средно аритметично: " + Math.Round(average, 2);
            double[] sorted = (double[])numbers.Clone();
            Array.Sort(sorted);
            double median;
            int n = sorted.Length;
            if (n % 2 == 1)
            {
                median = sorted[n / 2];
            }
            else
            {
                median = (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
            }
            lblMedian.Text = "Медиана: " + Math.Round(median, 2);
            double mode = numbers[0];
            int maxCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentCount = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i]) currentCount++;
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    mode = numbers[i];
                }
            }
            lblMode.Text = "Мода: " + mode;
            DrawChart(SeriesChartType.Column);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawChart(SeriesChartType.Column);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawChart(SeriesChartType.Pie);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawChart(SeriesChartType.Line);
        }
    }
}