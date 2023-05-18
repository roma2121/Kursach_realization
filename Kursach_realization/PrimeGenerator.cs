namespace Kursach_realization
{
    class PrimeGenerator
    {
        // Метод для генерации списка простых чисел в диапазоне [start, end]
        public static List<int> GeneratePrimesInRange(int start, int end)
        {
            // Создаем пустой список простых чисел
            List<int> primes = new List<int>();

            // Создаем булевский массив для хранения информации о том, является ли число простым
            bool[] isPrime = new bool[end + 1];

            // Инициализируем все числа как простые
            for (int i = 2; i <= end; i++)
            {
                isPrime[i] = true;
            }

            // Помечаем все кратные числа как составные
            for (int i = 2; i * i <= end; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= end; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            // Добавляем простые числа в диапазоне в список
            for (int i = Math.Max(start, 2); i <= end; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            // Возвращаем список простых чисел
            return primes;
        }
    }
}
