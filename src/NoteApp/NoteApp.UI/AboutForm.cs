using System.Windows.Forms;
using System.Diagnostics;

namespace NoteApp.UI
{
    /// <summary>
    /// Окно "О программе".
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Создает экземпляр <see cref="AboutForm"/>.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:makovskiynd@yandex.com");
        }

        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/pelemew/Note");
        }
    }
}
