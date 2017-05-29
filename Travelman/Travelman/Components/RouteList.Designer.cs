namespace Travelman.Components
{
    partial class RouteList
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
            this.lblMyRoutes = new MaterialSkin.Controls.MaterialLabel();
            this.panelListContainer = new System.Windows.Forms.Panel();
            this.lblNoRoutesToDisplay = new MaterialSkin.Controls.MaterialLabel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.lblNoRoutesToDisplay);
            this.panel.Controls.Add(this.lblMyRoutes);
            this.panel.Controls.Add(this.panelListContainer);
            this.panel.Location = new System.Drawing.Point(1, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(528, 512);
            this.panel.TabIndex = 0;
            // 
            // lblMyRoutes
            // 
            this.lblMyRoutes.AutoSize = true;
            this.lblMyRoutes.Depth = 0;
            this.lblMyRoutes.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblMyRoutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMyRoutes.Location = new System.Drawing.Point(225, 13);
            this.lblMyRoutes.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMyRoutes.Name = "lblMyRoutes";
            this.lblMyRoutes.Size = new System.Drawing.Size(80, 19);
            this.lblMyRoutes.TabIndex = 1;
            this.lblMyRoutes.Text = "My Routes";
            // 
            // panelListContainer
            // 
            this.panelListContainer.AutoScroll = true;
            this.panelListContainer.Location = new System.Drawing.Point(1, 40);
            this.panelListContainer.Name = "panelListContainer";
            this.panelListContainer.Size = new System.Drawing.Size(528, 469);
            this.panelListContainer.TabIndex = 0;
            // 
            // lblNoRoutesToDisplay
            // 
            this.lblNoRoutesToDisplay.AutoSize = true;
            this.lblNoRoutesToDisplay.Depth = 0;
            this.lblNoRoutesToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblNoRoutesToDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoRoutesToDisplay.Location = new System.Drawing.Point(141, 14);
            this.lblNoRoutesToDisplay.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNoRoutesToDisplay.Name = "lblNoRoutesToDisplay";
            this.lblNoRoutesToDisplay.Size = new System.Drawing.Size(247, 18);
            this.lblNoRoutesToDisplay.TabIndex = 2;
            this.lblNoRoutesToDisplay.Text = "There are no saved routes to display";
            // 
            // RouteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panel);
            this.Name = "RouteList";
            this.Size = new System.Drawing.Size(530, 515);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelListContainer;
        private MaterialSkin.Controls.MaterialLabel lblMyRoutes;
        private MaterialSkin.Controls.MaterialLabel lblNoRoutesToDisplay;
    }
}
