﻿#region Imports...
using System;
using System.Data;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using traveltips.Entities;
#endregion

namespace traveltips.Web.Data
{
	/// <summary>
	/// Binds a user-defined value to a parameter object.
	/// </summary>
	public class CustomParameter : Parameter
	{
		/// <summary>
		/// The user-defined value that the parameter is bound to.
		/// </summary>
		private Object _value = String.Empty;
		private String _valueTypeName;
		private Type _valueType;

		/// <summary>
		/// Initializes a new unnamed instance of the CustomParameter class.
		/// </summary>
		public CustomParameter()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the CustomParameter class with
		/// the values of the instance specified by the original parameter.
		/// </summary>
		/// <param name="original">A CustomParameter from which the current instance is initialized.</param>
		public CustomParameter(CustomParameter original)
			: base(original)
		{
			if ( original != null )
			{
				Value = original.Value;
			}
		}

		/// <summary>
		/// Initializes a new named instance of the CustomParameter class.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		public CustomParameter(String name)
			: base(name)
		{
		}

		/// <summary>
		/// Initializes a new named instance of the CustomParameter class,
		/// using the specified value.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="value">The user-defined value that the parameter is bound to.
		/// The default is a String.Emtpy.</param>
		public CustomParameter(String name, String value)
			: base(name)
		{
			Value = value;
		}

		/// <summary>
		/// Initializes a new named instance of the CustomParameter class,
		/// using the specified value.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="value">The user-defined value that the parameter is bound to.
		/// The default is a String.Emtpy.</param>
		public CustomParameter(String name, Object value)
			: base(name)
		{
			_value = value;
		}

		/// <summary>
		/// Initializes a new named and strongly typed instance of the
		/// CustomParameter class, using the specified property name to identify
		/// which System.Web.UI.DataSourceSelectArguments property to bind to.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="type">The type that the parameter represents. The default is System.TypeCode.Object.</param>
		/// <param name="value">The user-defined value that the parameter is bound to.
		/// The default is a String.Empty.</param>
		public CustomParameter(String name, TypeCode type, String value)
			: base(name, type)
		{
			Value = value;
		}

		/// <summary>
		/// Gets or sets the user-defined value that the CustomParameter object binds to.
		/// </summary>
		public String Value
		{
			get { return String.Format("{0}", _value); }
			set { _value = value; }
		}

		/// <summary>
		/// Gets or sets the user-defined value that the CustomParameter object binds to.
		/// </summary>
		[Browsable(false)]
		public Object ObjectValue
		{
			get { return _value; }
			set { _value = value; }
		}

		/// <summary>
		/// Gets or sets the name of the class that the CustomParameter.Value represents.
		/// </summary>
		public String ValueTypeName
		{
			get { return _valueTypeName; }
			set { _valueTypeName = value; }
		}

		/// <summary>
		/// Gets or set the type that the CustomParameter.Value represents.
		/// </summary>
		[Browsable(false)]
		public Type ValueType
		{
			get
			{
				if ( _valueType == null )
				{
					_valueType = EntityUtil.GetType(ValueTypeName);
				}

				return _valueType;
			}
			set { _valueType = value; }
		}

		/// <summary>
		/// Updates and returns the value of the CustomParameter object.
		/// </summary>
		/// <param name="context">The current System.Web.HttpContext of the request.</param>
		/// <param name="control">The System.Web.UI.Control that the parameter is bound to.</param>
		/// <returns>A System.Object that represents the updated and current value of the parameter.</returns>
		protected override Object Evaluate(HttpContext context, Control control)
		{
			Object value = _value;

			if ( ValueType != null )
			{
				value = EntityUtil.ChangeType(value, ValueType);
			}

			return value;
		}
	}
}
