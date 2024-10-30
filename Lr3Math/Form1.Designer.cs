namespace Lr3Math
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
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.radioMaximize = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMinimize = new System.Windows.Forms.RadioButton();
            this.txtObjectiveFunction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.AllPartsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllPartsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Location = new System.Drawing.Point(278, 7);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 62;
            this.dataGridViewInput.RowTemplate.Height = 28;
            this.dataGridViewInput.Size = new System.Drawing.Size(1193, 507);
            this.dataGridViewInput.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 44);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(12, 134);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 44);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "К-сть стовпців";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "К-сть рядків";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 69);
            this.button1.TabIndex = 5;
            this.button1.Text = "Згенерувати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Location = new System.Drawing.Point(278, 522);
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.RowHeadersWidth = 62;
            this.dataGridViewOutput.RowTemplate.Height = 28;
            this.dataGridViewOutput.Size = new System.Drawing.Size(1193, 507);
            this.dataGridViewOutput.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 960);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Обчислити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioMaximize
            // 
            this.radioMaximize.AutoSize = true;
            this.radioMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioMaximize.Location = new System.Drawing.Point(6, 25);
            this.radioMaximize.Name = "radioMaximize";
            this.radioMaximize.Size = new System.Drawing.Size(195, 33);
            this.radioMaximize.TabIndex = 8;
            this.radioMaximize.TabStop = true;
            this.radioMaximize.Text = "Максимізація";
            this.radioMaximize.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMinimize);
            this.groupBox1.Controls.Add(this.radioMaximize);
            this.groupBox1.Location = new System.Drawing.Point(17, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 123);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пошук";
            // 
            // radioMinimize
            // 
            this.radioMinimize.AutoSize = true;
            this.radioMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioMinimize.Location = new System.Drawing.Point(6, 57);
            this.radioMinimize.Name = "radioMinimize";
            this.radioMinimize.Size = new System.Drawing.Size(170, 33);
            this.radioMinimize.TabIndex = 9;
            this.radioMinimize.TabStop = true;
            this.radioMinimize.Text = "Мінімізація";
            this.radioMinimize.UseVisualStyleBackColor = true;
            // 
            // txtObjectiveFunction
            // 
            this.txtObjectiveFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtObjectiveFunction.Location = new System.Drawing.Point(17, 406);
            this.txtObjectiveFunction.Name = "txtObjectiveFunction";
            this.txtObjectiveFunction.Size = new System.Drawing.Size(206, 44);
            this.txtObjectiveFunction.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Коефіцієнти функції";
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.ItemHeight = 20;
            this.listBoxOutput.Location = new System.Drawing.Point(278, 1035);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(1193, 284);
            this.listBoxOutput.TabIndex = 12;
            // 
            // AllPartsGrid
            // 
            this.AllPartsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllPartsGrid.Location = new System.Drawing.Point(1477, 7);
            this.AllPartsGrid.Name = "AllPartsGrid";
            this.AllPartsGrid.RowHeadersWidth = 62;
            this.AllPartsGrid.RowTemplate.Height = 28;
            this.AllPartsGrid.Size = new System.Drawing.Size(1193, 1312);
            this.AllPartsGrid.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2715, 1341);
            this.Controls.Add(this.AllPartsGrid);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObjectiveFunction);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewOutput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllPartsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioMaximize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMinimize;
        private System.Windows.Forms.TextBox txtObjectiveFunction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.DataGridView AllPartsGrid;
    }
}

