using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;
using PROJECT.Core.Helpers;

namespace PROJECT.Core.Repository
{
    public class Student2Repository : Base
    {
        private const string SPS_STUDENT2_VIEWMODEL_SELECT = "sps_Student2ViewModelSelect";
        private const string SPS_STUDENT2_VIEWMODEL_INSERT = "sps_Student2ViewModelInsert";
        private const string SPS_STUDENT2_VIEWMODEL_DELETE = "sps_Student2ViewModelDelete";
        private const string SPS_STUDENT2_VIEWMODEL_UPDATE = "sps_Student2ViewModelUpdate";

        private const string SPS_STUDENT2_VIEWMODEL_SEARCH = "sps_Student2ViewModelSearch";
        private const string SPS_STUDENT2_VIEWMODEL_REPORT = "sps_Student2ViewModelReport";

        private const string COLUMN_NAME_STUDENTID = "StudentId";
        private const string COLUMN_NAME_NAME = "Name";
        private const string COLUMN_NAME_FLAG = "Flag";
        private const string COLUMN_NAME_GENDER = "Gender";
        private const string COLUMN_NAME_CURRENTDATE = "CurrentDate";
        private const string COLUMN_NAME_CURRENTTIME = "CurrentTime";
        private const string COLUMN_NAME_CURRENTDATETIME = "CurrentDateTime";
        private const string COLUMN_NAME_CHECKBOX = "CheckBox";
        private const string COLUMN_NAME_RADIOBUTTON = "RadioButton";
        private const string COLUMN_NAME_FILENAME = "FileName";

        private const string COLUMN_NAME_COUNTRYID = "CountryId";
        private const string COLUMN_NAME_COUNTRYNAME = "CountryName";
        private const string COLUMN_NAME_STATEID = "StateId";
        private const string COLUMN_NAME_STATENAME = "StateName";

        private const string COLUMN_NAME_COURSEID = "CourseId";
        private const string COLUMN_NAME_COURSETITLE = "CourseTitle";


        private const string COLUMN_NAME_STATUS = "Status";
        private const string COLUMN_NAME_RESULT = "Result";

        private const string COLUMN_NAME_KEYWORD = "Keyword";


        private const string COLUMN_NAME_FROMDATE = "FromDate";
        private const string COLUMN_NAME_TODATE = "ToDate";
        private const string COLUMN_NAME_CREATEDBY = "CreatedBy";
        private const string COLUMN_NAME_CREATEDDATE = "CreatedDate";

        public List<Student2ViewModel> Select(int Flag, Student2ViewModel objEntity)
        {
            var objEntityList = new List<Student2ViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_SELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STUDENTID, DbType.Int32, objEntity.StudentId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CREATEDBY, DbType.Int32, objEntity.CreatedBy);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new Student2ViewModel();


