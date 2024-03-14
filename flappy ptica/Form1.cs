using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_ptica
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int Inscore = 0;
        bool kraj = false;


        public Form1()
        {
            InitializeComponent();
            endText1.Text = "Kraj izgubio si jadnice";
            endText2.Text = "Rezultat: " + Inscore;
            gameDesigner.Text = "Prepravljeno by eduTech";

            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            scoreText.Text = "" + Inscore;


            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
                endGame();
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
                endGame();
            if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
                endGame();

            if (pipeBottom.Left < -60) {
                pipeBottom.Left = 900;
                Inscore += 1;
            }
            else if (pipeTop.Left < -90) {
                pipeTop.Left = 1400;
                Inscore += 1;
            }


        }

        private void inGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5;
            }

            if (kraj == true) {
                if (e.KeyCode == Keys.Space) {
                    Inscore = 0;
                    flappyBird.Location = new Point(29, 199);
                    ground.Location = new Point(0, 544);
                    pipeTop.Location = new Point(482, 0);
                    pipeBottom.Location = new Point(742, 291);
                    endText1.Visible = false;
                    endText2.Visible = false;
                    gameDesigner.Visible = false;
                    gameTimer.Start();
                    kraj = false;
                    
                }
            
            }

        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }

        }

        private void endGame() 
        {

            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Text = "Rezultat: " + Inscore;
            endText2.Visible = true;
            gameDesigner.Visible = true;
            kraj = true;

        }


    }
}
