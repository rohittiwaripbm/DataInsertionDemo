using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDataCode.Csfiles
{
    public class UserData
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _uname;

		public string UName
		{
			get { return _uname; }
			set { _uname = value; }
		}

		private string _uemail;

		public string UEmail
		{
			get { return _uemail; }
			set { _uemail = value; }
		}
		private string _mobno;

		public string MobileNo
		{
			get { return _mobno; }
			set { _mobno = value; }
		}
		private bool _uisactive;

		public bool Uisactive
		{
			get { return _uisactive; }
			set { _uisactive = value; }
		}





	}
}