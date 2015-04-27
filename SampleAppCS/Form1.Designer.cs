namespace SampleApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnStandard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPro = new System.Windows.Forms.Button();
            this.btnEnterprise = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enter License";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStandard
            // 
            this.btnStandard.Enabled = false;
            this.btnStandard.Location = new System.Drawing.Point(12, 105);
            this.btnStandard.Name = "btnStandard";
            this.btnStandard.Size = new System.Drawing.Size(107, 23);
            this.btnStandard.TabIndex = 2;
            this.btnStandard.Text = "Standard Feature";
            this.btnStandard.UseVisualStyleBackColor = true;
            this.btnStandard.Click += new System.EventHandler(this.btnStandard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnPro
            // 
            this.btnPro.Enabled = false;
            this.btnPro.Location = new System.Drawing.Point(138, 105);
            this.btnPro.Name = "btnPro";
            this.btnPro.Size = new System.Drawing.Size(75, 23);
            this.btnPro.TabIndex = 4;
            this.btnPro.Text = "Pro Feature";
            this.btnPro.UseVisualStyleBackColor = true;
            this.btnPro.Click += new System.EventHandler(this.btnPro_Click);
            // 
            // btnEnterprise
            // 
            this.btnEnterprise.Enabled = false;
            this.btnEnterprise.Location = new System.Drawing.Point(233, 105);
            this.btnEnterprise.Name = "btnEnterprise";
            this.btnEnterprise.Size = new System.Drawing.Size(107, 23);
            this.btnEnterprise.TabIndex = 5;
            this.btnEnterprise.Text = "Enterprise Feature";
            this.btnEnterprise.UseVisualStyleBackColor = true;
            this.btnEnterprise.Click += new System.EventHandler(this.btnEnterprise_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 157);
            this.Controls.Add(this.btnEnterprise);
            this.Controls.Add(this.btnPro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStandard);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPro;
        private System.Windows.Forms.Button btnEnterprise;
    }
}

