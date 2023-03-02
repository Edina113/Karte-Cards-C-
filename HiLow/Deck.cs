using System;

namespace Publicjoe.Windows.Cards
{
  /// <summary>
  /// Summary description for Deck.
  /// </summary>
  public class Deck
  {
    private int[] CardArray = new int[52];

    /// <summary>
    /// Initializes deck with the 52 integers.
    /// </summary>
    public Deck()
    {
      // Deck uses RankCollated cards 0 - 51
      for( int i = 0; i < 52; i++ )
      {
        CardArray[i] = i;
      }
    }

    /// <summary>
    /// Randomly rearrange integers
    /// </summary>
    public void Shuffle()
    {
      int[] newArray = new int[52];
      bool[] used = new bool[52];

      for( int j = 0; j < 52; j++ )
      {
        used[j] = false;
      }
    
      Random rnd = new Random();
      int iCount = 0;
      int iNum;

      while( iCount < 52 )
      {
        iNum = rnd.Next( 0, 52 ); // between 0 and 51

        if( used[iNum] == false )
        {
          newArray[iCount] = iNum;
          used[iNum] = true;
          iCount++;
        }
      }

      // Load original array with shuffled array
      CardArray = newArray;
    }    
   
    /// <summary>
    /// Obtains a card number from the deck.
    /// </summary>
    public int GetCard( int arrayNum )
    {
      if (arrayNum >= 0 && arrayNum <= 51)
        return CardArray[arrayNum];
      else
        throw (new System.ArgumentOutOfRangeException("arrayNum", arrayNum,
          "Value must be between 0 and 51."));
    }
  }
}
