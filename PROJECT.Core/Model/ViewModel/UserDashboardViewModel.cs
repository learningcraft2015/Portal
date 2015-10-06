using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Model.ViewModel
{
    public class UserDashboardViewModel
    {
        public UserDashboardViewModel()
        {
            Student2RecentMembersList = new List<Student2ViewModel>();
            Student2RecentActiveMembersList = new List<Student2ViewModel>();
        }
        public List<Student2ViewModel> Student2RecentMembersList { get; set; }
        public List<Student2ViewModel> Student2RecentActiveMembersList { get; set; }
    }
}
