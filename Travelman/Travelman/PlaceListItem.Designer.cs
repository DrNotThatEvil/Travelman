namespace Travelman
{
    partial class PlaceListItem
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
            this.lblName = new MaterialSkin.Controls.MaterialLabel();
            this.pbLocationIcon = new System.Windows.Forms.PictureBox();
            this.lblAddress = new MaterialSkin.Controls.MaterialLabel();
            this.pbLocationPicture = new System.Windows.Forms.PictureBox();
            this.lblNumOfReviews = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Depth = 0;
            this.lblName.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(41, 3);
            this.lblName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(148, 32);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Location name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLocationIcon
            // 
            this.pbLocationIcon.Location = new System.Drawing.Point(3, 3);
            this.pbLocationIcon.Name = "pbLocationIcon";
            this.pbLocationIcon.Size = new System.Drawing.Size(32, 32);
            this.pbLocationIcon.TabIndex = 1;
            this.pbLocationIcon.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Depth = 0;
            this.lblAddress.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddress.Location = new System.Drawing.Point(3, 38);
            this.lblAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(186, 23);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLocationPicture
            // 
            this.pbLocationPicture.Location = new System.Drawing.Point(195, 3);
            this.pbLocationPicture.Name = "pbLocationPicture";
            this.pbLocationPicture.Size = new System.Drawing.Size(90, 90);
            this.pbLocationPicture.TabIndex = 3;
            this.pbLocationPicture.TabStop = false;
            // 
            // lblNumOfReviews
            // 
            this.lblNumOfReviews.Depth = 0;
            this.lblNumOfReviews.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNumOfReviews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumOfReviews.Location = new System.Drawing.Point(101, 61);
            this.lblNumOfReviews.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNumOfReviews.Name = "lblNumOfReviews";
            this.lblNumOfReviews.Size = new System.Drawing.Size(88, 23);
            this.lblNumOfReviews.TabIndex = 4;
            this.lblNumOfReviews.Text = "(999+)";
            this.lblNumOfReviews.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlaceListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumOfReviews);
            this.Controls.Add(this.pbLocationPicture);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.pbLocationIcon);
            this.Controls.Add(this.lblName);
            this.Name = "PlaceListItem";
            this.Size = new System.Drawing.Size(288, 96);
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLocationPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblName;
        private System.Windows.Forms.PictureBox pbLocationIcon;
        private MaterialSkin.Controls.MaterialLabel lblAddress;
        private System.Windows.Forms.PictureBox pbLocationPicture;
        private MaterialSkin.Controls.MaterialLabel lblNumOfReviews;
    }
}
