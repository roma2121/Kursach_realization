using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Concurrent;

namespace Kursach_realization
{
    class Encryptor
    {
        // Размер ключа для шифрования
        public int keySize = 4096;

        public void StartEncrypt()
        {
            EncryptFile();
        }

        public void StartDencrypt()
        {
            (string privateKey, bool res) = KeyAssembly();

            if (res)
            {
                DecryptFile(privateKey);
            }
        }

        // Метод для шифрования выбранного файла с помощью алгоритма RSA
        public void EncryptFile()
        {
            // Инициализация объекта шифрования RSA
            using (RSACng rsa = new RSACng(keySize))
            {
                // Генерация ключей
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                // Вывод сообщения с инструкциями для сохранения теней ключа
                MessageBox.Show("Далее будет необходимо выбрать места для сохранения теней ключа.", "Инструкция", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Вызов метода для сохранения теней ключа
                bool res = SavingKeyShadow(privateKey);

                if (!res)
                {
                    return;
                }

                // Вычисление макисмального размера блока для шифрования
                int maxBlockSize = rsa.KeySize / 8 - 2 * 512 / 8 - 2;

                // Выбор файла для шифрования с помощью диалогового окна открытия файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл для шифрования";

                // Если файл выбран, шифруем его и сохраняем в новый файл
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string saveFilePath = "";

                    // Открытие диалогового окна для выбора места сохранения зашифрованного файла
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Encrypted files (*.enc)|*.enc";
                    saveFileDialog.Title = "Сохраните зашифрованный файл";
                    saveFileDialog.FileName = Path.GetFileName(filePath);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Определение расширения шифруемого файла
                        string extension = Path.GetExtension(filePath);

                        // Сохраняем зашифрованный файл с новым именем
                        saveFilePath = Path.ChangeExtension(saveFileDialog.FileName, extension + ".enc");

                        // Чтение файла и шифрование его блоками
                        using (FileStream readFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        using (FileStream saveFileStream = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write))
                        {
                            byte[] data = new byte[readFileStream.Length];
                            readFileStream.Read(data, 0, data.Length);

                            int blockCount = (int)Math.Ceiling((double)data.Length / maxBlockSize); // количество блоков

                            // Определите максимальное значение прогресса
                            int total = blockCount;

                            for (int i = 0; i < blockCount; i++)
                            {
                                int offset = i * maxBlockSize;
                                int length = Math.Min(maxBlockSize, data.Length - offset);
                                byte[] block = new byte[length];
                                Buffer.BlockCopy(data, offset, block, 0, length);

                                // Шифрование блока данных с помощью открытого ключа RSA
                                byte[] encryptedBlock = rsa.Encrypt(block, RSAEncryptionPadding.OaepSHA512);
                                saveFileStream.Write(encryptedBlock, 0, encryptedBlock.Length);
                            }
                        }
                        MessageBox.Show("Файл зашифрован!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Если пользователь не выбрал файл, выводим сообщение и завершаем выполнение метода
                        MessageBox.Show("Файл не выбран. Выберите файл и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Если пользователь не выбрал файл, выводим сообщение и завершаем выполнение метода
                    MessageBox.Show("Файл не выбран. Выберите файл и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Метод для расшифровки выбранного файла с помощью алгоритма RSA
        private void DecryptFile(string privateKey)
        {
            // Создаем новый объект RSA с заданным размером ключа и загружаем приватный ключ
            RSACng rsa = new RSACng(keySize);

            try
            {
                rsa.FromXmlString(privateKey);
            }
            catch
            {
                MessageBox.Show("Выберите правильные тени ключа для восстановления.", "Ключ не был восстановлен!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисляем максимальный размер блока данных, который можно расшифровать
            int maxBlockSize = rsa.KeySize / 8;

            // Вычисляем максимальный размер блока данных, который можно зашифровать
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Encrypted files (*.enc)|*.enc";
            openFileDialog.Title = "Выберите файл для расшифровки";

            // Если пользователь выбрал файл, то продолжаем работу
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string saveFilePath = "";

                // Извлекаем имя файла без расширения .enc
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string extansion = Path.GetExtension(fileNameWithoutExtension);

                // Открываем диалоговое окно для выбора места, куда нужно сохранить расшифрованный файл
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = $"{extansion.Substring(1).ToUpper()} (*{extansion})|*{extansion}|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохраните расшифрованный файл";
                saveFileDialog.FileName = fileNameWithoutExtension;

                // Если пользователь выбрал место для сохранения, то продолжаем работу
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveFilePath = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }

                // Считываем все байты из выбранного файла
                byte[] data = File.ReadAllBytes(filePath);

                // Вычисляем количество блоков данных
                int blockCount = (data.Length + maxBlockSize - 1) / maxBlockSize;

                // Создаем потокобезопасный словарь для хранения расшифрованных блоков данных
                ConcurrentDictionary<int, byte[]> decryptedBlocks = new ConcurrentDictionary<int, byte[]>();

                // Расшифровываем блоки данных параллельно с помощью Parallel.For
                Parallel.For(0, blockCount, i =>
                {
                    // Вычисляем смещение блока данных и его длину
                    int offset = i * maxBlockSize;
                    int length = Math.Min(maxBlockSize, data.Length - offset);

                    // Копируем данные блока в отдельный буфер
                    byte[] block = new byte[length];
                    Array.Copy(data, offset, block, 0, length);

                    // Расшифровываем блок и добавляем его в словарь
                    byte[] decryptedBuffer = rsa.Decrypt(block, RSAEncryptionPadding.OaepSHA512);
                    decryptedBlocks.TryAdd(i, decryptedBuffer);
                });

                // Сохраняем расшифрованные блоки данных в новый файл
                using (FileStream saveFileStream = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write))
                {
                    for (int i = 0; i < blockCount; i++)
                    {
                        byte[] decryptedBuffer;
                        if (decryptedBlocks.TryGetValue(i, out decryptedBuffer))
                        {
                            saveFileStream.Write(decryptedBuffer, 0, decryptedBuffer.Length);
                        }
                    }
                }

                // Выводим сообщение об успешном расшифровании файла
                MessageBox.Show("Файл расшифрован!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Если пользователь не выбрал файл, выводим сообщение и завершаем выполнение метода
                MessageBox.Show("Файл не выбран. Выберите файл и повторите попытку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод, сохраняющий тень ключа
        private bool SavingKeyShadow(string privateKey)
        {
            // Преобразуем приватный ключ в байты
            byte[] bytes = Encoding.ASCII.GetBytes(privateKey);

            // Создаем массив строк для сохранения данных
            string[] str = new string[5];

            // Задаем диапазон для генерации простых чисел
            int start = 100000;
            int end = 1000000;

            // Генерируем список простых чисел в заданном диапазоне
            List<int> primaryNumber = PrimeGenerator.GeneratePrimesInRange(start, end); // Генерируем список простых чисел в диапазоне

            // Создаем генератор случайных чисел
            Random random = new Random();

            // Для каждого байта в приватном ключе выполняем теневое разделение секрета
            for (int i = 0; i < bytes.Length; i++)
            {
                // Выбираем случайное простое число из списка
                BigInteger prime = primaryNumber[random.Next(0, primaryNumber.Count)]; // Выбираем случайно простое число из списка

                // Выполняем теневое разделение секрета для текущего байта
                List<Tuple<BigInteger, BigInteger>> shares = ShamirSecretSharing.SharingSecret(bytes[i], 3, prime);

                // Сохраняем полученные данные в соответствующие строки массива
                for (int j = 0; j < shares.Count; j++)
                {
                    str[j] += $"{prime}\r\n{shares[j].Item1}\r\n{shares[j].Item2}\r\n";
                }
            }

            // Создаем объект класса FileSaver
            FileSaver fileSaver = new FileSaver();

            // Сохраняем каждую теневую часть в отдельный файл
            for (int i = 0; i < str.Length; i++)
            {
                // Создаем имя файла для текущей теневой части
                string fileName = $"share_{i}.shadow";

                // Запрашиваем у пользователя путь для сохранения текущего файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Теневые файлы (*.shadow)|*.shadow";
                saveFileDialog.FileName = fileName;
                DialogResult result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Получаем путь к выбранному месту для сохранения текущего файла
                    string filePath = saveFileDialog.FileName;

                    // Вызываем метод SaveFile объекта fileSaver, передав ему путь к файлу
                    bool fileSaved = fileSaver.SaveFile(Path.GetPathRoot(filePath));

                    if (!fileSaved)
                    {
                        DialogResult answer = MessageBox.Show("Использование разных внешних носителей для хранения " +
                            "копий ключа является рекомендуемой мерой безопасности, чтобы " +
                            "защитить ключ от потери или утечки данных. Если все копии ключа " +
                            "хранятся на одном устройстве и оно выйдет из строя, или его " +
                            "скомпрометируют злоумышленники, то доступ к защищаемым данным " +
                            "будет утерян. Поэтому следует хранить копии ключа на разных " +
                            "устройствах, например, на внешних жестких дисках, флеш-накопителях " +
                            "или в облачном хранилище, чтобы обеспечить надежную защиту данных." +
                            "\r\n Вы действительно хотите сохранить тень ключа в этом месте?"
                            , "Нарушение безопасности хранения ключей!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (answer == DialogResult.Yes)
                        {
                            // Сохраняем теневую часть в файл
                            using (StreamWriter writer = new StreamWriter(filePath))
                            {
                                string line = str[i].TrimEnd('\r', '\n');
                                writer.WriteLine(line);
                            }
                        }
                        else
                        {
                            i--;
                        }
                    }
                    else
                    {
                        // Сохраняем теневую часть в файл
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            string line = str[i].TrimEnd('\r', '\n');
                            writer.WriteLine(line);
                        }
                    }
                }
                else
                {
                    // Если пользователь не выбрал файл, выводим сообщение и завершаем выполнение метода
                    DialogResult answer = MessageBox.Show("Место для сохранения файла не выбрано. Выберите место для сохранения файла и повторите попытку.", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (answer == DialogResult.Yes)
                    {
                        i--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Метод для генерации секретного ключа на основе нескольких частей, которые хранятся в разных файлах
        private (string, bool) KeyAssembly()
        {
            // Создаем новый список байт, в который будем сохранять секретный ключ
            List<byte> newBytes = new List<byte>();

            // Создаем новый список абонентов
            List<Abonent> abonents = new List<Abonent>();

            // Добавляем в список три новых абонента
            for (int i = 0; i < 3; i++)
            {
                abonents.Add(new Abonent());
            }

            MessageBox.Show("Необходимо поочередно выбрать 3 тени ключа для расшифровки файла.", "Выбор теней", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Проходимся по каждому абоненту и запрашиваем у пользователя путь к файлу с теневой частью
            for (int i = 0; i < 3; i++)
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "Text Files (*.shadow)|*.shadow";
                DialogResult result = openDialog.ShowDialog();

                // Если пользователь выбрал файл
                if (result == DialogResult.OK)
                {
                    string filePath = openDialog.FileName;

                    // Считываем данные из файла
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string primeLine = reader.ReadLine();
                            string xiLine = reader.ReadLine();
                            string yiLine = reader.ReadLine();

                            BigInteger prime = BigInteger.Parse(primeLine);
                            BigInteger xi = BigInteger.Parse(xiLine);
                            BigInteger yi = BigInteger.Parse(yiLine);

                            // Добавляем считанные данные в список текущего абонента
                            abonents[i].subset.Add(new Tuple<BigInteger, BigInteger>(xi, yi));
                            abonents[i].prime.Add(prime);
                        }
                    }
                }
                else
                {
                    // Если пользователь не выбрал файл, выводим сообщение и завершаем выполнение метода
                    DialogResult answer = MessageBox.Show("Файл не выбран. Выбрать файл повторно?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (answer == DialogResult.Yes)
                    {
                        i--;
                    }
                    else
                    {
                        return (null, false);
                    }
                }
            }

            // Проходимся по каждой теневой части и восстанавливаем оригинальный байт
            for (int i = 0; i < abonents[0].prime.Count; i++)
            {
                // Создаем новый список, в который добавляем теневые части всех абонентов
                List<Tuple<BigInteger, BigInteger>> subset = new List<Tuple<BigInteger, BigInteger>>();

                for (int j = 0; j < 3; j++)
                {
                    subset.Add(abonents[j].subset[i]);
                }

                // Восстанавливаем оригинальный байт на основе теневых частей и простого числа
                byte data = ShamirSecretSharing.RecoverSecret(subset, abonents[0].prime[i]);

                // Добавляем байт в новый список байт
                newBytes.Add(data);
            }

            // Преобразуем список байт в строку
            string byte_str = "";

            for (int i = 0; i < newBytes.Count; i++)
            {
                byte_str += newBytes[i];
            }

            // Преобразуем список байт в строку и возвращаем ее в качестве секретного ключа
            string privateKey = ByteArrayToString(newBytes.ToArray());
            return (privateKey, true);
        }

        // Метод ByteArrayToString преобразует массив байт в строку с использованием кодировки ASCII
        public static string ByteArrayToString(byte[] bytes)
        {
            string str = Encoding.ASCII.GetString(bytes);
            return str;
        }
    }
}
