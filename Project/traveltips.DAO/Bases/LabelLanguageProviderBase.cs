#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using traveltips.Entities;
using traveltips.DAO;

#endregion

namespace traveltips.DAO.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="LabelLanguageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class LabelLanguageProviderBase : LabelLanguageProviderBaseCore
	{
	} // end class
} // end namespace
