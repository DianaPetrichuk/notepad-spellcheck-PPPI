using System;
using System.Windows.Forms;

namespace NotepadApp.UI
{
    // Версия: 1.0
    // Главное окно приложения
    public class MainWindow : Form
    {
        private RichTextBox textArea;
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;

        public MainWindow()
        {
            InitializeComponents();
        }

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

        public void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }
    }
}
