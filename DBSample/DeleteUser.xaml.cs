using System;
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
	public partial class DeleteUser : PhoneApplicationPage
	{
		public DeleteUser()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			LoadUsers();
		}

		private void LoadUsers()
		{
			using (var db = new Model.UserDataContext(Model.UserDataContext.connString))
			{
				var users = from Model.User u in db.Users select u;
				userList.ItemsSource = users;
				userList.DisplayMemberPath = "FullName";
			}
		}

		private void userList_Tap(object sender, GestureEventArgs e)
		{			
			if (e.OriginalSource is TextBlock)
			{
				Model.User u = userList.SelectedItem as Model.User;
				using (var db = new Model.UserDataContext(Model.UserDataContext.connString))
				{
					db.Users.Attach(u);
					db.Users.DeleteOnSubmit(u);
					db.SubmitChanges();
				}

				status.Text = string.Concat(u.FullName, " deleted");
			}

			LoadUsers();
		}
	}
}