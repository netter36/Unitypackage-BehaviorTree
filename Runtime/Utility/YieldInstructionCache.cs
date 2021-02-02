using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree.Utility
{
    public static class YieldInstructionCache
    {
        private class FloatComparer : IEqualityComparer<float>
        {
            bool IEqualityComparer<float>.Equals (float x, float y)
            {
                return x.Equals(y);
            }
            int IEqualityComparer<float>.GetHashCode (float obj)
            {
                return obj.GetHashCode();
            }
        }

        public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
        public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

        private static readonly Dictionary<float, WaitForSeconds> TimeInterval = new Dictionary<float, WaitForSeconds>(new FloatComparer());

        public static WaitForSeconds WaitForSeconds(float seconds)
        {
            if (!TimeInterval.TryGetValue(seconds, out var wfs))
                TimeInterval.Add(seconds, wfs = new WaitForSeconds(seconds));
            return wfs;
        }
    }
}