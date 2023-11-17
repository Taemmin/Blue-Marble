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
    public partial class TakeOver : Form
    {
        private int idx; // 가지고있는 땅의 인덱스 위치
        public TakeOver()
        {
            InitializeComponent();
            LbTextSet();
        }
        public void LbTextSet()
        {
            lbAreaName.Text = ($"{MainBoard.areaInfo[MainBoard.areaIndex].areaName} 인수 하시겠습니까?");
            int diceTurn = 0;
            if (MainBoard.diceTurn == 1) diceTurn = 2;
            else diceTurn = 1;

            int nowMoney = 0;
            int buildPrice = 0;

            idx = MainBoard.player[diceTurn].areaIndex.IndexOf(MainBoard.areaIndex);
            if (MainBoard.player[diceTurn].buildName[idx] == "별장")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[0] * 1.5);
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - price;
                buildPrice = price;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "빌딩")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[1] * 1.5);
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - price;
                buildPrice = price;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "호텔")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[2] * 1.5);
                nowMoney = MainBoard.player[MainBoard.diceTurn].haveMoney - price;
                buildPrice = price;
            }
            lbPayMoney.Text = string.Format("인수비용 : {0:N0}원", buildPrice);
            lbNowMoney.Text = string.Format("인수후 금액 : {0:N0}원", nowMoney);
        }
        public void TakeOverPay() // 지불가격
        {
            int diceTurn = 0;
            if (MainBoard.diceTurn == 1) diceTurn = 2;
            else diceTurn = 1;

            idx = MainBoard.player[diceTurn].areaIndex.IndexOf(MainBoard.areaIndex);
            if (MainBoard.player[diceTurn].buildName[idx] == "별장")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[0] * 1.5);
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;
                MainBoard.player[diceTurn].haveMoney += price;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "빌딩")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[1] * 1.5);
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;
                MainBoard.player[diceTurn].haveMoney += price;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "호텔")
            {
                int price = (int)(MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[2] * 1.5);
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;
                MainBoard.player[diceTurn].haveMoney += price;
            }
        }
        public void TakeOverBuilding()
        {
            int diceTurn = 0;
            if (MainBoard.diceTurn == 1) diceTurn = 2;
            else diceTurn = 1;
            idx = MainBoard.player[diceTurn].areaIndex.IndexOf(MainBoard.areaIndex);
            if (MainBoard.player[diceTurn].buildName[idx] == "별장")
            {
                MainBoard.player[diceTurn].areaIndex.RemoveAt(idx);
                MainBoard.player[diceTurn].buildName.RemoveAt(idx);
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("별장");
                MainBoard.areaInfo[MainBoard.areaIndex].owner = MainBoard.diceTurn;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "빌딩")
            {
                MainBoard.player[diceTurn].areaIndex.RemoveAt(idx);
                MainBoard.player[diceTurn].buildName.RemoveAt(idx);
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("빌딩");
                MainBoard.areaInfo[MainBoard.areaIndex].owner = MainBoard.diceTurn;
            }
            else if (MainBoard.player[diceTurn].buildName[idx] == "호텔")
            {
                MainBoard.player[diceTurn].areaIndex.RemoveAt(idx);
                MainBoard.player[diceTurn].buildName.RemoveAt(idx);
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("호텔");
                MainBoard.areaInfo[MainBoard.areaIndex].owner = MainBoard.diceTurn;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            TakeOverPay();
            TakeOverBuilding();
            MessageBox.Show("인수 완료!!");
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}