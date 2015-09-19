using System;

class WaveBits
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        bool isInWave = false;
        byte currentBit = 0;
        byte start = 0;
        byte end = 0;
        byte largestWaveStart = 0;
        byte largestWaveEnd = 0;

        for (byte bitPos = 0; bitPos < 64; bitPos++)
        {
            ulong mask = number >> bitPos;

            byte bit = (byte)(mask & 1);
            if (!isInWave)
            {
                if (bit == 1)
                {
                    isInWave = true;
                    currentBit = bit;
                    start = bitPos;
                }
            }
            else
            {
                if (bit != currentBit)
                {
                    currentBit = bit;
                }
                else
                {
                    isInWave = false;
                    if (currentBit == 1)
                    {
                        end = (byte)(bitPos - (byte)1);
                    }
                    else
                    {
                        end = (byte)(bitPos - (byte)2);
                    }

                    if (end - start != 0)
                    {
                        if ((end - start) > (largestWaveEnd - largestWaveStart))
                        {
                            largestWaveStart = start;
                            largestWaveEnd = end;
                        }
                    }
                }

            }
        }


        if (isInWave)
        {
            if (currentBit == 0)
            {
                end = 62;
            }
            else
            {
                end = 63;
            }

            if (end - start != 0)
            {
                if ((end - start) > (largestWaveEnd - largestWaveStart))
                {
                    largestWaveStart = start;
                    largestWaveEnd = end;
                }
            }
        }

        if (largestWaveEnd - largestWaveStart <= 1)
        {
            Console.WriteLine("No waves found!");
        }
        else
        {
            ulong mask = 0;
            for (int count = 0; count < largestWaveStart; count++)
            {
                mask <<= 1;
                mask |= 1;
            }

            ulong leftPart = number >> largestWaveEnd + 1;

            // If shifted by more that 63 - wrong results.
            if (largestWaveEnd == 63)
            {
                leftPart = 0;
            }

            ulong rightPart = mask & number;

            ulong result = 0;
            result = rightPart;
            mask = leftPart << largestWaveStart;
            result |= mask;

            Console.WriteLine(result);

        }
    }
}