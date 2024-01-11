namespace numer0n
{
    //�k�������i�o�[�W�����P�j
    public partial class Form1 : Form
    {
        //�G�̐����́A�s���������̂ŕ�����ŊǗ�
        string teki_num;

        //�R���\�[���iLabel7)�ւ̕\���A�X�N���[���ȂǂȂǂ�Z�߂��N���X
        console_sys cos_Sys;

        //�f�o�b�O�p�ŏ�L�Ɠ����N���X�i�������Label8�j
        console_sys debug_Sys;

        //�����false�ɂ��邱�ƂŃf�o�b�O�ɂ͉����\������Ȃ��Ȃ�
        bool DEBUG = true;

        //form1�R���X�g���N�^
        //�������ŏ��Ɏ��s����邽�߁A�G�̐����A�R���\�[���N���X�Ȃǂ̏��������]�b�g�𕡐��u��
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
        //�f�o�b�O�ɕ\�����邽�߂̃v�����g�N���X
        private void debug_print(string msg)
        {
            if (DEBUG)
            {
                debug_Sys.println(msg);
            }
        }
        //�}�E�X�z�C�[����F�����A�㉺���邽�߂̃��]�b�g
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
        
        //�����̌�A�G�̕�����\��������A�����������郁�]�b�g
        private void teki_hyouji()
        {
            label1.Text = teki_num[0].ToString();
            label2.Text = teki_num[1].ToString();
            label3.Text = teki_num[2].ToString();
        }

        //�G�̐��������������郁�]�b�g
        //0~9�܂ŕ��񂾔z���1000��V���b�t�����邱�ƂŃ����_�����������Ă���
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

        //�ǂꂾ�����������Ă��邩�𐔂��郁�]�b�g
        //Java�̕������̂܂܈ڐA
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


        //�ǂꂾ�����������Ă��邩�𐔂��郁�]�b�g
        //Java�̕������̂܂܈ڐA
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

        //�����̕�����\�����邽�߂̃��x����Z�߂��z������������郁�]�b�g�B
        Label[] label_mikata = new Label[3];
        private void init_Label_mikata()
        {
            label_mikata[0] = label4;
            label_mikata[1] = label5;
            label_mikata[2] = label6;
        }
        //������
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //�e�L�X�g�{�b�N�X�ɕ����������Ă����Ƃ��ɁA�O��̂��̂��㏑�����邽�߂̕ϐ�
        string before = "";
        //�e�L�X�g�{�b�N�X�ɕύX�����������Ɏ��s����郁�]�b�g
        //�����ŁA���x���Ƃ̓������������Ă���
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

        //�����u�ł͂Ȃ��v�����`�F�b�N���郁�]�b�g
        private bool check_char(char ch)
        {
            return ch < '0' || ch > '9';
        }

        //call�������ꂽ���A�����񂪐������t�H�[�}�b�g�ɂȂ��Ă��邩�m���߂郁�]�b�g
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

        //Label7�ɕ������\�����郁�]�b�g
        private void println(string str)
        {
            cos_Sys.println(str);
        }

        //�N���A��A���ꂼ���������x���������郁�]�b�g
        private void reset()
        {
            cos_Sys.reset();
            teki_num = "   ";
            teki_hyouji();
            teki_num = init_number();
            debug_print(teki_num);
        }

        //call�������ꂽ���Ɏ��s����郁�]�b�g
        //�����̂ŁA���P�̗]�n�L
        private void button1_Click(object sender, EventArgs e)
        {

            if (check_num(textBox1.Text))
            {
                int keta_ans = keta((textBox1.Text), (teki_num));
                if (keta_ans == 3)
                {
                    println("���肠�I");
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
        //�N���b�N�����Ƃ��ɁA�R���\�[�������㏸���郁�]�b�g
        private void button2_Click(object sender, EventArgs e)
        {
            cos_Sys.up();
        }
        //�N���b�N�����Ƃ��ɁA�R���\�[������񉺍~���郁�]�b�g
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


        //�G���^�[�������������Acall�������ꂽ���̂悤�ɂȂ�@&�@j��k�ŃR���\�[���̍s�������ł���悤�ɂ������]�b�g
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

    //�R���\�[������������N���X�A�@����ɂ����Label���R���\�[�����ۂ��ł���
    class console_sys
    {
        //�^�[�Q�b�g�Ƃ��郉�x��
        private Label console_print_target;

        //�R���\�[���ɍő�\���ł���s��
        private int console_max;

        //�R���\�[���̃o�b�t�@�A����ɂ���ăX�N���[���������ł���
        //���^���ɂȂ����ꍇ�̏������K���Ȃ̂ŁA���P�̗]�n����
        private string[] buffer = new string[16384];

        //���A�z��̂ǂ��ɕ����񂪑}������邩��ۑ����郁�]�b�g
        //�z��̈�Ԍ��̂��߁A�u�����܂ŕ\������v�̎��ɂ��g���Ă���
        private int nextTarget = 0;

        //buffer�̍ő���鐔
        private const int max_buffer = 16384;

        //���A�ǂ���\�����Ă��邩��ۑ����Ă������]�b�g
        //����ŃX�N���[�����������Ă���
        int hyouji = 0;

        //���x���ɏ������ނ��߂̃��]�b�g�B
        //����Łu�X�N���[���v�u�v�����g�v���������Ă���
        private void print()
        {
            string str = "";
            for (int i = (hyouji - console_max) < 0 ? 0 : hyouji - console_max; i < hyouji; i++)
            {
                str += buffer[i] + '\n';
            }
            console_print_target.Text = str;
        }

        //�����́uprintln�v
        public void println(object msg)
        {
            if (nextTarget == max_buffer) return;
            buffer[nextTarget++] = msg.ToString() ?? "";
            hyouji = nextTarget;
            print();
        }

        //�X�N���[���ŏ㏸���邽�߂̃��]�b�g
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

        //�X�N���[���ŉ��~���邽�߂̃��]�b�g
        public void down()
        {
            if ((hyouji + 3) >= nextTarget)
            {
                hyouji = nextTarget;
            }
            else hyouji += 3;
            print();
        }

        //Label�����Z�b�g���鎞�ɌĂяo�����]�b�g
        //buffer�܂ŏ��������Ȃ��Ă����C�͂���񂾂��ǁA�Ȃ����o�O�����̂Ł@buffer��������
        public void reset()
        {
            buffer = new string[max_buffer];
            nextTarget = 0;
            hyouji = 0;
            print();
        }

        //�R���X�g���N�^
        //���x����n�����ƂŁA�ő�s���ƁA�^�[�Q�b�g�̃��x�������߂�
        public console_sys(Label target)
        {
            console_print_target = target;
            console_max = target.Height / target.Font.Height;
        }
    }
}