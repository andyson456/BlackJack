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
		Hand playerHand = new Hand();
		Hand computerHand = new Hand();
		Card c = new Card();
		Deck d = new Deck();
		bool playerTurn = false;
		bool computerTurn = false;
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

        private void frmBoard_Load(object sender, EventArgs e)
        {
			DisableCardVisibility();
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = true;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
			d.Shuffle();

			Card c1 = d.Deal();
			Card c2 = d.Deal();
			Card c3 = d.Deal();
			Card c4 = d.Deal();
			Card c5 = d.Deal();

			
			playerHand.AddCard(c1);
			Show(card16, c1);
			card16.Visible = true;

        }

        private void standButton_Click(object sender, EventArgs e)
        {
			d.Shuffle();

			Card c1 = d.Deal();
			Card c2 = d.Deal();
			Card c3 = d.Deal();
			Card c4 = d.Deal();
			Card c5 = d.Deal();


			computerHand.AddCard(c1);
			Show(card1, c1);
			card1.Visible = true;
		}

        private void playAgainButton_Click(object sender, EventArgs e)
        {
			DisableCardVisibility();
			hitButton.Enabled = true;
			standButton.Enabled = true;
			playerWinLabel.Visible = false;
			dealerWinLabel.Visible = false;
			playAgainButton.Enabled = true; 
		}
    }
}
