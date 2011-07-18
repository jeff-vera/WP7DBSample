using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Data.Linq;

namespace DBSample.Model
{
	public class UserDataContext : DataContext
	{
		public static string connString = "Data Source=isostore:/Users.sdf";

		public UserDataContext(string connString)
			: base(connString)
		{ }

		public Table<User> Users;
	}
}
