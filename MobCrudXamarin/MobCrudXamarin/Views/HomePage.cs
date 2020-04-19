using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobCrudXamarin.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Company";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);
            //Second Button
            button = new Button();
            button.Text = "Get";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);
            //Third Button
            button = new Button();
            button.Text = "Edit";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);
            //Fourth Button
            button = new Button();
            button.Text = "Delete";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        //First Button
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCompanyPage());
        }
        //Second Button
        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetCompaniesPage());
        }
        //Third Button
        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPage());
        }
        //Fourth Button
        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPage());
        }
    }
}