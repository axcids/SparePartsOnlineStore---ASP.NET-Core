using System;
using System.Linq;
using System.Text;

namespace Spareparts.Application.UPCGenerator;

public class UpcGenerator {

    private static readonly Random rng = new();
    public static string GenerateRandom() {
        int[] digits = new int[12];

        for (int i = 0; i < 11; i++)
            digits[i] = rng.Next(10);       // 0–9

        digits[11] = ComputeCheck(digits);  // last digit
        return DigitsToString(digits);
    }
    public static string FromPrefix(string prefix11) {
        if (prefix11 == null || prefix11.Length != 11 || !IsDigits(prefix11))
            throw new ArgumentException("Must supply exactly 11 numeric characters.", nameof(prefix11));

        int[] digits = StringToDigits(prefix11);
        Array.Resize(ref digits, 12);       // room for check
        digits[11] = ComputeCheck(digits);

        return DigitsToString(digits);
    }
    public static bool IsValid(string upc12) {
        if (upc12 == null || upc12.Length != 12 || !IsDigits(upc12))
            return false;

        int[] digits = StringToDigits(upc12);
        return digits[11] == ComputeCheck(digits);
    }
    private static int ComputeCheck(int[] digits) {
        int sum = 0;
        for (int i = 0; i < 11; i++) {
            int weight = (i % 2 == 0) ? 3 : 1;   // positions 0‒10
            sum += digits[i] * weight;
        }
        return (10 - (sum % 10)) % 10;
    }
    private static bool IsDigits(string s) {
        foreach (char c in s)
            if (c < '0' || c > '9') return false;
        return true;
    }

    private static int[] StringToDigits(string s) {
        int[] a = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
            a[i] = s[i] - '0';
        return a;
    }

    private static string DigitsToString(int[] a) {
        char[] chars = new char[a.Length];
        for (int i = 0; i < a.Length; i++)
            chars[i] = (char)('0' + a[i]);
        return new string(chars);
    }




}
