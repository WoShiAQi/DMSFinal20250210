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


namespace DMSFinal.ApprovedData.ViewModels.DepartmentHonorVMs
{
    public partial class DepartmentHonorListVM : BasePagedListVM<DepartmentHonor_View, DepartmentHonorSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                //this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                this.MakeStandardAction("DepartmentHonor", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
            };
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
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<DepartmentHonor_View> GetSearchQuery()
        {
            
                var query = DC.Set<DepartmentHonor>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.ProjectName, x => x.ProjectName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckContain(Searcher.AwardNo, x => x.AwardNo)
                .Where(x => x.Examine == CheckEnum.Pass)
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

    public class DepartmentHonor_View : DepartmentHonor{

    }
}
