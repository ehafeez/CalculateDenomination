using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculateDenomination
{
    class Program
    {
        /// <summary>
        /// didn't handle the odds, double mount, what will be the maximum amount???
        /// </summary>
        private static readonly List<int> denominations = new List<int>() { 10, 50, 100 };
        static void Main(string[] args)
        {           
            var amount = 100; //Enter the amount to calculate the denominations

            List<int> euros = new List<int>();
            Calculate(euros, denominations, 0, 0, amount);
            Console.ReadLine();
        }

        /// <summary>
        /// Calculate the Denomination
        /// </summary>
        /// <param name="euros"></param>
        /// <param name="amounts"></param>
        /// <param name="max"></param>
        /// <param name="total"></param>
        /// <param name="target"></param>
        static void Calculate(List<int> euros, List<int> amounts, int max, int total, int target)
        {
            if (total == target)
            {
                ShowDenomination(euros);
                return;
            }

            if (total > target)
            {
                return;
            }

            foreach (int amt in amounts)
            {
                if (amt >= max)
                {
                    List<int> getEuros = new List<int>(euros) { amt };
                    Calculate(getEuros, amounts, amt, total + amt, target);
                }
            }
        }

        /// <summary>
        /// Display the calculations
        /// </summary>
        /// <param name="amount"></param>
        static void ShowDenomination(List<int> amount)
        {
            var calculation = amount.GroupBy(u => u).Select(p => new { note = p.Key, total = p.Count() }).ToList();
            StringBuilder result = new StringBuilder();

            foreach (var item in calculation)
            {
                result.Append($"{item.total} x {item.note} EUR ").Append("+ ");
            }

            result = result.Remove(result.Length - 2, 1);
            Console.WriteLine(result.ToString());
        }
    }
}