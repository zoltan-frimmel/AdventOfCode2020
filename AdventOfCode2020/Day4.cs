using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class Day4
    {
        public delegate bool PassportFieldValidator(string value);

        public const string Input            = @".\inputs\day4.txt";
        public const string PartOneTestInput = @".\inputs\Day4_PartOne.txt";
        public const string PartTwoTestInput = @".\inputs\Day4_PartTwo.txt"; // Contains 4 invalid and 4 valid passports

        public static HashSet<string> RequiredFields = new HashSet<string>
            {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

        public static HashSet<string> ValidEyeColors = new HashSet<string>
            {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};

        public static Dictionary<string, PassportFieldValidator> Rules = new Dictionary<string, PassportFieldValidator>
        {
            {"byr", NumberValidator(1920, 2002)},
            {"iyr", NumberValidator(2010, 2020)},
            {"eyr", NumberValidator(2020, 2030)},
            {"hgt", ValidateHeight},
            {"hcl", ValidateHairColor},
            {"ecl", ValidateEyeColor},
            {"pid", ValidatePassportId},
            {"cid", v => true }
        };

        public static int PartOne()
        {
            var passports = SplitIntoPassports(IO.GetAll(Input));

            return passports.Select(
                    s => s
                        .Select(t => t.Substring(0, 3))
                        .ToHashSet())
                .Count(hs => RequiredFields.IsSubsetOf(hs));
        }

        public static int PartTwo()
        {
            var passports = SplitIntoPassports(IO.GetAll(Input));

            return passports.Count(ValidatePassport);
        }

        public static bool ValidatePassport(string[] values)
        {
            var keys = values.Select(v => v.Substring(0, 3)).ToHashSet();

            if (!RequiredFields.IsSubsetOf(keys))
                return false;

            return values
                .Select(value => value.Split(':'))
                .All(kvp => Rules[kvp[0]](kvp[1]));
        }

        public static bool ValidateHeight(string value)
        {
            if (value.EndsWith("cm"))
            {
                return NumberValidator(150, 193)(value.Substring(0, value.Length - 2));
            }

            if (value.EndsWith("in"))
            {
                return NumberValidator(59, 76)(value.Substring(0, value.Length - 2));
            }
            else
                return false;
        }

        public static bool ValidateHairColor(string value)
        {
            return Regex.IsMatch(value, "#[a-f0-9]{6}");
        }

        public static bool ValidateEyeColor(string value)
        {
            return ValidEyeColors.Contains(value);
        }

        public static bool ValidatePassportId(string value)
        {
            if (value.Length != 9)
                return false;

            return uint.TryParse(value, out var _);
        }

        public static PassportFieldValidator NumberValidator(int min, int max)
        {
            return value =>
            {
                if (!int.TryParse(value, out var year))
                    return false;

                return min <= year && year <= max;
            };
        }

        public static string[][] SplitIntoPassports(string input)
        {
            return input
                .Replace("\r\n\r\n", "|")
                .Replace("\r\n", " ")
                .Split('|')
                .Select(s => s.Split(' ').ToArray())
                .ToArray();
        }
    }
}