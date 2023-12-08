static int Part1(string[] input)
{
    List<HandPart1> hands = new();
    foreach (var line in input)
    {
        string cards = line.Split(' ')[0];
        hands.Add(new HandPart1(cards, int.Parse(line.Trim().Split(' ')[1])));
    }
    
    hands.Sort();

    int sum = 0;

    for (int i = 0; i < hands.Count; i++)
    {
        sum += hands[i].Bid * (i+1); 
    }

    return sum;
}

static int Part2(string[] input)
{
    List<HandPart2> hands = new();
    foreach (var line in input)
    {
        string cards = line.Split(' ')[0];
        hands.Add(new HandPart2(cards, int.Parse(line.Trim().Split(' ')[1])));
    }
    
    hands.Sort();

    int sum = 0;

    for (int i = 0; i < hands.Count; i++)
    {
        sum += hands[i].Bid * (i+1); 
    }

    return sum;
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine("Part 1: " + Part1(input));
Console.WriteLine("Part 2: " + Part2(input));


#region Classes
public class Hand
{
    public string Cards { get; set; }
    public int Bid { get; set; }
    public Hand(string cards, int bid)
    {
        Cards = cards;
        Bid = bid;
    }

    public int GetTypeValue()
    {
        var duplicates = Cards.Distinct();
        if (duplicates.Count() == Cards.Length)
            return 0;

        switch (duplicates.Count())
        {
            case 5:
                return 0;
            case 4:
                return 1;
            case 3:
                int highestCount = 1;
                foreach (char duplicate in duplicates)
                {
                    var count3 = Cards.Where(x => x == duplicate).Count();
                    if (count3 > highestCount)
                        highestCount = count3;
                }

                if (highestCount == 3)
                    return 3;
                else
                    return 2;
            case 2:
                int count2 = Cards.Where(x => x == duplicates.First()).Count();
                if (count2 == 4 || count2 == 1)
                    return 5;
                else
                    return 4;
            case 1:
                return 6;
        }
        return 0;
    }
}
public class HandPart1 : Hand, IComparable<HandPart1>
{
    public HandPart1(string cards, int bid) : base(cards, bid)
    {
    }

    public int CompareTo(HandPart1? other)
    {
        List<char> cardStrengthOrder = new(){ 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
        if (other == null)
            return 0;

        int otherTypeValue = other.GetTypeValue();
        int thisTypeValue = GetTypeValue();

        if (thisTypeValue < otherTypeValue)
        {
            return -1;
        }
        else if (thisTypeValue > otherTypeValue)
        {
            return +1;
        }else
        {
            int index = 0;
            char otherElement;
            char thisElement;

            do
            {
                otherElement = other.Cards[index];
                thisElement = Cards[index];

                var thisValue = cardStrengthOrder.FindIndex(x => x == Cards[index]);
                var otherValue = cardStrengthOrder.FindIndex(x => x == other.Cards[index]);

                if (thisValue < otherValue)
                    return +1;
                else if (thisValue > otherValue)
                    return -1;

                index++;
            } while (otherElement == thisElement && index < 5);

            return 0;
        }
    }
}

public class HandPart2 : Hand, IComparable<HandPart2>
{
    public HandPart2(string cards, int bid) : base(cards, bid)
    {
    }

    public int CompareTo(HandPart2? other)
    {
        List<char> cardStrengthOrder = new(){ 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' };
        if (other == null)
            return 0;

        int otherTypeValue = other.GetTypeValue();
        int thisTypeValue = GetTypeValue();

        foreach (char card in cardStrengthOrder)
        {
            var otherHand = new Hand(other.Cards.Replace('J', card), 0);
            if (otherHand.GetTypeValue() > otherTypeValue)
                otherTypeValue = otherHand.GetTypeValue();

            var thisHand = new Hand(Cards.Replace('J', card), 0);
            if (thisHand.GetTypeValue() > thisTypeValue)
                thisTypeValue = thisHand.GetTypeValue();
        }

        if (thisTypeValue < otherTypeValue)
        {
            return -1;
        }
        else if (thisTypeValue > otherTypeValue)
        {
            return +1;
        }else
        {
            int index = 0;
            char otherElement;
            char thisElement;

            do
            {
                otherElement = other.Cards[index];
                thisElement = Cards[index];

                var thisValue = cardStrengthOrder.FindIndex(x => x == Cards[index]);
                var otherValue = cardStrengthOrder.FindIndex(x => x == other.Cards[index]);

                if (thisValue < otherValue)
                    return +1;
                else if (thisValue > otherValue)
                    return -1;

                index++;
            } while (otherElement == thisElement && index < 5);

            return 0;
        }
    }
}

#endregion Classes