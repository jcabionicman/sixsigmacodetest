namespace CodingChallenge
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) => n == 0 ? 1 : n * GetFactorial(n - 1);

        public static string FormatSeparators(params string[] items) => string.Join(',', items);
    }
}