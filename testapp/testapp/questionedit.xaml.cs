using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace testapp
{
    /// <summary>
    /// Interaction logic for questionedit.xaml
    /// </summary>
    public partial class questionedit : Page
    {
        public static int num = 0;
        public static string sfile = "";
        private static string ques = "";
        private static string[] ans = new string[5];
        public questionedit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ans[4] = A1text.Text;
            MessageBox.Show($"Right Answer = {A1text.Text}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ans[4] = A2text.Text;
            MessageBox.Show($"Right Answer = {A2text.Text}");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ans[4] = A3text.Text;
            MessageBox.Show($"Right Answer = {A3text.Text}");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ans[4] = A4text.Text;
            MessageBox.Show($"Right Answer = {A4text.Text}");
        }

        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (qtext.Text.Trim() == "" || A1text.Text.Trim() == "" || A2text.Text.Trim() == "" || A3text.Text.Trim() == "" ||
                A4text.Text.Trim() == "")
            {
                MessageBox.Show("Cannot Have A Blank Question Or Answer");
            }if(ans[4].Trim() == "")
            {
                MessageBox.Show("Need A Right Answer");
            }
            else {
                ques = qtext.Text;
                ans[0] = A1text.Text;
                ans[1] = A2text.Text;
                ans[2] = A3text.Text;
                ans[3] = A4text.Text;
                questions.Add(ques, ans);
                using (StreamWriter file = new StreamWriter(sfile, false))
                    foreach (String key in questions.Keys)
                    {
                        file.Write($"{key} @@ ");
                        int temp = 1;
                        foreach (String item in questions[key])
                        {
                            if (temp == 5)
                            {
                                file.Write($"{item} ");
                            }
                            else
                            {
                                file.Write($"{item} ~~ ");
                                temp++;
                            }
                        }
                        file.WriteLine();
                    }
                MessageBox.Show("Question has been saved");
                make.Content = new selectquestion();
            }
        }


        public static string oq = "";
        public static string o1 = "";
        public static string o2 = "";
        public static string o3 = "";
        public static string o4 = "";
        public static string ori = "";
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Are You Sure? Anything Not Saved Will Be Lost","Confirm", 
                MessageBoxButton.YesNo);
            if(m == MessageBoxResult.Yes)
            {
                ques = oq;
                ans[0] = o1;
                ans[1] = o2;
                ans[2] = o3;
                ans[3] = o4;
                ans[4] = ori;
                selectquestion.questions.Add(ques, ans);
                make.Content = new selectquestion();
            }
        }
    }
}

