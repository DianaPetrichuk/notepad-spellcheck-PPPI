using System;
using System.IO;
using System.Windows.Forms;

namespace NotepadApp.Core
{
    // Версия: 1.0
    // Модуль работы с файлами
    public class FileManager
    {
        private string currentFilePath;
        private bool hasUnsavedChanges;

        public FileManager()
        {
            currentFilePath = null;
            hasUnsavedChanges = false;
        }

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

        public void MarkAsChanged()
        {
            hasUnsavedChanges = true;
        }
    }
}
