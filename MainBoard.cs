using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.Xml;
using System.Drawing.Printing;

namespace BlueMarble
{

    public struct AreaInfo // 지역 별 정보
    {
        public string areaName; // 지역 이름
        public int[] buildPrice; // 건물 별 가격 ( 빌라, 빌딩, 호텔, 랜드마크 )
        public int[] tollgatePrice; // 통행료 가격 ( 빌라, 빌딩, 호텔, 랜드마크 )
        public int[] buildSell; // 매도 가격 ( 빌라, 빌딩, 호텔, 랜드마크 )
        public int fundMoney; // 사회복지기금 모금액
        public int owner; // 소유주 player( 0 = 무, 1 = player1 , 2 = player2 )

        public AreaInfo(string areaName, int[] buildPrice, int[] tollgatePrice, int[] buildSell, int fundMoney, int owner)
        {
            this.areaName = areaName;
            this.buildPrice = buildPrice;
            this.tollgatePrice = tollgatePrice;
            this.buildSell = buildSell;
            this.fundMoney = fundMoney;
            this.owner = owner;

        }
    }

    public struct GoldKey // 황금 열쇠 정보
    {
        public string cardName; // 황금카드 이름
        public string cardExplain; // 황금카드 설명
    }

    public struct PlayerInfo // 플레이어 정보
    {
        public int haveMoney; // 보유 금액
        public int location; // 플레이어 위치
        public int unislandCnt; // 무인도 여부(0 ~ 3)
        public int freePasscard; // 우대권 개수
        public int freeUnisland; // 무인도 탈출권 개수
        public int worldTourCnt; // 세계여행 여부
        public List<int> areaIndex; // 소유한 지역 인덱스 번호
        public List<string> buildName; // 소유한 지역 건물 이름
    }

    public partial class MainBoard : Form
    {

        private PictureBox[] pbArea = new PictureBox[32]; // 지역 사진
        public static PictureBox[] pbBuild = new PictureBox[23]; // 지역별 건물 사진
        private PictureBox[] pbPlayer1 = new PictureBox[32]; // 플레이어1 위치
        private PictureBox[] pbPlayer2 = new PictureBox[32]; // 플레이어2 위치
        private int[,] buildLocation = { { 25, 0 }, { 0, 25 }, { 25, 90 }, { 80, 25 } }; // 건물 놓을 위치
        private int[,] playerLocation1 = { { 12, 70 }, { 60, 55 }, { 55, 10 }, { 10, 12 } }; // 건물 놓을 위치
        private int[,] playerLocation2 = { { 55, 70 }, { 60, 12 }, { 12, 10 }, { 10, 55 } }; // 건물 놓을 위치

        public static AreaInfo[] areaInfo = new AreaInfo[32]; // 지역에 대한 정보
        public GoldKey[] goldKey = new GoldKey[8]; // 황금 열쇠 정보

        public static PlayerInfo[] player = new PlayerInfo[3]; // 플레이어1 , 플레이어2 ( 0번 인덱스는 사용하지 않음 ) 

        public static int areaIndex = 0; // 해당 플레이어의 어떤 지역의 위치인지
        public static int diceTurn = 1; // 1: 플레이어1 , 2: 플레이어2
        public int diceSum = 0; // 주사위 2개의 합
        public int doubleNum = 0; // 더블 횟수

        public int playerLastLocation; // 플레이어 최종 위치
        public int playerNowLocation; // 플레이어 현재 위치

        public int diceRoll1 = 0; // 주사위 1
        public int diceRoll2 = 0; // 주사위 2
        public int goldKeyIndex = 0; // 황금열쇠 번호
        public int cnt = 0; // 주사위 숫자 초기화
        public int payFundCoin = 0; // 사회복지기금 코인 누적
        public static int showAreaTurn = 0; // 보유 현황 확인 플레이어 번호

        public MainBoard()
        {
            InitializeComponent();
            PbSet();
            BuildLocationSet();
            AreaInfoSet();
            GoldKeySet();
            timer1.Start();
        }

