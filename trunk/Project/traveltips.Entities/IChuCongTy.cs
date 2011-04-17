﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_ChuCongTy' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IChuCongTy 
	{
		/// <summary>			
		/// id_ChuCongTy : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_ChuCongTy"</remarks>
		System.Int64 IdChuCongTy { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int64 OriginalIdChuCongTy { get; set; }
			
		
		
		/// <summary>
		/// TenChuCongTy : 
		/// </summary>
		System.String  TenChuCongTy  { get; set; }
		
		/// <summary>
		/// TenCongTy : 
		/// </summary>
		System.String  TenCongTy  { get; set; }
		
		/// <summary>
		/// TenDangNhap : 
		/// </summary>
		System.String  TenDangNhap  { get; set; }
		
		/// <summary>
		/// Password : 
		/// </summary>
		System.String  Password  { get; set; }
		
		/// <summary>
		/// DiaChi : 
		/// </summary>
		System.String  DiaChi  { get; set; }
		
		/// <summary>
		/// DienThoaiCD : 
		/// </summary>
		System.String  DienThoaiCd  { get; set; }
		
		/// <summary>
		/// DienThoaiDD : 
		/// </summary>
		System.String  DienThoaiDd  { get; set; }
		
		/// <summary>
		/// NgayTao : 
		/// </summary>
		System.DateTime?  NgayTao  { get; set; }
		
		/// <summary>
		/// NgayKetThuc : 
		/// </summary>
		System.DateTime?  NgayKetThuc  { get; set; }
		
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
		///	which are related to this object through the relation congTyIdChuCongTy
		/// </summary>	
		TList<CongTy> CongTyCollection {  get;  set;}	

		#endregion Data Properties

	}
}

