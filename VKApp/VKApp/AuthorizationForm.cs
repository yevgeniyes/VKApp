using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKApp
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            VKApiOperationBase loginOperation = new VKApiOperationBase();
            loginOperation.Login(webBrowser);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string token;
            string id;

            VKApiOperationBase tokenOperation = new VKApiOperationBase();
            token = tokenOperation.GetToken(webBrowser, out id);
        }
    }
}
