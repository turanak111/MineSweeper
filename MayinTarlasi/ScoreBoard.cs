using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MayinTarlasi
{
    internal class ScoreBoard
    {
        private string _username;
        private int _flaggedmines;
        private double _scorevalue;
        private int _secondforscore;
    
        private static List<ScoreBoard> _scores = new List<ScoreBoard>()
        {
            new ScoreBoard("Turan", 15, 50, true),
            new ScoreBoard("Ahmet", 12, 100, true),
            new ScoreBoard("Efe", 10, 200, true),
            new ScoreBoard("Mehmet", 20, 400, true),
            new ScoreBoard("Safo", 18, 150, true),
            new ScoreBoard("Veli", 17, 190, true),
            new ScoreBoard("Lale", 20, 400, true)
        };
        private const int MaxScores = 10;

        public ScoreBoard(string username, int flaggedmines, int secondforscore, bool isInitialData = false)
        {
            _username = username;
            _flaggedmines = flaggedmines;
            _secondforscore = secondforscore;
            CalculateScore();
            if (!isInitialData)
            {
                AddToScoreList();
            }
        }

        private void CalculateScore()
        {
            _scorevalue = ((double)_flaggedmines / _secondforscore) * 1000;
        }

        private void AddToScoreList()
        {
            _scores.Add(this);
            var orderedScores = _scores.OrderByDescending(s => s._scorevalue).Take(MaxScores).ToList();
            _scores.Clear();
            _scores.AddRange(orderedScores);
        }

        public void ShowScoreBoard()
        {
            Form scoreForm = new Form
            {
                Text = "En İyi Skorlar",
                Size = new Size(400, 500),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            ListView listView = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12),
                BackColor = Color.FromArgb(40, 40, 40),
                ForeColor = Color.White
            };

            listView.Columns.Add("Sıra", 50);
            listView.Columns.Add("Oyuncu", 120);
            listView.Columns.Add("Skor", 100);
            listView.Columns.Add("Mayınlar", 80);
            listView.Columns.Add("Süre(sn)", 80);

         
            listView.Items.Clear();

            int rank = 1;
            foreach (var score in _scores.OrderByDescending(s => s._scorevalue))
            {
                var item = new ListViewItem(rank.ToString());
                item.SubItems.Add(score._username);
                item.SubItems.Add(score._scorevalue.ToString("F2"));
                item.SubItems.Add(score._flaggedmines.ToString());
                item.SubItems.Add(score._secondforscore.ToString());
                item.BackColor = rank % 2 == 0 ? Color.FromArgb(50, 50, 50) : Color.FromArgb(60, 60, 60);
                item.ForeColor = Color.LightYellow;
                listView.Items.Add(item);
                rank++;
            }

            scoreForm.Controls.Add(listView);
            scoreForm.ShowDialog();
        }

        public static void AddNewScore(string username, int flaggedMines, int seconds)
        {
            ScoreBoard newScore = new ScoreBoard(username, flaggedMines, seconds);
            newScore.ShowScoreBoard();
        }
    }
}