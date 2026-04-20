using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotepadApp.UI
{
    /// <summary>
    /// Перечисление доступных тем оформления интерфейса.
    /// </summary>
    public enum Theme
    {
        /// <summary>Светлая тема.</summary>
        Light,
        /// <summary>Тёмная тема.</summary>
        Dark,
        /// <summary>Системная тема (определяется настройками ОС).</summary>
        System
    }

    /// <summary>
    /// Менеджер тем оформления интерфейса.
    /// Отвечает за применение и хранение текущей темы приложения.
    /// </summary>
    public class ThemeManager
    {
        /// <summary>
        /// Текущая активная тема оформления.
        /// </summary>
        private Theme currentTheme;

        /// <summary>
        /// Инициализирует менеджер тем со значением по умолчанию — системная тема.
        /// </summary>
        public ThemeManager()
        {
            currentTheme = Theme.System;
        }

        /// <summary>
        /// Применяет выбранную тему оформления к указанной форме.
        /// </summary>
        /// <param name="form">Форма, к которой применяется тема.</param>
        /// <param name="theme">Тема оформления для применения.</param>
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

        /// <summary>
        /// Возвращает текущую активную тему оформления.
        /// </summary>
        /// <returns>Значение перечисления <see cref="Theme"/>.</returns>
        public Theme GetCurrentTheme()
        {
            return currentTheme;
        }
    }
}
