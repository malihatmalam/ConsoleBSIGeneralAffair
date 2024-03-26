using BSIGeneralAffair.API.Data.Helpers;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.Data
{
    public class HomepageData : IHomepageData
    {
        private readonly AppDbContext _context;

        public HomepageData(AppDbContext context)
        {
            _context = context;
        }

        private string GetConnectionString()
        {
            return DatabaseConnection.GetConnectionString();
        }

        public async Task<Homepage> GetHomepage(string employeeNumber)
        {
            try
            {
                var proposalData = (from proposals in _context.Proposals
                                    join employee in _context.Employees
                                    on proposals.UserId equals employee.UserId
                                    where (employee.EmployeeIdnumber == employeeNumber)
                                    select new
                                    {
                                        ProposalToken = proposals.ProposalToken,
                                        ProposalStatus = proposals.ProposalStatus,
                                        EmployeeNumber = employee.EmployeeIdnumber,
                                        ProposalType = proposals.ProposalType
                                    });
                var completedData = proposalData.Where(p => p.ProposalStatus.Contains("Completed")).Count();
                var waitingData = proposalData.Where(p => p.ProposalStatus.Contains("Waiting")).Count();
                var rejectData = proposalData.Where(p => p.ProposalStatus.Contains("Rejected")).Count();
                var procurementData = proposalData.Where(p => p.ProposalType.Contains("Procurement")).Count();
                var serviceData = proposalData.Where(p => p.ProposalType.Contains("Service")).Count();
                var homepageData = new Homepage()
                {
                    procurementProposal = procurementData,
                    serviceProposal = serviceData,
                    completedProposal = completedData,
                    waitingProposal = waitingData,
                    rejectProposal = rejectData
                };
                return homepageData;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"DAL - {ex.Message}");
            }
        }
    }
}
