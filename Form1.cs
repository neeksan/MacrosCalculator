namespace Foodie
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Dictionary<string, int>> info =
            new Dictionary<string, Dictionary<string, int>>
        {
            {
                "�������",
                new Dictionary<string, int>
                {
                    {"�������", 93},
                    {"������������", 21},
                    {"�������", 1},
                    {"�������", 3 }
                }

            },
            {
                "����",
                new Dictionary<string, int>
                    {
                        {"�������", 130},
                        {"������������", 28},
                        {"�������", 1},
                        {"�������", 3}
                    }
            },
            {
                "����",
                new Dictionary<string, int>
                    {
                        {"�������", 165 },
                        {"������������", 1},
                        {"�������", 4},
                        {"�������", 31}
                    }
            },
            {
                "����� �����",
                new Dictionary<string, int>
                    {
                        {"�������", 717},
                        {"������������", 1},
                        {"�������", 81},
                        {"�������", 1}
                    }
            },
            {
                "��������",
                new Dictionary<string, int>
                    {
                        {"�������", 717},
                        {"������������", 1},
                        {"�������", 81},
                        {"�������", 1}
                    }
            },
            {
                "������������� �����",
                new Dictionary<string, int>
                    {
                        {"�������", 884},
                        {"������������", 1},
                        {"�������", 100},
                        {"�������", 1}
                    }
            },
            {
                "���",
                new Dictionary<string, int>
                    {
                        {"�������", 44},
                        {"������������", 10},
                        {"�������", 1},
                        {"�������", 2}
                    }
            },
            {
                "�����",
                new Dictionary<string, int>
                    {
                        {"�������", 18},
                        {"������������", 4},
                        {"�������", 1},
                        {"�������", 1}
                    }
            },
            {
                "����������",
                new Dictionary<string, int>
                    {
                        {"�������", 15},
                        {"������������", 4},
                        {"�������", 1},
                        {"�������", 1}
                    }
            },
            {
                "�����",
                new Dictionary<string, int>
                    {
                        {"�������", 149},
                        {"������������", 33},
                        {"�������", 1},
                        {"�������", 7}
                    }
            },
            {
                "�����",
                new Dictionary<string, int>
                    {
                        {"�������", 28},
                        {"������������", 7},
                        {"�������", 1},
                        {"�������", 1}
                    }
            },
            {
                "�������/�����",
                new Dictionary<string, int>
                    {
                        {"�������", 150},
                        {"������������", 30},
                        {"�������", 1},
                        {"�������", 6}
                    }
            },
            {
                "������",
                new Dictionary<string, int>
                    {
                        {"�������", 365},
                        {"������������", 76},
                        {"�������", 1},
                        {"�������", 10}
                    }
            },
            {
                "��������",
                new Dictionary<string, int>
                    {
                        {"�������", 404},
                        {"������������", 4},
                        {"�������", 33},
                        {"�������", 23}
                    }
            },
            {
                "����",
                new Dictionary<string, int>
                    {
                        {"�������", 143},
                        {"������������", 1},
                        {"�������", 10},
                        {"�������", 13}
                    }
            },
            {
                "����� �����",
                new Dictionary<string, int>
                    {
                        {"�������", 50},
                        {"������������", 5},
                        {"�������", 2},
                        {"�������", 3}
                    }
            },
            {
                "�������",
                new Dictionary<string, int>
                    {
                        {"�������", 238},
                        {"������������", 1},
                        {"�������", 14},
                        {"�������", 26}
                    }
            },
            {
                "�������",
                new Dictionary<string, int>
                    {
                        {"�������", 260},
                        {"������������", 1},
                        {"�������", 17},
                        {"�������", 26}
                    }
            },
        };

        private double calories = 0;
        private double carbohydrates = 0;
        private double fats = 0;
        private double protein = 0;
        private double weight = 0;

        private int[] currentMacros = new int[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new BindingSource(info, null);
            comboBox1.DisplayMember = "Key";
            PrintLabel2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintLabel1();
            weight = Convert.ToInt32(richTextBox1.Text);
            UpdateMacros();
            PrintLabel2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            calories = 0;
            carbohydrates = 0;
            fats = 0;
            protein = 0;
            PrintLabel2();
        }
        
        private void PrintLabel2()
        {
            label2.Text = "";
            label2.Text =($"�������: {calories:f1} kCal\n������������: {carbohydrates:f1} �.\n�������: {fats:f1} �.\n�������: {protein:f1} �.");
        }
        private void UpdateMacros()
        {
            foreach (var item in info)
            {
                if (item.Key == comboBox1.Text)
                {
                    for (int i = 0; i < currentMacros.Length; i++)
                    {
                        var temp= item.Value.ElementAt(i);
                        currentMacros[i] = temp.Value;
                    }
                    break;
                }
            }
            
            calories += currentMacros[0] * (weight / 100);
            carbohydrates += currentMacros[1] * (weight / 100);
            fats += currentMacros[2] * (weight / 100);
            protein += currentMacros[3] * (weight / 100);
        }
        private void PrintLabel1()
        {
            if (comboBox1.Text != "" && richTextBox1.Text != "")
            {
                label1.Text += comboBox1.Text + " - " + richTextBox1.Text + "��.\n";
            }
            else
            {
                if (comboBox1.Text == "" && richTextBox1.Text == "")
                {
                    MessageBox.Show("�� �� �������� �����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (richTextBox1.Text == "")
                {
                    MessageBox.Show("������ '������' � ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("������ '�������' � ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}