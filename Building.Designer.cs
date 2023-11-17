namespace BlueMarble
{
    partial class Building
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Building));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pbBuild1 = new System.Windows.Forms.PictureBox();
            pbBuild2 = new System.Windows.Forms.PictureBox();
            pbBuild3 = new System.Windows.Forms.PictureBox();
            pbBuild4 = new System.Windows.Forms.PictureBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            rbRandmark = new System.Windows.Forms.RadioButton();
            rbHotel = new System.Windows.Forms.RadioButton();
            rbBuilding = new System.Windows.Forms.RadioButton();
            rbVilla = new System.Windows.Forms.RadioButton();
            btnOK = new System.Windows.Forms.Button();
            btnCancle = new System.Windows.Forms.Button();
            lbAreaName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild4).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(40, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(362, 65);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pbBuild1
            // 
            pbBuild1.Image = (System.Drawing.Image)resources.GetObject("pbBuild1.Image");
            pbBuild1.Location = new System.Drawing.Point(40, 166);
            pbBuild1.Name = "pbBuild1";
            pbBuild1.Size = new System.Drawing.Size(70, 70);
            pbBuild1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbBuild1.TabIndex = 2;
            pbBuild1.TabStop = false;
            // 
            // pbBuild2
            // 
            pbBuild2.Image = (System.Drawing.Image)resources.GetObject("pbBuild2.Image");
            pbBuild2.Location = new System.Drawing.Point(134, 166);
            pbBuild2.Name = "pbBuild2";
            pbBuild2.Size = new System.Drawing.Size(70, 70);
            pbBuild2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbBuild2.TabIndex = 3;
            pbBuild2.TabStop = false;
            // 
            // pbBuild3
            // 
            pbBuild3.Image = (System.Drawing.Image)resources.GetObject("pbBuild3.Image");
            pbBuild3.Location = new System.Drawing.Point(233, 166);
            pbBuild3.Name = "pbBuild3";
            pbBuild3.Size = new System.Drawing.Size(70, 70);
            pbBuild3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbBuild3.TabIndex = 4;
            pbBuild3.TabStop = false;
            // 
            // pbBuild4
            // 
            pbBuild4.Image = (System.Drawing.Image)resources.GetObject("pbBuild4.Image");
            pbBuild4.Location = new System.Drawing.Point(332, 166);
            pbBuild4.Name = "pbBuild4";
            pbBuild4.Size = new System.Drawing.Size(70, 70);
            pbBuild4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbBuild4.TabIndex = 5;
            pbBuild4.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbRandmark);
            groupBox1.Controls.Add(rbHotel);
            groupBox1.Controls.Add(rbBuilding);
            groupBox1.Controls.Add(rbVilla);
            groupBox1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(40, 253);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(362, 188);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "건설 비용";
            // 
            // rbRandmark
            // 
            rbRandmark.AutoSize = true;
            rbRandmark.Location = new System.Drawing.Point(192, 119);
            rbRandmark.Name = "rbRandmark";
            rbRandmark.Size = new System.Drawing.Size(137, 24);
            rbRandmark.TabIndex = 3;
            rbRandmark.Text = "랜드마크 : 9000";
            rbRandmark.UseVisualStyleBackColor = true;
            // 
            // rbHotel
            // 
            rbHotel.AutoSize = true;
            rbHotel.Location = new System.Drawing.Point(21, 119);
            rbHotel.Name = "rbHotel";
            rbHotel.Size = new System.Drawing.Size(107, 24);
            rbHotel.TabIndex = 2;
            rbHotel.Text = "호텔 : 9000";
            rbHotel.UseVisualStyleBackColor = true;
            // 
            // rbBuilding
            // 
            rbBuilding.AutoSize = true;
            rbBuilding.Location = new System.Drawing.Point(192, 58);
            rbBuilding.Name = "rbBuilding";
            rbBuilding.Size = new System.Drawing.Size(107, 24);
            rbBuilding.TabIndex = 1;
            rbBuilding.Text = "빌딩 : 9000";
            rbBuilding.UseVisualStyleBackColor = true;
            // 
            // rbVilla
            // 
            rbVilla.AutoSize = true;
            rbVilla.Location = new System.Drawing.Point(21, 58);
            rbVilla.Name = "rbVilla";
            rbVilla.Size = new System.Drawing.Size(107, 24);
            rbVilla.TabIndex = 0;
            rbVilla.Text = "별장 : 9000";
            rbVilla.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.Location = new System.Drawing.Point(40, 458);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(164, 58);
            btnOK.TabIndex = 7;
            btnOK.Text = "확인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancle
            // 
            btnCancle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCancle.Location = new System.Drawing.Point(238, 458);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new System.Drawing.Size(164, 58);
            btnCancle.TabIndex = 8;
            btnCancle.Text = "취소";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // lbAreaName
            // 
            lbAreaName.AutoSize = true;
            lbAreaName.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbAreaName.Location = new System.Drawing.Point(147, 103);
            lbAreaName.Name = "lbAreaName";
            lbAreaName.Size = new System.Drawing.Size(116, 45);
            lbAreaName.TabIndex = 9;
            lbAreaName.Text = "지역명";
            // 
            // Building
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 538);
            Controls.Add(lbAreaName);
            Controls.Add(btnCancle);
            Controls.Add(btnOK);
            Controls.Add(groupBox1);
            Controls.Add(pbBuild4);
            Controls.Add(pbBuild3);
            Controls.Add(pbBuild2);
            Controls.Add(pbBuild1);
            Controls.Add(pictureBox1);
            Name = "Building";
            Text = "건물 구매";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBuild4).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbBuild1;
        private System.Windows.Forms.PictureBox pbBuild2;
        private System.Windows.Forms.PictureBox pbBuild3;
        private System.Windows.Forms.PictureBox pbBuild4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRandmark;
        private System.Windows.Forms.RadioButton rbHotel;
        private System.Windows.Forms.RadioButton rbBuilding;
        private System.Windows.Forms.RadioButton rbVilla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lbAreaName;
    }
}