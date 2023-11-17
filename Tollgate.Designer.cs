namespace BlueMarble
{
    partial class Tollgate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tollgate));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lbAreaName = new System.Windows.Forms.Label();
            lbPayMoney = new System.Windows.Forms.Label();
            lbNowMoney = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            btnFree = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(27, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(363, 48);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbAreaName
            // 
            lbAreaName.AutoSize = true;
            lbAreaName.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbAreaName.Location = new System.Drawing.Point(21, 94);
            lbAreaName.Name = "lbAreaName";
            lbAreaName.Size = new System.Drawing.Size(116, 45);
            lbAreaName.TabIndex = 1;
            lbAreaName.Text = "지역명";
            // 
            // lbPayMoney
            // 
            lbPayMoney.AutoSize = true;
            lbPayMoney.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbPayMoney.ForeColor = System.Drawing.Color.Red;
            lbPayMoney.Location = new System.Drawing.Point(21, 163);
            lbPayMoney.Name = "lbPayMoney";
            lbPayMoney.Size = new System.Drawing.Size(143, 25);
            lbPayMoney.TabIndex = 2;
            lbPayMoney.Text = "통행료 : 50000";
            // 
            // lbNowMoney
            // 
            lbNowMoney.AutoSize = true;
            lbNowMoney.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbNowMoney.Location = new System.Drawing.Point(21, 216);
            lbNowMoney.Name = "lbNowMoney";
            lbNowMoney.Size = new System.Drawing.Size(223, 30);
            lbNowMoney.TabIndex = 3;
            lbNowMoney.Text = "지불 후 금액 : 353000";
            // 
            // btnOK
            // 
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.Location = new System.Drawing.Point(294, 185);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(111, 61);
            btnOK.TabIndex = 4;
            btnOK.Text = "확인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnFree
            // 
            btnFree.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnFree.Location = new System.Drawing.Point(294, 108);
            btnFree.Name = "btnFree";
            btnFree.Size = new System.Drawing.Size(111, 61);
            btnFree.TabIndex = 5;
            btnFree.Text = "우대권";
            btnFree.UseVisualStyleBackColor = true;
            btnFree.Click += btnFree_Click;
            // 
            // Tollgate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(417, 267);
            Controls.Add(btnFree);
            Controls.Add(btnOK);
            Controls.Add(lbNowMoney);
            Controls.Add(lbPayMoney);
            Controls.Add(lbAreaName);
            Controls.Add(pictureBox1);
            Name = "Tollgate";
            Text = "통행료";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbAreaName;
        private System.Windows.Forms.Label lbPayMoney;
        private System.Windows.Forms.Label lbNowMoney;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFree;
    }
}