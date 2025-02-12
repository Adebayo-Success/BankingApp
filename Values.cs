public static class Utility
{
    public static int? SelectEnum(string screenMessages, int validStart, int validEnd)
    {
        int outValue;
        while (true)
        {
            Console.WriteLine(screenMessages);
            bool isParsable = int.TryParse(Console.ReadLine(), out outValue);
            if(!isParsable)
            {
                return null;
            }

            if (isParsable && (outValue >= validStart) && (outValue <= validEnd))
            {
                break;
            }
        }
        return outValue;
    }
}