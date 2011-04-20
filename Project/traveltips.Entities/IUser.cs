﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_User' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IUser 
	{
		/// <summary>			
		/// id_User : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_User"</remarks>
		System.Int64 IdUser { get; set; }
				
		
		
		/// <summary>
		/// TenDangNhap : 
		/// </summary>
		System.String  TenDangNhap  { get; set; }
		
		/// <summary>
		/// Password : 
		/// </summary>
		System.String  Password  { get; set; }
		
		/// <summary>
		/// HoTen : 
		/// </summary>
		System.String  HoTen  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
		
		/// <summary>
		/// DiaChi : 
		/// </summary>
		System.String  DiaChi  { get; set; }
		
		/// <summary>
		/// DienThoai : 
		/// </summary>
		System.String  DienThoai  { get; set; }
		
		/// <summary>
		/// Website : 
		/// </summary>
		System.String  Website  { get; set; }
		
		/// <summary>
		/// Avatar : 
		/// </summary>
		System.String  Avatar  { get; set; }
		
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


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation commentIdUser
		/// </summary>	
		TList<Comment> CommentCollection {  get;  set;}	

		#endregion Data Properties

	}
}


