namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public int gridinput = 0;
        public int minenumber = 0;
        public int maxminenumber = 0;
        public string username;
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            username = userNameTextBox.Text;

            if (InputChecker())
            {
                Form2 form2 = new Form2(gridinput, minenumber, maxminenumber, username);

                form2.Show();


            }




        }

        private void mineTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void gridInputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public bool InputChecker()
        {

            if (int.TryParse(gridInputTextBox.Text, out gridinput))
            {
                maxminenumber = gridinput * gridinput / 2;
            }
            if (!int.TryParse(mineTextBox.Text, out minenumber))
            {
                MessageBox.Show("Please input a number to mine number");
                return false;
            }
            else if (!int.TryParse(gridInputTextBox.Text, out gridinput))
            {
                MessageBox.Show("Please input a number to grid number");
                return false;
            }
            else if (minenumber < 10)
            {
                MessageBox.Show("Mine number value cannot be less than 10");
                return false;
            }
            else if (minenumber > maxminenumber)
            {
                MessageBox.Show("Mine number value cannot be more than half of the grids " + "(" + maxminenumber + ")");
                return false;
            }
            else if (gridinput < 5)
            {
                MessageBox.Show("Grid input cannot be less than 5");
                return false;
            }
            else if (gridinput > 30)
            {
                MessageBox.Show("Grid input cannot be more than 30");
                return false;
            }
            else if (username.Length == 0)
            {
                MessageBox.Show("Username cannot be empty");
                return false;
            }
            return true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
