using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       


        private void button1_Click(object sender, RoutedEventArgs e)
        {

            //Window3 menuWindow = new Window3(Convert.ToString(score));
            //menuWindow.ShowDialog();
        }

        

        public async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string str_Velosity;
            string str_Angle;

            while (true)
            {
                str_Velosity = Convert.ToString(str_velosity.Text);
                str_Angle = Convert.ToString(str_angle.Text);
                if (
                    (int.TryParse(str_velosity.Text, out int _Velosity))
                    &&
                    (Double.TryParse(str_angle.Text, out double _Angle)))                
                        break;
                else
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка");
                    return;
                }
            }
          
            double num_Angle = Convert.ToDouble(str_Angle)* Math.PI/180;
            double num_Velosity = Convert.ToDouble(str_Velosity);

            str_Angle = Convert.ToString(num_Angle);
            
        
            var class1 = new Class1(num_Angle, num_Velosity);
            
            class1.Fly(str_Angle, str_Velosity);
           
            var target = new Target();
           

            double i = 0;
            while (true)
            {
                
                
                double Max_Distance = ((class1.FlyOnCordX(str_Angle, str_Velosity, i)) + 10);
                double Max_Fly = 300 - (class1.FlyOnCordY(str_Angle, str_Velosity, i));
                await Task.Delay(5);
                if ((Max_Distance <= 750) && (Max_Fly <= 350) && (Max_Distance > 0) && (Max_Fly > 0))
                {
                    Canvas.SetTop(Bird, Max_Fly);
                    Canvas.SetLeft(Bird, Max_Distance);
                    if (target.IsHit(Bird1))
                    {
                        
                        Canvas.SetTop(Bird, 300);
                        Canvas.SetLeft(Bird, 10);
                        target.RandSwitch(Bird1);
                        Oshko.Text = Convert.ToString( Convert.ToDouble(Oshko.Text)+1);
                        break;
                    }
                    if (i >= 15) break;
                }
                else
                {
                   System.Windows.Forms.MessageBox.Show("Промах");
                    Canvas.SetTop(Bird, 300);
                    Canvas.SetLeft(Bird, 10);
                    return;
                }
                i += 0.04;
            }
                  


            
            

            
           
        }

        public MainWindow()
        {
            
            InitializeComponent();
        }

        
    }

}

