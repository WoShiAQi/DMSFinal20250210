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


namespace DMSFinal.ApprovedData.ViewModels.STAwardVMs
{
    public partial class STAwardListVM : BasePagedListVM<STAward_View, STAwardSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("STAward", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("STAward", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<STAward_View>> InitGridHeader()
        {            
                return new List<GridColumn<STAward_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.Topic),
                this.MakeGridHeader(x => x.AwardNo),
                this.MakeGridHeader(x => x.RewardName),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.AwardLevel),
                this.MakeGridHeader(x => x.RewardTime),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IfOurSchool),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<STAward_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<STAward>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckContain(Searcher.AwardNo, x => x.AwardNo)
                .CheckEqual(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new STAward_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    AwardNo = x.AwardNo,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else
            {
                var query = DC.Set<STAward>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckContain(Searcher.AwardNo, x => x.AwardNo)
                .CheckEqual(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new STAward_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    AwardNo = x.AwardNo,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            
        }

    }

    public class STAward_View : STAward{

    }
}
