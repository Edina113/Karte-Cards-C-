using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Publicjoe.Windows;
using Publicjoe.Windows.Cards;

namespace HiLow
{
  public partial class Form1 : Form
  {
    private Card cardDrawing;
    private Deck TheDeck;
    private int currentCard = 0;
    private bool winLose = true;
   

   

    public Form1()
    {
      InitializeComponent();

      cardDrawing = new Card();
      cardDrawing.Begin(this.CreateGraphics());

      TheDeck = new Deck();
      TheDeck.Shuffle();

    }


        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Raèunar iz špila od 52 karte nasumièno izvlaèi èetiri karte. Inicijalno, igraèu je prikazana samo prva karta dok su ostale tri pokrivene.. " +
                          "Igraè, zatim, bira jednu od ponuðenih opcija.");

            MessageBox.Show("Za drugu kartu, tj Veæa, Manja ili Ista u odnosu na prvu kartu. " +
                 "Ukoliko, igraè uspiješno pogodi vrijednost druge karte u odnosu na prvu kartu, druga karta se prikazuje, a igraè ponovo ima izbor vrijednosti treæe karte u odnosu na drugu." +
                 " Igra se završava pobjedom igraèa, sa odgovarajuæom porukom, ukoliko se sve èetiri karte uspiješno otkriju. ");
        }
    

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    

    protected override void OnPaint(PaintEventArgs e)
    { 
      for (int i = 0; i <= currentCard; i++)
      {
        cardDrawing.DrawCard(new Point((10 + (i * 80)), 34), TheDeck.GetCard(i));
      }

      for (int i = currentCard + 1; i < 5; i++)
      {
        cardDrawing.DrawCardBack(new Point((10 + (i * 80)), 34));
      }

      if (winLose == false)
      {
        buttonPlay.Visible = true;
      }
      else if (currentCard == 4)
      {
        buttonPlay.Visible = true;
        
 
        }  
       
      base.OnPaint(e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonHigher_Click(object sender, EventArgs e)
    {
      if (winLose == true)
      {
        int prev = TheDeck.GetCard(currentCard);

        currentCard++;
        int cur = TheDeck.GetCard(currentCard);

        int curRank = (int)cardDrawing.RankFromCardIndex(cur);
        int prevRank = (int)cardDrawing.RankFromCardIndex(prev);

        if (curRank < prevRank)
        {
          winLose = false;
          MessageBox.Show("Izgubio si!");
        }

        if (currentCard == 4)
        {
          MessageBox.Show("Pobjeda je tvoja!");
        }

        Invalidate();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonLower_Click(object sender, EventArgs e)
        {
            if (winLose == true)
      {
        int prev = TheDeck.GetCard(currentCard);
        currentCard++;
        int cur = TheDeck.GetCard(currentCard);

        int curRank = (int)cardDrawing.RankFromCardIndex(cur);
        int prevRank = (int)cardDrawing.RankFromCardIndex(prev);

        if (curRank > prevRank)
        {
          winLose = false;
          MessageBox.Show("Izgubio si!");
        }

        if (currentCard == 4)
        {
          MessageBox.Show("Pobjeda je tvoja!");
        }

        Invalidate();
      }
    }

    private void buttonPlay_Click(object sender, EventArgs e)
    {
      
      
      currentCard = 0;
      winLose = true;

      TheDeck.Shuffle();
      buttonPlay.Visible = true;

     

    
    }

    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (winLose == true)
            {
                int prev = TheDeck.GetCard(currentCard);

                currentCard++;
                int cur = TheDeck.GetCard(currentCard);

                int curRank = (int)cardDrawing.RankFromCardIndex(cur);
                int prevRank = (int)cardDrawing.RankFromCardIndex(prev);

                if (curRank != prevRank)
                {
                    winLose = true;
                    MessageBox.Show("Izgubio si");
                }

                if (currentCard == 4)
                {
                    MessageBox.Show("Pobjeda je tvoja");
                }

                Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kontaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Za sva pitanja obratite se na moj mail @musazahirovic11@gmail.com");
        }

        private void radioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikaciju pravio Mustafa Zahiroviæ IV-2");
        }

        private void oMeniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }
