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
            this.lblFrom = new MaterialSkin.Controls.MaterialLabel();
            this.lblTo = new MaterialSkin.Controls.MaterialLabel();
            this.lblFromValue = new MaterialSkin.Controls.MaterialLabel();
            this.lblToValue = new MaterialSkin.Controls.MaterialLabel();
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
            this.btnShowRoute.Location = new System.Drawing.Point(8, 116);
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
            this.btnDeleteRoute.Location = new System.Drawing.Point(121, 116);
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
            this.pbRouteImage.Location = new System.Drawing.Point(248, 8);
            this.pbRouteImage.Name = "pbRouteImage";
            this.pbRouteImage.Size = new System.Drawing.Size(256, 144);
            this.pbRouteImage.TabIndex = 2;
            this.pbRouteImage.TabStop = false;
            // 
            // lblRouteName
            // 
            this.lblRouteName.AutoSize = true;
            this.lblRouteName.Depth = 0;
            this.lblRouteName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRouteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRouteName.Location = new System.Drawing.Point(4, 8);
            this.lblRouteName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRouteName.Name = "lblRouteName";
            this.lblRouteName.Size = new System.Drawing.Size(89, 19);
            this.lblRouteName.TabIndex = 3;
            this.lblRouteName.Text = "Route name";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Depth = 0;
            this.lblFrom.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFrom.Location = new System.Drawing.Point(4, 36);
            this.lblFrom.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(48, 19);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Depth = 0;
            this.lblTo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTo.Location = new System.Drawing.Point(4, 64);
            this.lblTo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 19);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To:";
            // 
            // lblFromValue
            // 
            this.lblFromValue.AutoSize = true;
            this.lblFromValue.Depth = 0;
            this.lblFromValue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblFromValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFromValue.Location = new System.Drawing.Point(58, 36);
            this.lblFromValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFromValue.Name = "lblFromValue";
            this.lblFromValue.Size = new System.Drawing.Size(41, 19);
            this.lblFromValue.TabIndex = 6;
            this.lblFromValue.Text = "Start";
            // 
            // lblToValue
            // 
            this.lblToValue.AutoSize = true;
            this.lblToValue.Depth = 0;
            this.lblToValue.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblToValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblToValue.Location = new System.Drawing.Point(58, 64);
            this.lblToValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblToValue.Name = "lblToValue";
            this.lblToValue.Size = new System.Drawing.Size(86, 19);
            this.lblToValue.TabIndex = 7;
            this.lblToValue.Text = "Destination";
            // 
            // RouteListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblToValue);
            this.Controls.Add(this.lblFromValue);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblRouteName);
            this.Controls.Add(this.pbRouteImage);
            this.Controls.Add(this.btnDeleteRoute);
            this.Controls.Add(this.btnShowRoute);
            this.Name = "RouteListItem";
            this.Size = new System.Drawing.Size(508, 160);
            ((System.ComponentModel.ISupportInitialize)(this.pbRouteImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnShowRoute;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeleteRoute;
        private System.Windows.Forms.PictureBox pbRouteImage;
        private MaterialSkin.Controls.MaterialLabel lblRouteName;
        private MaterialSkin.Controls.MaterialLabel lblFrom;
        private MaterialSkin.Controls.MaterialLabel lblTo;
        private MaterialSkin.Controls.MaterialLabel lblFromValue;
        private MaterialSkin.Controls.MaterialLabel lblToValue;
    }
}
