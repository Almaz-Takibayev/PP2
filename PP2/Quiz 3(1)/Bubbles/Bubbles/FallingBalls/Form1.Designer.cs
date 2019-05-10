namespace FallingBalls
{
    partial class FallingBalls
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
            this.components = new System.ComponentModel.Container();
            this.Create = new System.Windows.Forms.Timer(this.components);
            this.Fall = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Enabled = true;
            this.Create.Interval = 1500;
            this.Create.Tick += new System.EventHandler(this.Create_Tick);
            // 
            // Fall
            // 
            this.Fall.Enabled = true;
            this.Fall.Interval = 20;
            this.Fall.Tick += new System.EventHandler(this.Fall_Tick);
            // 
            // FallingBalls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(634, 411);
            this.Name = "FallingBalls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bubbles";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FallingBalls_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FallingBalls_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Create;
        private System.Windows.Forms.Timer Fall;
    }
}

