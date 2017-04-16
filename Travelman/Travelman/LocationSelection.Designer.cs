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
            this.panelInput = new System.Windows.Forms.Panel();
            this.tbInput = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.timerAutocompleteRequest = new System.Windows.Forms.Timer(this.components);
            this.panelInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BackColor = System.Drawing.Color.White;
            this.panelInput.Controls.Add(this.tbInput);
            this.panelInput.Location = new System.Drawing.Point(3, 3);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(288, 48);
            this.panelInput.TabIndex = 0;
            // 
            // tbInput
            // 
            this.tbInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbInput.Depth = 0;
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Hint = "";
            this.tbInput.Location = new System.Drawing.Point(56, 14);
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
            this.tbInput.Leave += new System.EventHandler(this.tbInput_Leave);
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // timerAutocompleteRequest
            // 
            this.timerAutocompleteRequest.Interval = 1000;
            this.timerAutocompleteRequest.Tick += new System.EventHandler(this.timerAutocompleteRequestFinished);
            // 
            // LocationSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelInput);
            this.Name = "LocationSelection";
            this.Size = new System.Drawing.Size(294, 555);
            this.panelInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Timer timerAutocompleteRequest;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbInput;
    }
}