        public void PbSet() // 픽처박스 배열 초기화, 플레이어 초기화
        {
            // 플레이어 초기화
            player[1].haveMoney = 5000000;
            player[1].areaIndex = new List<int>();
            player[1].buildName = new List<string>();

            player[2].haveMoney = 5000000;
            player[2].areaIndex = new List<int>();
            player[2].buildName = new List<string>();

            lbPlayer1.Text = string.Format("Player1 : {0:N0}원", player[1].haveMoney);
            lbPlayer2.Text = string.Format("Player2 : {0:N0}원", player[2].haveMoney);

            // pbArea 배열 초기화
            pbArea = new PictureBox[32]    {pbArea0, pbArea1, pbArea2, pbArea3, pbArea4, pbArea5, pbArea6, pbArea7, pbArea8, pbArea9, pbArea10,
                                            pbArea11, pbArea12, pbArea13, pbArea14, pbArea15, pbArea16, pbArea17, pbArea18, pbArea19, pbArea20,
                                            pbArea21, pbArea22, pbArea23, pbArea24, pbArea25, pbArea26, pbArea27, pbArea28, pbArea29, pbArea30, pbArea31};
            // pbPlayer1 배열 초기화
            pbPlayer1 = new PictureBox[32] {pbPlayer1_0, pbPlayer1_1, pbPlayer1_2, pbPlayer1_3, pbPlayer1_4, pbPlayer1_5, pbPlayer1_6, pbPlayer1_7, pbPlayer1_8, pbPlayer1_9, pbPlayer1_10,
                                            pbPlayer1_11, pbPlayer1_12, pbPlayer1_13, pbPlayer1_14, pbPlayer1_15, pbPlayer1_16, pbPlayer1_17, pbPlayer1_18, pbPlayer1_19, pbPlayer1_20,
                                            pbPlayer1_21, pbPlayer1_22, pbPlayer1_23, pbPlayer1_24, pbPlayer1_25, pbPlayer1_26, pbPlayer1_27, pbPlayer1_28, pbPlayer1_29, pbPlayer1_30, pbPlayer1_31};

            //pbPlayer2 배열 초기화
            pbPlayer2 = new PictureBox[32]  {pbPlayer2_0, pbPlayer2_1, pbPlayer2_2, pbPlayer2_3, pbPlayer2_4, pbPlayer2_5, pbPlayer2_6, pbPlayer2_7, pbPlayer2_8, pbPlayer2_9, pbPlayer2_10,
                                             pbPlayer2_11, pbPlayer2_12, pbPlayer2_13, pbPlayer2_14, pbPlayer2_15, pbPlayer2_16, pbPlayer2_17, pbPlayer2_18, pbPlayer2_19, pbPlayer2_20,
                                             pbPlayer2_21, pbPlayer2_22, pbPlayer2_23, pbPlayer2_24, pbPlayer2_25, pbPlayer2_26, pbPlayer2_27, pbPlayer2_28, pbPlayer2_29, pbPlayer2_30, pbPlayer2_31};
            // pbBuild 배열 초기화
            pbBuild = new PictureBox[23]    {pbBuild0, pbBuild1, pbBuild2, pbBuild3, pbBuild4, pbBuild5, pbBuild6, pbBuild7, pbBuild8, pbBuild9, pbBuild10,
                                             pbBuild11, pbBuild12, pbBuild13, pbBuild14, pbBuild15, pbBuild16, pbBuild17, pbBuild18, pbBuild19, pbBuild20, pbBuild21, pbBuild22};
            // 플레이어 초기 위치 초기화
            pbPlayer1[0].Visible = true;
            pbPlayer2[0].Visible = true;
        }

        public void BuildLocationSet() // 픽처박스 사진 뒷 배경 제거
        {
            int pbBuildIndex = 0;
            for (int i = 0; i < pbArea.Length; i++)
            {
                if (i == 0 || i == 4 || i == 8 || i == 14 || i == 16 || i == 19 || i == 24 || i == 27 || i == 29)
                    continue;
                int Point = pbBuildIndex / 6;
                int x = buildLocation[Point, 0];
                int y = buildLocation[Point, 1];
                pbArea[i].Controls.Add(pbBuild[pbBuildIndex]);
                pbBuild[pbBuildIndex].Location = new Point(x, y);
                pbBuild[pbBuildIndex].BackColor = Color.Transparent;

                pbBuildIndex++;
            }
            int playerIndex = 0;
            for (int i = 0; i < pbPlayer1.Length; i++)
            {
                int Point = playerIndex / 8;
                int x = playerLocation1[Point, 0];
                int y = playerLocation1[Point, 1];
                pbArea[i].Controls.Add(pbPlayer1[playerIndex]);
                pbPlayer1[playerIndex].Location = new Point(x, y);
                pbPlayer1[playerIndex].BackColor = Color.Transparent;
                playerIndex++;
            }
            playerIndex = 0;
            for (int i = 0; i < pbPlayer1.Length; i++)
            {
                int Point = playerIndex / 8;
                int x = playerLocation2[Point, 0];
                int y = playerLocation2[Point, 1];
                pbArea[i].Controls.Add(pbPlayer2[playerIndex]);
                pbPlayer2[playerIndex].Location = new Point(x, y);
                pbPlayer2[playerIndex].BackColor = Color.Transparent;
                playerIndex++;
            }
            pbArea[16].Controls.Add(pbFundCoin);
            pbFundCoin.Location = new Point(36, 50);
            pbFundCoin.BackColor = Color.Transparent;
        }