                            objEntityViewModel.StudentId = reader.GetColumnValue<int>(COLUMN_NAME_STUDENTID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Gender = (GenderEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_GENDER);
                            objEntityViewModel.CurrentDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATE);
                            objEntityViewModel.CurrentTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTTIME);
                            objEntityViewModel.CurrentDateTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATETIME);
                            objEntityViewModel.Checkbox = reader.GetColumnValue<bool>(COLUMN_NAME_CHECKBOX);
                            objEntityViewModel.RadioButton = reader.GetColumnValue<Int16>(COLUMN_NAME_RADIOBUTTON);
                            objEntityViewModel.FileName = reader.GetColumnValue<String>(COLUMN_NAME_FILENAME);

                            objEntityViewModel.StateId = reader.GetColumnValue<Int32>(COLUMN_NAME_STATEID);
                            objEntityViewModel.CountryId = reader.GetColumnValue<Int32>(COLUMN_NAME_COUNTRYID);
                            objEntityViewModel.StateName = reader.GetColumnValue<String>(COLUMN_NAME_STATENAME);
                            objEntityViewModel.CountryName = reader.GetColumnValue<String>(COLUMN_NAME_COUNTRYNAME);

                            objEntityViewModel.CourseId = reader.GetColumnValue<int>(COLUMN_NAME_COURSEID);
                            objEntityViewModel.CourseTitle = reader.GetColumnValue<string>(COLUMN_NAME_COURSETITLE);
                            objEntityViewModel.Status = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_STATUS);


                            objEntityViewModel.CreatedBy = reader.GetColumnValue<Int32>(COLUMN_NAME_CREATEDBY);
                            objEntityViewModel.CreatedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CREATEDDATE);



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

        public List<Student2ViewModel> Search(int Flag, Student2ViewModel objEntity)
        {
            var objEntityList = new List<Student2ViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_SEARCH))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_KEYWORD, DbType.String, objEntity.Keyword);




                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new Student2ViewModel();


                            objEntityViewModel.StudentId = reader.GetColumnValue<int>(COLUMN_NAME_STUDENTID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Gender = (GenderEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_GENDER);
                            objEntityViewModel.CurrentDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATE);
                            objEntityViewModel.CurrentTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTTIME);
                            objEntityViewModel.CurrentDateTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATETIME);
                            objEntityViewModel.Checkbox = reader.GetColumnValue<bool>(COLUMN_NAME_CHECKBOX);
                            objEntityViewModel.RadioButton = reader.GetColumnValue<Int16>(COLUMN_NAME_RADIOBUTTON);
                            objEntityViewModel.FileName = reader.GetColumnValue<String>(COLUMN_NAME_FILENAME);

                            objEntityViewModel.StateId = reader.GetColumnValue<Int32>(COLUMN_NAME_STATEID);
                            objEntityViewModel.CountryId = reader.GetColumnValue<Int32>(COLUMN_NAME_COUNTRYID);
                            objEntityViewModel.StateName = reader.GetColumnValue<String>(COLUMN_NAME_STATENAME);
                            objEntityViewModel.CountryName = reader.GetColumnValue<String>(COLUMN_NAME_COUNTRYNAME);

                            objEntityViewModel.CourseId = reader.GetColumnValue<int>(COLUMN_NAME_COURSEID);
                            objEntityViewModel.CourseTitle = reader.GetColumnValue<string>(COLUMN_NAME_COURSETITLE);
                            objEntityViewModel.Status = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_STATUS);

                            objEntityViewModel.CreatedBy = reader.GetColumnValue<Int32>(COLUMN_NAME_CREATEDBY);
                            objEntityViewModel.CreatedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CREATEDDATE);


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

        public List<Student2ViewModel> Report(int Flag, Student2ViewModel objEntity)
        {
            var objEntityList = new List<Student2ViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_REPORT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FROMDATE, DbType.DateTime, objEntity.FromDate);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_TODATE, DbType.DateTime, objEntity.ToDate);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_COURSEID, DbType.Int32, objEntity.CourseId);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new Student2ViewModel();


                            objEntityViewModel.StudentId = reader.GetColumnValue<int>(COLUMN_NAME_STUDENTID);
                            objEntityViewModel.Name = reader.GetColumnValue<string>(COLUMN_NAME_NAME);

                            objEntityViewModel.Gender = (GenderEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_GENDER);
                            objEntityViewModel.CurrentDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATE);
                            objEntityViewModel.CurrentTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTTIME);
                            objEntityViewModel.CurrentDateTime = reader.GetColumnValue<DateTime>(COLUMN_NAME_CURRENTDATETIME);
                            objEntityViewModel.Checkbox = reader.GetColumnValue<bool>(COLUMN_NAME_CHECKBOX);
                            objEntityViewModel.RadioButton = reader.GetColumnValue<Int16>(COLUMN_NAME_RADIOBUTTON);
                            objEntityViewModel.FileName = reader.GetColumnValue<String>(COLUMN_NAME_FILENAME);

                            objEntityViewModel.StateId = reader.GetColumnValue<Int32>(COLUMN_NAME_STATEID);
                            objEntityViewModel.CountryId = reader.GetColumnValue<Int32>(COLUMN_NAME_COUNTRYID);
                            objEntityViewModel.StateName = reader.GetColumnValue<String>(COLUMN_NAME_STATENAME);
                            objEntityViewModel.CountryName = reader.GetColumnValue<String>(COLUMN_NAME_COUNTRYNAME);

                            objEntityViewModel.CourseId = reader.GetColumnValue<int>(COLUMN_NAME_COURSEID);
                            objEntityViewModel.CourseTitle = reader.GetColumnValue<string>(COLUMN_NAME_COURSETITLE);
                            objEntityViewModel.Status = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_STATUS);

                            objEntityViewModel.CreatedBy = reader.GetColumnValue<Int32>(COLUMN_NAME_CREATEDBY);
                            objEntityViewModel.CreatedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CREATEDDATE);

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
        public Student2ViewModel Insert(Student2ViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_INSERT))
                {



                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_NAME, DbType.String, objEntity.Name);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_GENDER, DbType.Int16, objEntity.Gender);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTDATE, DbType.DateTime, objEntity.CurrentDate);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTTIME, DbType.DateTime, objEntity.CurrentTime);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTDATETIME, DbType.DateTime, objEntity.CurrentDateTime);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CHECKBOX, DbType.Boolean, objEntity.Checkbox);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_RADIOBUTTON, DbType.Int16, objEntity.RadioButton);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FILENAME, DbType.String, objEntity.FileName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STATEID, DbType.Int32, objEntity.StateId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_COURSEID, DbType.Int32, objEntity.CourseId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STATUS, DbType.Int32, objEntity.Status);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CREATEDBY, DbType.Int32, objEntity.CreatedBy);

                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_STUDENTID, DbType.Int32, objEntity.StudentId);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.StudentId = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_STUDENTID));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntity;
        }

        public Student2ViewModel Update(int Flag, Student2ViewModel objEntity)
        {
            try
            {

                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_UPDATE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STUDENTID, DbType.Int32, objEntity.StudentId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_NAME, DbType.String, objEntity.Name);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_GENDER, DbType.Int16, objEntity.Gender);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTDATE, DbType.Date, objEntity.CurrentDate);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTTIME, DbType.Time, objEntity.CurrentTime);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CURRENTDATETIME, DbType.DateTime, objEntity.CurrentDateTime);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CHECKBOX, DbType.Boolean, objEntity.Checkbox);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_RADIOBUTTON, DbType.Int16, objEntity.RadioButton);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FILENAME, DbType.String, objEntity.FileName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STATEID, DbType.Int32, objEntity.StateId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_COURSEID, DbType.Int32, objEntity.CourseId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STATUS, DbType.Int32, objEntity.Status);

                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);


                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
                //
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntity;
        }

        public int Delete(int Flag, Student2ViewModel objEntity)
        {
            int result = 0;
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_STUDENT2_VIEWMODEL_DELETE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STUDENTID, DbType.Int32, objEntity.StudentId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_STATUS, DbType.Int16, objEntity.Status);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return result;
        }

    }
}
