using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    internal static class Shared
    {
        public static string[] GetLineData(string line)
        {
            return line.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        public static int ConvertToInt32(string stringToConvert, string argumentName = null)
        {
            if (int.TryParse(stringToConvert, out int number))
                return number;
            if (string.IsNullOrEmpty(argumentName))
                argumentName = "Argument";
            throw new ArgumentException($"\"{argumentName}\" cannot be parsed as integer.");
        }

        public static void CheckCondition<T>(T resultToCheck, Predicate<T> term, string failedMessage)
        {
            if (!term(resultToCheck))
                throw new ArgumentException(failedMessage);
        }
    }
}
