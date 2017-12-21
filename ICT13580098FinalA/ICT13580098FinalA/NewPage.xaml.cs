using ICT13580098FinalA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580098FinalA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPage : ContentPage
    {
        Employee emp;
        public NewPage(Employee emp=null)
        {
            InitializeComponent();

            this.emp = emp;
            titleLabel.Text = emp == null ? "เพิ่มข้อมูลพนักงาน" : "แก้ไขข้อมูลพนักงาน";

            genderPicker.Items.Add("ชาย");
            genderPicker.Items.Add("หญิง");
            sectionPicker.Items.Add("การบัญชี");
            sectionPicker.Items.Add("พนักงานทำความสะอาด");
            sectionPicker.Items.Add("โปรแกรมมิ่ง");
            statusPicker.Items.Add("โสด");
            statusPicker.Items.Add("หย่าร้าง");
            statusPicker.Items.Add("สมรส");

            myStepper.ValueChanged += MyStepper_ValueChanged;
            mySlider.ValueChanged += MySlider_ValueChanged;

            saveButton.Clicked += SaveButton_Clicked;

            if(emp != null)
            {
                nameEntry.Text = emp.Name;
                lastNameEntry.Text = emp.Lastname;
                ageEntry.Text = emp.Age.ToString();
                genderPicker.SelectedItem = emp.Gender;
                sectionPicker.SelectedItem = emp.Section;
                telEntry.Text = emp.TellNo;
                emailEntry.Text = emp.Email;
                addressEditor.Text = emp.Address;
                statusPicker.SelectedItem = emp.Engage;
                valueLabel.Text = emp.Child.ToString();
                salaryLabel.Text = emp.Salary.ToString();

            }
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกข้อมูลนี้ใช่หรือไม่", "ใช่", "ยกเลิก");
            if (isOk)
            {
                var detail = new Employee();
                if (emp==null)
                {
                
                detail.Name = nameEntry.Text;
                detail.Lastname = lastNameEntry.Text;
                detail.Age = int.Parse(ageEntry.Text);
                detail.Gender = genderPicker.SelectedItem.ToString();
                detail.Section = sectionPicker.SelectedItem.ToString();
                detail.TellNo = telEntry.Text;
                detail.Email = emailEntry.Text;
                detail.Address = addressEditor.Text;
                detail.Engage = statusPicker.SelectedItem.ToString();
                detail.Child = int.Parse(valueLabel.Text);
                detail.Salary = decimal.Parse(salaryLabel.Text);
                var id = App.DbHelper.AddDetail(detail);
                await DisplayAlert("บันทึกข้อมูลสำเร็จ", "รหัสพนักงานของคุณคือ #" + id, "ตกลง");
                }
                else
                {
                    detail.Name = nameEntry.Text;
                    detail.Lastname = lastNameEntry.Text;
                    detail.Age = int.Parse(ageEntry.Text);
                    detail.Gender = genderPicker.SelectedItem.ToString();
                    detail.Section = sectionPicker.SelectedItem.ToString();
                    detail.TellNo = telEntry.Text;
                    detail.Email = emailEntry.Text;
                    detail.Address = addressEditor.Text;
                    detail.Engage = statusPicker.SelectedItem.ToString();
                    detail.Child = int.Parse(valueLabel.Text);
                    detail.Salary = decimal.Parse(salaryLabel.Text);
                    var id = App.DbHelper.UpdateDetail(detail);
                    await DisplayAlert("แก้ไขข้อมูลเรียบร้อย", "รหัสพนักงาน #" + id+" ถูกแก้ไขแล้ว", "ตกลง");
                }
                await Navigation.PopModalAsync();


            }
        }

        private void MySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            salaryLabel.Text = value.ToString();
        }

        private void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int value = (int)e.NewValue;
            valueLabel.Text = value.ToString();
        }
    }
}