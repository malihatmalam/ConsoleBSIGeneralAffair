using BSIGeneralAffair.API.Data.Helpers;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace BSIGeneralAffair.API.Data
{
    public class ApprovalData : IApprovalData
    {
        private readonly AppDbContext _context;

        public ApprovalData(AppDbContext context)
        {
            _context = context;
        }
        private string GetConnectionString()
        {
            return DatabaseConnection.GetConnectionString();
        }

        public async Task<Task> Approval(Approval approval)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = @"[GeneralAffair].[USP_Mobile_ApprovalProposalProcess]";
                    var param = new
                    {
                        ProposalToken = approval.ProposalToken,
                        EmployeeIDNumber = approval.EmployeeIDNumber,
                        ApprovalReason = approval.ApprovalReason,
                        ApprovalType = approval.ApprovalStatus
                    };
                    int result = conn.Execute(strSql, param);

                    //jika result = -1, berarti update data gagal
                    if (result == 1)
                    {
                        throw new Exception("Approval data failed..");
                    }
                    return Task.CompletedTask;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Approval>> GetHistoryApproval(string proposalToken)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    List<Approval> approvals = new List<Approval>();

                    var strSql = @"[GeneralAffair].[USP_HistoryApprovalProposal]";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProposalToken", proposalToken);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Approval approval = new Approval();
                            approval.ApproverName = dr["ApproverName"].ToString();
                            approval.ApprovalStatus = dr["ApprovalStatus"].ToString();
                            approval.ApproverPosition = dr["ApproverPosition"].ToString();
                            approval.ApprovalReason = dr["ApprovalReason"].ToString();
                            approval.ApprovalAt = (DateTime)dr["ApprovalAt"];

                            approvals.Add(approval);
                        }
                    }
                    return approvals;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }
    }
}
