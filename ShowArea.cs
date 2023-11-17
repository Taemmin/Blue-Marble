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
    public partial class ShowArea : Form
    {
        public ShowArea()
        {
            InitializeComponent();
            ListViewSet();
        }

        public void ListViewSet() // ListView1에 보유한 지역 정보 입력
        {
            for (int i = 0; i < MainBoard.player[MainBoard.showAreaTurn].areaIndex.Count; i++)
            {
                int areaIndex = MainBoard.player[MainBoard.showAreaTurn].areaIndex[i]; // 해당 지역의 인덱스 번호
                string buildName = MainBoard.player[MainBoard.showAreaTurn].buildName[i]; // 건물 상태 ( 별장, 빌딩, 호텔, 랜드마크 )
                string areaName = MainBoard.areaInfo[areaIndex].areaName; // 해당 지역의 이름
                // 건물 상태에 따른 가격
                int buildPrice = 0;
                switch (buildName)
                {
                    case "별장":
                        buildPrice = MainBoard.areaInfo[areaIndex].buildSell[0];
                        break;
                    case "빌딩":
                        buildPrice = MainBoard.areaInfo[areaIndex].buildSell[1];
                        break;
                    case "호텔":
                        buildPrice = MainBoard.areaInfo[areaIndex].buildSell[2];
                        break;
                    case "랜드마크":
                        buildPrice = MainBoard.areaInfo[areaIndex].buildSell[3];
                        break;
                }
                listView1.Items.Add(new ListViewItem(new string[] { areaName, buildName, buildPrice.ToString() }));
            }
            // 보유 카드 라벨로 보여주기
            lbFreePassCard.Text = string.Format("우대권 개수 : " + MainBoard.player[MainBoard.showAreaTurn].freePasscard + "개");
            lbFreeUnisland.Text = string.Format("무인도 탈출권 개수 : " + MainBoard.player[MainBoard.showAreaTurn].freeUnisland + "개");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
