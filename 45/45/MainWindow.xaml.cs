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
using _45.Tree;
 

namespace _45
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string aktualnyText;
        TreeViewItem treeItem;
        public MainWindow()
        {
            InitializeComponent();
        
            eventList.Items.Add("Czy grać w piłke ?");
            eventList.Items.Add("Czy zatrudnić kandydata?");
            eventList.Items.Add("Czy przyznać zasiłek?");
            eventList.Items.Add("Czy wypisać ze szpitala ?");

        }

        public void Uzupelnij(int number)
        {
            Helpers helpers = new Helpers();
            DataTable dt = helpers.getDataTable(number);
            Attribute[] attributes = helpers.GetListOfAttribute(dt).ToArray();
            DecisionTree decisionTree = new DecisionTree();
            TreeNode root = decisionTree.mountTree(dt, "rezultat", attributes);  
            root.printNode(root,ref treeItem);    
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            treeItem = new TreeViewItem();
            treeItem.Header = "decision tree 4.5";
             trvMenu.Items.Add(treeItem);
            if (trvMenu.Items.Count > 1)
            {
                trvMenu.Items.RemoveAt(0);
                
            }
            Uzupelnij(eventList.SelectedIndex);
           
        }

        
        
    }
}










