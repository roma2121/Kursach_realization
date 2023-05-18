namespace Kursach_realization
{
    public class FileSaver
    {
        // Создаем приватное поле, которое будет хранить пути к сохраненным файлам
        private readonly List<string> savedFilePaths = new List<string>();


        // Метод для сохранения файла
        // Принимает путь к файлу, который нужно сохранить
        // Возвращает true, если файл успешно сохранен, и false, если место сохранения уже использовалось
        public bool SaveFile(string filePath)
        {
            // Проверяем, содержится ли данный путь в списке сохраненных файлов
            if (savedFilePaths.Contains(filePath))
            {
                // Если путь уже использовался, возвращаем false
                return false;
            }
            else
            {
                // Если путь не использовался, добавляем его в список сохраненных файлов
                savedFilePaths.Add(filePath);

                // Возвращаем true, так как файл успешно сохранен
                return true;
            }
        }
    }
}
