	

#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Data;

using traveltips.Entities;
using traveltips.Entities.Validation;

using traveltips.DAO;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion

namespace traveltips.Services
{		
	
	///<summary>
	/// An component type implementation of the 'tbl_SanPham' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class SanPhamService : traveltips.Services.SanPhamServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the SanPhamService class.
		/// </summary>
		public SanPhamService() : base()
		{
		}
		
	}//End Class


} // end namespace
