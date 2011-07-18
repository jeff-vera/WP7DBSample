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
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DBSample.Model
{
	[Table]
	public class User
	{
		[Column(
			IsPrimaryKey=true,
			IsDbGenerated=true,
			DbType="INT NOT NULL Identity",
			CanBeNull=false)]
		public int Id { get; set; }

		[Column]
		public string FirstName { get; set; }

		[Column]
		public string LastName { get; set; }

		[Column]
		public DateTime CreatedOn { get; set; }
	}
}
