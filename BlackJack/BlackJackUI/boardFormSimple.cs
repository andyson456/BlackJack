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
		private Deck d;
		private BJHand playerHand;
		private BJHand dealerHand;
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

		private void LoadPlayerHand(BJHand h)
		{

			for (int i = 0; i < 5; i++)
			{
				PictureBox pb = GetPictureBox(i + 1);
				if (i < h.NumCards)
				{
					Show(pb, h.GetCard(i));
					pb.Visible = true;
				}
				else
				{
					pb.Hide();
				}
			}
		}

		private void LoadDealerHand(BJHand h)
		{

			for (int i = 0; i < 5; i++)
			{
				PictureBox pb = GetPictureBox(i + 16);
				if (i < h.NumCards)
				{
					Show(pb, h.GetCard(i));
					pb.Visible = true;
				}
				else
				{
					pb.Hide();
				}
			}
		}

		private void Setup()
		{
			//Created objects
			d = new Deck();
			d.Shuffle();
			playerHand = new BJHand(d, 2);
			dealerHand = new BJHand(d, 2);

			//Add's cards to UI
			LoadPlayerHand(playerHand);
			LoadDealerHand(dealerHand);

			//Showing what's visible
			hitButton.Enabled = true;
			standButton.Enabled = true;
			playerWinLabel.Visible = false;
			dealerWinLabel.Visible = false;
			playAgainButton.Enabled = false;
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
			Setup();
		}

        private void hitButton_Click(object sender, EventArgs e)
        {
			//Add's card to players hand
			playerHand.AddCard(d.Deal());
			LoadPlayerHand(playerHand);

			//if over 21, Change board and displays message
			if (playerHand.IsBusted)
			{
				hitButton.Enabled = false;
				standButton.Enabled = false;
				playAgainButton.Enabled = true;
				dealerWinLabel.Visible = true;
				if (MessageBox.Show("Press OK to Play Again", "You LOST!", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					Setup();
				}
			}
			else
			{
				MessageBox.Show("Next Move");
			}
		}

		private void standButton_Click(object sender, EventArgs e)
		{
			//if score is < 17
			if (dealerHand.Score < 17)
			{
				//Draw until score is <= 17
				while (dealerHand.Score <= 17)
				{
					dealerHand.AddCard(d.Deal());
					LoadDealerHand(dealerHand);
				}
			}
			else if (dealerHand.Score == 21)
			{
				//If dealer score IS 21, winning condition
				hitButton.Enabled = false;
				standButton.Enabled = false;
				playAgainButton.Enabled = true;
				dealerWinLabel.Visible = true;
				if (MessageBox.Show("Press OK to Play Again", "Dealer had 21!", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					Setup();
				}
			}
			else
			{
				//Else just Draw ONE CARD
				dealerHand.AddCard(d.Deal());
				LoadDealerHand(dealerHand);
			}
		}

        private void playAgainButton_Click(object sender, EventArgs e)
        {
			Setup();
		}
    }
}
