using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ticketsystem
{
    public partial class Form1 : Form
    {
        ComboBox comboBox1 = new ComboBox();
        ComboBox comboBox2 = new ComboBox();

        TextBox textBox1 = new TextBox();
        TextBox textBox2 = new TextBox();
        TextBox textBox3 = new TextBox();
        TextBox textBox4 = new TextBox();

        MaskedTextBox maskedTextBox1 = new MaskedTextBox();

        DateTimePicker dateTimePicker1 = new DateTimePicker();
        ComboBox timeComboBox = new ComboBox();

        ListBox listBox1 = new ListBox();

        Button button1 = new Button();
        Button button2 = new Button();
        Button button3 = new Button();
        Button button4 = new Button();

        List<string> tickets = new List<string>();

        public Form1()
        {
            InitializeComponent();
            CreateInterface();
        }

        private void CreateInterface()
        {
            Text = "Fast Travel";
            Size = new Size(900, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.Gray;
            MinimumSize = new Size(900, 650);

            Label title = new Label();
            title.Text = "Fast Travel";
            title.Font = new Font("Arial", 24, FontStyle.Bold);
            title.ForeColor = Color.Navy;
            title.AutoSize = true;
            title.Location = new Point(300, 20);
            Controls.Add(title);

            GroupBox travelGroup = new GroupBox();
            travelGroup.Text = "Travel information";
            travelGroup.ForeColor = Color.White;
            travelGroup.Font = new Font("Arial", 11, FontStyle.Bold);
            travelGroup.Location = new Point(20, 80);
            travelGroup.Size = new Size(410, 270);
            Controls.Add(travelGroup);

            Label fromLabel = new Label();
            fromLabel.Text = "Haradan:";
            fromLabel.ForeColor = Color.White;
            fromLabel.Location = new Point(15, 45);
            fromLabel.AutoSize = true;
            travelGroup.Controls.Add(fromLabel);

            string[] cities =
            {
                "Bakı",
                "Sumqayıt",
                "Gəncə",
                "Mingəçevir",
                "Şəki",
                "Lənkəran",
                "Quba",
                "Qusar",
                "Şamaxı",
                "Şirvan",
                "Yevlax",
                "Naxçıvan",
                "Qəbələ",
                "Xaçmaz",
                "Salyan",
                "Ağcabədi",
                "Ağdaş",
                "Bərdə",
                "Tovuz",
                "Şəmkir",
                "Qazax",
                "Lerik",
                "Masallı",
                "Astara",
                "Zaqatala",
                "Balakən",
                "İsmayıllı",
                "Füzuli",
                "Cəlilabad",
                "Biləsuvar"
            };

            comboBox1.Location = new Point(120, 40);
            comboBox1.Size = new Size(150, 30);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(cities);
            travelGroup.Controls.Add(comboBox1);

            Label toLabel = new Label();
            toLabel.Text = "Haraya:";
            toLabel.ForeColor = Color.White;
            toLabel.Location = new Point(15, 90);
            toLabel.AutoSize = true;
            travelGroup.Controls.Add(toLabel);

            comboBox2.Location = new Point(120, 85);
            comboBox2.Size = new Size(150, 30);
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.AddRange(cities);
            travelGroup.Controls.Add(comboBox2);

            button2.Text = "<  >";
            button2.Location = new Point(300, 40);
            button2.Size = new Size(70, 80);
            button2.BackColor = Color.DarkRed;
            button2.ForeColor = Color.White;
            button2.Click += button2_Click;
            travelGroup.Controls.Add(button2);

            Label dateLabel = new Label();
            dateLabel.Text = "Tarix:";
            dateLabel.ForeColor = Color.White;
            dateLabel.Location = new Point(15, 140);
            dateLabel.AutoSize = true;
            travelGroup.Controls.Add(dateLabel);

            dateTimePicker1.Location = new Point(120, 135);
            dateTimePicker1.Size = new Size(120, 30);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            travelGroup.Controls.Add(dateTimePicker1);

            Label timeLabel = new Label();
            timeLabel.Text = "Saat:";
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new Point(15, 175);
            timeLabel.AutoSize = true;
            travelGroup.Controls.Add(timeLabel);

            timeComboBox.Location = new Point(245, 135);
            timeComboBox.Size = new Size(90, 30);
            timeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            for (int hour = 0; hour < 24; hour++)
            {
                for (int minute = 0; minute < 60; minute += 30)
                {
                    timeComboBox.Items.Add(
                        $"{hour:00}:{minute:00}"
                    );
                }
            }

            timeComboBox.SelectedIndex = 0;
            travelGroup.Controls.Add(timeComboBox);

            Label seatLabel = new Label();
            seatLabel.Text = "Yer:";
            seatLabel.ForeColor = Color.White;
            seatLabel.Location = new Point(15, 220);
            seatLabel.AutoSize = true;
            travelGroup.Controls.Add(seatLabel);

            textBox4.Location = new Point(120, 215);
            textBox4.Size = new Size(150, 30);
            travelGroup.Controls.Add(textBox4);

            GroupBox personGroup = new GroupBox();
            personGroup.Text = "Person information";
            personGroup.ForeColor = Color.White;
            personGroup.Font = new Font("Arial", 11, FontStyle.Bold);
            personGroup.Location = new Point(450, 80);
            personGroup.Size = new Size(410, 270);
            Controls.Add(personGroup);

            Label nameLabel = new Label();
            nameLabel.Text = "Ad və soyad:";
            nameLabel.ForeColor = Color.White;
            nameLabel.Location = new Point(15, 45);
            nameLabel.AutoSize = true;
            personGroup.Controls.Add(nameLabel);

            textBox1.Location = new Point(145, 40);
            textBox1.Size = new Size(200, 30);
            personGroup.Controls.Add(textBox1);

            Label finLabel = new Label();
            finLabel.Text = "FIN:";
            finLabel.ForeColor = Color.White;
            finLabel.Location = new Point(15, 95);
            finLabel.AutoSize = true;
            personGroup.Controls.Add(finLabel);

            textBox2.Location = new Point(145, 90);
            textBox2.Size = new Size(200, 30);
            textBox2.MaxLength = 7;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            personGroup.Controls.Add(textBox2);

            Label phoneLabel = new Label();
            phoneLabel.Text = "Telefon:";
            phoneLabel.ForeColor = Color.White;
            phoneLabel.Location = new Point(15, 145);
            phoneLabel.AutoSize = true;
            personGroup.Controls.Add(phoneLabel);

            maskedTextBox1.Location = new Point(145, 140);
            maskedTextBox1.Size = new Size(200, 30);
            maskedTextBox1.Mask = "(00) 000-00-00";
            personGroup.Controls.Add(maskedTextBox1);

            Label emailLabel = new Label();
            emailLabel.Text = "Email:";
            emailLabel.ForeColor = Color.White;
            emailLabel.Location = new Point(15, 195);
            emailLabel.AutoSize = true;
            personGroup.Controls.Add(emailLabel);

            textBox3.Location = new Point(145, 190);
            textBox3.Size = new Size(200, 30);
            personGroup.Controls.Add(textBox3);

            button1.Text = "Bilet al";
            button1.Location = new Point(10, 230);
            button1.Size = new Size(380, 35);
            button1.BackColor = Color.Navy;
            button1.ForeColor = Color.White;
            button1.Font = new Font("Arial", 11, FontStyle.Bold);
            button1.Click += button1_Click;
            personGroup.Controls.Add(button1);

            listBox1.Location = new Point(20, 370);
            listBox1.Size = new Size(840, 120);
            listBox1.Font = new Font("Arial", 10);
            Controls.Add(listBox1);

            button3.Text = "Siyahıdan sil";
            button3.Location = new Point(20, 510);
            button3.Size = new Size(160, 45);
            button3.BackColor = Color.DarkRed;
            button3.ForeColor = Color.White;
            button3.Click += button3_Click;
            Controls.Add(button3);

            button4.Text = "Proqramdan çıxış";
            button4.Location = new Point(690, 510);
            button4.Size = new Size(170, 45);
            button4.BackColor = Color.DarkOrange;
            button4.ForeColor = Color.White;
            button4.Click += button4_Click;
            Controls.Add(button4);
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 ||
                comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Haradan və haraya şəhərlərini seçin!");
                return;
            }

            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                MessageBox.Show(
                    "Gediş və təyinat şəhərləri fərqli olmalıdır!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ad və soyad daxil edin!");
                textBox1.Focus();
                return;
            }

            string fin = textBox2.Text.Trim().ToUpper();

            if (!Regex.IsMatch(fin, @"^[A-Z0-9]{7}$"))
            {
                MessageBox.Show(
                    "FIN 7 simvoldan ibarət olmalıdır!\n" +
                    "Yalnız ingilis hərfləri və rəqəmlər daxil edin!");

                textBox2.Focus();
                return;
            }

            if (!maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show(
                    "Telefon nömrəsini tam daxil edin!");

                maskedTextBox1.Focus();
                return;
            }

            string email = textBox3.Text.Trim();

            if (!Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Email ünvanını düzgün daxil edin!");

                textBox3.Focus();
                return;
            }

            if (!int.TryParse(textBox4.Text, out int seat) ||
                seat < 1 ||
                seat > 50)
            {
                MessageBox.Show(
                    "Yer nömrəsi 1-50 arasında olmalıdır!");

                textBox4.Focus();
                return;
            }

            string ticket =
                (tickets.Count + 1) +
                ") " +
                comboBox1.Text +
                " - " +
                comboBox2.Text +
                " (" +
                dateTimePicker1.Value.ToString("dd/MM/yyyy") +
                " " +
                timeComboBox.Text +
                ") Yer: " +
                seat +
                " | " +
                textBox1.Text.Trim();

            tickets.Add(ticket);

            listBox1.Items.Add(ticket);

            MessageBox.Show(
                "Bilet uğurla əlavə edildi!",
                "Gasanoff Travel",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            int fromIndex = comboBox1.SelectedIndex;
            int toIndex = comboBox2.SelectedIndex;

            comboBox1.SelectedIndex = toIndex;
            comboBox2.SelectedIndex = fromIndex;
        }

        private void button3_Click(object? sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show(
                    "Silmək üçün siyahıdan bilet seçin!");
                return;
            }

            tickets.RemoveAt(index);
            listBox1.Items.RemoveAt(index);

            for (int i = 0; i < tickets.Count; i++)
            {
                int bracket = tickets[i].IndexOf(")");

                if (bracket >= 0)
                {
                    tickets[i] =
                        (i + 1) +
                        tickets[i].Substring(bracket);
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(tickets.ToArray());
        }

        private void button4_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Proqramdan çıxmaq istəyirsiniz?",
                "Gasanoff Travel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}