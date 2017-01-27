using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _45.Db;
using _45.Db.Models;

namespace _45
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string aktualnyText;
             
        public MainWindow()
        {
            InitializeComponent();
            Uzupelnij();
        }

        public void Uzupelnij()
        {

            Attribute pogoda = LoadAtributes.GetAttribute();
            var dd=5;

            //Attribute pogoda = new Attribute("pogoda", new string[] { "slonecznie", "pochmurnie", "deszczowo" });
            Attribute temperatura = new Attribute("temperatura", new string[] { "wysoka", "niska", "umiarkowana" });
            Attribute zachmurzenie = new Attribute("zachmurzenie", new string[] { "wysokie", "umiarkowane" });
            Attribute wiatr = new Attribute("wiatr", new string[] { "tak", "nie" });

            Attribute[] attributes = new Attribute[] { pogoda, temperatura, zachmurzenie, wiatr };

            DataTable samples = ID3Sample.getDataTable();

            DecisionTreeID3 id3 = new DecisionTreeID3();
            TreeNode root = id3.mountTree(samples, "rezultat", attributes);

            string kolejnosc = string.Empty;           
            ID3Sample.printNode(root, "                      ", ref kolejnosc);

            tak.Text = kolejnosc;


        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            Uzupelnij();
            }

    
        }             
             

        
    }






