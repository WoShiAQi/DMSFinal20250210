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


namespace DMSFinal.ApprovedData.ViewModels.StudentCompetitionVMs
{
    public partial class StudentCompetitionListVM : BasePagedListVM<StudentCompetition_View, StudentCompetitionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("StudentCompetition", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<StudentCompetition_View>> InitGridHeader()
        {
            return new List<GridColumn<StudentCompetition_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.StudentName),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.TeacherName),
                this.MakeGridHeader(x => x.CompetitionName),
                this.MakeGridHeader(x => x.AwardLevel),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeader(x => x.RewardTime),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<StudentCompetition_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<StudentCompetition>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.StudentName, x => x.StudentName)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.TeacherName, x => x.TeacherName)
                .CheckContain(Searcher.CompetitionName, x => x.CompetitionName)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.Level, x => x.Level)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new StudentCompetition_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    StudentName = x.StudentName,
                    JobNo = x.JobNo,
                    TeacherName = x.TeacherName,
                    CompetitionName = x.CompetitionName,
                    AwardLevel = x.AwardLevel,
                    AwardingUnit = x.AwardingUnit,
                    Level = x.Level,
                    RewardTime = x.RewardTime,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<StudentCompetition>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.StudentName, x => x.StudentName)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.TeacherName, x => x.TeacherName)
                .CheckContain(Searcher.CompetitionName, x => x.CompetitionName)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.Level, x => x.Level)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new StudentCompetition_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    StudentName = x.StudentName,
                    JobNo = x.JobNo,
                    TeacherName = x.TeacherName,
                    CompetitionName = x.CompetitionName,
                    AwardLevel = x.AwardLevel,
                    AwardingUnit = x.AwardingUnit,
                    Level = x.Level,
                    RewardTime = x.RewardTime,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class StudentCompetition_View : StudentCompetition{

    }
}
