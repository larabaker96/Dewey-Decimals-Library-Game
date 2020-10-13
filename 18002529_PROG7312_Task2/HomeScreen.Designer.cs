namespace _18002529_PROG7312_Task2
{
    partial class HomeScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.btnReplaceBooks = new System.Windows.Forms.Button();
            this.btnIdentifyAreas = new System.Windows.Forms.Button();
            this.btnCallNumbers = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtXP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReplaceBooks
            // 
            this.btnReplaceBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceBooks.Location = new System.Drawing.Point(73, 317);
            this.btnReplaceBooks.Name = "btnReplaceBooks";
            this.btnReplaceBooks.Size = new System.Drawing.Size(140, 35);
            this.btnReplaceBooks.TabIndex = 0;
            this.btnReplaceBooks.Text = "Replace Books";
            this.btnReplaceBooks.UseVisualStyleBackColor = true;
            this.btnReplaceBooks.Click += new System.EventHandler(this.btnReplaceBooks_Click);
            // 
            // btnIdentifyAreas
            // 
            this.btnIdentifyAreas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIdentifyAreas.Location = new System.Drawing.Point(338, 317);
            this.btnIdentifyAreas.Name = "btnIdentifyAreas";
            this.btnIdentifyAreas.Size = new System.Drawing.Size(140, 35);
            this.btnIdentifyAreas.TabIndex = 1;
            this.btnIdentifyAreas.Text = "Identify Areas";
            this.btnIdentifyAreas.UseVisualStyleBackColor = true;
            this.btnIdentifyAreas.Click += new System.EventHandler(this.btnIdentifyAreas_Click);
            // 
            // btnCallNumbers
            // 
            this.btnCallNumbers.Enabled = false;
            this.btnCallNumbers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCallNumbers.Location = new System.Drawing.Point(585, 317);
            this.btnCallNumbers.Name = "btnCallNumbers";
            this.btnCallNumbers.Size = new System.Drawing.Size(140, 35);
            this.btnCallNumbers.TabIndex = 2;
            this.btnCallNumbers.Text = "Find Call Numbers";
            this.btnCallNumbers.UseVisualStyleBackColor = true;
            this.btnCallNumbers.Click += new System.EventHandler(this.btnCallNumbers_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(238, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 25);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Welcome! Select a button to continue!";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(333, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 19);
            this.label5.TabIndex = 31;
            this.label5.Text = "XP:";
            // 
            // txtXP
            // 
            this.txtXP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXP.Location = new System.Drawing.Point(367, 413);
            this.txtXP.Name = "txtXP";
            this.txtXP.ReadOnly = true;
            this.txtXP.Size = new System.Drawing.Size(111, 25);
            this.txtXP.TabIndex = 30;
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtXP);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnReplaceBooks);
            this.Controls.Add(this.btnCallNumbers);
            this.Controls.Add(this.btnIdentifyAreas);
            this.Name = "HomeScreen";
            this.Text = "Welcome!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplaceBooks;
        private System.Windows.Forms.Button btnIdentifyAreas;
        private System.Windows.Forms.Button btnCallNumbers;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtXP;
    }
}

