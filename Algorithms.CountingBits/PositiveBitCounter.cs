// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

using System.Collections;
using System.Linq;
using Payvision.CodeChallenge.Base.Helpers;
using System;
using System.Collections.Generic;

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    #region Interface
    /// <summary>
    /// interface for bit counter operations
    /// </summary>
    public interface IBitCounter
    {
        /// <summary>
        /// Converts integer to binary and counts number of 0's and 1's
        /// </summary>
        /// <param name="input"></param>
        /// <returns>IEnumerable&lt;int&gt;</returns>
        IEnumerable<int> Count(int input);
    }
    #endregion

    #region Implementation
    /// <summary>
    /// Positive Bit Counter
    /// </summary>
    public class PositiveBitCounter : IBitCounter
    {
        /// <summary>
        /// Converts integer to binary and counts number of 0's and 1's
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IEnumerable<int> Count(int input)
        {
            Guard.IsPositive(input, () => input);

            var searchResult = new List<int>();
            var bitArray = new BitArray(BitConverter.GetBytes(input));

            var searchPosition = 0;
            int positiveBits = 0;
            var bitsEnumerator = bitArray.Cast<bool>().GetEnumerator();

            while (bitsEnumerator.MoveNext())
            {
                if (bitsEnumerator.Current)
                {
                    searchResult.Add(searchPosition);
                    positiveBits++;
                }
                searchPosition++;
            }

            searchResult.Insert(0, positiveBits);

            return searchResult;
        }
    }
    #endregion
}