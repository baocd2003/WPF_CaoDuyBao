using Service;
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

namespace CarRentingWPF_CaoDuyBao.Admin
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        private IRentingManagementService _rentService;
        public Report()
        {
            InitializeComponent();
            _rentService = new RentingManagementService();
        }

        private void DetailsDgv_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sDatePick.SelectedDate == null)
            {
                MessageBox.Show("Please select start date");
                return;
            }
            if (eDatePick.SelectedDate == null)
            {
                MessageBox.Show("Please select end date");
                return;
            }
            DetailsDgv.ItemsSource = _rentService.ReportDetails((DateTime)sDatePick.SelectedDate, (DateTime)eDatePick.SelectedDate);
        }
    }
}
