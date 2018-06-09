using System.Windows.Forms;

namespace CurrencyLIVE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbCurrencyA = new System.Windows.Forms.ComboBox();
            this.cbCurrencyB = new System.Windows.Forms.ComboBox();
            this.tbCurrencyA = new System.Windows.Forms.TextBox();
            this.tbCurrencyB = new System.Windows.Forms.TextBox();
            this.btnRevert = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(363, 403);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cbCurrencyA
            // 
            this.cbCurrencyA.FormattingEnabled = true;
            this.cbCurrencyA.Location = new System.Drawing.Point(369, 12);
            this.cbCurrencyA.Name = "cbCurrencyA";
            this.cbCurrencyA.Size = new System.Drawing.Size(100, 21);
            this.cbCurrencyA.TabIndex = 1;
            this.cbCurrencyA.SelectedIndexChanged += new System.EventHandler(this.cbCurrencyA_SelectedIndexChanged);
            // 
            // cbCurrencyB
            // 
            this.cbCurrencyB.FormattingEnabled = true;
            this.cbCurrencyB.Location = new System.Drawing.Point(511, 12);
            this.cbCurrencyB.Name = "cbCurrencyB";
            this.cbCurrencyB.Size = new System.Drawing.Size(100, 21);
            this.cbCurrencyB.TabIndex = 1;
            this.cbCurrencyB.SelectedIndexChanged += new System.EventHandler(this.cbCurrencyB_SelectedIndexChanged);
            // 
            // tbCurrencyA
            // 
            this.tbCurrencyA.Location = new System.Drawing.Point(370, 40);
            this.tbCurrencyA.Name = "tbCurrencyA";
            this.tbCurrencyA.Size = new System.Drawing.Size(100, 20);
            this.tbCurrencyA.TabIndex = 2;
            this.tbCurrencyA.TextChanged += new System.EventHandler(this.tbCurrencyA_TextChanged);
            // 
            // tbCurrencyB
            // 
            this.tbCurrencyB.Location = new System.Drawing.Point(511, 40);
            this.tbCurrencyB.Name = "tbCurrencyB";
            this.tbCurrencyB.Size = new System.Drawing.Size(100, 20);
            this.tbCurrencyB.TabIndex = 2;
            // 
            // btnRevert
            // 
            this.btnRevert.Image = ((System.Drawing.Image)(resources.GetObject("btnRevert.Image")));
            this.btnRevert.Location = new System.Drawing.Point(478, 9);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(25, 25);
            this.btnRevert.TabIndex = 3;
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(370, 67);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(444, 324);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 403);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.tbCurrencyB);
            this.Controls.Add(this.tbCurrencyA);
            this.Controls.Add(this.cbCurrencyB);
            this.Controls.Add(this.cbCurrencyA);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbCurrencyA;
        private System.Windows.Forms.ComboBox cbCurrencyB;
        private System.Windows.Forms.TextBox tbCurrencyA;
        private System.Windows.Forms.TextBox tbCurrencyB;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

