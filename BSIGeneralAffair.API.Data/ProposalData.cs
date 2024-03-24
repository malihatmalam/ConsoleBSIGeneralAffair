using BSIGeneralAffair.API.Data.Helpers;
using BSIGeneralAffair.API.Data.Interfaces;
using BSIGeneralAffair.API.Domain.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using Dapper;
using static Dapper.SqlMapper;
using Microsoft.EntityFrameworkCore;


namespace BSIGeneralAffair.API.Data
{
    public class ProposalData : IProposalData
    {
        private readonly AppDbContext _context;

        private string GetConnectionString()
        {
            return DatabaseConnection.GetConnectionString();
        }

        public ProposalData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Cancel(string proposalToken)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = @"[GeneralAffair].[USP_Mobile_CancelProposal]";
                    var param = new
                    {
                        ProposalToken = proposalToken
                    };
                    int result = conn.Execute(strSql, param);

                    //jika result = -1, berarti update data gagal
                    if (result == 1)
                    {
                        throw new ArgumentException("Cancel proposal failed..");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<Proposal> GetByProposalToken(string proposalToken)
        {
            try
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
                                proposal.VendorId = -1;
                            }
                            else
                            {
                                proposal.VendorId = (short?)Convert.ToInt32(dr["VendorID"]);
                            }
                            proposal.Departement = new Departement();
                            proposal.Departement.DepartementName = dr["DepartementName"].ToString();
                            proposal.User = new User();
                            proposal.User.UserFirstName = dr["EmployeeName"].ToString();
                            proposal.Vendor = new Vendor();
                            proposal.Vendor.VendorName = dr["VendorName"].ToString();
                            proposal.Vendor.VendorAddress = dr["VendorAddress"].ToString();
                            proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                            proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                            proposal.ProposalRequireDate = (DateTime)dr["ProposalRequireDate"];
                            proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                            proposal.ProposalNote = dr["ProposalNote"].ToString();
                            proposal.ProposalType = dr["ProposalType"].ToString();
                            proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                            proposal.ProposalApproveLevel = (byte)Convert.ToInt32(dr["ProposalApproveLevel"]);
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
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Proposal>> GetHistoryProposal(string employeeNumber, string typeProposal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    List<Proposal> proposals = new List<Proposal>();

                    var strSql = "";
                    if (typeProposal == "Procurement")
                    {
                        strSql = @"[GeneralAffair].[USP_Mobile_MyHistoryProcurement]";
                    }
                    else
                    {
                        strSql = @"[GeneralAffair].[USP_Mobile_MyHistoryService]";
                    }

                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Proposal proposal = new Proposal();
                            proposal.ProposalToken = dr["ProposalToken"].ToString();
                            proposal.Departement = new Departement();
                            proposal.Departement.DepartementName = dr["DepartementName"].ToString();
                            proposal.User = new User();
                            proposal.User.UserFirstName = dr["employeename"].ToString();
                            proposal.Vendor = new Vendor();
                            proposal.Vendor.VendorName = dr["vendorname"].ToString();
                            proposal.Vendor.VendorAddress = dr["vendoraddress"].ToString();
                            proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                            proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                            proposal.ProposalRequireDate = (DateTime)dr["ProposalRequireDate"];
                            proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                            proposal.ProposalNote = dr["ProposalNote"].ToString();
                            proposal.ProposalType = dr["ProposalType"].ToString();
                            proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                            proposal.ProposalApproveLevel = (byte)Convert.ToInt32(dr["ProposalApproveLevel"]);
                            proposal.ProposalNegotiationNote = dr["NegotiationNote"].ToString();

                            proposals.Add(proposal);
                        }
                    }
                    return proposals;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<IEnumerable<Proposal>> GetWaitingProposal(string employeeNumber)
        {
            try
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
                            proposal.Departement = new Departement();
                            proposal.Departement.DepartementName = dr["DepartementName"].ToString();
                            proposal.User = new User();
                            proposal.User.UserFirstName = dr["employeename"].ToString();
                            proposal.Vendor = new Vendor();
                            proposal.Vendor.VendorName = dr["vendorname"].ToString();
                            proposal.Vendor.VendorAddress = dr["vendoraddress"].ToString();
                            proposal.ProposalObjective = dr["ProposalObjective"].ToString();
                            proposal.ProposalDescription = dr["ProposalDescription"].ToString();
                            proposal.ProposalRequireDate = (DateTime)dr["ProposalRequireDate"];
                            proposal.ProposalBudget = Convert.ToDecimal(dr["ProposalBudget"]);
                            proposal.ProposalNote = dr["ProposalNote"].ToString();
                            proposal.ProposalType = dr["ProposalType"].ToString();
                            proposal.ProposalStatus = dr["ProposalStatus"].ToString();
                            proposal.ProposalApproveLevel = (byte)Convert.ToInt32(dr["ProposalApproveLevel"]);
                            proposal.ProposalNegotiationNote = dr["NegotiationNote"].ToString();

                            proposals.Add(proposal);
                        }
                    }
                    return proposals;
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<Task> Update(Proposal updateProposal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = @"[GeneralAffair].[USP_Mobile_UpdateProposal]";
                    var param = new
                    {
                        ProposalToken = updateProposal.ProposalToken,
                        VendorID = updateProposal.VendorId,
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
                        throw new ArgumentException("Update data failed..");
                    }

                    return Task.CompletedTask;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Data - {ex.Message}");
            }
        }

        public async Task<Task> Create(Proposal createProposal, string employeeNumber, string typeProposal, string? assetNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    var strSql = "";
                    int result = 0;
                    if (typeProposal == "Procurement")
                    {
                        strSql = @"[GeneralAffair].[USP_Mobile_StoreProposal]";
                        var param = new
                        {
                            EmployeeIDNumber = employeeNumber,
                            ProposalObjective = createProposal.ProposalObjective,
                            ProposalDescription = createProposal.ProposalDescription,
                            ProposalRequireDate = createProposal.ProposalRequireDate,
                            ProposalBudget = createProposal.ProposalBudget,
                            ProposalNote = createProposal.ProposalNote,
                            ProposalType = "Procurement"
                        };

                        result = conn.Execute(strSql, param);
                    }
                    else
                    {
                        strSql = @"[GeneralAffair].[USP_Mobile_StoreProposalTypeService]";
                        var param = new
                        {
                            EmployeeIDNumber = employeeNumber,
                            AssetNumber = assetNumber,
                            ProposalObjective = createProposal.ProposalObjective,
                            ProposalDescription = createProposal.ProposalDescription,
                            ProposalRequireDate = createProposal.ProposalRequireDate,
                            ProposalBudget = createProposal.ProposalBudget,
                            ProposalNote = createProposal.ProposalNote,
                        };

                        result = conn.Execute(strSql, param);
                    }

                    //jika result = -1, berarti update data gagal
                    if (result == 1)
                    {
                        throw new ArgumentException("Create data failed..");
                    }

                    return Task.CompletedTask;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Data - {ex.Message}");
            }
        }
    }
}
