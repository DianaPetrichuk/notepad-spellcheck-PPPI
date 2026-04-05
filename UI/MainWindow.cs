using System;
using System.Windows.Forms;

namespace NotepadApp.UI
{
    /// <summary>
    /// Главное окно приложения.
    /// Предоставляет пользовательский интерфейс редактора:
    /// текстовое поле, строку меню и строку состояния.
    /// </summary>
    public class MainWindow : Form
    {
        /// <summary>
        /// Основная область ввода и редактирования текста.
        /// </summary>
        private RichTextBox textArea;

        /// <summary>
        /// Строка меню главного окна.
        /// </summary>
        private MenuStrip menuStrip;

        /// <summary>
        /// Строка состояния в нижней части окна.
        /// </summary>
        private StatusStrip statusStrip;

        /// <summary>
        /// Метка в строке состояния для вывода сообщений.
        /// </summary>
        private ToolStripStatusLabel statusLabel;

        /// <summary>
        /// Инициализирует новый экземпляр главного окна
        /// и запускает настройку компонентов интерфейса.
        /// </summary>
        public MainWindow()
        {
            InitializeComponents();
        }

        /// <summary>
        /// Выполняет инициализацию и размещение всех
        /// визуальных компонентов главного окна.
        /// </summary>
        private void InitializeComponents()
        {
            this.Text = "Блокнот с проверкой орфографии";
            this.Width = 800;
            this.Height = 600;

            textArea = new RichTextBox();
            textArea.Dock = DockStyle.Fill;

            menuStrip = new MenuStrip();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel("Готово");
            statusStrip.Items.Add(statusLabel);

            this.Controls.Add(textArea);
            this.Controls.Add(menuStrip);
            this.Controls.Add(statusStrip);
        }

        /// <summary>
        /// Обновляет текст в строке состояния.
        /// </summary>
        /// <param name="message">Сообщение для отображения в строке состояния.</param>
        public void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }
    }
}
