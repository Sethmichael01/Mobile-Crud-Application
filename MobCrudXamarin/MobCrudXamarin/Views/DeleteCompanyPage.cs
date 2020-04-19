using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using MobCrudXamarin.Models;

using Xamarin.Forms;

namespace MobCrudXamarin.Views
{
    public class DeleteCompanyPage : ContentPage
    {
        private ListView _ListView;
        private Button _SaveEntry;
        Company company = new Company();
        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Mydb.db3");
        public DeleteCompanyPage()
        {
            this.Title = "Delete Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _ListView = new ListView();
            _ListView.ItemsSource = db.Table<Company>().OrderBy(n => n.Name).ToList();
            _ListView.ItemSelected += _ListView_ItemSelected;
            stackLayout.Children.Add(_ListView);

            _SaveEntry = new Button();
            _SaveEntry.Text = "Delete";
            _SaveEntry.Clicked += _SaveEntry_Clicked;
            stackLayout.Children.Add(_SaveEntry);

            Content = stackLayout;
        }

        private async void _SaveEntry_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Company>().Delete(d => d.Id == company.Id);
            await Navigation.PopAsync();

        }
        private void _ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;           
        }
    }
}