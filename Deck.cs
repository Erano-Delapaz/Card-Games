using System.Collections;
using System.Reflection.Emit;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

public class Deck
{
    public enum Suit {
        Club , 
        Spade, 
        Heart,
        Diamond
    }

    public enum Value {
        Ace = 1, 
        Two = 2, 
        Three = 3, 
        Four = 4, 
        Five = 5, 
        Six = 6, 
        Seven = 7, 
        Eight = 8, 
        Nine = 9, 
        Ten = 10, 
        Jack = 11, 
        Queen = 12, 
        King = 13
    }
    
    //array to store cards in deck 
    List<Card> deckArray = new List<Card>(); 
    
    public Deck() {
        
        foreach(int n in Enum.GetValues<Value>()) {
            Card c = new Card(n, Suit.Club); 
            Card c2 = new Card(n, Suit.Diamond);
            Card c3 = new Card(n, Suit.Heart);
            Card c4 = new Card(n, Suit.Spade); 

            deckArray.Add(c); 
            deckArray.Add(c2); 
            deckArray.Add(c3); 
            deckArray.Add(c4); 
        }
    }

    public void showDeck() {
        foreach(Card c in deckArray) {
            if(c.value == 1) {
                Console.Write("[" + Deck.Value.Ace + "," + suitDisplay(c.suit) + "]"); 
            }
            else if(c.value == 11){
                Console.Write("[" + Deck.Value.Jack + "," + suitDisplay(c.suit) + "]"); 
            }
            else if(c.value == 12){
                Console.Write("[" + Deck.Value.Queen + "," + suitDisplay(c.suit) + "]"); 
            }
            else if(c.value == 13){
                Console.Write("[" + Deck.Value.King + "," + suitDisplay(c.suit) + "]"); 
            }
            else {
                Console.Write("[" + c.value + "," + suitDisplay(c.suit) + "]"); 
            }
        }
    }
    
    //converts suit to a Unicode string to display as a pictogram
    public string suitDisplay(Suit su) {
        string suitStr = ""; 
            if(su == Suit.Club) {
                suitStr = "\u2663";
            }
            else if(su == Suit.Diamond) {
                suitStr = "\u2666";
            }
            else if(su == Suit.Heart) {
                suitStr = "\u2665";
            }
            else if(su == Suit.Spade) {
                suitStr = "\u2660";
            }
        return suitStr; 
    }

    public void shuffle() {
        var rand = new Random(); 
        List<Card> tempDeckArray = new List<Card>(52);  
        foreach(Card c in this.deckArray) {
            int i = rand.Next(52);
            tempDeckArray.Add(this.deckArray[i]); 
        }
        this.deckArray = tempDeckArray; 
    }

    private class Card {
        public int value {get; set;} 
        public Suit suit {get; set;}

    
        public Card(int v, Suit s) {
            value = v; 
            suit = s;  
        } 
    }
}
