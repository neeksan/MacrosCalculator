namespace Foodie
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Dictionary<string, int>> info =
            new Dictionary<string, Dictionary<string, int>>
        {
            {
                "Картофи",
                new Dictionary<string, int>
                {
                    {"Калории", 93},
                    {"Въглехидрати", 21},
                    {"Мазнини", 1},
                    {"Протеин", 3 }
                }

            },
            {
                "Ориз",
                new Dictionary<string, int>
                    {
                        {"Калории", 130},
                        {"Въглехидрати", 28},
                        {"Мазнини", 1},
                        {"Протеин", 3}
                    }
            },
            {
                "Пиле",
                new Dictionary<string, int>
                    {
                        {"Калории", 165 },
                        {"Въглехидрати", 1},
                        {"Мазнини", 4},
                        {"Протеин", 31}
                    }
            },
            {
                "Краве масло",
                new Dictionary<string, int>
                    {
                        {"Калории", 717},
                        {"Въглехидрати", 1},
                        {"Мазнини", 81},
                        {"Протеин", 1}
                    }
            },
            {
                "Маргарин",
                new Dictionary<string, int>
                    {
                        {"Калории", 717},
                        {"Въглехидрати", 1},
                        {"Мазнини", 81},
                        {"Протеин", 1}
                    }
            },
            {
                "Слънчогледово масло",
                new Dictionary<string, int>
                    {
                        {"Калории", 884},
                        {"Въглехидрати", 1},
                        {"Мазнини", 100},
                        {"Протеин", 1}
                    }
            },
            {
                "Лук",
                new Dictionary<string, int>
                    {
                        {"Калории", 44},
                        {"Въглехидрати", 10},
                        {"Мазнини", 1},
                        {"Протеин", 2}
                    }
            },
            {
                "Домат",
                new Dictionary<string, int>
                    {
                        {"Калории", 18},
                        {"Въглехидрати", 4},
                        {"Мазнини", 1},
                        {"Протеин", 1}
                    }
            },
            {
                "Краставица",
                new Dictionary<string, int>
                    {
                        {"Калории", 15},
                        {"Въглехидрати", 4},
                        {"Мазнини", 1},
                        {"Протеин", 1}
                    }
            },
            {
                "Чесън",
                new Dictionary<string, int>
                    {
                        {"Калории", 149},
                        {"Въглехидрати", 33},
                        {"Мазнини", 1},
                        {"Протеин", 7}
                    }
            },
            {
                "Чушки",
                new Dictionary<string, int>
                    {
                        {"Калории", 28},
                        {"Въглехидрати", 7},
                        {"Мазнини", 1},
                        {"Протеин", 1}
                    }
            },
            {
                "Спагети/Паста",
                new Dictionary<string, int>
                    {
                        {"Калории", 150},
                        {"Въглехидрати", 30},
                        {"Мазнини", 1},
                        {"Протеин", 6}
                    }
            },
            {
                "Брашно",
                new Dictionary<string, int>
                    {
                        {"Калории", 365},
                        {"Въглехидрати", 76},
                        {"Мазнини", 1},
                        {"Протеин", 10}
                    }
            },
            {
                "Кашкавал",
                new Dictionary<string, int>
                    {
                        {"Калории", 404},
                        {"Въглехидрати", 4},
                        {"Мазнини", 33},
                        {"Протеин", 23}
                    }
            },
            {
                "Яйце",
                new Dictionary<string, int>
                    {
                        {"Калории", 143},
                        {"Въглехидрати", 1},
                        {"Мазнини", 10},
                        {"Протеин", 13}
                    }
            },
            {
                "Краве мляко",
                new Dictionary<string, int>
                    {
                        {"Калории", 50},
                        {"Въглехидрати", 5},
                        {"Мазнини", 2},
                        {"Протеин", 3}
                    }
            },
            {
                "Свинско",
                new Dictionary<string, int>
                    {
                        {"Калории", 238},
                        {"Въглехидрати", 1},
                        {"Мазнини", 14},
                        {"Протеин", 26}
                    }
            },
            {
                "Говеждо",
                new Dictionary<string, int>
                    {
                        {"Калории", 260},
                        {"Въглехидрати", 1},
                        {"Мазнини", 17},
                        {"Протеин", 26}
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
            label2.Text =($"Калории: {calories:f1} kCal\nВъглехидрати: {carbohydrates:f1} г.\nМазнини: {fats:f1} г.\nПротеин: {protein:f1} г.");
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
                label1.Text += comboBox1.Text + " - " + richTextBox1.Text + "гр.\n";
            }
            else
            {
                if (comboBox1.Text == "" && richTextBox1.Text == "")
                {
                    MessageBox.Show("Не са въведени данни", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (richTextBox1.Text == "")
                {
                    MessageBox.Show("Полето 'Грамаж' е празно", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Полето 'Продукт' е празно", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}