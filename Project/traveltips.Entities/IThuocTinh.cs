﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_ThuocTinh' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IThuocTinh 
	{
		/// <summary>			
		/// id_ThuocTinh : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_ThuocTinh"</remarks>
		System.Int64 IdThuocTinh { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int64 OriginalIdThuocTinh { get; set; }
			
		
		
		/// <summary>
		/// TenThuocTinh : 
		/// </summary>
		System.String  TenThuocTinh  { get; set; }
		
		/// <summary>
		/// MaThuocTinh : 
		/// </summary>
		System.String  MaThuocTinh  { get; set; }
		
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
		///	which are related to this object through the relation thuocTinhSanPhamIdThuocTinh
		/// </summary>	
		TList<ThuocTinhSanPham> ThuocTinhSanPhamCollection {  get;  set;}	

		#endregion Data Properties

	}
}

