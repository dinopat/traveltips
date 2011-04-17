	

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
using traveltips.DAO.Bases;

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

        public bool IsExistEmailOfAdmin_Sp(string email)
        {
            object[] paramObj = new object[1];
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter();
            param1.ParameterName = "@email";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Size = 50;
            param1.Value = email;

            paramObj[0] = param1.Value;
            DataSet ds = DataRepository.Provider.ExecuteDataSet("sp_CheckExistAdminEmail", paramObj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public bool IsExistAdminAccount_Sp(string tenDangNhap)
        {
            object[] paramObj = new object[1];
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter();
            param1.ParameterName = "@tenDangNhap";
            param1.SqlDbType = SqlDbType.VarChar;
            param1.Size = 50;
            param1.Value = tenDangNhap;

            paramObj[0] = param1.Value;
            DataSet ds= DataRepository.Provider.ExecuteDataSet("sp_CheckExistAdminTenDangNhap", paramObj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public bool IsExistAdminAccount(string tenDangNhap)
        {
            bool isExistAdminAccount = false;
            AdminParameterBuilder query1 = new AdminParameterBuilder();
            query1.AppendEquals(AdminColumn.TenDangNhap, tenDangNhap);
      
            //SqlFilterParameter filterParam = new SqlFilterParameter(AdminColumn.TenDangNhap, tenDangNhap, 0);
            //query1.Parameters.Add(filterParam);
            


            TList<Admin> list1 = DataRepository.AdminProvider.Find(query1.GetParameters());
            if (list1.Count > 0)
            {
                isExistAdminAccount = true;
            }
            else
            {
                isExistAdminAccount = false;
            }
            return isExistAdminAccount;
        }

        public bool IsExistEmailOfAdmin(string email)
        {
            bool isExistEmailOfAdmin = false;
            AdminParameterBuilder query1 = new AdminParameterBuilder();
            SqlFilterParameter filterParam = new SqlFilterParameter(AdminColumn.Email, email, 0);
            query1.Parameters.Add(filterParam);

            TList<Admin> list1 = DataRepository.AdminProvider.Find(query1.GetParameters());
            if (list1.Count > 0)
            {
                isExistEmailOfAdmin = true;
            }
            else
            {
                isExistEmailOfAdmin = false;
            }
            return isExistEmailOfAdmin;
        }

	}//End Class


} // end namespace
