using System.Collections.Generic;
using System;

namespace BehaviorTree.Utility
{
    public enum ShuffleMode
    {
        Fast,
        Security,
        ThreadSafe
    }

    public static class MoreExtension
    {
        public static void Shuffle<T>(this IList<T> list, ShuffleMode shuffleMode = ShuffleMode.Fast)
        {
            switch (shuffleMode)
            {
                case ShuffleMode.Fast:
                    list.FastShuffle();
                    break;
                case ShuffleMode.Security:
                    list.SecurityShuffle();
                    break;
                case ShuffleMode.ThreadSafe:
                    list.SafeShuffle();
                    break;
                default:
                    throw new Exception("Please set the correct mode.");
            }
        }

        private static void FastShuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1) {
                n--;
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void SecurityShuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private static void SafeShuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}