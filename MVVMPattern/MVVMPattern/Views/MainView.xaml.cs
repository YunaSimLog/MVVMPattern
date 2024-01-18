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
using System.Windows.Shapes;

namespace MVVMPattern.Views
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            tbID.TextChanged += Txt_TextChanged;
            tbTitle.TextChanged += Txt_TextChanged;
            tbRenter.TextChanged += Txt_TextChanged;
            tbRentalPeriod.TextChanged += Txt_TextChanged;
        }

        /// <summary>
        /// 한국어 텍스트 박스에 입력시 버벅 거림 오류를 제거하기 위함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression be = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }
    }
}
