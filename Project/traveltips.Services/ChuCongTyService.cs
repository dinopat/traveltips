	

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
	/// An component type implementation of the 'tbl_ChuCongTy' table.
	///</summary>
	/// <remarks>
	/// All custom implementations should be done here.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class ChuCongTyService : traveltips.Services.ChuCongTyServiceBase
	{
		/// <summary>
		/// Initializes a new instance of the ChuCongTyService class.
		/// </summary>
		public ChuCongTyService() : base()
		{
		}

        public TList<ChuCongTy> GetChuCongTyInfo()
        {
            return DataRepository.ChuCongTyProvider.GetAll();
        }

        public void DeleteChuCongTyByIdChuCongTy(long idChuCongTy)
        {
            DataRepository.ChuCongTyProvider.Delete(idChuCongTy);
        }

        public ChuCongTy GetChuCongTyInfoByIdChuCongTy(long idChuCongTy)
        {
            return DataRepository.ChuCongTyProvider.GetByIdChuCongTy(idChuCongTy);
        }

        public bool UpdateChuCongTy(ChuCongTy chuCTyInfo)
        {
            bool isUpdateChuCongTy = false;
            try
            {
                isUpdateChuCongTy = DataRepository.ChuCongTyProvider.Update(chuCTyInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdateChuCongTy;
        }

        public bool BlockChuCongTyByIdChuCongTy(long idChuCongTy)
        {
            bool isBlockChuCongTy = false;
            try
            {
                ChuCongTy ct = GetChuCongTyInfoByIdChuCongTy(idChuCongTy);
                ct.Flag = 1;
                isBlockChuCongTy = DataRepository.ChuCongTyProvider.Update(ct);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isBlockChuCongTy;
        }

        public bool InsertChuCongTy(ChuCongTy chuCongTyInfo)
        {
            bool isInsertChuCongTy = false;
            try
            {
                isInsertChuCongTy = DataRepository.ChuCongTyProvider.Insert(chuCongTyInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isInsertChuCongTy;
        }



	}//End Class


} // end namespace
