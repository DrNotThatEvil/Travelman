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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblIcon = new System.Windows.Forms.Label();
            this.timerAutocompleteRequest = new System.Windows.Forms.Timer(this.components);
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbInput);
            this.panel1.Controls.Add(this.lblIcon);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 48);
            this.panel1.TabIndex = 0;
            // 
            // tbInput
            // 
            this.tbInput.Depth = 0;
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Hint = "";
            this.tbInput.Location = new System.Drawing.Point(56, 17);
            this.tbInput.Margin = new System.Windows.Forms.Padding(8);
            this.tbInput.MaxLength = 32767;
            this.tbInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbInput.Name = "tbInput";
            this.tbInput.PasswordChar = '\0';
            this.tbInput.SelectedText = "";
            this.tbInput.SelectionLength = 0;
            this.tbInput.SelectionStart = 0;
            this.tbInput.Size = new System.Drawing.Size(224, 23);
            this.tbInput.TabIndex = 2;
            this.tbInput.TabStop = false;
            this.tbInput.UseSystemPasswordChar = false;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // lblIcon
            // 
            this.lblIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIcon.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblIcon.Location = new System.Drawing.Point(8, 8);
            this.lblIcon.Margin = new System.Windows.Forms.Padding(8);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(32, 32);
            this.lblIcon.TabIndex = 1;
            // 
            // timerAutocompleteRequest
            // 
            this.timerAutocompleteRequest.Interval = 1000;
            this.timerAutocompleteRequest.Tick += new System.EventHandler(this.timerAutocompleteRequestFinished);
            // 
            // materialListView1
            // 
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.materialListView1.Location = new System.Drawing.Point(3, 51);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.MultiSelect = false;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.ShowGroups = false;
            this.materialListView1.Size = new System.Drawing.Size(288, 0);
            this.materialListView1.TabIndex = 0;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            this.materialListView1.SelectedIndexChanged += new System.EventHandler(this.materialListView1_SelectedIndexChanged);
            // 
            // LocationSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.materialListView1);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(80, 0);
            this.Name = "LocationSelection";
            this.Size = new System.Drawing.Size(294, 208);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerAutocompleteRequest;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private System.Windows.Forms.Label lblIcon;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbInput;
    }
}
