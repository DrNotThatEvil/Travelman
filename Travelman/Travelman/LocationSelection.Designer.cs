namespace Travelman
{
    partial class LocationSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.iconButton1 = new FontAwesomeIcons.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 56);
            this.panel1.TabIndex = 0;
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.SystemColors.Control;
            this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(62, 8);
            this.tbInput.Margin = new System.Windows.Forms.Padding(8);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(218, 28);
            this.tbInput.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.ActiveColor = System.Drawing.Color.Black;
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.Enabled = false;
            this.iconButton1.IconType = FontAwesomeIcons.IconType.FlagO;
            this.iconButton1.InActiveColor = System.Drawing.Color.DimGray;
            this.iconButton1.Location = new System.Drawing.Point(3, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(48, 48);
            this.iconButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconButton1.TabIndex = 1;
            this.iconButton1.TabStop = false;
            this.iconButton1.ToolTipText = null;
            // 
            // LocationSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LocationSelection";
            this.Size = new System.Drawing.Size(294, 307);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbInput;
        private FontAwesomeIcons.IconButton iconButton1;
    }
}
