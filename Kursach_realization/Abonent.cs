using System.Numerics;

namespace Kursach_realization
{
    class Abonent
    {
        // Публичное поле subset типа List, хранящее кортежи (BigInteger, BigInteger)
        // Список будет использоваться для хранения теневых частей текущего абонента
        public List<Tuple<BigInteger, BigInteger>> subset = new List<Tuple<BigInteger, BigInteger>>();

        // Публичное поле prime типа List, хранящее значения простых чисел
        // Список будет использоваться для хранения простых чисел, используемых для разделения секрета
        public List<BigInteger> prime = new List<BigInteger>();
    }
}
