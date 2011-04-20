﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_Admin' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IAdmin 
	{
		/// <summary>			
		/// id_Admin : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_Admin"</remarks>
		System.Int64 IdAdmin { get; set; }
				
		
		
		/// <summary>
		/// TenDangNhap : 
		/// </summary>
		System.String  TenDangNhap  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
		
		/// <summary>
		/// Password : 
		/// </summary>
		System.String  Password  { get; set; }
		
		/// <summary>
		/// HoTen : 
		/// </summary>
		System.String  HoTen  { get; set; }
		
		/// <summary>
		/// DienThoai : 
		/// </summary>
		System.String  DienThoai  { get; set; }
		
		/// <summary>
		/// Flag : 
		/// </summary>
		System.Byte?  Flag  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


