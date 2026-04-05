using System;
using System.IO;
using System.Windows.Forms;

namespace NotepadApp.Core
{
    /// <summary>
    /// Модуль работы с файлами.
    /// Обеспечивает создание, открытие и сохранение документов
    /// в форматах TXT и RTF.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Путь к текущему открытому файлу.
        /// Null если файл ещё не сохранялся.
        /// </summary>
        private string currentFilePath;

        /// <summary>
        /// Флаг наличия несохранённых изменений в документе.
        /// </summary>
        private bool hasUnsavedChanges;

        /// <summary>
        /// Инициализирует модуль работы с файлами.
        /// </summary>
        public FileManager()
        {
            currentFilePath = null;
            hasUnsavedChanges = false;
        }

        /// <summary>
        /// Открывает диалог выбора файла и возвращает его содержимое.
        /// </summary>
        /// <returns>Содержимое выбранного файла в виде строки,
        /// или null если пользователь отменил выбор.</returns>
        public string OpenFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt|RTF файлы (*.rtf)|*.rtf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = dialog.FileName;
                    return File.ReadAllText(currentFilePath);
                }
            }
            return null;
        }

        /// <summary>
        /// Сохраняет содержимое документа в текущий файл.
        /// Если файл не был сохранён ранее — вызывает диалог сохранения.
        /// </summary>
        /// <param name="content">Текст документа для сохранения.</param>
        public void SaveFile(string content)
        {
            if (currentFilePath == null)
                SaveFileAs(content);
            else
            {
                File.WriteAllText(currentFilePath, content);
                hasUnsavedChanges = false;
            }
        }

        /// <summary>
        /// Открывает диалог сохранения и записывает документ по выбранному пути.
        /// </summary>
        /// <param name="content">Текст документа для сохранения.</param>
        public void SaveFileAs(string content)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt|RTF файлы (*.rtf)|*.rtf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = dialog.FileName;
                    File.WriteAllText(currentFilePath, content);
                    hasUnsavedChanges = false;
                }
            }
        }

        /// <summary>
        /// Проверяет наличие несохранённых изменений и при необходимости
        /// предлагает пользователю сохранить документ.
        /// </summary>
        /// <returns>False если пользователь отменил операцию, иначе True.</returns>
        public bool CheckUnsavedChanges()
        {
            if (hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "Есть несохранённые изменения. Сохранить?",
                    "Внимание",
                    MessageBoxButtons.YesNoCancel);
                return result != DialogResult.Cancel;
            }
            return true;
        }

        /// <summary>
        /// Помечает документ как имеющий несохранённые изменения.
        /// </summary>
        public void MarkAsChanged()
        {
            hasUnsavedChanges = true;
        }
    }
}
