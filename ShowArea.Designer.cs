namespace BlueMarble
{
    partial class ShowArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowArea));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            listView1 = new System.Windows.Forms.ListView();
            chCityName = new System.Windows.Forms.ColumnHeader();
            chBuildName = new System.Windows.Forms.ColumnHeader();
            lbFreePassCard = new System.Windows.Forms.Label();
            lbFreeUnisland = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(26, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(305, 61);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chCityName, chBuildName });
            listView1.Location = new System.Drawing.Point(26, 93);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(305, 308);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // chCityName
            // 
            chCityName.Text = "지역 이름";
            chCityName.Width = 150;
            // 
            // chBuildName
            // 
            chBuildName.Text = "건물 이름";
            chBuildName.Width = 150;
            // 
            // lbFreePassCard
            // 
            lbFreePassCard.AutoSize = true;
            lbFreePassCard.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbFreePassCard.Location = new System.Drawing.Point(26, 413);
            lbFreePassCard.Name = "lbFreePassCard";
            lbFreePassCard.Size = new System.Drawing.Size(177, 30);
            lbFreePassCard.TabIndex = 2;
            lbFreePassCard.Text = "우대권 개수 : 0개";
            // 
            // lbFreeUnisland
            // 
            lbFreeUnisland.AutoSize = true;
            lbFreeUnisland.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbFreeUnisland.Location = new System.Drawing.Point(26, 453);
            lbFreeUnisland.Name = "lbFreeUnisland";
            lbFreeUnisland.Size = new System.Drawing.Size(247, 30);
            lbFreeUnisland.TabIndex = 3;
            lbFreeUnisland.Text = "무인도 탈출권 개수 : 0개";
            // 
            // btnOK
            // 
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.Location = new System.Drawing.Point(26, 498);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(305, 45);
            btnOK.TabIndex = 4;
            btnOK.Text = "확 인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // ShowArea
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(356, 557);
            Controls.Add(btnOK);
            Controls.Add(lbFreeUnisland);
            Controls.Add(lbFreePassCard);
            Controls.Add(listView1);
            Controls.Add(pictureBox1);
            Name = "ShowArea";
            Text = "보유 현황";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chCityName;
        private System.Windows.Forms.ColumnHeader chBuildName;
        private System.Windows.Forms.Label lbFreePassCard;
        private System.Windows.Forms.Label lbFreeUnisland;
        private System.Windows.Forms.Button btnOK;
    }
}