using System.Numerics;

namespace Kursach_realization
{
    // Класс для реализации схемы разделения секрета Шамира
    static class ShamirSecretSharing
    {
        // Метод для генерации пар (xi, yi) для всех участников, используя случайно сгенерированный полином f(x)
        // secret - секретное значение, которое нужно разделить
        // minParticipants - минимальное количество участников, необходимое для восстановления секрета
        // prime - простое число, используемое в арифметике по модулю
        public static List<Tuple<BigInteger, BigInteger>> SharingSecret(byte secret, int minParticipants, BigInteger prime)
        {
            List<Tuple<BigInteger, BigInteger>> shares;

            Random random = new Random();

            // Генерируем случайные коэффициенты для полинома f(x)
            BigInteger[] a = new BigInteger[minParticipants - 1];
            for (int i = 0; i < minParticipants - 1; i++)
            {
                a[i] = new BigInteger(random.Next((int)prime));
            }

            // Строим полином f(x)
            Func<BigInteger, BigInteger> f = x =>
            {
                BigInteger result = new BigInteger(secret);
                for (int i = 0; i < minParticipants - 1; i++)
                {
                    result += a[i] * BigInteger.Pow(x, i + 1);
                }
                return result % prime;
            };

            // Генерируем пары значений (xi, yi) для всех участников
            int n = 5;
            shares = new List<Tuple<BigInteger, BigInteger>>();
            for (int i = 0; i < n; i++)
            {
                BigInteger xi = new BigInteger(random.Next((int)prime));
                BigInteger yi = f(xi);
                shares.Add(new Tuple<BigInteger, BigInteger>(xi, yi));
            }

            return shares;
        }

        // Метод для восстановления секрета по заданному подмножеству пар (xi, yi)
        // subset - подмножество пар (xi, yi)
        // prime - простое число, используемое в арифметике по модулю
        public static byte RecoverSecret(List<Tuple<BigInteger, BigInteger>> subset, BigInteger prime)
        {
            int _minParticipants = 3; // минимальное количество участников, необходимое для восстановления секрета

            // Проверяем, что выбрано достаточное число участников для восстановления секрета
            if (subset.Count < _minParticipants)
            {
                throw new ArgumentException("Not enough shares to recover secret.");
            }

            // Вычисляем полином Лагранжа L(x) по выбранным парам значений (xi, yi)
            Func<BigInteger, BigInteger> lagrange = x =>
            {
                BigInteger result = 0;
                for (int i = 0; i < subset.Count; i++)
                {
                    BigInteger xi = subset[i].Item1;
                    BigInteger yi = subset[i].Item2;

                    BigInteger numerator = 1;
                    BigInteger denominator = 1;

                    for (int j = 0; j < subset.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        BigInteger xj = subset[j].Item1;

                        numerator *= x - xj;
                        denominator *= xi - xj;
                    }

                    result += yi * numerator * BigInteger.ModPow(denominator, prime - 2, prime);
                }

                return (result % prime + prime) % prime;
            };

            // Восстанавливаем секретное значение
            BigInteger recoveredSecret = lagrange(0);

            // Преобразуем BigInteger в byte
            byte[] byteArray = recoveredSecret.ToByteArray();
            byte recoveredSecretByte = byteArray[0];

            return recoveredSecretByte;
        }
    }
}
