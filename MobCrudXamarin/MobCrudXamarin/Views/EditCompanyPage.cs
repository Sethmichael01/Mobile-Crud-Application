using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;

using Xamarin.Forms;
using MobCrudXamarin.Models;

namespace MobCrudXamarin.Views
{
    public class EditCompanyPage : ContentPage
    {
        private ListView _ListView;
        private Entry _IdEntry;
        private Entry _nameEntry;
        private Entry _AddressEntry;
        private Button _SaveEntry;
        Company company = new Company();
        //Database
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Mydb.db3");
        public EditCompanyPage()
        {
            this.Title = "Edit Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _ListView = new ListView();
            _ListView.ItemsSource = db.Table<Company>().OrderBy(n => n.Name).ToList();
            _ListView.ItemSelected += _ListView_ItemSelected;
            stackLayout.Children.Add(_ListView);

            _IdEntry = new Entry();
            _IdEntry.Placeholder = "Id";
            _IdEntry.IsVisible = false;
            stackLayout.Children.Add(_IdEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company Name";
            stackLayout.Children.Add(_nameEntry);

            _AddressEntry = new Entry();
            _AddressEntry.Keyboard = Keyboard.Text;
            _AddressEntry.Placeholder = "Company Address";
            stackLayout.Children.Add(_AddressEntry);

            _SaveEntry = new Button();
            _SaveEntry.Text = "Update";
            _SaveEntry.Clicked += _SaveEntry_Clicked;
            stackLayout.Children.Add(_SaveEntry);

            Content = stackLayout;

        }

        private async void _SaveEntry_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                Id = Convert.ToInt32(_IdEntry.Text),
                Name = _nameEntry.Text,
                Address = _AddressEntry.Text
            };
            db.Update(company);
            await Navigation.PopAsync();

        }

        private void _ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;
            _IdEntry.Text = company.Id.ToString();
            _nameEntry.Text = company.Name;
            _AddressEntry.Text = company.Address;
        }
    }
}