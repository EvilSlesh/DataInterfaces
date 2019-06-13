﻿using ServerService.Dto.Reports;
using ServerService.Dto.Reports.Financial;
using ServerService.Dto.Reports.Hosts;
using ServerService.Dto.Reports.Operators;
using ServerService.Dto.Reports.Overview;
using ServerService.Dto.Reports.Products;
using ServerService.Dto.Reports.Users;
using System.Collections.Generic;

namespace ServerService
{
    public interface IReportsService
    {
        FinancialReportDTO GetFinancialReport(FinancialReportFilterDTO Filters);

        List<HostGroupDTO> GetHostGroups();

        HostUsageReportDTO GetHostUsageReport(HostUsageReportFilterDTO Filters);

        OverviewReportDTO GetOverviewReport(OverviewReportFilterDTO Filters);

        UsersReportDTO GetUsersReport(UsersReportFilterDTO Filters);

        List<ProductDTO> GetProducts();

        List<OperatorDTO> GetOperators();

        StockReportDTO GetStockReport(StockReportFilterDTO Filters);

        ProductReportDTO GetProductReport(ProductReportFilterDTO Filters);

        OperatorsLogReportDTO GetOperatorsLogReport(OperatorsLogReportFilterDTO Filters);
    }
}