using ICT13580098FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580098FinalA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;
            
        }

        protected override void OnAppearing()
        {
            LoadData();
         }
        void LoadData()
        {
            employeeListview.ItemsSource = App.DbHelper.GetDetail();
        }
        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NewPage());
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var emp = button.CommandParameter as Employee;
            Navigation.PushModalAsync(new NewPage(emp));
            

        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบข้อมูลนี้ใช่หรือไม่?", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                var button = sender as MenuItem;
                var emp = button.CommandParameter as Employee;
                App.DbHelper.DeleteEmp(emp);

               await DisplayAlert("การลบเสร็จสิ้น", "ข้อมูลได้ถูกลบทิ้งแล้ว", "ตกลง");

                LoadData();
            }

        }
    }
}
