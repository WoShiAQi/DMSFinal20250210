using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DMSFinal.Model.BasicData;
using DMSFinal.Model;


namespace DMSFinal.BasicData.ViewModels.DepartmentHonorVMs
{
    public partial class DepartmentHonorListVM : BasePagedListVM<DepartmentHonor_View, DepartmentHonorSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    this.MakeAction("DepartmentHonor","Edit","审核","审核",GridActionParameterTypesEnum.SingleIdWithNull,"BasicData",dialogWidth: 800).SetShowInRow(true),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<DepartmentHonor_View>> InitGridHeader()
        {
            return new List<GridColumn<DepartmentHonor_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.ProjectName),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.AwardLevel),
                this.MakeGridHeader(x => x.RewardTime),
                this.MakeGridHeader(x => x.AwardNo),
                this.MakeGridHeader(x => x.Examine),
                this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<DepartmentHonor_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<DepartmentHonor>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.ProjectName, x => x.ProjectName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckContain(Searcher.AwardNo, x => x.AwardNo)
                //.CheckEqual(Searcher.Examine, x => x.Examine)
                //.CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.Examine == CheckEnum.Checking)
                .Select(x => new DepartmentHonor_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    ProjectName = x.ProjectName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    AwardNo = x.AwardNo,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<DepartmentHonor>()
                    .CheckEqual(Searcher.Department, x => x.Department)
                    .CheckContain(Searcher.ProjectName, x => x.ProjectName)
                    .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                    .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                    .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                    .CheckContain(Searcher.AwardNo, x => x.AwardNo)
                    .CheckEqual(Searcher.Examine, x => x.Examine)
                    //.CheckContain(Searcher.Reason, x => x.Reason)
                    //.Where(x => x.JobNo == LoginUserInfo.ITCode)
                    .Where(x => x.Examine != CheckEnum.Pass)
                    .Select(x => new DepartmentHonor_View
                    {
                        ID = x.ID,
                        Department = x.Department,
                        ProjectName = x.ProjectName,
                        AwardingUnit = x.AwardingUnit,
                        AwardLevel = x.AwardLevel,
                        RewardTime = x.RewardTime,
                        AwardNo = x.AwardNo,
                        Examine = x.Examine,
                        Reason = x.Reason,
                    })
                    .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class DepartmentHonor_View : DepartmentHonor{

    }
}
