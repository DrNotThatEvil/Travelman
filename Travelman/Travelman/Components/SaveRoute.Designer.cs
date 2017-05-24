namespace Travelman.Components
{
    partial class SaveRoute
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
            this.panel = new System.Windows.Forms.Panel();
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.tfName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblTitle = new MaterialSkin.Controls.MaterialLabel();
            this.tfFrom = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblFrom = new MaterialSkin.Controls.MaterialLabel();
            this.tfTo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblTo = new MaterialSkin.Controls.MaterialLabel();
            this.btnSaveRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.btnSaveRoute);
            this.panel.Controls.Add(this.tfTo);
            this.panel.Controls.Add(this.lblTo);
            this.panel.Controls.Add(this.tfFrom);
            this.panel.Controls.Add(this.lblFrom);
            this.panel.Controls.Add(this.lblTitle);
            this.panel.Controls.Add(this.tfName);
            this.panel.Controls.Add(this.lblName);
            this.panel.Location = new System.Drawing.Point(1, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(256, 286);
            this.panel.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(4, 40);
            this.lblName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tfName
            // 
            this.tfName.Depth = 0;
            this.tfName.Hint = "";
            this.tfName.Location = new System.Drawing.Point(8, 65);
            this.tfName.MaxLength = 255;
            this.tfName.MouseState = MaterialSkin.MouseState.HOVER;
            this.tfName.Name = "tfName";
            this.tfName.PasswordChar = '\0';
            this.tfName.SelectedText = "";
            this.tfName.SelectionLength = 0;
            this.tfName.SelectionStart = 0;
            this.tfName.Size = new System.Drawing.Size(240, 23);
            this.tfName.TabIndex = 1;
            this.tfName.TabStop = false;
            this.tfName.UseSystemPasswordChar = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.Depth = 0;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(8, 10);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Save Route";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tfFrom
            // 
            this.tfFrom.Depth = 0;
            this.tfFrom.Enabled = false;
            this.tfFrom.Hint = "";
            this.tfFrom.Location = new System.Drawing.Point(10, 127);
            this.tfFrom.MaxLength = 255;
            this.tfFrom.MouseState = MaterialSkin.MouseState.HOVER;
            this.tfFrom.Name = "tfFrom";
            this.tfFrom.PasswordChar = '\0';
            this.tfFrom.SelectedText = "";
            this.tfFrom.SelectionLength = 0;
            this.tfFrom.SelectionStart = 0;
            this.tfFrom.Size = new System.Drawing.Size(240, 23);
            this.tfFrom.TabIndex = 4;
            this.tfFrom.TabStop = false;
            this.tfFrom.UseSystemPasswordChar = false;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Depth = 0;
            this.lblFrom.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFrom.Location = new System.Drawing.Point(6, 102);
            this.lblFrom.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(44, 19);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "From";
            // 
            // tfTo
            // 
            this.tfTo.Depth = 0;
            this.tfTo.Enabled = false;
            this.tfTo.Hint = "";
            this.tfTo.Location = new System.Drawing.Point(8, 189);
            this.tfTo.MaxLength = 255;
            this.tfTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.tfTo.Name = "tfTo";
            this.tfTo.PasswordChar = '\0';
            this.tfTo.SelectedText = "";
            this.tfTo.SelectionLength = 0;
            this.tfTo.SelectionStart = 0;
            this.tfTo.Size = new System.Drawing.Size(240, 23);
            this.tfTo.TabIndex = 6;
            this.tfTo.TabStop = false;
            this.tfTo.UseSystemPasswordChar = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Depth = 0;
            this.lblTo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTo.Location = new System.Drawing.Point(4, 164);
            this.lblTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 19);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To";
            // 
            // btnSaveRoute
            // 
            this.btnSaveRoute.AutoSize = true;
            this.btnSaveRoute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveRoute.Depth = 0;
            this.btnSaveRoute.Icon = null;
            this.btnSaveRoute.Location = new System.Drawing.Point(78, 234);
            this.btnSaveRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveRoute.Name = "btnSaveRoute";
            this.btnSaveRoute.Primary = true;
            this.btnSaveRoute.Size = new System.Drawing.Size(102, 36);
            this.btnSaveRoute.TabIndex = 7;
            this.btnSaveRoute.Text = "Save route";
            this.btnSaveRoute.UseVisualStyleBackColor = true;
            // 
            // SaveRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panel);
            this.Name = "SaveRoute";
            this.Size = new System.Drawing.Size(258, 289);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private MaterialSkin.Controls.MaterialLabel lblName;
        private MaterialSkin.Controls.MaterialSingleLineTextField tfName;
        private MaterialSkin.Controls.MaterialLabel lblTitle;
        private MaterialSkin.Controls.MaterialSingleLineTextField tfFrom;
        private MaterialSkin.Controls.MaterialLabel lblFrom;
        private MaterialSkin.Controls.MaterialSingleLineTextField tfTo;
        private MaterialSkin.Controls.MaterialLabel lblTo;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveRoute;
    }
}
