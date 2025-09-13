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


namespace DMSFinal.ApprovedData.ViewModels.CourseVMs
{
    public partial class CourseListVM : BasePagedListVM<Course_View, CourseSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Course", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Course", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<Course_View>> InitGridHeader()
        {
            return new List<GridColumn<Course_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.RewardName),
                this.MakeGridHeader(x => x.AwardingUnit),
                this.MakeGridHeader(x => x.AwardLevel),
                this.MakeGridHeader(x => x.RewardTime),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IfOurSchool),                
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Course_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<Course>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Course_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    JobNo = x.JobNo,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else
            {
                var query = DC.Set<Course>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.RewardName, x => x.RewardName)
                .CheckContain(Searcher.AwardingUnit, x => x.AwardingUnit)
                .CheckEqual(Searcher.AwardLevel, x => x.AwardLevel)
                .CheckBetween(Searcher.RewardTime?.GetStartTime(), Searcher.RewardTime?.GetEndTime(), x => x.RewardTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Course_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    RewardName = x.RewardName,
                    AwardingUnit = x.AwardingUnit,
                    AwardLevel = x.AwardLevel,
                    RewardTime = x.RewardTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    JobNo = x.JobNo,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class Course_View : Course{

    }
}
