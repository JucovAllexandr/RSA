using System;
using System.Numerics;
using Org.BouncyCastle.Math;
using BigInteger = Org.BouncyCastle.Math.BigInteger;

namespace RSA
{
    class Program
    {
        
        static void Main(string[] args)
        {
            RSA rsa = new RSA(512);
            BigInteger c = rsa.Encrypt(new BigInteger("123456"));
            Console.WriteLine("Encrypt: "+c);
            Console.WriteLine("Decrypt: "+rsa.Decrypt(c));
        }
    }
}