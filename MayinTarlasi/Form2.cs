
using System.Security;

namespace MayinTarlasi
   
{
    public partial class Form2 : Form
    {

        Game game;

        public Form2(int gridinput, int minenumber, int maxminenumber, string username)
        {
            InitializeComponent();
             game = new Game(gridinput, minenumber, maxminenumber, username, this, timer1);


        }   

        private void Oyun_Load(object sender, EventArgs e)
        {

           
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            game.TimerTick();
        }












    }
}
