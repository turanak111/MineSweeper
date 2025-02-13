using System;
using System.Drawing; 
using System.Windows.Forms; 

namespace MayinTarlasi
{
    internal class Game
    {

        // Değişkenler
        int correctlyflaggedmines = 0;

        int hamledegiskeni = 0;
        int second = 0, minute = 0;
        PictureBox flagIcon;
        PictureBox mineIcon;
        int _gridinput;
        int _minenumber;
        int _maxminenumber;
        string _username;
        Button[][] buttons;
        bool[][] isMine;
        bool[][] isOpened;
        Label seconds = new Label();
        Label hamlecounter = new Label();
        Form2 _oyun;
        private System.Windows.Forms.Timer timer1;
        int secondforscore = 0;
        // Constructor 
        public Game(int gridinput, int minenumber, int maxminenumber, string username,Form2 oyun,System.Windows.Forms.Timer timer)
        {
            this._oyun = oyun;
            timer1 = timer;
            string sourceDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Images");
            string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            string[] images = { "flag.png", "mineimage.png" };
            _gridinput = gridinput;
            _minenumber = minenumber;
            _maxminenumber = maxminenumber;
            _username = username;

            
            buttons = new Button[_gridinput][];
            isMine = new bool[_gridinput][];
            isOpened = new bool[_gridinput][];
            for (int i = 0; i < _gridinput; i++)
            {
                buttons[i] = new Button[_gridinput];
                isMine[i] = new bool[_gridinput];
                isOpened[i] = new bool[_gridinput];
            }

         
            seconds.Location = new Point((_gridinput * 30) + 80, ((_gridinput * 30) + 10) / 8);
            seconds.Font = new Font(seconds.Font.FontFamily, 16, seconds.Font.Style);
            seconds.AutoSize = true;
            hamlecounter.AutoSize = true;

            hamlecounter.Location = new Point((_gridinput * 30) + 65, ((_gridinput * 30) + 50) / 4);

            hamlecounter.Font = new Font(hamlecounter.Font.FontFamily, 16, hamlecounter.Font.Style);
            hamlecounter.AutoSize = true;
            hamlecounter.Size = new Size(400, 200);

            CreateButtons();
            timer1.Start();

            _oyun.Controls.Add(seconds);
            _oyun.Controls.Add(hamlecounter);
        
            hamlecounter.Text = "Hamle: " + hamledegiskeni;
        }

        public void CreateButtons()
        {


            for (int i = 0; i < _gridinput; i++)
            {
                buttons[i] = new Button[_gridinput];
                isMine[i] = new bool[_gridinput];
                isOpened[i] = new bool[_gridinput];

                for (int j = 0; j < _gridinput; j++)
                {
                    isMine[i][j] = false;
                    isOpened[i][j] = false;

                    buttons[i][j] = new Button();
                    buttons[i][j].Text = "";
                    buttons[i][j].Location = new Point((i * 30) + 2, (j * 30) + 2);
                    buttons[i][j].Width = 30;
                    buttons[i][j].Height = 30;
                    buttons[i][j].BackColor = Color.Gray;
                    buttons[i][j].UseVisualStyleBackColor = false;
                    buttons[i][j].FlatStyle = FlatStyle.Flat;
                    buttons[i][j].FlatAppearance.BorderColor = Color.LightBlue;
                    buttons[i][j].AutoSize = false;
                    buttons[i][j].TabStop = false;
                    buttons[i][j].Margin = new Padding(0);
                    buttons[i][j].MouseDown += new MouseEventHandler(Button_Click);
                    buttons[i][j].Tag = Tuple.Create(i, j);

                    _oyun.Controls.Add(buttons[i][j]);
                }
            }
            int heightsize = buttons[1][1].Height;
            int weightsize = buttons[1][1].Width;
            PutMinestoButtons();
            _oyun.ClientSize = new Size((heightsize * _gridinput) + 200, (weightsize * _gridinput) + 10);

        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Hamle();
            if (e.Button == MouseButtons.Right)
            {
                ToggleFlag(clickedButton);

            }
            else
            {


                if (clickedButton != null)
                {
                    var coordinates = clickedButton.Tag as Tuple<int, int>;
                    int i = coordinates.Item1;
                    int j = coordinates.Item2;
                    if (isMine[i][j])
                    {
                        LosingGame();
                    }
                    else
                    {

                        OpenButton(clickedButton, i, j);
                        WinControl();
                    }
                }
            }


        }
        private string LookForMines(Button clickedButton)
        {
            var coordinates = clickedButton.Tag as Tuple<int, int>;
            int i = coordinates.Item1;
            int j = coordinates.Item2;
            int countofminesaround = 0;
            if (isOpened[i][j])
            {
                return "";
            }

            if (clickedButton.Controls.ContainsKey("flagIcon"))
            {
                RemoveFlag(clickedButton);
            }
            if (i > 0)
            {
                if (isMine[i - 1][j])
                {
                    countofminesaround++;
                }

            }
            if (j > 0)
            {
                if (isMine[i][j - 1])
                {
                    countofminesaround++;
                }
            }
            if (j > 0 && i > 0)
            {
                if (isMine[i - 1][j - 1])
                {
                    countofminesaround++;
                }
            }
            if (i < _gridinput - 1)
            {
                if (isMine[i + 1][j])
                {
                    countofminesaround++;
                }
            }
            if (j < _gridinput - 1)
            {

                if (isMine[i][j + 1])
                {
                    countofminesaround++;
                }
            }
            if (i < _gridinput - 1 && j < _gridinput - 1)
            {
                if (isMine[i + 1][j + 1])
                {
                    countofminesaround++;
                }

            }
            if (i > 0 && j < _gridinput - 1)
            {
                if (isMine[i - 1][j + 1])
                {
                    countofminesaround++;
                }
            }
            if (i < _gridinput - 1 && j > 0)
            {
                if (isMine[i + 1][j - 1])
                {
                    countofminesaround++;
                }
            }
            if (countofminesaround == 0)
            {
                isOpened[i][j] = true;
                if (i > 0)
                {
                    OpenButton(buttons[i - 1][j], i - 1, j);

                }

                if (j > 0 && i > 0)
                {
                    OpenButton(buttons[i - 1][j - 1], i - 1, j - 1);
                }
                if (i < _gridinput - 1)
                {
                    OpenButton(buttons[i + 1][j], i + 1, j);
                }
                if (j < _gridinput - 1)
                {
                    OpenButton(buttons[i][j + 1], i, j + 1);
                }
                if (i < _gridinput - 1 && j < _gridinput - 1)
                {
                    OpenButton(buttons[i + 1][j + 1], i + 1, j + 1);

                }
                if (i > 0 && j < _gridinput - 1)
                {
                    OpenButton(buttons[i - 1][j + 1], i - 1, j + 1);
                }
                if (i < _gridinput - 1 && j > 0)
                {
                    OpenButton(buttons[i + 1][j - 1], i + 1, j - 1);
                }
                return "";

            }
            isOpened[i][j] = true;
            return (countofminesaround.ToString());
        }

