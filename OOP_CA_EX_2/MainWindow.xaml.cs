using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace OOP_CA_EX_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        ObservableCollection<Student> filteredStudents = new ObservableCollection<Student>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string[] names = {"John","Paul","George","Ringo" };

            Student s1 = new Student("John", "Lennon", 1);
            Student s2 = new Student("Paul", "McCartney", 2);


            students.Add(s1);
            students.Add(s2);
            //names.Add("John");
            //names.Add("Paul");

            // telling item source that this list is what i want it to load
            lbxNames.ItemsSource = students;
        }

        private void tbxNewName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxFirstName.Clear();
        }

        private void BtnAddName_Click(object sender, RoutedEventArgs e)
        {
            // Read details from screen
            string firstName = tbxFirstName.Text;
            string lastname = tbxLastName.Text;
            int year =Convert.ToInt32(tbxYear.Text);

            // Create student object
            Student student = new Student(firstName, lastname, year);

            // Add to observable Collection
            students.Add(student);

            //string newName = tbxNewName.Text;
            //Add to Array/List
            //names.Add(newName);

            // Refresh the disply manually
            //lbxNames.ItemsSource = null;
            //lbxNames.ItemsSource = names;
        }

        private void lbxNames_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check what has been selected
            //Student selectedStudent = (Student)lbxNames.SelectedItem;
            Student selectedStudent = lbxNames.SelectedItem as Student;

            // Ensure it is not null
            if(selectedStudent != null)
            {
                // Take action - Update the display
                tbxFirstName.Text = selectedStudent.FirstName;
                tbxLastName.Text = selectedStudent.LastName;
                tbxYear.Text = selectedStudent.Year.ToString();
            }


        }

        private void tbxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxLastName.Clear();
        }

        private void rbAll_Checked(object sender, RoutedEventArgs e)
        {
            // Setter
            int year = 0;
            filteredStudents.Clear();
            lbxNames.ItemsSource = null;

            // Find out what was selected
            if(rbAll.IsChecked == true)
            {
                lbxNames.ItemsSource = students;
            }
            else
            {
                if (rbYear1.IsChecked == true)
                {
                    year = 1;
                }
                else if (rbYear2.IsChecked == true)
                {
                    year = 2;
                }
                foreach (Student student in students)
                {
                    if (student.Year == year)
                    {
                        filteredStudents.Add(student);
                    }
                }

                lbxNames.ItemsSource = filteredStudents;
            }
          
            
        }

        private void tbxYear_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxYear.Clear();
        }
    }
}
