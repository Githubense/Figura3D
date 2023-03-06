namespace Figuras3D
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
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.RotarX = new System.Windows.Forms.Button();
            this.RotarY = new System.Windows.Forms.Button();
            this.RotarZ = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PCT_CANVAS.Location = new System.Drawing.Point(12, 12);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1241, 671);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // RotarX
            // 
            this.RotarX.Location = new System.Drawing.Point(12, 711);
            this.RotarX.Name = "RotarX";
            this.RotarX.Size = new System.Drawing.Size(184, 48);
            this.RotarX.TabIndex = 1;
            this.RotarX.Text = "RotarX";
            this.RotarX.UseVisualStyleBackColor = true;
            this.RotarX.Click += new System.EventHandler(this.RotarX_Click);
            // 
            // RotarY
            // 
            this.RotarY.Location = new System.Drawing.Point(221, 711);
            this.RotarY.Name = "RotarY";
            this.RotarY.Size = new System.Drawing.Size(184, 48);
            this.RotarY.TabIndex = 2;
            this.RotarY.Text = "RotarY";
            this.RotarY.UseVisualStyleBackColor = true;
            this.RotarY.Click += new System.EventHandler(this.RotarY_Click);
            // 
            // RotarZ
            // 
            this.RotarZ.Location = new System.Drawing.Point(434, 711);
            this.RotarZ.Name = "RotarZ";
            this.RotarZ.Size = new System.Drawing.Size(184, 48);
            this.RotarZ.TabIndex = 3;
            this.RotarZ.Text = "RotarZ";
            this.RotarZ.UseVisualStyleBackColor = true;
            this.RotarZ.Click += new System.EventHandler(this.RotarZ_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 8;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1265, 782);
            this.Controls.Add(this.RotarZ);
            this.Controls.Add(this.RotarY);
            this.Controls.Add(this.RotarX);
            this.Controls.Add(this.PCT_CANVAS);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Button RotarX;
        private System.Windows.Forms.Button RotarY;
        private System.Windows.Forms.Button RotarZ;
        private System.Windows.Forms.Timer timer1;
    }
}

