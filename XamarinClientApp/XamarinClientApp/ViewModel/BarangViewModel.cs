﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp.ViewModel
{
    public class BarangViewModel : BindableObject
    {
        private RestClient _client =
           new RestClient("http://onderdilshop.azurewebsites.net/");

        private ObservableCollection<Barangs> listBarang;
        public ObservableCollection<Barangs> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/Barangs", Method.GET);
            var _response = await _client.Execute<List<Barangs>>(_request);
            ListBarang = new ObservableCollection<Barangs>(_response.Data);
        }

        public BarangViewModel()
        {
            RefreshDataAsync();
        }
    }
}
