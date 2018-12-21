namespace TrainTesting
{
    partial class FormSettings
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
            this.Status = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeRequest = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ColorName = new System.Windows.Forms.TextBox();
            this.QueryStyles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(12, 25);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(100, 20);
            this.Status.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Time request";
            // 
            // TimeRequest
            // 
            this.TimeRequest.Location = new System.Drawing.Point(12, 64);
            this.TimeRequest.Name = "TimeRequest";
            this.TimeRequest.Size = new System.Drawing.Size(100, 20);
            this.TimeRequest.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Color Name";
            // 
            // ColorName
            // 
            this.ColorName.Location = new System.Drawing.Point(12, 103);
            this.ColorName.Name = "ColorName";
            this.ColorName.Size = new System.Drawing.Size(100, 20);
            this.ColorName.TabIndex = 12;
            // 
            // QueryStyles
            // 
            this.QueryStyles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.QueryStyles.FormattingEnabled = true;
            this.QueryStyles.Location = new System.Drawing.Point(200, 9);
            this.QueryStyles.Name = "QueryStyles";
            this.QueryStyles.Size = new System.Drawing.Size(454, 407);
            this.QueryStyles.TabIndex = 14;
            this.QueryStyles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.QueryStyles_DrawItem);
            this.QueryStyles.DoubleClick += new System.EventHandler(this.QueryStyles_DoubleClick);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 434);
            this.Controls.Add(this.QueryStyles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ColorName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeRequest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Status);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TimeRequest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ColorName;
        private System.Windows.Forms.ListBox QueryStyles;
    }
}