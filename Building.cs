using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueMarble
{
    public partial class Building : Form
    {
        public Building()
        {
            InitializeComponent();
            BuildingInfoSet();
        }

        public void BuildingInfoSet() // 라디오 버튼 활성 or 비활성 처리 및 건물 별 가격 초기화
        {
            // 지역명 텍스트 초기화
            lbAreaName.Text = MainBoard.areaInfo[MainBoard.areaIndex].areaName;

            // 라디오 버튼 활성화
            rbVilla.Enabled = true;
            rbBuilding.Enabled = true;
            rbHotel.Enabled = true;
            rbRandmark.Enabled = true;

            int[] buildPrice = new int[4]; // 건물 별 가격 저장
            buildPrice[0] = MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[0];
            buildPrice[1] = MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[1];
            buildPrice[2] = MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[2];
            buildPrice[3] = MainBoard.areaInfo[MainBoard.areaIndex].buildPrice[3];

            // 라디오 버튼 텍스트 지역별 가격 초기화
            rbVilla.Text = string.Format("별장 : " + buildPrice[0]);
            rbBuilding.Text = string.Format("빌딩 : " + buildPrice[1]);
            rbHotel.Text = string.Format("호텔 : " + buildPrice[2]);
            rbRandmark.Text = string.Format("랜드마크 : " + buildPrice[3]);

            if (MainBoard.areaInfo[MainBoard.areaIndex].owner == 0) // 소유주가 없을 경우
            {
                rbRandmark.Enabled = false;
                // 관광지일 경우
                if (MainBoard.areaIndex == 6 || MainBoard.areaIndex == 11 || MainBoard.areaIndex == 21)
                {
                    rbVilla.Enabled = false;
                    rbBuilding.Enabled = false;
                    rbHotel.Enabled = false;
                    rbRandmark.Enabled = true;
                }
            }
            else // 소유주가 본인 일 경우
            {
                int index = MainBoard.player[MainBoard.diceTurn].areaIndex.IndexOf(MainBoard.areaIndex); // 해당 지역이 플레이어 areaIndex 리스트의 몇번 인덱스에 있는지
                string buildName = MainBoard.player[MainBoard.diceTurn].buildName[index];
                if (buildName == "별장")
                {
                    // 라디오 버튼 비활성화
                    rbVilla.Enabled = false;
                    rbRandmark.Enabled = false;

                    // 해당 건물 별 가격 초기화
                    rbVilla.Text = string.Format("별장 : " + 0);
                    rbBuilding.Text = string.Format("빌딩 : " + (buildPrice[1] - buildPrice[0]));
                    rbHotel.Text = string.Format("호텔 : " + (buildPrice[2] - buildPrice[0]));
                    rbRandmark.Text = string.Format("랜드마크 : " + (buildPrice[3] - buildPrice[0]));
                }
                else if (buildName == "빌딩")
                {
                    // 라디오 버튼 비활성화
                    rbVilla.Enabled = false;
                    rbBuilding.Enabled = false;
                    rbRandmark.Enabled = false;

                    // 해당 건물 별 가격 초기화
                    rbVilla.Text = string.Format("별장 : " + 0);
                    rbBuilding.Text = string.Format("빌딩 : " + 0);
                    rbHotel.Text = string.Format("호텔 : " + (buildPrice[2] - buildPrice[1]));
                    rbRandmark.Text = string.Format("랜드마크 : " + (buildPrice[3] - buildPrice[1]));
                }
                else if (buildName == "호텔")
                {
                    // 라디오 버튼 비활성화
                    rbVilla.Enabled = false;
                    rbBuilding.Enabled = false;
                    rbHotel.Enabled = false;

                    // 해당 건물 별 가격 초기화
                    rbVilla.Text = string.Format("별장 : " + 0);
                    rbBuilding.Text = string.Format("빌딩 : " + 0);
                    rbHotel.Text = string.Format("호텔 : " + 0);
                    rbRandmark.Text = string.Format("랜드마크 : " + (buildPrice[3] - buildPrice[2]));
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int[] buildArea = { 0, 0, 1, 2, 0, 3, 4, 5, 0, 6, 7, 8, 9, 10, 0, 11, 0, 12, 13, 0, 14, 15, 16, 17, 0, 18, 19, 0, 20, 0, 21, 22 };
            int buildIndex = buildArea[MainBoard.areaIndex]; // 건물 별 인덱스 위치

            int playerBuildIndex = MainBoard.player[MainBoard.diceTurn].areaIndex.IndexOf(MainBoard.areaIndex); // 해당 플레이어가 소유한 건물의 위치 areaIndex 배열 안의 인덱스 번호

            if (!rbVilla.Checked && !rbBuilding.Checked && !rbHotel.Checked && !rbRandmark.Checked) // 건물 하나도 선택 안했을 경우
            {
                MessageBox.Show("건물을 하나 선택해 주세요.");
                return;
            }
            if (rbVilla.Checked) // 빌라 선택시
            {
                string[] strTemp = rbVilla.Text.Split("별장 : ");
                int price = int.Parse(strTemp[1]);
                // 플레이어가 가진 금액이 사려는 건물 금액보다 작을 경우
                if (MainBoard.player[MainBoard.diceTurn].haveMoney < price)
                {
                    MessageBox.Show("금액이 부족합니다.");
                    return;
                }

                // player 정보에 구매 지역 전 리스트 값 제거
                if (MainBoard.player[MainBoard.diceTurn].areaIndex.Contains(MainBoard.areaIndex))
                {
                    MainBoard.player[MainBoard.diceTurn].areaIndex.RemoveAt(playerBuildIndex);
                    MainBoard.player[MainBoard.diceTurn].buildName.RemoveAt(playerBuildIndex);
                }

                // player 정보에 구매 지역 인덱스 번호, 건물 이름 저장
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("별장");

                // 건물 구매 시 player 보유 금액 빼기
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;

                // 건물 사진 넣기
                MainBoard.pbBuild[buildIndex].Image = pbBuild1.Image;
                MainBoard.pbBuild[buildIndex].Visible = true;
            }
            else if (rbBuilding.Checked) // 빌딩 선택시
            {
                string[] strTemp = rbBuilding.Text.Split("빌딩 : ");
                int price = int.Parse(strTemp[1]);
                // 플레이어가 가진 금액이 사려는 건물 금액보다 작을 경우
                if (MainBoard.player[MainBoard.diceTurn].haveMoney < price)
                {
                    MessageBox.Show("금액이 부족합니다.");
                    return;
                }

                // player 정보에 구매 지역 전 리스트 값 제거
                if (MainBoard.player[MainBoard.diceTurn].areaIndex.Contains(MainBoard.areaIndex))
                {
                    MainBoard.player[MainBoard.diceTurn].areaIndex.RemoveAt(playerBuildIndex);
                    MainBoard.player[MainBoard.diceTurn].buildName.RemoveAt(playerBuildIndex);
                }

                // player 정보에 구매 지역 인덱스 번호, 건물 이름 저장
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("빌딩");

                // 건물 구매 시 player 보유 금액 빼기
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;

                // 건물 사진 넣기
                MainBoard.pbBuild[buildIndex].Image = pbBuild2.Image;
                MainBoard.pbBuild[buildIndex].Visible = true;
            }
            else if (rbHotel.Checked) // 호텔 선택시
            {
                string[] strTemp = rbHotel.Text.Split("호텔 : ");
                int price = int.Parse(strTemp[1]);
                // 플레이어가 가진 금액이 사려는 건물 금액보다 작을 경우
                if (MainBoard.player[MainBoard.diceTurn].haveMoney < price)
                {
                    MessageBox.Show("금액이 부족합니다.");
                    return;
                }

                // player 정보에 구매 지역 전 리스트 값 제거
                if (MainBoard.player[MainBoard.diceTurn].areaIndex.Contains(MainBoard.areaIndex))
                {
                    MainBoard.player[MainBoard.diceTurn].areaIndex.RemoveAt(playerBuildIndex);
                    MainBoard.player[MainBoard.diceTurn].buildName.RemoveAt(playerBuildIndex);
                }

                // player 정보에 구매 지역 인덱스 번호, 건물 이름 저장
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("호텔");

                // 건물 구매 시 player 보유 금액 빼기
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;

                // 건물 사진 넣기
                MainBoard.pbBuild[buildIndex].Image = pbBuild3.Image;
                MainBoard.pbBuild[buildIndex].Visible = true;
            }
            else if (rbRandmark.Checked) // 랜드마크 선택시
            {
                string[] strTemp = rbRandmark.Text.Split("랜드마크 : ");
                int price = int.Parse(strTemp[1]);
                // 플레이어가 가진 금액이 사려는 건물 금액보다 작을 경우
                if (MainBoard.player[MainBoard.diceTurn].haveMoney < price)
                {
                    MessageBox.Show("금액이 부족합니다.");
                    return;
                }

                // player 정보에 구매 지역 전 리스트 값 제거
                if (MainBoard.player[MainBoard.diceTurn].areaIndex.Contains(MainBoard.areaIndex))
                {
                    MainBoard.player[MainBoard.diceTurn].areaIndex.RemoveAt(playerBuildIndex);
                    MainBoard.player[MainBoard.diceTurn].buildName.RemoveAt(playerBuildIndex);
                }

                // player 정보에 구매 지역 인덱스 번호, 건물 이름 저장
                MainBoard.player[MainBoard.diceTurn].areaIndex.Add(MainBoard.areaIndex);
                MainBoard.player[MainBoard.diceTurn].buildName.Add("랜드마크");

                // 건물 구매 시 player 보유 금액 빼기
                MainBoard.player[MainBoard.diceTurn].haveMoney -= price;

                // 건물 사진 넣기
                MainBoard.pbBuild[buildIndex].Image = pbBuild4.Image;
                MainBoard.pbBuild[buildIndex].Visible = true;
            }
            MainBoard.areaInfo[MainBoard.areaIndex].owner = MainBoard.diceTurn; // 소유주 변경
            MessageBox.Show("구매 완료.");
            this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
