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
    public class GetCompaniesPage : ContentPage
    {
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Mydb.db3");
        public GetCompaniesPage()
        {
            this.Title = "Companies";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Company>().OrderBy(n => n.Name).ToList();
            stackLayout.Children.Add(_listView);
            Content = stackLayout;
        }
    }
}