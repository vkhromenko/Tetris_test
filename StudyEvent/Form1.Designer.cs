namespace StudyEvent
{
    partial class TetrisGame
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
            this.shapePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.shapePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // shapePicture
            // 
            this.shapePicture.Location = new System.Drawing.Point(0, 0);
            this.shapePicture.Name = "shapePicture";
            this.shapePicture.Size = new System.Drawing.Size(435, 653);
            this.shapePicture.TabIndex = 0;
            this.shapePicture.TabStop = false;
            this.shapePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.shapePicture_Paint);
            // 
            // TetrisGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 653);
            this.Controls.Add(this.shapePicture);
            this.Name = "TetrisGame";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisGame_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.shapePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox shapePicture;
    }
}

