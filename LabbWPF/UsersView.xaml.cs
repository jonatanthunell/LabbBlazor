﻿using LabbBlazor;
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

namespace LabbWPF
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private UsersViewModel _viewModel;
        public UsersView()
        {
            InitializeComponent();
            _viewModel = new UsersViewModel(new ApiDataAccess());
            DataContext = _viewModel;
        }
        private async void OnLoaded_Event(object sender, RoutedEventArgs e)
        {
            await _viewModel.SetUserDataAsync();
        }
    }
}