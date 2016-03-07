using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            new AuthorizationForm().Show();
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            VKApiOperationBase logoutOperation = new VKApiOperationBase();
            logoutOperation.Logout();
        }
    }
}
