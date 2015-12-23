using System;
using System.Security.Cryptography;

namespace Algorithms
{
    public class CryptoRandom : Random
    {
        private RandomNumberGenerator randomNumberGenerator;

        public CryptoRandom()
        {
            randomNumberGenerator = RandomNumberGenerator.Create();
        }

        public override int Next()
        {
            return Next(0, int.MaxValue);
        }

        public override int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        public override int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) 
                + minValue;
        }

        public override void NextBytes(byte[] buffer)
        {
            randomNumberGenerator.GetBytes(buffer);
        }

        public override double NextDouble()
        {
            var bytes = new byte[4];
            randomNumberGenerator.GetBytes(bytes);
            return (double)BitConverter.ToUInt32(bytes, 0) / UInt32.MaxValue;
        }

        protected override double Sample()
        {
            return NextDouble();
        }
    }
}
