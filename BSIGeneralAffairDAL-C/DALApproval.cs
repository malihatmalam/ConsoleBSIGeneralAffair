using BSIGeneralAffairBO_C;
using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;

namespace BSIGeneralAffairDAL_C
{
    public class DALApproval : IApprovalDAL
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Approval> GetHistoryApproval(string proposalToken)
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
                        approval.ApprovalAt = dr["ApprovalAt"].ToString(); 

                        approvals.Add(approval);
                    }
                }
                return approvals;
            }
        }

        public void ApprovalCMS(Approval approval)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_CMS_ApprovalProposalProcess]";
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
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"{sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void ApprovalMobile(Approval approval)
        {
            throw new NotImplementedException();
        }

    }
}
