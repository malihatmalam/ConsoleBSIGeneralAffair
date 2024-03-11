using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSIGeneralAffairBLL
{
    public class DashboardBLL
    {
        private DALDashboard _dashboardDAL;
        public DashboardBLL()
        {
            _dashboardDAL = new DALDashboard();
        }

        public Dashboard GetDashboard() {
            return _dashboardDAL.GetDashboard();

        }
    }
}
