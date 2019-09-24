namespace RSA
{
    public class Helper
    {
        static public Org.BouncyCastle.Math.BigInteger GenerateBigIntegerPrimes(int bits)
        {
            Org.BouncyCastle.Security.SecureRandom ran = new Org.BouncyCastle.Security.SecureRandom();
            Org.BouncyCastle.Math.BigInteger c = new Org.BouncyCastle.Math.BigInteger(bits, ran);
            
            for (; ; )
            {
                if (c.IsProbablePrime(100) == true) break;
                c = c.Subtract(new Org.BouncyCastle.Math.BigInteger("1"));
            }
            return (c);
        }
    }
}