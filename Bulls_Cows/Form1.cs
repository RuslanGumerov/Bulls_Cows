using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bulls_Cows
{
    public partial class Game : Form
    {
        private Random rand = new Random();
        private int[] x = new int[4];
        private int polnoeSovpodenie;
        private int chastichnoeSovpodenie;
        private string s;

        public Game()
        {
            InitializeComponent();
            NewGame();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void NewGame()
        {
            NovoeChislo();
            label2.Text = "";
            label3.Text = "";
            textBox1.ReadOnly = false;
            int kol_najatii = 0;

        }
        private void NovoeChislo()
        {
            bool contains;

            for (int i = 0; i < 4; i++)
            {
                do
                {
                    contains = false;
                    x[i] = rand.Next(10);
                    for (int k = 0; k < i; k++)
                        if (x[k] == x[i])
                            contains = true;
                } while (contains);
            }
            s = x[0].ToString() + x[1] + x[2] + x[3];
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Char.IsDigit(e.KeyChar) проверка, является ли нажатая клавиша цифрой. возвращает true или false
            //e.KeyChar == (char)Keys.Back проверяет, является ли нажатая клавиша бекспейсом.
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                // если были нажаты цифра или бекспейс, то событие обработать в обычном режиме
                e.Handled = false;
            else
                //иначе, поставить метку что событие обработанно, но не пускать сигнал в текстбокс
                e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void RezultShow()
        {
            label2.Text += textBox1.Text + "    коров " + polnoeSovpodenie + ",  быков " + chastichnoeSovpodenie + "\n";
        }

        private void SravnenieChisel()
        {
            polnoeSovpodenie = 0;
            chastichnoeSovpodenie = 0;
            char[] ch = textBox1.Text.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                // если строка s содержит в себе элемент массива
                if (s.Contains(ch[i]))
                {
                    // если номер символа в массиве совпадает с номером символа в строке
                    if (s[i] == ch[i])
                        // увеличиваем счетчик полного совпадения
                        polnoeSovpodenie++;
                    chastichnoeSovpodenie++;
                    // если номер символа в массиве не совпадает с номером символа в строке
                    // увеличиваем счетчик неполного совпадения

                }

                if (polnoeSovpodenie > 3)
                {
                    MessageBox.Show("   Уху, ты выйграл, ты молодец!" +
                        "\n Для победы тебе понадобилось " + kol_najatii + " попыток." +
                        "\n Попробуй улучшить свой результат BRUHHH.");
                }
            }

        }

        int kol_najatii = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            kol_najatii++;
            if (textBox1.Text.Length != 4)
            {
                MessageBox.Show("Число должно состоять из четырех элементов");
            }
            else
            {
                SravnenieChisel();
                RezultShow();
            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = s;
            label2.Text = "";
            textBox1.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Камплюхтер задумал четыре различные цифры из 0,1,2,...9. Игрок делает ходы, чтобы узнать эти цифры и их порядок." +
                " Каждый ход состоит из четырёх цифр, 0 может стоять на первом месте." +
                " \n\n В ответ компуктер показывает число отгаданных цифр, стоящих на своих местах (число коров) и число отгаданных цифр, стоящих не на своих местах (число быков).");
        }

    }
}
