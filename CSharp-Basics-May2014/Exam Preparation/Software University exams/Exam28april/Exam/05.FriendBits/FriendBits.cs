using System;
class FriendBits
{
    static void Main()
    {
        uint N = uint.Parse(Console.ReadLine());
        string friendBits = "";
        string aloneBits = "";
        string bitsToAdd = "";
        uint bit = 0;
        int count = 0;
        while (N > 0)
        {
            bit = N & 1;
            bitsToAdd += bit;
            count++;
            uint nextBit = (N >> 1) & 1;
            N >>= 1;
            if (nextBit != bit && count == 1)
            {
                aloneBits += bitsToAdd;
                bitsToAdd = "";
                count = 0;
            }
            else if (nextBit != bit && count > 1)
            {
                friendBits += bitsToAdd;
                bitsToAdd = "";
                count = 0;
            }
        }

        friendBits = Reverse(friendBits);
        aloneBits = Reverse(aloneBits);
        uint friends = 0;
        uint alones = 0;
        if (friendBits != "")
        {
            friends = Convert.ToUInt32(friendBits, 2);
        }

        if (aloneBits != "")
        {
            alones = Convert.ToUInt32(aloneBits, 2);
        }
        Console.WriteLine(friends);
        Console.WriteLine(alones);
    }

    public static string Reverse(string s)
    {
        if (s == "") return "";

        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
