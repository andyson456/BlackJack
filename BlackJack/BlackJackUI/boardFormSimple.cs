using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack
{
    public partial class boardFormSimple : Form
    {
		#region Instance Variables
		BJHand playerHand;
		BJHand computerHand;
		Card c = new Card();
		Deck d = new Deck();
        #endregion

        public boardFormSimple()
        {
            InitializeComponent();
        }

        #region Methods
        public void Show(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\" + c.FileName);
        }

        public void ShowBack(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\black_back.jpg");
        }
		#endregion

		private PictureBox GetPictureBox(int i)
		{
			PictureBox pB = (PictureBox)this.Controls["card" + i];
			return pB;
		}

		public void DealHand(BJHand currentHand, bool player, bool reveal)
		{
			int pBIndex;
			if (player)
				pBIndex = 1;
			else
				pBIndex = 16;

			if (reveal)
			{
				for (int i = 0; i < 5; i++)
				{
					PictureBox pB = GetPictureBox(i + pBIndex);
					if (i < playerHand.NumCards)
					{
						Show(pB, currentHand.GetCard(i));
						pB.Show();
					}
					else
						pB.Hide();
				}
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					PictureBox pB = GetPictureBox(i + pBIndex);
					if (i < playerHand.NumCards)
					{
						ShowBack(pB, currentHand.GetCard(i));
						pB.Show();
					}
					else
						pB.Hide();
				}
			}
		}
/*
		public void DisableCardVisibility()
		{
			card1.Visible = false;
			card2.Visible = false;
			card3.Visible = false;
			card4.Visible = false;
			card5.Visible = false;
			card16.Visible = false;
			card17.Visible = false;
			card18.Visible = false;
			card19.Visible = false;
			card20.Visible = false;
		}
*/
        private void frmBoard_Load(object sender, EventArgs e)
        {
			d.Shuffle();
			//DisableCardVisibility();
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;

			playerHand = new BJHand(d, 2);
			computerHand = new BJHand(d, 2);

			DealHand(computerHand, false, false);
			DealHand(playerHand, true, true);
		}

        private void hitButton_Click(object sender, EventArgs e)
        {
			playerHand.AddCard(d.Deal());
			DealHand(playerHand, true, true);

			if (playerHand.IsBusted)
			{
				dealerWinLabel.Show();
				hitButton.Enabled = false;
				standButton.Enabled = false;
				playerWinLabel.Visible = true;
			}
        }

        private void standButton_Click(object sender, EventArgs e)
        {
			computerHand.AddCard(d.Deal());
			DealHand(computerHand, false, true);

			if (computerHand.IsBusted)
			{
				playerWinLabel.Show();
				hitButton.Enabled = false;
				standButton.Enabled = false;
				dealerWinLabel.Enabled = true;
			}
		}

        private void playAgainButton_Click(object sender, EventArgs e)
        {
			//DisableCardVisibility();
			hitButton.Enabled = true;
			standButton.Enabled = true;
			playerWinLabel.Visible = false;
			dealerWinLabel.Visible = false;
			playAgainButton.Enabled = false; 
		}
    }
}
