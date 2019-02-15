namespace oop_cursovik
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMoveRandom = new System.Windows.Forms.RadioButton();
            this.radioMoveArrow = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMoveRandom);
            this.groupBox1.Controls.Add(this.radioMoveArrow);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим движения";
            // 
            // radioMoveRandom
            // 
            this.radioMoveRandom.AutoSize = true;
            this.radioMoveRandom.Location = new System.Drawing.Point(7, 43);
            this.radioMoveRandom.Name = "radioMoveRandom";
            this.radioMoveRandom.Size = new System.Drawing.Size(152, 17);
            this.radioMoveRandom.TabIndex = 1;
            this.radioMoveRandom.Text = "Случайное перемещение";
            this.radioMoveRandom.UseVisualStyleBackColor = true;
            this.radioMoveRandom.CheckedChanged += new System.EventHandler(this.radioMoveRandom_CheckedChanged);
            this.radioMoveRandom.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.radioMoveRandom_PreviewKeyDown);
            // 
            // radioMoveArrow
            // 
            this.radioMoveArrow.AutoSize = true;
            this.radioMoveArrow.Checked = true;
            this.radioMoveArrow.Location = new System.Drawing.Point(6, 19);
            this.radioMoveArrow.Name = "radioMoveArrow";
            this.radioMoveArrow.Size = new System.Drawing.Size(150, 17);
            this.radioMoveArrow.TabIndex = 0;
            this.radioMoveArrow.TabStop = true;
            this.radioMoveArrow.Text = "Премещение стрелками";
            this.radioMoveArrow.UseVisualStyleBackColor = true;
            this.radioMoveArrow.CheckedChanged += new System.EventHandler(this.radioMoveArrow_CheckedChanged);
            this.radioMoveArrow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.radioMoveArrow_PreviewKeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсовик";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMoveRandom;
        private System.Windows.Forms.RadioButton radioMoveArrow;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

