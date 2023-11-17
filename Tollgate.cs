using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BlueMarble
{
    public partial class Tollgate : Form
    {
        int idx; // 가지고있는 땅의 인덱스 위치
        public Tollgate()
        {
            InitializeComponent();
            LbTextSet();
            FreeCheck();
        }
        public void FreeCheck() // 우대권 소유 여부
        {
            btnFree.Enabled = false;
            if (MainBoard.player[MainBoard.diceTurn].freePasscard > 0) // 우대권 소유
                btnFree.Enabled = true;
            else // 우대권이 없을 때
                btnFree.Enabled = false;
        }
        public void LbTextSet() // 라벨 값 초기화
        {
            // 지역명 초기화
            lbAreaName.Text = MainBoard.areaInfo[MainBoard.areaIndex].areaName;
            // 지역 건물별 가격 초기화
            int diceTurn = 0;
            if (MainBoard.diceTurn == 1) diceTurn = 2;
            else diceTurn = 1;
            int nowMoney = 0;
            int tollgatePrice = 0;
            idx = MainBoard.player[diceTurn].areaIndex.IndexOf(MainBoard.areaIndex);
            if (MainBoard.player[diceTurn].buildName[idx] == "별장")
            {
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[0];
                tollgatePrice = MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[0];
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "빌딩")
            {
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[1];
                tollgatePrice = MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[1];
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "호텔")
            {
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[2];
                tollgatePrice = MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[2];
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "랜드마크")
            {
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[3];
                tollgatePrice = MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[3];
            }
            lbPayMoney.Text = string.Format("통행료 : {0:N0}원", tollgatePrice);
            lbNowMoney.Text = string.Format("지불후 금액 : {0:N0}원", nowMoney);
        }
        public void TollGatePay() // 지불가격
        {
            int diceTurn = 0;
            if (MainBoard.diceTurn == 1) diceTurn = 2;
            else diceTurn = 1;
            idx = MainBoard.player[diceTurn].areaIndex.IndexOf(MainBoard.areaIndex);
            if (MainBoard.player[diceTurn].buildName[idx] == "별장")
            {
                MainBoard.player[MainBoard.diceTurn].haveMoney -= MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[0];
                MainBoard.player[diceTurn].haveMoney += MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[0];
                this.Close();
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "빌딩")
            {
                MainBoard.player[MainBoard.diceTurn].haveMoney -= MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[1];
                MainBoard.player[diceTurn].haveMoney += MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[1];
                this.Close();
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "호텔")
            {
                MainBoard.player[MainBoard.diceTurn].haveMoney -= MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[2];
                MainBoard.player[diceTurn].haveMoney += MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[2];
                this.Close();
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "랜드마크")
            {
                MainBoard.player[MainBoard.diceTurn].haveMoney -= MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[3];
                MainBoard.player[diceTurn].haveMoney += MainBoard.areaInfo[MainBoard.areaIndex].tollgatePrice[3];
                this.Close();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            TollGatePay();
        }
        private void btnFree_Click(object sender, EventArgs e)
        {
            MainBoard.player[MainBoard.diceTurn].freePasscard--;

            MessageBox.Show("무료로 이용합니다.");
            this.Close();
        }
    }
}