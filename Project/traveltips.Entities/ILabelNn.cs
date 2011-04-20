﻿using System;
using System.ComponentModel;

namespace traveltips.Entities
{
	/// <summary>
	///		The data structure representation of the 'tbl_LabelNN' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ILabelNn 
	{
		/// <summary>			
		/// id_Label : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "tbl_LabelNN"</remarks>
		System.Int64 IdLabel { get; set; }
				
		
		
		/// <summary>
		/// MaLabel : 
		/// </summary>
		System.String  MaLabel  { get; set; }
		
		/// <summary>
		/// TenLabel : 
		/// </summary>
		System.String  TenLabel  { get; set; }
		
		/// <summary>
		/// MoTa : 
		/// </summary>
		System.String  MoTa  { get; set; }
		
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
		///	which are related to this object through the relation labelLanguageIdLabel
		/// </summary>	
		TList<LabelLanguage> LabelLanguageCollection {  get;  set;}	

		#endregion Data Properties

	}
}


