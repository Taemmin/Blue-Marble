namespace BlueMarble
{
    partial class BuildSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildSale));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            listView1 = new System.Windows.Forms.ListView();
            chCityName = new System.Windows.Forms.ColumnHeader();
            chBuildName = new System.Windows.Forms.ColumnHeader();
            chSalePrice = new System.Windows.Forms.ColumnHeader();
            listView2 = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            btnSelect = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lbNowMoney = new System.Windows.Forms.Label();
            lbPayMoney = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            btnSurrender = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(26, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(390, 60);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chCityName, chBuildName, chSalePrice });
            listView1.Location = new System.Drawing.Point(26, 114);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(354, 184);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // chCityName
            // 
            chCityName.Text = "지역이름";
            chCityName.Width = 150;
            // 
            // chBuildName
            // 
            chBuildName.Text = "건물이름";
            chBuildName.Width = 90;
            // 
            // chSalePrice
            // 
            chSalePrice.Text = "매각금액";
            chSalePrice.Width = 110;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView2.Location = new System.Drawing.Point(26, 304);
            listView2.Name = "listView2";
            listView2.Size = new System.Drawing.Size(354, 184);
            listView2.TabIndex = 2;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "지역이름";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "건물이름";
            columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "매각금액";
            columnHeader3.Width = 110;
            // 
            // btnSelect
            // 
            btnSelect.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSelect.Location = new System.Drawing.Point(397, 114);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(144, 55);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "매각 선택";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCancel.Location = new System.Drawing.Point(397, 304);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(144, 55);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "선택 취소";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbNowMoney
            // 
            lbNowMoney.AutoSize = true;
            lbNowMoney.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbNowMoney.Location = new System.Drawing.Point(26, 544);
            lbNowMoney.Name = "lbNowMoney";
            lbNowMoney.Size = new System.Drawing.Size(150, 21);
            lbNowMoney.TabIndex = 5;
            lbNowMoney.Text = "보유 금액 : 100000";
            // 
            // lbPayMoney
            // 
            lbPayMoney.AutoSize = true;
            lbPayMoney.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbPayMoney.Location = new System.Drawing.Point(26, 511);
            lbPayMoney.Name = "lbPayMoney";
            lbPayMoney.Size = new System.Drawing.Size(150, 21);
            lbPayMoney.TabIndex = 6;
            lbPayMoney.Text = "매각 금액 : 100000";
            // 
            // btnOK
            // 
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.Location = new System.Drawing.Point(26, 587);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(250, 55);
            btnOK.TabIndex = 7;
            btnOK.Text = "매각";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnSurrender
            // 
            btnSurrender.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSurrender.Location = new System.Drawing.Point(291, 587);
            btnSurrender.Name = "btnSurrender";
            btnSurrender.Size = new System.Drawing.Size(250, 55);
            btnSurrender.TabIndex = 8;
            btnSurrender.Text = "항 복";
            btnSurrender.UseVisualStyleBackColor = true;
            btnSurrender.Click += btnSurrender_Click;
            // 
            // BuildSale
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(581, 654);
            Controls.Add(btnSurrender);
            Controls.Add(btnOK);
            Controls.Add(lbPayMoney);
            Controls.Add(lbNowMoney);
            Controls.Add(btnCancel);
            Controls.Add(btnSelect);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(pictureBox1);
            Name = "BuildSale";
            Text = "건물 매각";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chCityName;
        private System.Windows.Forms.ColumnHeader chBuildName;
        private System.Windows.Forms.ColumnHeader chSalePrice;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNowMoney;
        private System.Windows.Forms.Label lbPayMoney;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSurrender;
    }
}