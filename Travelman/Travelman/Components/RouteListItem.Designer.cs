namespace Travelman.Components
{
    partial class RouteListItem
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
            this.btnShowRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDeleteRoute = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pbRouteImage = new System.Windows.Forms.PictureBox();
            this.lblRouteName = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbRouteImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowRoute
            // 
            this.btnShowRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowRoute.AutoSize = true;
            this.btnShowRoute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowRoute.Depth = 0;
            this.btnShowRoute.Icon = null;
            this.btnShowRoute.Location = new System.Drawing.Point(8, 148);
            this.btnShowRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShowRoute.Name = "btnShowRoute";
            this.btnShowRoute.Primary = true;
            this.btnShowRoute.Size = new System.Drawing.Size(107, 36);
            this.btnShowRoute.TabIndex = 0;
            this.btnShowRoute.Text = "Show route";
            this.btnShowRoute.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteRoute.AutoSize = true;
            this.btnDeleteRoute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteRoute.Depth = 0;
            this.btnDeleteRoute.Icon = null;
            this.btnDeleteRoute.Location = new System.Drawing.Point(121, 148);
            this.btnDeleteRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Primary = true;
            this.btnDeleteRoute.Size = new System.Drawing.Size(115, 36);
            this.btnDeleteRoute.TabIndex = 1;
            this.btnDeleteRoute.Text = "Delete route";
            this.btnDeleteRoute.UseVisualStyleBackColor = true;
            // 
            // pbRouteImage
            // 
            this.pbRouteImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRouteImage.Location = new System.Drawing.Point(8, 8);
            this.pbRouteImage.Name = "pbRouteImage";
            this.pbRouteImage.Size = new System.Drawing.Size(240, 92);
            this.pbRouteImage.TabIndex = 2;
            this.pbRouteImage.TabStop = false;
            // 
            // lblRouteName
            // 
            this.lblRouteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Depth = 0;
            this.lblRouteName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRouteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRouteName.Location = new System.Drawing.Point(4, 114);
            this.lblRouteName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(89, 19);
            this.lblRouteName.TabIndex = 3;
            this.lblRouteName.Text = "Route name";
            // 
            // RouteListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.pbRouteImage);
            this.Controls.Add(this.btnDeleteRoute);
            this.Controls.Add(this.btnShowRoute);
            this.Name = "RouteListItem";
            this.Size = new System.Drawing.Size(256, 192);
            ((System.ComponentModel.ISupportInitialize)(this.pbRouteImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnShowRoute;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteRoute;
        private System.Windows.Forms.PictureBox pbRouteImage;
        private MaterialSkin.Controls.MaterialLabel lblRouteName;
    }
}
