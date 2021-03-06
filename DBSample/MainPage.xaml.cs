﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DBSample
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			using (
				var db = new Model.UserDataContext(Model.UserDataContext.connString))
			{
				var users = from Model.User u in db.Users select u;
				userList.ItemsSource = users;
				userList.DisplayMemberPath = "FullName";
			}			
		}

		private void AddUser_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/AddUser.xaml", UriKind.Relative));
		}

		private void DeleteUser_Click(object sender, EventArgs e)
		{
			NavigationService.Navigate(new Uri("/DeleteUser.xaml", UriKind.Relative));
		}
	}
}