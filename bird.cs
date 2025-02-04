using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_form
{
    public partial class asd : Form
    {
        int pipeSpeed = 8;   //파이프를 왼쪽으로 보내는 속도
        int gravity = 5;     //새를 떨어트리는 속도
        int score = 0;       //점수


        public asd()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;                  //새의 위치값에 중력값을 증가시켜 새가 떨어지게 보임
            pipeBottom.Left -= pipeSpeed;               //아래 파이프를 속도 만큼 감소 
            pipeTop.Left -= pipeSpeed;                  //위 파이프를 속도 만큼 감소
            scoreText.Text = "Score : " + score;        //점수 추가
            
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;              //아래 파이프가 화면에서 벗어날 시 오른 쪽 화면으로 위치 초기화
                score++;                            //점수 증가

            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;                 //위 파이프가 화면에서 벗어날 시 오른 쪽 화면으로 위치 초기화
                score++;                            //점수 증가
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||   //새의 위치가 아래 파이프에 닿을 시
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||      //새의 위치가 위 파이프에 닿을 시
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25 //새가 땅이나, 화면 위로 사라질시
                )
            {
                endGame();  //게임 종료 함수 호출
            }

            if (score > 5)  //점수가 5점 이상일 시 
            {
                pipeSpeed = 15; //속도가 15로 증가
            }
            
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)  //입력 키가 스페이스 일때
            {
                gravity = -15; //중력 값이 15감소, 새의 위치가 위로 상승
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;  //중력 값이 15증가, 새의 위치가 아래로 하락
            }
        }

        private void endGame()
        {
            gameTimer.Stop();                   //게임 종료 
            scoreText.Text += " Game over!!!";  // 게임 종료 문구 출력

        }
    }
}
