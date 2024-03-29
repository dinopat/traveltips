﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_ThanhPho' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IThanhPho 
	{
		/// <summary>			
		/// id_ThanhPho : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_ThanhPho"</remarks>
		System.Int64 IdThanhPho { get; set; }
				
		
		
		/// <summary>
		/// id_QuocGia : 
		/// </summary>
		System.Int64?  IdQuocGia  { get; set; }
		
		/// <summary>
		/// TenTP : 
		/// </summary>
		System.String  TenTp  { get; set; }
		
		/// <summary>
		/// MaTP : 
		/// </summary>
		System.String  MaTp  { get; set; }
		
		/// <summary>
		/// Mota : 
		/// </summary>
		System.String  Mota  { get; set; }
		
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
		///	which are related to this object through the relation quanIdThanhPho
		/// </summary>	
		TList<Quan> QuanCollection {  get;  set;}	

		#endregion Data Properties

	}
}


