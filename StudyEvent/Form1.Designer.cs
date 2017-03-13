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
            this.mainArea = new System.Windows.Forms.SplitContainer();
            this.shapePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).BeginInit();
            this.mainArea.Panel1.SuspendLayout();
            this.mainArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shapePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mainArea
            // 
            this.mainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainArea.Location = new System.Drawing.Point(0, 0);
            this.mainArea.Name = "mainArea";
            // 
            // mainArea.Panel1
            // 
            this.mainArea.Panel1.Controls.Add(this.shapePicture);
            this.mainArea.Size = new System.Drawing.Size(630, 653);
            this.mainArea.SplitterDistance = 419;
            this.mainArea.TabIndex = 0;
            // 
            // shapePicture
            // 
            this.shapePicture.Location = new System.Drawing.Point(0, 0);
            this.shapePicture.Name = "shapePicture";
            this.shapePicture.Size = new System.Drawing.Size(417, 653);
            this.shapePicture.TabIndex = 0;
            this.shapePicture.TabStop = false;
            this.shapePicture.Paint += new System.Windows.Forms.PaintEventHandler(this.shapePicture_Paint);
            // 
            // TetrisGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 653);
            this.Controls.Add(this.mainArea);
            this.Name = "TetrisGame";
            this.Text = "Form1";
            this.mainArea.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainArea)).EndInit();
            this.mainArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shapePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainArea;
        private System.Windows.Forms.PictureBox shapePicture;
    }
}

