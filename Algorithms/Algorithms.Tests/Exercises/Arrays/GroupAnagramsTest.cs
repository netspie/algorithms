using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algorithms.Tests.Exercises;

public class GroupAnagramsTests
{
    

    [Test]
    public void GroupAnagramTest()
    {
        Assert.That(
            GroupAnagrams(["act", "pots", "tops", "cat", "stop", "hat"])
                .Zip(new List<List<string>> { new() { "act", "cat" }, new() { "pots", "tops", "stop" }, new() { "hat" } })
                .Select((data, y) => data.First.SequenceEqual(data.Second)).All(r => r is true));

        Assert.That(
            GroupAnagrams([""])
                .Zip(new List<List<string>> { new() { "" } })
                .Select((data, y) => data.First.SequenceEqual(data.Second)).All(r => r is true));

        Assert.That(
            GroupAnagrams(["ape", "pea", "tax"])
                .Zip(new List<List<string>> { new() { "ape", "pea" }, new() { "tax" } })
                .Select((data, y) => data.First.SequenceEqual(data.Second)).All(r => r is true));
    }

    public record Block
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }
        public int e { get; set; }
        public int f { get; set; }
        public int g { get; set; }
        public int h { get; set; }
        public int i { get; set; }
        public int j { get; set; }
        public int k { get; set; }
        public int l { get; set; }
        public int m { get; set; }
        public int n { get; set; }
        public int o { get; set; }
        public int p { get; set; }
        public int q { get; set; }
        public int r { get; set; }
        public int s { get; set; }
        public int t { get; set; }
        public int u { get; set; }
        public int v { get; set; }
        public int w { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        // Indexer for accessing/modifying fields based on their alphabetical index ('a' to 'z')
        public int this[char letter]
        {
            get
            {
                return letter switch
                {
                    'a' => a,
                    'b' => b,
                    'c' => c,
                    'd' => d,
                    'e' => e,
                    'f' => f,
                    'g' => g,
                    'h' => h,
                    'i' => i,
                    'j' => j,
                    'k' => k,
                    'l' => l,
                    'm' => m,
                    'n' => n,
                    'o' => o,
                    'p' => p,
                    'q' => q,
                    'r' => r,
                    's' => s,
                    't' => t,
                    'u' => u,
                    'v' => v,
                    'w' => w,
                    'x' => x,
                    'y' => y,
                    'z' => z,
                    _ => throw new ArgumentOutOfRangeException(nameof(letter), "Letter must be between 'a' and 'z'.")
                };
            }
            set
            {
                switch (letter)
                {
                    case 'a': a = value; break;
                    case 'b': b = value; break;
                    case 'c': c = value; break;
                    case 'd': d = value; break;
                    case 'e': e = value; break;
                    case 'f': f = value; break;
                    case 'g': g = value; break;
                    case 'h': h = value; break;
                    case 'i': i = value; break;
                    case 'j': j = value; break;
                    case 'k': k = value; break;
                    case 'l': l = value; break;
                    case 'm': m = value; break;
                    case 'n': n = value; break;
                    case 'o': o = value; break;
                    case 'p': p = value; break;
                    case 'q': q = value; break;
                    case 'r': r = value; break;
                    case 's': s = value; break;
                    case 't': t = value; break;
                    case 'u': u = value; break;
                    case 'v': v = value; break;
                    case 'w': w = value; break;
                    case 'x': x = value; break;
                    case 'y': y = value; break;
                    case 'z': z = value; break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(letter), "Letter must be between 'a' and 'z'.");
                }
            }
        }
    }

    class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[]? x, T[]? y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode([DisallowNull] T[] arr)
        {
            unchecked
            {
                int hash = 17; // Start with a prime number
                foreach (T element in arr)
                {
                    hash = hash * 23 + element?.GetHashCode() ?? 0;
                }
                return hash;
            }
        }
    }

    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<Block, List<string>>();

        for (int i = 0; i < strs.Length; i++)
        {
            var block = new Block();
            for (int j = 0; j < strs[i].Length; j++)
                block[strs[i][j]]++;

            if (!map.TryGetValue(block, out var items))
                map.Add(block, items = new());

            items.Add(strs[i]);
        }

        return map.Values.ToList();
    }
}
