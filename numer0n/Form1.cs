namespace numer0n
{
    //ヌメロン（バージョン１）
    public partial class Form1 : Form
    {
        //敵の数字は、都合がいいので文字列で管理
        string teki_num;

        //コンソール（Label7)への表示、スクロールなどなどを纏めたクラス
        console_sys cos_Sys;

        //デバッグ用で上記と同じクラス（こちらはLabel8）
        console_sys debug_Sys;

        //これをfalseにすることでデバッグには何も表示されなくなる
        bool DEBUG = true;

        //form1コンストラクタ
        //ここが最初に実行されるため、敵の数字、コンソールクラスなどの初期化メゾットを複数置く
        public Form1()
        {
            InitializeComponent();
            teki_num = init_number();
            init_Label_mikata();
            cos_Sys = new console_sys(label7);
            debug_Sys = new console_sys(label8);
            debug_print(teki_num);
            label7.MouseWheel += Label7_MouseWheel;
        }
        //デバッグに表示するためのプリントクラス
        private void debug_print(string msg)
        {
            if (DEBUG)
            {
                debug_Sys.println(msg);
            }
        }
        //マウスホイールを認識し、上下するためのメゾット
        private void Label7_MouseWheel(object? sender, MouseEventArgs e)
        {
            if ((e.Delta * SystemInformation.MouseWheelScrollLines / 120) > 0)
            {
                cos_Sys.up();
            }
            else
            {
                cos_Sys.down();
            }
        }
        
        //正解の後、敵の文字を表示したり、初期化をするメゾット
        private void teki_hyouji()
        {
            label1.Text = teki_num[0].ToString();
            label2.Text = teki_num[1].ToString();
            label3.Text = teki_num[2].ToString();
        }

        //敵の数字を初期化するメゾット
        //0~9まで並んだ配列を1000回シャッフルすることでランダムを実現している
        private string init_number()
        {

            Random r
                = new Random();
            int[] arrays = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            int i1, i2, temp;
            for (int i = 0; i < 1000; i++)
            {
                i1 = r.Next(arrays.Length);
                i2 = r.Next(arrays.Length);
                temp = arrays[i1];
                arrays[i1] = arrays[i2];
                arrays[i2] = temp;
            }
            return arrays[0].ToString() + arrays[1].ToString() + arrays[2].ToString();
        }

        //どれだけ桁が合っているかを数えるメゾット
        //Javaの物をそのまま移植
        private int keta(string s1, string s2)
        {
            int keta_ans = 0;
            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
            {
                if (s1[i] == s2[i])
                {
                    keta_ans++;
                }
            }
            return keta_ans;
        }


        //どれだけ数が合っているかを数えるメゾット
        //Javaの物をそのまま移植
        private int kazu(string s1, string s2)
        {
            int kazu_ans = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        kazu_ans++;
                    }
                }
            }
            return kazu_ans;
        }

        //味方の文字を表示するためのラベルを纏めた配列を初期化するメゾット。
        Label[] label_mikata = new Label[3];
        private void init_Label_mikata()
        {
            label_mikata[0] = label4;
            label_mikata[1] = label5;
            label_mikata[2] = label6;
        }
        //いつもの
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //テキストボックスに文字が入ってきたときに、前回のものを上書きするための変数
        string before = "";
        //テキストボックスに変更が入った時に実行されるメゾット
        //ここで、ラベルとの同期を実装している
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (check_char(textBox1.Text[i]))
                {
                    textBox1.Text = before;
                    return;
                }
            }
            before = textBox1.Text;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                label_mikata[i].Text = textBox1.Text[i].ToString();
            }
            for (int i = textBox1.Text.Length; i < 3; i++)
            {
                label_mikata[i].Text = "";
            }
        }

        //数字「ではない」かをチェックするメゾット
        private bool check_char(char ch)
        {
            return ch < '0' || ch > '9';
        }

        //callが押された時、文字列が正しいフォーマットになっているか確かめるメゾット
        private bool check_num(string str)
        {
            if (str.Length != 3) return false;
            if (str[0] == str[1] || str[0] == str[2] || str[1] == str[2]) { return false; }
            for (int i = 0; i < str.Length; i++)
            {
                if (check_char(str[i])) { return false; }
            }
            return true;
        }

        //Label7に文字列を表示するメゾット
        private void println(string str)
        {
            cos_Sys.println(str);
        }

        //クリア後、それぞれをもう一度初期化するメゾット
        private void reset()
        {
            cos_Sys.reset();
            teki_num = "   ";
            teki_hyouji();
            teki_num = init_number();
            debug_print(teki_num);
        }

        //callが押された時に実行されるメゾット
        //汚いので、改善の余地有
        private void button1_Click(object sender, EventArgs e)
        {

            if (check_num(textBox1.Text))
            {
                int keta_ans = keta((textBox1.Text), (teki_num));
                if (keta_ans == 3)
                {
                    println("くりあ！");
                    teki_hyouji();
                    MessageBox.Show("Numer0n!!!");
                    reset();
                    textBox1.Text = "";
                    return;
                }
                int kazu_ans = kazu((textBox1.Text), (teki_num));
                println("number = " + textBox1.Text + " keta = " + keta_ans + " kazu = " + kazu_ans);
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            textBox1.Text = "";
        }

        private void textBox1_ControlRemoved(object sender, ControlEventArgs e)
        {
        }

        private void textBox1_ControlAdded(object sender, ControlEventArgs e)
        {
        }
        //クリックしたときに、コンソールが一回上昇するメゾット
        private void button2_Click(object sender, EventArgs e)
        {
            cos_Sys.up();
        }
        //クリックしたときに、コンソールが一回下降するメゾット
        private void button3_Click(object sender, EventArgs e)
        {
            cos_Sys.down();
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void label7_MouseUp(object sender, MouseEventArgs e)
        {
        }


        //エンターを押した時も、callが押された時のようになる　&　jとkでコンソールの行き来をできるようにしたメゾット
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.J)
            {
                cos_Sys.down();
            }
            else if (e.KeyCode == Keys.K)
            {
                cos_Sys.up();
            }
        }
    }

    //コンソールを実装するクラス、　これによってLabelをコンソールっぽくできた
    class console_sys
    {
        //ターゲットとするラベル
        private Label console_print_target;

        //コンソールに最大表示できる行数
        private int console_max;

        //コンソールのバッファ、これによってスクロールが実装できる
        //満タンになった場合の処理が適当なので、改善の余地あり
        private string[] buffer = new string[16384];

        //次、配列のどこに文字列が挿入されるかを保存するメゾット
        //配列の一番後ろのため、「ここまで表示する」の時にも使っている
        private int nextTarget = 0;

        //bufferの最大入る数
        private const int max_buffer = 16384;

        //今、どこを表示しているかを保存しておくメゾット
        //これでスクロールを実現している
        int hyouji = 0;

        //ラベルに書き込むためのメゾット。
        //これで「スクロール」「プリント」を実装している
        private void print()
        {
            string str = "";
            for (int i = (hyouji - console_max) < 0 ? 0 : hyouji - console_max; i < hyouji; i++)
            {
                str += buffer[i] + '\n';
            }
            console_print_target.Text = str;
        }

        //いつもの「println」
        public void println(object msg)
        {
            if (nextTarget == max_buffer) return;
            buffer[nextTarget++] = msg.ToString() ?? "";
            hyouji = nextTarget;
            print();
        }

        //スクロールで上昇するためのメゾット
        public void up()
        {
            if (hyouji - 3 <= console_max)
            {
                hyouji = console_max;
            }
            else
                hyouji -= 3;
            print();
        }

        //スクロールで下降するためのメゾット
        public void down()
        {
            if ((hyouji + 3) >= nextTarget)
            {
                hyouji = nextTarget;
            }
            else hyouji += 3;
            print();
        }

        //Labelをリセットする時に呼び出すメゾット
        //bufferまで初期化しなくていい気はするんだけど、なぜかバグったので　bufferも初期化
        public void reset()
        {
            buffer = new string[max_buffer];
            nextTarget = 0;
            hyouji = 0;
            print();
        }

        //コンストラクタ
        //ラベルを渡すことで、最大行数と、ターゲットのラベルを決める
        public console_sys(Label target)
        {
            console_print_target = target;
            console_max = target.Height / target.Font.Height;
        }
    }
}