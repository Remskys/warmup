using System;

namespace dummy_app.Helpers
{
    public static class FakeLoadHelper
    {
        private const int Baseline = 9999 * 1000;
        private static readonly Random _rnd = new Random();

        public static void EmulateCpuLoad(int multiplier)
        {
            double f = 0;
            while (f < 1)
            {
                f += f + _rnd.NextDouble();
            }
            for (int i = 1; i < Baseline * multiplier; i++)
            {
                f = Math.Pow(f, i);
            }
        }
    }
}