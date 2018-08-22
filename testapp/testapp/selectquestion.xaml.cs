using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace testapp
{
    /// <summary>
    /// Interaction logic for selectquestion.xaml
    /// </summary>
    public partial class selectquestion : Page
    {
        public selectquestion()
        {
            InitializeComponent();
            foreach (string file in questions.Keys)
            {
                quizzes.Items.Add(file);
            }
        }

        public static Dictionary<string, string[]> questions = new Dictionary<string, string[]>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            questionedit q = new questionedit();
            foreach(string key in questions.Keys)
            {
                if((string)quizzes.SelectedItem == key)
                {
                    q.qtext.Text = key.Trim();
                    questionedit.oq = key.Trim();
                    q.A1text.Text = questions[key][0].Trim();
                    questionedit.o1 = questions[key][0].Trim();
                    q.A2text.Text = questions[key][1].Trim();
                    questionedit.o2 = questions[key][1].Trim();
                    q.A3text.Text = questions[key][2].Trim();
                    questionedit.o3 = questions[key][2].Trim();
                    q.A4text.Text = questions[key][3].Trim();
                    questionedit.o4 = questions[key][3].Trim();
                    questionedit.ori = questions[key][4].Trim();
                    questions.Remove(key);
                    break;
                }
            }
            questionedit.questions = questions;
            back.Content = q;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            back.Content = new editquiz();
        }
    }
}
