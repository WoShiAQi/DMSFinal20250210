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


namespace DMSFinal.BasicData.ViewModels.VerticalSubjectVMs
{
    public partial class VerticalSubjectListVM : BasePagedListVM<VerticalSubject_View, VerticalSubjectSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001") {
                return new List<GridAction>
                {
                    this.MakeAction("VerticalSubject","Edit","审核","审核",GridActionParameterTypesEnum.SingleIdWithNull,"BasicData",dialogWidth: 800).SetShowInRow(true),
                    //this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    //this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };
            }
            else
            {
                return new List<GridAction>
                {
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "BasicData", dialogWidth: 800),
                    this.MakeStandardAction("VerticalSubject", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "BasicData"),
                };

            }
                
        }


        protected override IEnumerable<IGridColumn<VerticalSubject_View>> InitGridHeader()
        {
            return new List<GridColumn<VerticalSubject_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.SubjectName),
                this.MakeGridHeader(x => x.SubjectLevel),
                this.MakeGridHeader(x => x.SubjectSource),
                this.MakeGridHeader(x => x.SubjectNo),
                this.MakeGridHeader(x => x.Funds),
                this.MakeGridHeader(x => x.StartTime),
                this.MakeGridHeader(x => x.IfCose),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IfOurSchool),
                this.MakeGridHeader(x => x.Examine),
                this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<VerticalSubject_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<VerticalSubject>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.SubjectName, x => x.SubjectName)
                .CheckEqual(Searcher.SubjectLevel, x => x.SubjectLevel)
                .CheckContain(Searcher.SubjectSource, x => x.SubjectSource)
                .CheckContain(Searcher.SubjectNo, x => x.SubjectNo)
                .CheckEqual(Searcher.Funds, x => x.Funds)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckEqual(Searcher.IfCose, x => x.IfCose)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                //.CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.Examine == CheckEnum.Checking)
                .Select(x => new VerticalSubject_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    SubjectName = x.SubjectName,
                    SubjectLevel = x.SubjectLevel,
                    SubjectSource = x.SubjectSource,
                    SubjectNo = x.SubjectNo,
                    Funds = x.Funds,
                    StartTime = x.StartTime,
                    IfCose = x.IfCose,
                    EndTime = x.EndTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<VerticalSubject>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.SubjectName, x => x.SubjectName)
                .CheckEqual(Searcher.SubjectLevel, x => x.SubjectLevel)
                .CheckContain(Searcher.SubjectSource, x => x.SubjectSource)
                .CheckContain(Searcher.SubjectNo, x => x.SubjectNo)
                .CheckEqual(Searcher.Funds, x => x.Funds)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckEqual(Searcher.IfCose, x => x.IfCose)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IfOurSchool, x => x.IfOurSchool)
                .CheckEqual(Searcher.Examine, x => x.Examine)
                //.CheckContain(Searcher.Reason, x => x.Reason)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine != CheckEnum.Pass)
                .Select(x => new VerticalSubject_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    SubjectName = x.SubjectName,
                    SubjectLevel = x.SubjectLevel,
                    SubjectSource = x.SubjectSource,
                    SubjectNo = x.SubjectNo,
                    Funds = x.Funds,
                    StartTime = x.StartTime,
                    IfCose = x.IfCose,
                    EndTime = x.EndTime,
                    Rank = x.Rank,
                    IfOurSchool = x.IfOurSchool,
                    Examine = x.Examine,
                    Reason = x.Reason,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class VerticalSubject_View : VerticalSubject{

    }
}
