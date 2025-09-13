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


namespace DMSFinal.ApprovedData.ViewModels.TeacherCompetitionVMs
{
    public partial class TeacherCompetitionListVM : BasePagedListVM<TeacherCompetition_View, TeacherCompetitionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("TeacherCompetition", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<TeacherCompetition_View>> InitGridHeader()
        {
            return new List<GridColumn<TeacherCompetition_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.CompetitionName),
                this.MakeGridHeader(x => x.RewardLevel),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.RewardTime),
                this.MakeGridHeader(x => x.Rank),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TeacherCompetition_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<TeacherCompetition>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.CompetitionName, x => x.CompetitionName)
                .CheckEqual(Searcher.RewardLevel, x => x.RewardLevel)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.Level, x => x.Level)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new TeacherCompetition_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    CompetitionName = x.CompetitionName,
                    RewardLevel = x.RewardLevel,
                    AwardingUnit = x.AwardingUnit,
                    Level = x.Level,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<TeacherCompetition>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.CompetitionName, x => x.CompetitionName)
                .CheckEqual(Searcher.RewardLevel, x => x.RewardLevel)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.Level, x => x.Level)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new TeacherCompetition_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    CompetitionName = x.CompetitionName,
                    RewardLevel = x.RewardLevel,
                    AwardingUnit = x.AwardingUnit,
                    Level = x.Level,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class TeacherCompetition_View : TeacherCompetition{

    }
}
