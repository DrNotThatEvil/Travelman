namespace Travelman
{
    partial class MainForm
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
            this.formContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // formContent
            // 
            this.formContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formContent.BackColor = System.Drawing.SystemColors.Control;
            this.formContent.Location = new System.Drawing.Point(8, 64);
            this.formContent.Name = "formContent";
            this.formContent.Size = new System.Drawing.Size(784, 528);
            this.formContent.TabIndex = 1;
            this.formContent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dummyPanel_MouseClick);
            this.formContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dummyPanel_MouseDown);
            this.formContent.MouseEnter += new System.EventHandler(this.formContent_MouseEnter);
            this.formContent.MouseLeave += new System.EventHandler(this.formContent_MouseLeave);
            this.formContent.MouseHover += new System.EventHandler(this.formContent_MouseHover);
            this.formContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formContent_MouseMove);
            this.formContent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dummyPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.formContent);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Travelman";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel formContent;
    }
}

