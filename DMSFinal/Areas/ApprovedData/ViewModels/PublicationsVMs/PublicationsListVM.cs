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


namespace DMSFinal.ApprovedData.ViewModels.PublicationsVMs
{
    public partial class PublicationsListVM : BasePagedListVM<Publications_View, PublicationsSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Publications", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Publications", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<Publications_View>> InitGridHeader()
        {
            return new List<GridColumn<Publications_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.PublicationForm),
                this.MakeGridHeader(x => x.PublicationName),
                this.MakeGridHeader(x => x.Press),
                this.MakeGridHeader(x => x.PublicationTime),
                this.MakeGridHeader(x => x.WriteWordCount),
                this.MakeGridHeader(x => x.BookNo),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IsOurSchool),
                this.MakeGridHeader(x => x.JobNo),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Publications_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<Publications>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckEqual(Searcher.PublicationForm, x => x.PublicationForm)
                .CheckContain(Searcher.PublicationName, x => x.PublicationName)
                .CheckContain(Searcher.Press, x => x.Press)
                .CheckBetween(Searcher.PublicationTime?.GetStartTime(), Searcher.PublicationTime?.GetEndTime(), x => x.PublicationTime, includeMax: false)
                .CheckEqual(Searcher.WriteWordCount, x => x.WriteWordCount)
                .CheckContain(Searcher.BookNo, x => x.BookNo)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Publications_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    PublicationForm = x.PublicationForm,
                    PublicationName = x.PublicationName,
                    Press = x.Press,
                    PublicationTime = x.PublicationTime,
                    WriteWordCount = x.WriteWordCount,
                    BookNo = x.BookNo,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                    JobNo = x.JobNo,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<Publications>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckEqual(Searcher.PublicationForm, x => x.PublicationForm)
                .CheckContain(Searcher.PublicationName, x => x.PublicationName)
                .CheckContain(Searcher.Press, x => x.Press)
                .CheckBetween(Searcher.PublicationTime?.GetStartTime(), Searcher.PublicationTime?.GetEndTime(), x => x.PublicationTime, includeMax: false)
                .CheckEqual(Searcher.WriteWordCount, x => x.WriteWordCount)
                .CheckContain(Searcher.BookNo, x => x.BookNo)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Publications_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    PublicationForm = x.PublicationForm,
                    PublicationName = x.PublicationName,
                    Press = x.Press,
                    PublicationTime = x.PublicationTime,
                    WriteWordCount = x.WriteWordCount,
                    BookNo = x.BookNo,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                    JobNo = x.JobNo,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class Publications_View : Publications{

    }
}
