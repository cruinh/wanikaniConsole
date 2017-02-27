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

                Label usernameLabel = new Label();
                usernameLabel.Size = new Size(200, 15);
                usernameLabel.Text = "User: " + userInfo.username;
                usernameLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(usernameLabel);

                componentY += usernameLabel.Size.Height;

                Label levelLabel = new Label();
                levelLabel.Size = new Size(200, 15);
                levelLabel.Text = "Level: " + userInfo.level;
                levelLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(levelLabel);

                componentY += levelLabel.Size.Height;

                Label titleLabel = new Label();
                titleLabel.Size = new Size(200, 15);
                titleLabel.Text = "Title: " + userInfo.title;
                titleLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(titleLabel);

                componentY += titleLabel.Size.Height;

                Label aboutLabel = new Label();
                aboutLabel.Size = new Size(200, 15);
                aboutLabel.Text = "About: " + userInfo.about;
                aboutLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(aboutLabel);

                componentY += aboutLabel.Size.Height;

                Label websiteLabel = new Label();
                websiteLabel.Size = new Size(200, 15);
                websiteLabel.Text = "Website: " + userInfo.website;
                websiteLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(websiteLabel);

                componentY += websiteLabel.Size.Height;

                Label twitterLabel = new Label();
                twitterLabel.Size = new Size(200, 15);
                twitterLabel.Text = "Twitter: " + userInfo.twitter;
                twitterLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(twitterLabel);

                componentY += twitterLabel.Size.Height;

                Label topicsLabel = new Label();
                topicsLabel.Size = new Size(200, 15);
                topicsLabel.Text = "Topics: " + userInfo.topics_count;
                topicsLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(topicsLabel);

                componentY += topicsLabel.Size.Height;

                Label postsLabel = new Label();
                postsLabel.Size = new Size(200, 15);
                postsLabel.Text = "Posts: " + userInfo.posts_count;
                postsLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(postsLabel);

                componentY += postsLabel.Size.Height;

                Label creationLabel = new Label();
                creationLabel.Size = new Size(200, 15);
                creationLabel.Text = "Creation Date: " + userInfo.creation_date_native;
                creationLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(creationLabel);

                componentY += creationLabel.Size.Height;

                Label vacationLabel = new Label();
                vacationLabel.Size = new Size(200, 15);
                vacationLabel.Text = "Vacation: " + userInfo.vacation_date_native.ToString().TrimStart();
                vacationLabel.Location = new Point(componentX, componentY);
                this.Controls.Add(vacationLabel);

                //componentY += vacationLabel.Size.Height;
            }
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
