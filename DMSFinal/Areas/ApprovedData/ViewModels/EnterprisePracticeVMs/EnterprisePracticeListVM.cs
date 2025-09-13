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


namespace DMSFinal.ApprovedData.ViewModels.EnterprisePracticeVMs
{
    public partial class EnterprisePracticeListVM : BasePagedListVM<EnterprisePractice_View, EnterprisePracticeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("EnterprisePractice", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<EnterprisePractice_View>> InitGridHeader()
        {
            return new List<GridColumn<EnterprisePractice_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.CompanyName),
                this.MakeGridHeader(x => x.PracticalWay),
                this.MakeGridHeader(x => x.StartTime),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeader(x => x.Contacts),
                this.MakeGridHeader(x => x.PhoneNumber),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<EnterprisePractice_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<EnterprisePractice>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.CompanyName, x => x.CompanyName)
                .CheckEqual(Searcher.PracticalWay, x => x.PracticalWay)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.Contacts, x => x.Contacts)
                .CheckContain(Searcher.PhoneNumber, x => x.PhoneNumber)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new EnterprisePractice_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    CompanyName = x.CompanyName,
                    PracticalWay = x.PracticalWay,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Contacts = x.Contacts,
                    PhoneNumber = x.PhoneNumber,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<EnterprisePractice>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.CompanyName, x => x.CompanyName)
                .CheckEqual(Searcher.PracticalWay, x => x.PracticalWay)
                .CheckBetween(Searcher.StartTime?.GetStartTime(), Searcher.StartTime?.GetEndTime(), x => x.StartTime, includeMax: false)
                .CheckBetween(Searcher.EndTime?.GetStartTime(), Searcher.EndTime?.GetEndTime(), x => x.EndTime, includeMax: false)
                .CheckContain(Searcher.Contacts, x => x.Contacts)
                .CheckContain(Searcher.PhoneNumber, x => x.PhoneNumber)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new EnterprisePractice_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    CompanyName = x.CompanyName,
                    PracticalWay = x.PracticalWay,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Contacts = x.Contacts,
                    PhoneNumber = x.PhoneNumber,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class EnterprisePractice_View : EnterprisePractice{

    }
}
