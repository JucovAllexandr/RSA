using System;
using System.Numerics;
using Org.BouncyCastle.Math;
using BigInteger = Org.BouncyCastle.Math.BigInteger;

namespace RSA
{
    public class RSA
    {
        private  BigInteger p;
        private  BigInteger q;
        private  BigInteger n;
        private  BigInteger fn;
        private  BigInteger e;
        private  BigInteger d;
        public RSA(int bits)
        {
            p = Helper.GenerateBigIntegerPrimes(bits);
            //p = new Org.BouncyCastle.Math.BigInteger("3557");
            q = Helper.GenerateBigIntegerPrimes(bits);
            //q = new Org.BouncyCastle.Math.BigInteger("2579");
            Console.WriteLine("p generated "+ p);
            Console.WriteLine("q generated "+ q);
            n = p.Multiply(q);
            Console.WriteLine("n = "+ n);
            BigInteger p1 = p.Subtract(new BigInteger("1"));
            BigInteger q1 = q.Subtract(new BigInteger("1"));
            fn = p1.Multiply(q1); 
            Console.WriteLine("Функция Эйлера = "+ fn);
            int[] er = new[] {17, 257, 65537};
            Random rand = new Random((int)System.DateTime.Now.Ticks);
            e = new BigInteger(er[rand.Next(0, er.Length)].ToString());
            Console.WriteLine("e = "+ e);
            
            d = e.ModInverse(fn);
            Console.WriteLine("d = "+ d);

            Console.WriteLine("Public Key: " + e + ", " + n);
            Console.WriteLine("Private Key: " + d + ", " + n);
        }

        public BigInteger Encrypt(BigInteger m)
        {
           /* e = new BigInteger("3");
            m = new BigInteger("111111");
            n = new BigInteger("9173503");*/
           Console.WriteLine("Encrypt message: "+m);
            return m.ModPow(e, n);
        }
        
        public BigInteger Decrypt(BigInteger c)
        {
           /* d = new BigInteger("6111579");*/
            return c.ModPow(d, n);
        }
    }
}