        public void AreaInfoSet() // 지역 초기화
        {
            int[] price = { 50000, 150000, 250000, 350000 };
            int[] price2 = { 10000, 90000, 250000, 350000 };
            int[] price3 = { 25000, 75000, 125000, 175000 };
            areaInfo[1] = new AreaInfo("타이베이", price, price2, price3, 0, 0);
            price = new int[] { 50000, 150000, 250000, 400000 };
            price2 = new int[] { 20000, 180000, 450000, 600000 };
            price3 = new int[] { 25000, 75000, 125000, 200000 };
            areaInfo[2] = new AreaInfo("베이징", price, price2, price3, 0, 0);
            price = new int[] { 50000, 150000, 250000, 450000 };
            price2 = new int[] { 20000, 180000, 450000, 600000 };
            price3 = new int[] { 25000, 75000, 125000, 225000 };
            areaInfo[3] = new AreaInfo("마닐라", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[4] = new AreaInfo("황금열쇠", price, price, price, 0, 0);
            price = new int[] { 50000, 150000, 250000, 500000 };
            price2 = new int[] { 30000, 270000, 550000, 700000 };
            price3 = new int[] { 25000, 75000, 125000, 175000 };
            areaInfo[5] = new AreaInfo("싱가포르", price, price2, price3, 0, 0);
            price = new int[] { 0, 0, 0, 200000 };
            price2 = new int[] { 0, 0, 0, 300000 };
            price3 = new int[] { 0, 0, 0, 100000 };
            areaInfo[6] = new AreaInfo("제주도", price, price2, price3, 0, 0);
            price = new int[] { 50000, 150000, 250000, 550000 };
            price2 = new int[] { 30000, 270000, 550000, 750000 };
            price3 = new int[] { 25000, 75000, 125000, 225000 };
            areaInfo[7] = new AreaInfo("카이로", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[8] = new AreaInfo("무인도", price, price, price, 0, 0);
            price = new int[] { 100000, 300000, 500000, 700000 };
            price2 = new int[] { 150000, 450000, 750000, 950000 };
            price3 = new int[] { 50000, 150000, 250000, 350000 };
            areaInfo[9] = new AreaInfo("아테네", price, price2, price3, 0, 0);
            price = new int[] { 100000, 300000, 500000, 750000 };
            price2 = new int[] { 180000, 500000, 900000, 1000000 };
            price3 = new int[] { 50000, 150000, 250000, 375000 };
            areaInfo[10] = new AreaInfo("코펜하겐", price, price2, price3, 0, 0);
            price = new int[] { 0, 0, 0, 400000 };
            price2 = new int[] { 0, 0, 0, 500000 };
            price3 = new int[] { 0, 0, 0, 200000 };
            areaInfo[11] = new AreaInfo("부산", price, price3, price3, 0, 0);
            price = new int[] { 100000, 300000, 500000, 800000 };
            price2 = new int[] { 180000, 500000, 900000, 1050000 };
            price3 = new int[] { 50000, 150000, 250000, 400000 };
            areaInfo[12] = new AreaInfo("스톡홀름", price, price2, price3, 0, 0);
            price = new int[] { 100000, 300000, 500000, 850000 };
            price2 = new int[] { 180000, 500000, 900000, 950000 };
            price3 = new int[] { 50000, 150000, 250000, 425000 };
            areaInfo[13] = new AreaInfo("베를린", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[14] = new AreaInfo("황금열쇠", price, price, price, 0, 0);
            price = new int[] { 100000, 300000, 500000, 900000 };
            price2 = new int[] { 220000, 600000, 1000000, 1150000 };
            price3 = new int[] { 50000, 150000, 250000, 450000 };
            areaInfo[15] = new AreaInfo("오타와", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[16] = new AreaInfo("사회복지기금", price, price, price, 0, 0);
            price = new int[] { 150000, 450000, 750000, 1050000 };
            price2 = new int[] { 300000, 750000, 1100000, 1300000 };
            price3 = new int[] { 75000, 225000, 375000, 525000 };
            areaInfo[17] = new AreaInfo("상파울루", price, price2, price3, 0, 0);
            price = new int[] { 150000, 450000, 750000, 1100000 };
            price2 = new int[] { 300000, 750000, 1100000, 1450000 };
            price3 = new int[] { 75000, 225000, 375000, 550000 };
            areaInfo[18] = new AreaInfo("시드니", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[19] = new AreaInfo("황금열쇠", price, price, price, 0, 0);
            price = new int[] { 150000, 450000, 750000, 1200000 };
            price2 = new int[] { 330000, 800000, 1150000, 1600000 };
            price3 = new int[] { 75000, 225000, 375000, 600000 };
            areaInfo[20] = new AreaInfo("하와이", price, price2, price3, 0, 0);
            price = new int[] { 0, 0, 0, 300000 };
            price2 = new int[] { 0, 0, 0, 400000 };
            price3 = new int[] { 0, 0, 0, 150000 };
            areaInfo[21] = new AreaInfo("컬럼비아호", price, price2, price3, 0, 0);
            price = new int[] { 150000, 450000, 750000, 1250000 };
            price2 = new int[] { 360000, 850000, 1200000, 1700000 };
            price3 = new int[] { 75000, 225000, 375000, 625000 };
            areaInfo[22] = new AreaInfo("리스본", price, price2, price3, 0, 0);
            price = new int[] { 150000, 450000, 750000, 1300000 };
            price2 = new int[] { 390000, 900000, 1300000, 1800000 };
            price3 = new int[] { 75000, 225000, 375000, 650000 };
            areaInfo[23] = new AreaInfo("마드리드", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[24] = new AreaInfo("세계여행", price, price, price, 0, 0);
            price = new int[] { 200000, 600000, 1000000, 1350000 };
            price2 = new int[] { 450000, 1000000, 1400000, 1900000 };
            price3 = new int[] { 100000, 300000, 500000, 675000 };
            areaInfo[25] = new AreaInfo("도쿄", price, price2, price3, 0, 0);
            price = new int[] { 200000, 600000, 1000000, 1400000 };
            price2 = new int[] { 500000, 1100000, 1500000, 2000000 };
            price3 = new int[] { 100000, 300000, 500000, 700000 };
            areaInfo[26] = new AreaInfo("파리", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[27] = new AreaInfo("사회복지기금 내기", price, price, price, 0, 0);
            price = new int[] { 200000, 600000, 1000000, 1450000 };
            price2 = new int[] { 550000, 1200000, 1600000, 2100000 };
            price3 = new int[] { 100000, 300000, 500000, 725000 };
            areaInfo[28] = new AreaInfo("런던", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[29] = new AreaInfo("황금열쇠", price, price, price, 0, 0);
            price = new int[] { 200000, 600000, 1000000, 1500000 };
            price2 = new int[] { 600000, 1300000, 1700000, 2200000 };
            price3 = new int[] { 100000, 300000, 500000, 750000 };
            areaInfo[30] = new AreaInfo("뉴욕", price, price2, price3, 0, 0);
            price = new int[] { 200000, 600000, 1000000, 1550000 };
            price2 = new int[] { 650000, 1400000, 1800000, 2300000 };
            price3 = new int[] { 100000, 300000, 500000, 775000 };
            areaInfo[31] = new AreaInfo("서울", price, price2, price3, 0, 0);
            price = new int[] { 0 };
            areaInfo[0] = new AreaInfo("START", price, price, price, 0, 0);
        }

        public void GoldKeySet() // 황금 열쇠 정보 초기화
        {
            goldKey[0].cardName = "무인도 탈출";
            goldKey[0].cardExplain = "특수 무전기 - (무인도에 갇혀 있을 때 사용할 수 있습니다, 1회 사용 후 반납합니다.)";
            goldKey[1].cardName = "무인도";
            goldKey[1].cardExplain = "폭풍을 만났습니다. 무인도로 곧장 가세요. - (출발지를 지나더라도 월급을 받을 수 없습니다.)";
            goldKey[2].cardName = "관광여행";
            goldKey[2].cardExplain = "제주도로 가세요 - (제주도 소유주에게 통행료를 지불합니다. 출발지를 지나갈 경우, 월급을 받습니다.)";
            goldKey[3].cardName = "고속도로";
            goldKey[3].cardExplain = "출발지까지 곧바로 가세요. - (출발지에서 월급을 받습니다.)";
            goldKey[4].cardName = "우대권";
            goldKey[4].cardExplain = "상대방이 소유한 장소에 통행료 없이 머무를 수 있습니다. (1회 사용후, 황금 열쇠함에 반납합니다. 중요한 순간에 쓰세요.)";
            goldKey[5].cardName = "관광여행";
            goldKey[5].cardExplain = "(가장비싼도시-부산)으로 가세요. - (부산을 상대방이 가지고 있는 경우, 통행료를 지불합니다)";
            goldKey[6].cardName = "세계여행 초청장";
            goldKey[6].cardExplain = "세계여행 초청장이 왔습니다. 세계여행 칸으로 이동하시오. (세계여행은 무료이므로 탑승료를 지불하지 않습니다, 출발지를 지나갈 경우 월급을 받습니다.)";
            goldKey[7].cardName = "사회복지기금 접수처";
            goldKey[7].cardExplain = "사회복지기금 기부칸으로 가세요.- (출발지를 지나갈 경우, 월급을 받습니다.)";
        }

        public void GoldKeyAction() // 황금열쇠 이벤트 처리
        {
            playerNowLocation = player[diceTurn].location;

            if (goldKeyIndex == 0)  // 무인도 탈출 카드 
            {
                MessageBox.Show(string.Format(goldKey[0].cardName + "\n" + goldKey[0].cardExplain));
                player[diceTurn].freeUnisland++;
            }
            else if (goldKeyIndex == 1) // 무인도로 이동
            {
                MessageBox.Show(string.Format(goldKey[1].cardName + "\n" + goldKey[1].cardExplain)); // 출발지 지나도 월급을 받지 못함.

                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 8;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                doubleNum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 2) // 제주도 관광여행
            {
                MessageBox.Show(string.Format(goldKey[2].cardName + "\n" + goldKey[2].cardExplain));
                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 6;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 3) // 출발지로 이동
            {
                MessageBox.Show(string.Format(goldKey[3].cardName + "\n" + goldKey[3].cardExplain));
                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 0;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 4) // 우대권
            {
                MessageBox.Show(string.Format(goldKey[4].cardName + "\n" + goldKey[4].cardExplain));
                player[diceTurn].freePasscard++;
            }
            else if (goldKeyIndex == 5) // 관광여행
            {
                MessageBox.Show(string.Format(goldKey[5].cardName + "\n" + goldKey[5].cardExplain));
                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 11;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 6) // 세계여행초청장
            {
                MessageBox.Show(string.Format(goldKey[6].cardName + "\n" + goldKey[6].cardExplain));
                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 24;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                doubleNum = 0;
                timer2.Start();
            }
            else if (goldKeyIndex == 7) // 사회복지 기금 납부
            {
                int i = 0;
                MessageBox.Show(string.Format(goldKey[7].cardName + "\n" + goldKey[7].cardExplain));

                playerNowLocation = player[diceTurn].location;
                player[diceTurn].location = 27;
                playerLastLocation = player[diceTurn].location;
                diceSum = 0;
                timer2.Start();
            }
        }

        public void WorldTour() // 세계 일주 이벤트 처리
        {
            // 현재 위치 및 최종 위치 초기화
            playerNowLocation = player[diceTurn].location;
            playerLastLocation = areaIndex;
            pbDice.Enabled = false;
            pbDice.Image = imageList2.Images[1];
            // 말 이동
            diceSum = 0;
            timer2.Start();
            // 위치 값 수정
            player[diceTurn].location = areaIndex;
            // 주사위 버튼 활성화 및 턴 넘기기
            pbDice.Enabled = true;
            pbDice.Image = imageList2.Images[0];
            timer1.Start();
        }

        public void WelFareFund() // 사회 복지 기금 돈 수령 이벤트 처리
        {
            MessageBox.Show(string.Format("{0:N0}를 받습니다.", areaInfo[16].fundMoney));
            player[diceTurn].haveMoney += areaInfo[16].fundMoney;
            areaInfo[16].fundMoney = 0;
            pbFundCoin.Image = null;
        }

        public void PayFund() // 사회 복지 기금 기부 이벤트 처리
        {
            MessageBox.Show("150,000원을 지불합니다.");

            player[diceTurn].haveMoney -= 150000;

            areaInfo[16].fundMoney += 150000;
            if (payFundCoin == 0)
            {
                pbFundCoin.Image = imageList3.Images[payFundCoin];
                payFundCoin++;
            }
            else if (payFundCoin == 1)
            {
                pbFundCoin.Image = imageList3.Images[payFundCoin];
                payFundCoin++;
            }
            else if (payFundCoin == 2)
            {
                pbFundCoin.Image = imageList3.Images[payFundCoin];

            }
            else
                pbFundCoin.Image = imageList3.Images[2];

            // 매각 할 건물이 없을 경우
            if (player[diceTurn].areaIndex.Count < 1 && player[diceTurn].haveMoney < 0)
            {
                MessageBox.Show(string.Format("GAME OVER!!\n매각 할 건물이 없습니다.\nPlayer{0} 패배!!", diceTurn));
                this.Close();
            }
            if (player[diceTurn].haveMoney < 0)
            {
                // 매각 창 띄우기
                BuildSale buildSale = new BuildSale();
                buildSale.ShowDialog();
                buildSale.Dispose();
                // 매각 후 금액이 0원 보다 적으면 패배
                if (player[diceTurn].haveMoney < 0)
                {
                    MessageBox.Show(string.Format("GAME OVER!!\nPlayer{0} 패배!!", diceTurn));
                    this.Close();
                }
            }
        }

        public bool TollgateCheck() // 통행료 지불 가능한지 체크
        {
            // 돈이 부족한 경우 게임 오버
            int turnTemp = 0;
            if (diceTurn == 1) turnTemp = 2;
            else turnTemp = 1;
            int index = player[turnTemp].areaIndex.IndexOf(areaIndex);
            string buildNameTemp = player[turnTemp].buildName[index];
            int areaPrice = 0;
            switch (buildNameTemp)
            {
                case "별장":
                    areaPrice = areaInfo[areaIndex].tollgatePrice[0];
                    break;
                case "빌딩":
                    areaPrice = areaInfo[areaIndex].tollgatePrice[1];
                    break;
                case "호텔":
                    areaPrice = areaInfo[areaIndex].tollgatePrice[2];
                    break;
                case "랜드마크":
                    areaPrice = areaInfo[areaIndex].tollgatePrice[3];
                    break;
            }
            if (player[diceTurn].haveMoney < areaPrice) // 지불 할 돈이 없는 경우
                return false;
            else return true; // 지불 가능한 경우
        }

        public bool TakeOverCheck() // 인수 가능한지 체크
        {
            int turnTemp = 0;
            if (diceTurn == 1) turnTemp = 2;
            else turnTemp = 1;
            int index = player[turnTemp].areaIndex.IndexOf(areaIndex);
            string buildNameTemp = player[turnTemp].buildName[index];

            if (buildNameTemp == "랜드마크") // 인수 불가
                return false;
            int areaPrice = 0;
            switch (buildNameTemp)
            {
                case "별장":
                    areaPrice = (int)(areaInfo[areaIndex].buildPrice[0] * 1.5);
                    break;
                case "빌딩":
                    areaPrice = (int)(areaInfo[areaIndex].buildPrice[1] * 1.5);
                    break;
                case "호텔":
                    areaPrice = (int)(areaInfo[areaIndex].buildPrice[2] * 1.5);
                    break;
                case "랜드마크":
                    areaPrice = (int)(areaInfo[areaIndex].buildPrice[3] * 1.5);
                    break;
            }
            if (player[diceTurn].haveMoney < areaPrice) // 인수 할 돈이 없는 경우
                return false;
            else return true; // 인수 가능한 경우
        }

        public void AreaSpot() // 건물 살 수 있는 지역에 따른 이벤트 처리
        {
            if (areaInfo[areaIndex].owner == 0) // 소유주가 없을 경우
            {
                Building building = new Building();
                building.ShowDialog();
                building.Dispose();
            }
            else if (areaInfo[areaIndex].owner == diceTurn) // 자기 소유의 건물
            {
                // 건설된 건물이 랜드마크일 경우 구매 창 띄우지 않기
                int index = player[diceTurn].areaIndex.IndexOf(areaIndex);
                if (player[diceTurn].buildName[index] == "랜드마크")
                    return;
                // 랜드마크 아닐 경우 건물 구매 창 띄우기
                Building building = new Building();
                building.ShowDialog();
                building.Dispose();
            }
            else // 상대 소유의 건물 일 경우
            {
                if (TollgateCheck()) // 통행료 지불이 가능한 경우
                {
                    // 통행료 지불
                    Tollgate tollgate = new Tollgate();
                    tollgate.ShowDialog();
                    tollgate.Dispose();
                    // 플레이어별 금액 출력
                    lbPlayer1.Text = string.Format("Player1 : {0:N0}원", player[1].haveMoney);
                    lbPlayer2.Text = string.Format("Player2 : {0:N0}원", player[2].haveMoney);
                    // 인수 가능한지 체크 후 인수 창 띄우기
                    if (TakeOverCheck())
                    {
                        TakeOver takeover = new TakeOver();
                        takeover.ShowDialog();
                        takeover.Dispose();
                    }
                }
                else // 통행료 지불이 불가능한 경우
                {
                    // 통행료 지불
                    Tollgate tollgate = new Tollgate();
                    tollgate.ShowDialog();
                    tollgate.Dispose();
                    // 매각 할 건물이 없을 경우
                    if (player[diceTurn].areaIndex.Count < 1)
                    {
                        MessageBox.Show(string.Format("GAME OVER!!\nPlayer{0} 패배!!", diceTurn));
                        this.Close();
                    }
                    if (player[diceTurn].haveMoney < 0)
                    {
                        // 매각 창 띄우기
                        BuildSale buildSale = new BuildSale();
                        buildSale.ShowDialog();
                        buildSale.Dispose();
                    }
                    // 매각 후 금액이 0원 보다 적으면 패배
                    if (player[diceTurn].haveMoney < 0)
                    {
                        MessageBox.Show(string.Format("GAME OVER!!\nPlayer{0} 패배!!", diceTurn));
                        this.Close();
                    }
                }
            }
            lbPlayer1.Text = string.Format("Player1 : {0:N0}원", player[1].haveMoney);
            lbPlayer2.Text = string.Format("Player2 : {0:N0}원", player[2].haveMoney);
        }

        public bool WorldTourCheck() // 월드 투어 여부 체크
        {
            if (player[diceTurn].worldTourCnt == 0) return false; // 세계 여행이 아닐 때
            else // 세계 여행을 할 때
            {
                timer1.Stop();
                player[diceTurn].worldTourCnt = 0;
                MessageBox.Show("이동 할 지역을 선택해주세요.");
                pbDice.Enabled = false;
                pbDice.Image = imageList2.Images[1];
                return true;
            }
        }

        public void PlayerMove() // 플레이어 이동
        {
            player[diceTurn].location += diceSum;

            player[diceTurn].location %= 32; // 지역 인덱스 ( 0 ~ 31 )

            if (doubleNum == 3) // 더블 3번일 경우 무인도로 이동
            {
                player[diceTurn].location = 8;
                doubleNum = 0;
            }

            if (player[diceTurn].location == 0) return; // 출발점
            else if (player[diceTurn].location == 4 || player[diceTurn].location == 14 || player[diceTurn].location == 19 || player[diceTurn].location == 29) // 황금열쇠
            {
                Random rand = new Random();
                goldKeyIndex = rand.Next(0, 8);
                GoldKeyAction();
            }
            else if (player[diceTurn].location == 8) player[diceTurn].unislandCnt = 3; // 무인도
            else if (player[diceTurn].location == 16) WelFareFund(); // 사회 복지 기금 돈 수령
            else if (player[diceTurn].location == 27) PayFund();// 사회 복지 기금 기부
            else if (player[diceTurn].location == 24) // 세계 여행 
            {
                player[diceTurn].worldTourCnt++;
                timer1.Stop();
                MessageBox.Show("다음턴에 세계여행을 이용할 수 있습니다.");
                timer1.Start();
            }
            else // 지역에 걸렸을 때
            {
                areaIndex = player[diceTurn].location;
                AreaSpot();
            }
            lbPlayer1.Text = string.Format("Player1 : {0:N0}원", player[1].haveMoney);
            lbPlayer2.Text = string.Format("Player2 : {0:N0}원", player[2].haveMoney);
        }

        public void UnislandCheck() // 무인도 면제카드 여부 체크
        {
            // 무인도에 있고, 무인도 면제 카드가 있을 경우
            if (player[diceTurn].freeUnisland > 0 && player[diceTurn].unislandCnt > 0)
            {
                player[diceTurn].freeUnisland--;
                player[diceTurn].unislandCnt = 0;
                MessageBox.Show(string.Format("무인도 탈출 카드를 사용합니다.\n남은 카드는 " + player[diceTurn].freeUnisland + "개 입니다."));
            }
        }



        private void pbArea0_Click(object sender, EventArgs e)  //출발
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 0;
                WorldTour();
            }
        }
        private void pbArea1_Click(object sender, EventArgs e)  //타이베이
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 1;
                WorldTour();
            }
        }
        private void pbArea2_Click(object sender, EventArgs e)  //베이징
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 2;
                WorldTour();
            }
        }
        private void pbArea3_Click(object sender, EventArgs e)  //마닐라
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 3;
                WorldTour();
            }
        }
        private void pbArea4_Click(object sender, EventArgs e)  //황금열쇠
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 4;
                WorldTour();
            }
        }
        private void pbArea5_Click(object sender, EventArgs e)  //싱가포르
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 5;
                WorldTour();
            }
        }
        private void pbArea6_Click(object sender, EventArgs e)  //제주도
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 6;
                WorldTour();
            }
        }
        private void pbArea7_Click(object sender, EventArgs e) //카이로
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 7;
                WorldTour();
            }
        }
        private void pbArea8_Click(object sender, EventArgs e) //무인도
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 8;
                WorldTour();
            }
        }
        private void pbArea9_Click(object sender, EventArgs e) //아테네
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 9;
                WorldTour();
            }
        }
        private void pbArea10_Click(object sender, EventArgs e)  //코펜하겐
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 10;
                WorldTour();
            }
        }
        private void pbArea11_Click(object sender, EventArgs e)  //부산
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 11;
                WorldTour();
            }
        }
        private void pbArea12_Click(object sender, EventArgs e) //스톡홀롬
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 12;
                WorldTour();
            }
        }
        private void pbArea13_Click(object sender, EventArgs e)  //베를린
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 13;
                WorldTour();
            }
        }
        private void pbArea14_Click(object sender, EventArgs e)  //황금열쇠
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 14;
                WorldTour();
            }
        }
        private void pbArea15_Click(object sender, EventArgs e) //오타와
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 15;
                WorldTour();
            }
        }
        private void pbArea16_Click(object sender, EventArgs e)  //사회복지기금
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 16;
                WorldTour();
            }
        }
        private void pbArea17_Click(object sender, EventArgs e) //상파울로
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 17;
                WorldTour();
            }
        }
        private void pbArea18_Click(object sender, EventArgs e)  //시드니
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 18;
                WorldTour();
            }
        }
        private void pbArea19_Click(object sender, EventArgs e)  //황금열쇠
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 19;
                WorldTour();
            }
        }
        private void pbArea20_Click(object sender, EventArgs e)  //하와이
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 20;
                WorldTour();
            }
        }
        private void pbArea21_Click(object sender, EventArgs e)  //컬럼비아호
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 21;
                WorldTour();
            }
        }
        private void pbArea22_Click(object sender, EventArgs e)  //리스본
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 22;
                WorldTour();
            }
        }
        private void pbArea23_Click(object sender, EventArgs e)  //마드리드
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 23;
                WorldTour();
            }
        }
        private void pbArea25_Click(object sender, EventArgs e)  //도쿄
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 25;
                WorldTour();
            }
        }
        private void pbArea26_Click(object sender, EventArgs e) //파리
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 26;
                WorldTour();
            }
        }
        private void pbArea27_Click(object sender, EventArgs e)  //사회복지기금
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 27;
                WorldTour();
            }
        }
        private void pbArea28_Click(object sender, EventArgs e)  //런던
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 28;
                WorldTour();
            }
        }
        private void pbArea29_Click(object sender, EventArgs e)  //황금열쇠
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 29;
                WorldTour();
            }
        }
        private void pbArea30_Click(object sender, EventArgs e) //뉴욕
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 30;
                WorldTour();
            }
        }
        private void pbArea31_Click(object sender, EventArgs e)  //서울
        {
            if (player[diceTurn].location == 24)
            {
                areaIndex = 31;
                WorldTour();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 월드투어 여부 체크
            WorldTourCheck();
            // 무인도에 있고 무인도 탈출 카드가 있는지 체크
            UnislandCheck();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pbDice.Enabled = false;
            pbDice.Image = imageList2.Images[1];
            if (playerNowLocation == playerLastLocation)
            {
                timer2.Stop();
                int locationTemp = player[diceTurn].location;
                PlayerMove();
                if (doubleNum > 0) // 더블일 경우
                {
                    if (player[diceTurn].location == 24 || player[diceTurn].location == 8 || locationTemp == 8)
                    {
                        if (diceTurn == 1) diceTurn = 2;
                        else diceTurn = 1;
                        doubleNum = 0;
                    }
                }
                else // 더블이 아닌 경우
                {
                    if (goldKeyIndex == 0 || goldKeyIndex == 4)
                    {
                        if (diceTurn == 1) diceTurn = 2;
                        else diceTurn = 1;
                    }
                }
                goldKeyIndex = 0;
                if (diceTurn == 1) lbTurn.ForeColor = Color.Red;
                else lbTurn.ForeColor = Color.Blue;
                lbTurn.Text = ($"Player{diceTurn}");
                pbDice.Enabled = true;
                pbDice.Image = imageList2.Images[0];
                return;
            }
            // 플레이어 말 이동 전
            if (diceTurn == 1) pbPlayer1[playerNowLocation].Visible = false; // 1번 플레이어
            else pbPlayer2[playerNowLocation].Visible = false; // 2번 플레이어

            playerNowLocation = (playerNowLocation + 1) % 32;

            // 플레이어 말 이동 후
            if (diceTurn == 1) pbPlayer1[playerNowLocation].Visible = true; // 1번 플레이어
            else pbPlayer2[playerNowLocation].Visible = true; // 2번 플레이어

            // 월급 지급
            if (playerNowLocation == 0)
            {
                player[diceTurn].haveMoney += 300000;
                lbPlayer1.Text = string.Format("Player1 : {0:N0}원", player[1].haveMoney);
                lbPlayer2.Text = string.Format("Player2 : {0:N0}원", player[2].haveMoney);
                MessageBox.Show("월급 30만원을 지급합니다.");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pbDice.Enabled = false;
            pbDice.Image = imageList2.Images[1];
            if (cnt < 6)
            {
                pbDice1.Image = imageList1.Images[cnt];
                pbDice2.Image = imageList1.Images[cnt];
            }
            cnt++;

            if (cnt == 6)
            {
                pbDice1.Image = imageList1.Images[int.Parse(lbDice1.Text) - 1];
                pbDice2.Image = imageList1.Images[int.Parse(lbDice2.Text) - 1];

                // 현재 위치 및 최종 위치 초기화
                playerNowLocation = player[diceTurn].location;
                playerLastLocation = (player[diceTurn].location + diceSum) % 32;

                // 더블 3번 연속일 경우
                if (doubleNum == 3)
                {
                    MessageBox.Show("더블 연속 3번으로 무인도로 이동");
                    playerLastLocation = 8;
                }

                if (player[diceTurn].unislandCnt > 0) // 무인도에 있을 때
                {
                    if (diceRoll1 == diceRoll2) // 주사위가 더블이면 탈출
                    {
                        MessageBox.Show("더블! 무인도 탈출!!");
                        timer2.Start();
                        player[diceTurn].unislandCnt = 0;
                        doubleNum = 0;
                        if (diceTurn == 1) lbTurn.ForeColor = Color.Red;
                        else lbTurn.ForeColor = Color.Blue;
                        lbTurn.Text = ($"Player{diceTurn}");
                        timer3.Stop();
                        return;
                    }
                    else
                    {
                        if (diceTurn == 1) diceTurn = 2;
                        else diceTurn = 1;
                        if (diceTurn == 1) lbTurn.ForeColor = Color.Red;
                        else lbTurn.ForeColor = Color.Blue;
                        lbTurn.Text = ($"Player{diceTurn}");
                        MessageBox.Show("탈출 실패!");
                        pbDice.Enabled = true;
                        pbDice.Image = imageList2.Images[0];
                    }
                }
                // 무인도가 아닐 경우
                else timer2.Start();
                timer3.Stop();
                cnt = 0;
            }
        }

        private void btnShowArea1_Click(object sender, EventArgs e)
        {
            showAreaTurn = 1;
            ShowArea showArea = new ShowArea();
            showArea.ShowDialog();
            showArea.Dispose();
        }

        private void btnShowArea2_Click(object sender, EventArgs e)
        {
            showAreaTurn = 2;
            ShowArea showArea = new ShowArea();
            showArea.ShowDialog();
            showArea.Dispose();
        }

        private void pbDice_Click(object sender, EventArgs e)
        {
            pbDice.Enabled = false;
            pbDice.Image = imageList2.Images[1];

            Random random = new Random();
            diceRoll1 = random.Next(1, 7);
            diceRoll2 = random.Next(1, 7);

            diceSum = diceRoll1 + diceRoll2;
            lbDice1.Text = diceRoll1.ToString();
            lbDice2.Text = diceRoll2.ToString();
            // 현재 위치 및 최종 위치 초기화
            playerNowLocation = player[diceTurn].location;
            playerLastLocation = (player[diceTurn].location + diceSum) % 32;
            cnt = 0;

            if (player[diceTurn].unislandCnt > 0) // 무인도에 있을 경우
            {
                player[diceTurn].unislandCnt--;
                cnt = 0;
                timer3.Start();
                cnt = 0;
            }
            else // 무인도가 아닐 경우
            {
                if (diceRoll1 == diceRoll2) // 더블이면
                {
                    doubleNum++;
                    if (doubleNum != 3)
                    {
                        timer3.Start();
                        cnt = 0;
                    }
                    else // 무인도 이동
                    {
                        diceSum = 0;
                        timer3.Start();
                        cnt = 0;
                    }
                }
                else // 더블이 아니면
                {
                    timer3.Start();
                    cnt = 0;
                    doubleNum = 0;
                }
            }
            if (diceTurn == 1) lbTurn.ForeColor = Color.Red;
            else lbTurn.ForeColor = Color.Blue;
            lbTurn.Text = ($"Player{diceTurn}");
            pbDice.Enabled = true;
            pbDice.Image = imageList2.Images[0];
        }
    }
}