using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;

using PROJECT.Core.Model.ViewModel;

namespace PROJECT.Core.Repository
{


    public class CountryStateRepository : Base
    {
        const string SPS_COUNTRYSTATEVIEWMODELSELECT = "sps_CountryStateViewModelSelect";


        const string COLUMN_NAME_FLAG = "Flag";
        const string COLUMN_NAME_COUNTRYID = "CountryId";
        const string COLUMN_NAME_COUNTRYNAME = "CountryName";
        const string COLUMN_NAME_STATEID = "StateId";
        const string COLUMN_NAME_STATENAME = "StateName";

        public List<CountryStateViewModel> Select(int flag,CountryStateViewModel objEntity)
        {

            var objEntityList = new List<CountryStateViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_COUNTRYSTATEVIEWMODELSELECT))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, flag);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new CountryStateViewModel();

                            objEntityViewModel.CountryId = reader.GetColumnValue<Int32>(COLUMN_NAME_COUNTRYID);
                            objEntityViewModel.CountryName = reader.GetColumnValue<String>(COLUMN_NAME_COUNTRYNAME);
                            objEntityViewModel.StateId = reader.GetColumnValue<Int32>(COLUMN_NAME_STATEID);
                            objEntityViewModel.StateName = reader.GetColumnValue<String>(COLUMN_NAME_STATENAME);


                            if (objEntityViewModel != null)
                            {
                                objEntityList.Add(objEntityViewModel);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntityList;
        }


      
    }
}
