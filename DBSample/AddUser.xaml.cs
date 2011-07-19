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
	public partial class AddUser : PhoneApplicationPage
	{
		public AddUser()
		{
			InitializeComponent();
		}

		private void addUser_Click(object sender, RoutedEventArgs e)
		{
			Model.User u = new Model.User
			{
				FirstName = firstName.Text,
				LastName = lastName.Text,
				CreatedOn = DateTime.Now
			};

			using (var db = new Model.UserDataContext(Model.UserDataContext.connString))
			{
				db.Users.InsertOnSubmit(u);
				db.SubmitChanges();
				status.Text = string.Concat("User ", u.FullName, " added");

				firstName.Text = "";
				lastName.Text = "";
			}
		}
	}
}