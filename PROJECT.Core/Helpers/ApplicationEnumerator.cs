using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Helpers
{
    /// <summary>
    /// Flags for user operations
    /// </summary>
    /// 


    public enum GenderEnum
    {
        Male = 1,
        Female = 2

    }
    public enum QuestionAnswerEnum
    {
        Yes = 1,
        No = 2

    }

    public enum RegistrationFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4
    }

    public enum StatusEnum
    {

        Active = 1,
        Inactive = 2

    }

    public enum UserTypes
    {
        Admin = 1,
        User = 2,
        CRO = 3




    }
    public enum UserFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,
        UpdateStatusByID = 5,
        UserSignIn = 6,
        UpdatePasswordByID = 7
    }


    public enum ResultFlags
    {

        OldPasswordMismatch = -2,
        Duplicate = -1,
        Failure = 0,
        Success = 1


    }
    public enum CourseFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,


    }
    public enum StudentFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,

        DeleteChangeStatusByID = 5,
        SelectAllByKeyword = 6,
        SelectAllByReport = 7,
        SelectAllByRecentMembers = 8,
        SelectAllByRecentActiveMembers = 9,
        SelectTop4ByRecentDate = 10,
        SelectTop4ByRandom = 11,

    }
    public enum CountryStateFlags
    {
        SelectByID = 1,
        SelectAll = 2,
        DeleteByID = 3,
        UpdateByID = 4,
        SelectAllForOptionGroup = 5,


    }


    public static class ApplicationConstant
    {

        public static string UPLOADED_STUDENT_IMAGE_PATH = "~/Uploads/Students/";


    }

}
