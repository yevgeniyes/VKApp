using System;
using System.Windows.Forms;
using System.IO;

namespace VKApp
{
    /// <summary>
    /// Base class for operation with VK API
    /// </summary>
    class VKApiOperationBase
    {
        private string appId = "5339510";
        private string scope = "audio";

        /// <summary>
        /// Performing Login operation
        /// </summary>
        public void Login(WebBrowser webBrowser)
        {
            string url = "https://oauth.vk.com/authorize?client_id=" + appId + "&display=popup&redirect_uri=https://oauth.vk.com/blank.html&scope=" + scope + "&response_type=token&v=5.45";
            webBrowser.Navigate(url);
        }

        /// <summary>
        /// Return token and id
        /// </summary>
        public string GetToken(WebBrowser webBrowser, out string id)
        {
            if (webBrowser.Url.ToString().Contains("#access_token"))
            {
                string splitedUrl = webBrowser.Url.ToString().Split('#')[1];
                string token = splitedUrl.Split('&')[0].Split('=')[1];
                id = splitedUrl.Split('=')[3];
                MessageBox.Show("Authorization successful!\n\nToken = " + token + "\nID = " + id);
                Form.ActiveForm.Close();
                return token;
            }
            else
            {
                id = null;
                return null;
            }
        }

        /// <summary>
        /// Performing Logout operation by deleting cookies
        /// </summary>
        public void Logout()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
            string[] cookies = Directory.GetFiles(path);
            bool isDeleted = false;

            foreach (string cookie in cookies)
            {
                try
                {
                    File.Delete(cookie);
                    isDeleted = true;
                }
                catch
                {}
            }
            if (isDeleted) MessageBox.Show("Logout completed!\nRestart the app to Login");
        }
    }
}
