using CroydonPestControl.Infrastructure.Interfaces;
using CroydonPestControl.Infrastructure.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using CroydonPestControl.Core.Models;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using CroydonPestControl.Core.Helpers;

namespace CroydonPestControl.Infrastructure
{
    public class InspectionRepository:BaseRepository, IInspectionRepository
    {
        private readonly ILogger<InspectionRepository> _logger;
        private readonly IXmlHelper _xmlHelper;
        public InspectionRepository(IConfiguration config, ILogger<InspectionRepository> logger, IXmlHelper xmlHelper) : base(config)
        {
            _logger = logger;
            _xmlHelper = xmlHelper;
        }

        public async Task<IEnumerable<Inspection>> GetAllInspectionsAsync(int userId, DateTime? inspectionDate = null)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("UserId", userId, dbType: DbType.Int32);
                param.Add("InspectionDate", inspectionDate, dbType: DbType.DateTime);

                _logger.LogInformation("Calling stored procedure dbo.GetAllPendingInspections with Parameters:[UserId: {0}, InspectionDate: {1}]", userId, inspectionDate);

                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Inspection,Core.ViewModels.Officer, Tenant, Address, Inspection>("dbo.GetAllPendingInspections", (inspection, officer, tenant, address) =>
                    {
                        inspection.Tenant = tenant;
                        inspection.Address = address;
                        inspection.Officer = officer;
                        return inspection;
                    }, param, splitOn: "OfficerId,TenantId, PropertyId", commandType: CommandType.StoredProcedure);
                });

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<List<Inspection>> GetInspectionsByUserIdAsync(int userId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("UserId", userId, dbType: DbType.Int32);
                param.Add("Inspections", dbType: DbType.Xml, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure dbo.GetUserPendingInspections with UserId:  {0}", userId);

                var result=await WithConnection(async c =>
                {
                    await c.ExecuteAsync("dbo.GetUserPendingInspections", param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@Inspections");
                });

                return _xmlHelper.ConvertFromXml<List<Inspection>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AssignInspectionsAsync(AssignInspectionsRequest request)
        {
            try
            { 
                var param = new DynamicParameters();
                param.Add("UserId", request.OfficerId, dbType: DbType.Int32);
                param.Add("AssignedBy", request.AssignedById, dbType: DbType.Int32);
                param.Add("Inspections", String.Join("|", request.InspectionIds), dbType: DbType.String);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure dbo.AssignInspections with Parameters:[UserId: {0}, AssignedBy:{1},Inspections :[{2}]", 
                                        request.OfficerId, request.AssignedById, string.Join("|", request.InspectionIds));

                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("dbo.AssignInspections", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Officer>> GetAllOfficersAsync()
        {
            try
            {
                _logger.LogInformation("Calling stored procedure dbo.GetOfficers");
                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<Officer>("dbo.GetOfficers", commandType: CommandType.StoredProcedure);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveInspectionAsync(string inspection)
        {
            try
            {
                _logger.LogInformation("Calling stored procedure dbo.SaveInspection with inspection XML:{0}", inspection);
                var param = new DynamicParameters();
                param.Add("Inspection", inspection, dbType: DbType.Xml);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("dbo.SaveInspection", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<bool> UpdateInspectionNoAccessAsync(UpdateInspectionRequest request)
        {
            try
            {
                _logger.LogInformation("Calling stored procedure dbo.UpdateInspectionNoAccess with request : {@0}",request);
                var param = new DynamicParameters();
                param.Add("InspectionId", request.InspectionId, dbType: DbType.Int32);
                param.Add("NoAccessId", request.NoAccessId, dbType: DbType.Int32);
                param.Add("FollowUpId", request.FollowUp!=null? request.FollowUp.Id:-1, dbType: DbType.Int32);
                param.Add("FollowUpNotes", request.FollowUp != null ? request.FollowUp.Note : string.Empty, dbType: DbType.String);
                param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                return await WithConnection(async c =>
                {
                    await c.ExecuteAsync("dbo.UpdateInspectionNoAccess", param, commandType: CommandType.StoredProcedure);
                    return param.Get<bool>("@Result");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FollowUpDatesResponse>> GetFollowUpDatesAsync(int inspectionId, string pests)
        {
            try
            {
                _logger.LogInformation("Calling stored procedure dbo.GetFollowUpDates with inspectionId:{0} and pests:[{1}]", inspectionId, pests);

                var param = new DynamicParameters();
                param.Add("InspectionId", inspectionId, dbType: DbType.Int32);
                param.Add("Pests", pests, dbType: DbType.String);

                return await WithConnection(async c =>
                {
                    return await c.QueryAsync<FollowUpDatesResponse>("dbo.GetFollowUpDates", param, commandType: CommandType.StoredProcedure);
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<List<Inspection>> GetInspectionsByPropertyIdAsync(int propertyId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("PropertyId", propertyId, dbType: DbType.Int32);
                param.Add("Inspections", dbType: DbType.Xml, direction: ParameterDirection.Output);

                _logger.LogInformation("Calling stored procedure BlockCycle.GetInspectionsByPropertyId with propertyId:  {0}", propertyId);

                var result = await WithConnection(async c =>
                {
                    await c.ExecuteAsync("BlockCycle.GetInspectionsByPropertyId", param, commandType: CommandType.StoredProcedure);
                    return param.Get<string>("@Inspections");
                });

                return _xmlHelper.ConvertFromXml<List<Inspection>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
