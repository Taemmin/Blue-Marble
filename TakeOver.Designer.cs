namespace BlueMarble
{
    partial class TakeOver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakeOver));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lbAreaName = new System.Windows.Forms.Label();
            lbPayMoney = new System.Windows.Forms.Label();
            btnOK = new System.Windows.Forms.Button();
            btnCancle = new System.Windows.Forms.Button();
            lbNowMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(8, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(404, 59);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbAreaName
            // 
            lbAreaName.AutoSize = true;
            lbAreaName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbAreaName.Location = new System.Drawing.Point(74, 107);
            lbAreaName.Name = "lbAreaName";
            lbAreaName.Size = new System.Drawing.Size(197, 30);
            lbAreaName.TabIndex = 1;
            lbAreaName.Text = "지역명 인수할까요?";
            // 
            // lbPayMoney
            // 
            lbPayMoney.AutoSize = true;
            lbPayMoney.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbPayMoney.ForeColor = System.Drawing.Color.Red;
            lbPayMoney.Location = new System.Drawing.Point(90, 145);
            lbPayMoney.Name = "lbPayMoney";
            lbPayMoney.Size = new System.Drawing.Size(216, 32);
            lbPayMoney.TabIndex = 2;
            lbPayMoney.Text = "인수비용 => 9000";
            // 
            // btnOK
            // 
            btnOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnOK.Location = new System.Drawing.Point(10, 208);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(169, 58);
            btnOK.TabIndex = 3;
            btnOK.Text = "확인";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancle
            // 
            btnCancle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCancle.Location = new System.Drawing.Point(227, 208);
            btnCancle.Name = "btnCancle";
            btnCancle.Size = new System.Drawing.Size(169, 58);
            btnCancle.TabIndex = 4;
            btnCancle.Text = "취소";
            btnCancle.UseVisualStyleBackColor = true;
            btnCancle.Click += btnCancle_Click;
            // 
            // lbNowMoney
            // 
            lbNowMoney.AutoSize = true;
            lbNowMoney.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbNowMoney.Location = new System.Drawing.Point(70, 288);
            lbNowMoney.Name = "lbNowMoney";
            lbNowMoney.Size = new System.Drawing.Size(252, 25);
            lbNowMoney.TabIndex = 5;
            lbNowMoney.Text = "인수 후 남은 금액 => 3000";
            // 
            // TakeOver
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(422, 333);
            Controls.Add(lbNowMoney);
            Controls.Add(btnCancle);
            Controls.Add(btnOK);
            Controls.Add(lbPayMoney);
            Controls.Add(lbAreaName);
            Controls.Add(pictureBox1);
            Name = "TakeOver";
            Text = "도시 인수";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbAreaName;
        private System.Windows.Forms.Label lbPayMoney;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lbNowMoney;
    }
}