        private void OpenButton(Button clickedButton, int i, int j)
        {

            if (!isOpened[i][j])
            {
                clickedButton.Enabled = false;
                clickedButton.Text = LookForMines(clickedButton);
                clickedButton.FlatAppearance.BorderColor = Color.DarkGray;
                clickedButton.BackColor = Color.DarkCyan;

            }

        }
        private void LosingGame()
        {
            MessageBox.Show("You Lost");
            GameEnd();
        }
        private void PutMinestoButtons()
        {
            Random rnd = new Random();

            for (int a = 0; a < _minenumber; a++)
            {
                var i = rnd.Next(_gridinput);
                var j = rnd.Next(_gridinput);
                if (!isMine[i][j])
                {
                    isMine[i][j] = true;
                }
                else
                {
                    a--;
                    continue;
                }


            }
        }
        private void ToggleFlag(Button clickedButton)
        {
            var coordinates = clickedButton.Tag as Tuple<int, int>;
            int i = coordinates.Item1;
            int j = coordinates.Item2;

            if (clickedButton.Controls.ContainsKey("flagIcon"))
            {
                RemoveFlag(clickedButton);
               
                if (isMine[i][j])
                {
                    correctlyflaggedmines--;
                }
            }
            else
            {
                flagIcon = new PictureBox
                {
                    Name = "flagIcon",
                    Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "flag.png")),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(clickedButton.Width, clickedButton.Height),
                    Location = new Point(0, 0),
                    BackColor = Color.Transparent
                };
                flagIcon.Enabled = false;
                clickedButton.Controls.Add(flagIcon);

                
                if (isMine[i][j])
                {
                    correctlyflaggedmines++;
                }
            }
        }

        private void RemoveFlag(Button clickedButton)
        {
            flagIcon = (PictureBox)clickedButton.Controls["flagIcon"];
            clickedButton.Controls.Remove(flagIcon);

        }
        private void WinControl()
        {
            int buttoncounterforwin = 0;
            int buttonwithoutmine = (_gridinput * _gridinput) - _minenumber;
            for (int i = 0; i < _gridinput; i++)
            {
                for (int j = 0; j < _gridinput; j++)
                {
                    if (!isMine[i][j] && isOpened[i][j])
                    {
                        buttoncounterforwin++;

                    }
                }
            }
            if (buttoncounterforwin >= buttonwithoutmine)
            {

                WinGame();
                ScoreBoard.AddNewScore(_username, correctlyflaggedmines, secondforscore);

            }
        }
        private void WinGame()
        {
            MessageBox.Show("You win");
            GameEnd();
        }
        private void GameEnd()
        {

   
            timer1.Stop();
            for (int i = 0; i < _gridinput; i++)
            {
                for (int j = 0; j < _gridinput; j++)
                {
                    buttons[i][j].Enabled = false;
                    if (isMine[i][j])
                    {
                        mineIcon = new PictureBox
                        {
                            Name = "mineIcon",

                            Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "mineimage.png")),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(buttons[1][1].Width - 5, buttons[1][1].Height - 5),
                            BackColor = Color.Transparent,
                            Location = new Point(
                             (buttons[1][1].Width - (buttons[1][1].Width - 5)) / 2,
                             (buttons[1][1].Height - (buttons[1][1].Height - 5)) / 2)
                        };
                        mineIcon.Enabled = false;
                        buttons[i][j].Controls.Add(mineIcon);
                        buttons[i][j].Enabled = false;
                        buttons[i][j].BackColor = Color.Red;

                    }
                }
            }
        }

        private void Hamle()
        {
            hamledegiskeni++;
            hamlecounter.Text = "Hamle: " + hamledegiskeni;
        }
        public void TimerTick()
        {
          
            
                if (second == 60)
                {
                    second = 0;
                    minute++;

                }
                seconds.Text = String.Format("{0:D2}", minute) + ":" + String.Format("{0:D2}", second);
                second++;
            secondforscore++;
           
        }
    }
}
