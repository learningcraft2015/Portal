using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECT.Core.Utility;
using PROJECT.Core.Helpers;

namespace PROJECT.Core.Repository
{
    public class CourseRepository : Base
    {

        private const string SPS_COURSE_VIEWMODEL_SELECT = "sps_CourseViewModelSelect";
        private const string COLUMN_NAME_COURSEID = "CourseId";
        private const string COLUMN_NAME_COURSETITLE = "CourseTitle";
        private const string COLUMN_NAME_FLAG = "Flag";
        private const string COLUMN_NAME_STATUS = "Status";
        private const string COLUMN_NAME_RESULT = "Result";

        public List<CourseViewModel> Select(int Flag, CourseViewModel objEntity)
        {
            var objEntityList = new List<CourseViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_COURSE_VIEWMODEL_SELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_COURSEID, DbType.Int32, objEntity.CourseId);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new CourseViewModel();


                            objEntityViewModel.CourseId = reader.GetColumnValue<int>(COLUMN_NAME_COURSEID);
                            objEntityViewModel.CourseTitle = reader.GetColumnValue<string>(COLUMN_NAME_COURSETITLE);
                            objEntityViewModel.Status = reader.GetColumnValue<Int16>(COLUMN_NAME_STATUS);
                        




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
