using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadApp.UI
{
    // Версия: 1.0
    // Менеджер тем оформления
    public enum Theme { Light, Dark, System }

    public class ThemeManager
    {
        private Theme currentTheme;

        public ThemeManager()
        {
            currentTheme = Theme.System;
        }

        public void ApplyTheme(Form form, Theme theme)
        {
            currentTheme = theme;
            switch (theme)
            {
                case Theme.Light:
                    form.BackColor = Color.White;
                    form.ForeColor = Color.Black;
                    break;
                case Theme.Dark:
                    form.BackColor = Color.FromArgb(30, 30, 30);
                    form.ForeColor = Color.White;
                    break;
                case Theme.System:
                    form.BackColor = SystemColors.Window;
                    form.ForeColor = SystemColors.WindowText;
                    break;
            }
        }

        public Theme GetCurrentTheme()
        {
            return currentTheme;
        }
    }
}
