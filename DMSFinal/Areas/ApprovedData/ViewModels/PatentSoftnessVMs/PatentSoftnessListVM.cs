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


namespace DMSFinal.ApprovedData.ViewModels.PatentSoftnessVMs
{
    public partial class PatentSoftnessListVM : BasePagedListVM<PatentSoftness_View, PatentSoftnessSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("PatentSoftness", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };

            }
                
        }


        protected override IEnumerable<IGridColumn<PatentSoftness_View>> InitGridHeader()
        {
            return new List<GridColumn<PatentSoftness_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.Topic),
                this.MakeGridHeader(x => x.PatentCategory),
                this.MakeGridHeader(x => x.AuthorizedDate),
                this.MakeGridHeader(x => x.PatentNumber),
                this.MakeGridHeader(x => x.ApplicationTime),
                this.MakeGridHeader(x => x.ApplicationNumber),
                this.MakeGridHeader(x => x.IfEmployee),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IsOurSchool),
                this.MakeGridHeader(x => x.HoldTime),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<PatentSoftness_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<PatentSoftness>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckEqual(Searcher.PatentCategory, x => x.PatentCategory)
                .CheckBetween(Searcher.AuthorizedDate?.GetStartTime(), Searcher.AuthorizedDate?.GetEndTime(), x => x.AuthorizedDate, includeMax: false)
                .CheckContain(Searcher.PatentNumber, x => x.PatentNumber)
                .CheckBetween(Searcher.ApplicationTime?.GetStartTime(), Searcher.ApplicationTime?.GetEndTime(), x => x.ApplicationTime, includeMax: false)
                .CheckContain(Searcher.ApplicationNumber, x => x.ApplicationNumber)
                .CheckEqual(Searcher.IfEmployee, x => x.IfEmployee)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .CheckEqual(Searcher.HoldTime, x => x.HoldTime)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                .CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new PatentSoftness_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    PatentCategory = x.PatentCategory,
                    AuthorizedDate = x.AuthorizedDate,
                    PatentNumber = x.PatentNumber,
                    ApplicationTime = x.ApplicationTime,
                    ApplicationNumber = x.ApplicationNumber,
                    IfEmployee = x.IfEmployee,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                    HoldTime = x.HoldTime,
                    JobNo = x.JobNo,
       
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<PatentSoftness>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.Topic, x => x.Topic)
                .CheckEqual(Searcher.PatentCategory, x => x.PatentCategory)
                .CheckBetween(Searcher.AuthorizedDate?.GetStartTime(), Searcher.AuthorizedDate?.GetEndTime(), x => x.AuthorizedDate, includeMax: false)
                .CheckContain(Searcher.PatentNumber, x => x.PatentNumber)
                .CheckBetween(Searcher.ApplicationTime?.GetStartTime(), Searcher.ApplicationTime?.GetEndTime(), x => x.ApplicationTime, includeMax: false)
                .CheckContain(Searcher.ApplicationNumber, x => x.ApplicationNumber)
                .CheckEqual(Searcher.IfEmployee, x => x.IfEmployee)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .CheckEqual(Searcher.HoldTime, x => x.HoldTime)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                .CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new PatentSoftness_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    Topic = x.Topic,
                    PatentCategory = x.PatentCategory,
                    AuthorizedDate = x.AuthorizedDate,
                    PatentNumber = x.PatentNumber,
                    ApplicationTime = x.ApplicationTime,
                    ApplicationNumber = x.ApplicationNumber,
                    IfEmployee = x.IfEmployee,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                    HoldTime = x.HoldTime,
                    JobNo = x.JobNo,
      
                })
                .OrderBy(x => x.ID);
                return query;
            }                
        }
    }

    public class PatentSoftness_View : PatentSoftness{

    }
}
