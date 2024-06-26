using System.Xml.Linq;

public class Card
{
    public static int handLimit = 5; // Change when desired
    static Random random = new Random();
    public static List<Card> deck = new List<Card>();
    public static List<Card> hand = new List<Card>();
    static int cardsInDeck;
    public int value; // Parameter 1
    public string suite; // Parameter 2
    public string title; // Parameter 3
    public Card(int value, string suite, string title)
    {
        this.value = value;
        this.suite = suite;
        this.title = title;
    }
    public static void CreateDeck()
    {
        string[] title = {"two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "ace"};
        string[] royalTitle = {"jack", "queen", "king"};
        for (int i = 2; i <= 11; i++)
        {
            deck.Add(new Card(i, "clubs", title[i - 2]));
            deck.Add(new Card(i, "spades", title[i - 2]));
            deck.Add(new Card(i, "hearts", title[i - 2]));
            deck.Add(new Card(i, "diamonds", title[i - 2]));
        }
        for (int j = 0; j < 3; j++)
        {
            deck.Add(new Card(10, "clubs", royalTitle[j]));
            deck.Add(new Card(10, "spades", royalTitle[j]));
            deck.Add(new Card(10, "hearts", royalTitle[j]));
            deck.Add(new Card(10, "diamonds", royalTitle[j]));
        }
        cardsInDeck = deck.Count();
    }
    public static void EraseDeck(bool createNewDeck)
    {
        deck.Clear();
        
        if (createNewDeck)
        {
            CreateDeck();
        }
    }
    public static void RemoveCardsFromHand(int howmany) 
    {
        for (int i = 0; i < howmany; i++)
        {
            hand.RemoveAt(i);
        }
    }
    public static void Draw(int howMany)
    {
        if (handLimit > cardsInDeck)
        {
            handLimit = cardsInDeck;
        }    

        for (int i = 1; i <= howMany; i++)
        {
            if (hand.Count() < handLimit)
            {
                Card SelectedCard = deck[random.Next(0, cardsInDeck)];
                hand.Add(SelectedCard);
                deck.Remove(SelectedCard);
            }
            else
            {
                Console.WriteLine("Hand limit reached.");
            }
        }
    }
}