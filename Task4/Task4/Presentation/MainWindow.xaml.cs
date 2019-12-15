
using Presentation.ViewModels;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            AddPersonView addPersonView = new AddPersonView();
            AddInvetoryView addInvetoryView = new AddInvetoryView();
            AddInvoiceView addInvoiceView = new AddInvoiceView();
            AddProductView addProductView = new AddProductView();
            ViewAll viewAll = new ViewAll();
            InitializeComponent();
            DataContext = new StoreViewModel(addPersonView, addInvoiceView, addInvetoryView, addProductView);
        }

 
    }
}
