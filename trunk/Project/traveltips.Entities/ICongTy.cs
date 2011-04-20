﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_CongTy' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ICongTy 
	{
		/// <summary>			
		/// id_CongTy : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_CongTy"</remarks>
		System.Int64 IdCongTy { get; set; }
				
		
		
		/// <summary>
		/// id_ChuCongTy : 
		/// </summary>
		System.Int64?  IdChuCongTy  { get; set; }
		
		/// <summary>
		/// id_DanhMuc : 
		/// </summary>
		System.Int64?  IdDanhMuc  { get; set; }
		
		/// <summary>
		/// id_QuocGia : 
		/// </summary>
		System.Int64?  IdQuocGia  { get; set; }
		
		/// <summary>
		/// id_ThanhPho : 
		/// </summary>
		System.Int64?  IdThanhPho  { get; set; }
		
		/// <summary>
		/// id_Quan : 
		/// </summary>
		System.Int64?  IdQuan  { get; set; }
		
		/// <summary>
		/// id_Duong : 
		/// </summary>
		System.Int64?  IdDuong  { get; set; }
		
		/// <summary>
		/// id_KhuVuc : 
		/// </summary>
		System.Int64?  IdKhuVuc  { get; set; }
		
		/// <summary>
		/// SoNha : 
		/// </summary>
		System.String  SoNha  { get; set; }
		
		/// <summary>
		/// DienThoaiCD : 
		/// </summary>
		System.String  DienThoaiCd  { get; set; }
		
		/// <summary>
		/// DienThoaiDD : 
		/// </summary>
		System.String  DienThoaiDd  { get; set; }
		
		/// <summary>
		/// Fax : 
		/// </summary>
		System.String  Fax  { get; set; }
		
		/// <summary>
		/// Email : 
		/// </summary>
		System.String  Email  { get; set; }
		
		/// <summary>
		/// Website : 
		/// </summary>
		System.String  Website  { get; set; }
		
		/// <summary>
		/// HinhThucTT : 
		/// </summary>
		System.String  HinhThucTt  { get; set; }
		
		/// <summary>
		/// ThoiGianPV : Luu duoi dang: Tu;den
		/// </summary>
		System.String  ThoiGianPv  { get; set; }
		
		/// <summary>
		/// AnhMinhHoa : 
		/// </summary>
		System.String  AnhMinhHoa  { get; set; }
		
		/// <summary>
		/// GhiChu : 
		/// </summary>
		System.String  GhiChu  { get; set; }
		
		/// <summary>
		/// MoTaNgan : 
		/// </summary>
		System.String  MoTaNgan  { get; set; }
		
		/// <summary>
		/// MoTaChiTiet : 
		/// </summary>
		System.String  MoTaChiTiet  { get; set; }
		
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
		///	which are related to this object through the relation galleryIdCongTy
		/// </summary>	
		TList<Gallery> GalleryCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation tinTucIdCongTy
		/// </summary>	
		TList<TinTuc> TinTucCollection {  get;  set;}	
	

		/// <summary>
		///	Holds a  SanPham entity object
		///	which is related to this object through the relation sanPhamIdSanPham
		/// </summary>
		SanPham SanPham { get; set; }
	

		/// <summary>
		///	Holds a  DichVu entity object
		///	which is related to this object through the relation dichVuIdDichVu
		/// </summary>
		DichVu DichVu { get; set; }


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation commentIdCongty
		/// </summary>	
		TList<Comment> CommentCollection {  get;  set;}	

		#endregion Data Properties

	}
}


