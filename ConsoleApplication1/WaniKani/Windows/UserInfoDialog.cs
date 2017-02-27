using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaniKani
{
    class UserInfoDialog : Form
    {
        private UserInfo userInfo;
        private PictureBox pictureBox1 = new PictureBox();

        public UserInfoDialog(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }

        public void show()
        {
            var consoleBounds = Screen.PrimaryScreen.Bounds;
            var consoleArea = Screen.PrimaryScreen.WorkingArea;

            this.ShowDialog();
        }

        public void hide()
        {
            this.Hide();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (userInfo != null)
            {
                this.Text = userInfo.username;

                int componentX = 8;
                int componentY = 8;
                if (userInfo.gravatar != null)
                {
                    Bitmap gravatarImage = gravatar(userInfo.gravatar);
                    PictureBox gravatarImageBox = new PictureBox();
                    gravatarImageBox.Image = gravatarImage;
                    gravatarImageBox.Location = new Point(componentX, componentY);
                    gravatarImageBox.Size = gravatarImage.Size;
                    this.Controls.Add(gravatarImageBox);

                    componentX += gravatarImage.Size.Width + 4;
                }

                string username = "User: " + userInfo.username;
                addLabel(componentX, componentY, username);

                componentY += labelHeight;

                string level = "Level: " + userInfo.level;
                addLabel(componentX, componentY, level);

                componentY += labelHeight;

                string title = "Title: " + userInfo.title;
                addLabel(componentX, componentY, title);

                componentY += labelHeight;

                string about = "About: " + userInfo.about;
                addLabel(componentX, componentY, about);

                componentY += labelHeight;

                string website = "Website: " + userInfo.website;
                addLabel(componentX, componentY, website);

                componentY += labelHeight;

                string twitter = "Twitter: " + userInfo.twitter;
                addLabel(componentX, componentY, twitter);

                componentY += labelHeight;

                string topics = "Topics: " + userInfo.topics_count;
                addLabel(componentX, componentY, topics);

                componentY += labelHeight;
                
                string posts = "Posts: " + userInfo.posts_count;
                addLabel(componentX, componentY, posts);

                componentY += labelHeight;
                
                string creation = "Creation Date: " + userInfo.creation_date_native;
                addLabel(componentX, componentY, creation);

                componentY += labelHeight;

                string vacation = "Vacation: " + userInfo.vacation_date_native.ToString().TrimStart();
                addLabel(componentX, componentY, vacation);

                //componentY += vacationLabel.Size.Height;
            }
        }

        private const int labelWidth = 200;
        private const int labelHeight = 15;

        private void addLabel(int x, int y, string text)
        {
            Label label = new Label();
            label.Size = new Size(labelWidth, labelHeight);
            label.Text = text;
            label.Location = new Point(x, y);
            this.Controls.Add(label);
        }

        private static Bitmap gravatar(string userHash)
        {
            string url = "https://www.gravatar.com/avatar/" + userHash;

            System.Net.WebRequest request =
            System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap bitmap2 = new Bitmap(responseStream);
            return bitmap2;
        }
    }
}
