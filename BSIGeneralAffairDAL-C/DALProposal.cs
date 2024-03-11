using BSIGeneralAffairDAL_C.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using BSIGeneralAffairBO_C;
using Dapper;
using static Dapper.SqlMapper;
using System.Xml.Linq;

namespace BSIGeneralAffairDAL_C
{
    public class DALProposal : IProposalDAL
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }

        public IEnumerable<Proposal> GetHistoryProposal(string typeProposal, int pageNumber, int pageSize, string search)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Proposal> proposals = new List<Proposal>();

                var strSql = "";
                if (typeProposal == "Procurement")
                {
                    strSql = @"[GeneralAffair].[USP_HistoryProcurement]";
                }
                else
                {
                    strSql = @"[GeneralAffair].[USP_HistoryService]";
                }

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", $"%{search}%");
                cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Proposal proposal = new Proposal();
                        proposal.ProposalToken = dr["ProposalToken"].ToString();
                        proposal.Department.DepartementName = dr["DepartementName"].ToString();
                        proposal.User.UserFullName = dr["EmployeeName"].ToString();
                        proposal.Employee.EmployeePosition = dr["EmployeePosition"].ToString();
                        proposal.Vendor.VendorName = dr["VendorName"].ToString();
                        proposal.Vendor.VendorAddress = dr["VendorAddress"].ToString();
                        proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                        proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                        proposal.ProposalRequireDate = dr["ProposalRequireDate"].ToString();
                        proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                        proposal.ProposalNote = dr["ProposalNote"].ToString();
                        proposal.ProposalType = dr["ProposalType"].ToString();
                        proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                        proposal.ProposalApproveLevel = (short?)Convert.ToInt32(dr["ProposalApproveLevel"]);
                        proposal.ProposalNegotiationNote = dr["NegotiationNote"].ToString();

                        proposals.Add(proposal);
                    }
                }
                return proposals;
            }
        }

        public Proposal GetByProposalToken(string proposalToken)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Proposal> proposals = new List<Proposal>();

                var strSql = @"[GeneralAffair].[USP_DetailProposal]";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProposalToken", proposalToken);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Proposal proposal = new Proposal();
                        proposal.ProposalToken = dr["ProposalToken"].ToString();
                        if (dr["VendorID"] is DBNull)
                        {
                            proposal.VendorID = -1;
                        }
                        else {
                            proposal.VendorID = (short?)Convert.ToInt32(dr["VendorID"]);
                        }
                        proposal.Department.DepartementName = dr["DepartementName"].ToString();
                        proposal.User.UserFullName = dr["EmployeeName"].ToString();
                        proposal.Employee.EmployeePosition = dr["EmployeePosition"].ToString();
                        proposal.Vendor.VendorName = dr["VendorName"].ToString();
                        proposal.Vendor.VendorAddress = dr["VendorAddress"].ToString();
                        proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                        proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                        proposal.ProposalRequireDate = dr["ProposalRequireDate"].ToString();
                        proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                        proposal.ProposalNote = dr["ProposalNote"].ToString();
                        proposal.ProposalType = dr["ProposalType"].ToString();
                        proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                        proposal.ProposalApproveLevel = (short?)Convert.ToInt32(dr["ProposalApproveLevel"]);
                        proposal.ProposalNegotiationNote = dr["NegotiationNote"].ToString();

                        proposals.Add(proposal);
                    }
                }
                Proposal proposalFirst = new Proposal();

                if (proposals.Count != 0)
                {
                    proposalFirst = proposals[0];
                }

                return proposalFirst;
            }
        }

        public IEnumerable<Proposal> GetWaitingProposal(string employeeNumber)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                List<Proposal> proposals = new List<Proposal>();

                var strSql = @"[GeneralAffair].[USP_SelectWaitingProposal]";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("EmployeeNumber", employeeNumber);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Proposal proposal = new Proposal();
                        proposal.ProposalToken = dr["ProposalToken"].ToString();
                        proposal.Department.DepartementName = dr["DepartementName"].ToString();
                        proposal.User.UserFullName = dr["EmployeeName"].ToString();
                        proposal.Employee.EmployeePosition = dr["EmployeePosition"].ToString();
                        proposal.Vendor.VendorName = dr["VendorName"].ToString();
                        proposal.Vendor.VendorAddress = dr["VendorAddress"].ToString();
                        proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                        proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                        proposal.ProposalRequireDate = dr["ProposalRequireDate"].ToString();
                        proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                        proposal.ProposalNote = dr["ProposalNote"].ToString();
                        proposal.ProposalType = dr["ProposalType"].ToString();
                        proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                        proposal.ProposalApproveLevel = (short?)Convert.ToInt32(dr["ProposalApproveLevel"]);
                        proposal.ProposalNegotiationNote = dr["NegotiationNote"].ToString();

                        proposals.Add(proposal);
                    }
                }
                return proposals;
            }
        }

        public void Update(Proposal updateProposal)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var strSql = @"[GeneralAffair].[USP_Mobile_UpdateProposal]";
                    var param = new
                    {
                        ProposalToken = updateProposal.ProposalToken,
                        VendorID = updateProposal.VendorID,
                        ProposalObjective = updateProposal.ProposalObjective,
                        ProposalDescription = updateProposal.ProposalDescription,
                        ProposalRequireDate = updateProposal.ProposalRequireDate,
                        ProposalBudget = updateProposal.ProposalBudget,
                        ProposalNote = updateProposal.ProposalNote,
                        ProposalNegotiationNote = updateProposal.ProposalNegotiationNote
                    };
                    int result = conn.Execute(strSql, param);

                    //jika result = -1, berarti update data gagal
                    if (result == 1)
                    {
                        throw new Exception("Update data failed..");
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

        public void UploadFileProposal(ProposalFile file)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string typeProposal, string search)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT COUNT(*) FROM [GeneralAffair].[Proposals] as Proposal
				Join [Person].Users as Users 
				on Users.UserID = Proposal.UserID
				Join [HumanResource].Departements as Departement
				on Departement.DepartementID = Proposal.DepartementID 
				Left join [GeneralAffair].Vendors as  Vendor
				on Vendor.VendorID = Proposal.VendorID  
				Join [HumanResource].Employees as Employee
				on Employee.UserID = Users.UserID 
				where Proposal.ProposalType = @ProposalType 
				and ( Proposal.[ProposalToken] like @Search 
				or Isnull(Users.[UserFirstName], '') + ' '  + IsNull (Users.[UserLastName], '') like @Search
				or Proposal.[ProposalStatus] like @Search) ";
                var param = new { Search = $"%{search}%", ProposalType = typeProposal };
                var result = Convert.ToInt32(conn.ExecuteScalar(strSql, param));
                return result;
            }

        }
    }
}
