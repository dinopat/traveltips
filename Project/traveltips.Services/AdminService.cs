	

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
	/// An component type implementation of the 'tbl_Admin' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class AdminService : traveltips.Services.AdminServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the AdminService class.
		/// </summary>
		public AdminService() : base()
		{
		}

        public bool Insert(Admin adminEntity)
        {
            try
            {
                return DataRepository.AdminProvider.Insert(adminEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isExistAdminAccount(string tenDangNhap)
        {
            object s = DataRepository.Provider.ExecuteScalar(CommandType.Text, "select * from");
            return false;
        }
	}//End Class


} // end namespace
