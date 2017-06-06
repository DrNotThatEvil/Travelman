namespace Travelman.View
{
    sealed partial class MainView
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
            this.scMenubar = new System.Windows.Forms.SplitContainer();
            this.btnSaveRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMyRoutes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnStartOver = new MaterialSkin.Controls.MaterialRaisedButton();
            this.scSidebar = new System.Windows.Forms.SplitContainer();
            this.scSidebarHorizontal = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.scMenubar)).BeginInit();
            this.scMenubar.Panel1.SuspendLayout();
            this.scMenubar.Panel2.SuspendLayout();
            this.scMenubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSidebar)).BeginInit();
            this.scSidebar.Panel1.SuspendLayout();
            this.scSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSidebarHorizontal)).BeginInit();
            this.scSidebarHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMenubar
            // 
            this.scMenubar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMenubar.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMenubar.IsSplitterFixed = true;
            this.scMenubar.Location = new System.Drawing.Point(0, 0);
            this.scMenubar.Name = "scMenubar";
            this.scMenubar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMenubar.Panel1
            // 
            this.scMenubar.Panel1.Controls.Add(this.btnSaveRoute);
            this.scMenubar.Panel1.Controls.Add(this.btnMyRoutes);
            this.scMenubar.Panel1.Controls.Add(this.btnStartOver);
            this.scMenubar.Panel1MinSize = 64;
            // 
            // scMenubar.Panel2
            // 
            this.scMenubar.Panel2.Controls.Add(this.scSidebar);
            this.scMenubar.Size = new System.Drawing.Size(784, 528);
            this.scMenubar.SplitterDistance = 64;
            this.scMenubar.TabIndex = 0;
            // 
            // btnSaveRoute
            // 
            this.btnSaveRoute.AutoSize = true;
            this.btnSaveRoute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveRoute.Depth = 0;
            this.btnSaveRoute.Enabled = false;
            this.btnSaveRoute.Icon = null;
            this.btnSaveRoute.Location = new System.Drawing.Point(224, 16);
            this.btnSaveRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveRoute.Name = "btnSaveRoute";
            this.btnSaveRoute.Primary = true;
            this.btnSaveRoute.Size = new System.Drawing.Size(102, 36);
            this.btnSaveRoute.TabIndex = 3;
            this.btnSaveRoute.Text = "Save route";
            this.btnSaveRoute.UseVisualStyleBackColor = true;
            this.btnSaveRoute.Click += new System.EventHandler(this.SaveRoute_Click);
            // 
            // btnMyRoutes
            // 
            this.btnMyRoutes.AutoSize = true;
            this.btnMyRoutes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMyRoutes.Depth = 0;
            this.btnMyRoutes.Icon = null;
            this.btnMyRoutes.Location = new System.Drawing.Point(122, 16);
            this.btnMyRoutes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMyRoutes.Name = "btnMyRoutes";
            this.btnMyRoutes.Primary = true;
            this.btnMyRoutes.Size = new System.Drawing.Size(96, 36);
            this.btnMyRoutes.TabIndex = 1;
            this.btnMyRoutes.Text = "My routes";
            this.btnMyRoutes.UseVisualStyleBackColor = true;
            // 
            // btnStartOver
            // 
            this.btnStartOver.AutoSize = true;
            this.btnStartOver.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartOver.Depth = 0;
            this.btnStartOver.Icon = null;
            this.btnStartOver.Location = new System.Drawing.Point(14, 16);
            this.btnStartOver.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartOver.Name = "btnStartOver";
            this.btnStartOver.Primary = true;
            this.btnStartOver.Size = new System.Drawing.Size(102, 36);
            this.btnStartOver.TabIndex = 0;
            this.btnStartOver.Text = "Start over";
            this.btnStartOver.UseVisualStyleBackColor = true;
            this.btnStartOver.Click += new System.EventHandler(this.StartOver);
            // 
            // scSidebar
            // 
            this.scSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSidebar.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSidebar.IsSplitterFixed = true;
            this.scSidebar.Location = new System.Drawing.Point(0, 0);
            this.scSidebar.Name = "scSidebar";
            // 
            // scSidebar.Panel1
            // 
            this.scSidebar.Panel1.Controls.Add(this.scSidebarHorizontal);
            this.scSidebar.Panel1MinSize = 288;
            this.scSidebar.Size = new System.Drawing.Size(784, 460);
            this.scSidebar.SplitterDistance = 288;
            this.scSidebar.TabIndex = 0;
            // 
            // scSidebarHorizontal
            // 
            this.scSidebarHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSidebarHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSidebarHorizontal.IsSplitterFixed = true;
            this.scSidebarHorizontal.Location = new System.Drawing.Point(0, 0);
            this.scSidebarHorizontal.Name = "scSidebarHorizontal";
            this.scSidebarHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSidebarHorizontal.Panel2
            // 
            this.scSidebarHorizontal.Panel2.AutoScroll = true;
            this.scSidebarHorizontal.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scSidebarHorizontal.Size = new System.Drawing.Size(288, 460);
            this.scSidebarHorizontal.SplitterDistance = 96;
            this.scSidebarHorizontal.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scMenubar);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(784, 528);
            this.scMenubar.Panel1.ResumeLayout(false);
            this.scMenubar.Panel1.PerformLayout();
            this.scMenubar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMenubar)).EndInit();
            this.scMenubar.ResumeLayout(false);
            this.scSidebar.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSidebar)).EndInit();
            this.scSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scSidebarHorizontal)).EndInit();
            this.scSidebarHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMenubar;
        private System.Windows.Forms.SplitContainer scSidebar;
        private System.Windows.Forms.SplitContainer scSidebarHorizontal;
        private MaterialSkin.Controls.MaterialRaisedButton btnMyRoutes;
        private MaterialSkin.Controls.MaterialRaisedButton btnStartOver;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveRoute;
    }
}
