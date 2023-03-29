namespace Lab_12_Comp
{
    partial class Form2
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
            this.buttonGenCurv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGenCurv
            // 
            this.buttonGenCurv.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonGenCurv.Font = new System.Drawing.Font("Montserrat SemiBold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGenCurv.Location = new System.Drawing.Point(150, 75);
            this.buttonGenCurv.Name = "buttonGenCurv";
            this.buttonGenCurv.Size = new System.Drawing.Size(300, 100);
            this.buttonGenCurv.TabIndex = 0;
            this.buttonGenCurv.Text = "Generate a Curv.data ";
            this.buttonGenCurv.UseVisualStyleBackColor = false;
            this.buttonGenCurv.Click += new System.EventHandler(this.buttonGenCurv_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.buttonGenCurv);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGenCurv;
    }
}