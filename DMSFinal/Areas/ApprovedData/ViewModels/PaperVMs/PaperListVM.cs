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


namespace DMSFinal.ApprovedData.ViewModels.PaperVMs
{
    public partial class PaperListVM : BasePagedListVM<Paper_View, PaperSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
            else {
                return new List<GridAction>
                {
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ApprovedData", dialogWidth: 800),
                    //this.MakeStandardAction("Paper", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ApprovedData", dialogWidth: 800),
                    this.MakeStandardAction("Paper", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ApprovedData"),
                };
            }
                
        }


        protected override IEnumerable<IGridColumn<Paper_View>> InitGridHeader()
        {
            return new List<GridColumn<Paper_View>>{
                this.MakeGridHeader(x => x.Department),
                this.MakeGridHeader(x => x.JobNo),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Title1),
                this.MakeGridHeader(x => x.Title2),
                this.MakeGridHeader(x => x.PaperTitle),
                this.MakeGridHeader(x => x.MagazineName),
                this.MakeGridHeader(x => x.PublicTime),
                this.MakeGridHeader(x => x.Info),
                this.MakeGridHeader(x => x.Category),
                this.MakeGridHeader(x => x.IsSCI),
                this.MakeGridHeader(x => x.SCINo),
                this.MakeGridHeader(x => x.IsEI),
                this.MakeGridHeader(x => x.EINo),
                this.MakeGridHeader(x => x.IsISTP),
                this.MakeGridHeader(x => x.ISTPNo),
                this.MakeGridHeader(x => x.Num),
                this.MakeGridHeader(x => x.ImpactFactor),
                this.MakeGridHeader(x => x.Rank),
                this.MakeGridHeader(x => x.IsOurSchool),
                //this.MakeGridHeader(x => x.Examine),
                //this.MakeGridHeader(x => x.Reason),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Paper_View> GetSearchQuery()
        {
            if (LoginUserInfo.Roles[0].RoleCode == "001")
            {
                var query = DC.Set<Paper>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.PaperTitle, x => x.PaperTitle)
                .CheckContain(Searcher.MagazineName, x => x.MagazineName)
                .CheckBetween(Searcher.PublicTime?.GetStartTime(), Searcher.PublicTime?.GetEndTime(), x => x.PublicTime, includeMax: false)
                .CheckContain(Searcher.Info, x => x.Info)
                .CheckEqual(Searcher.Category, x => x.Category)
                .CheckEqual(Searcher.IsSCI, x => x.IsSCI)
                .CheckContain(Searcher.SCINo, x => x.SCINo)
                .CheckEqual(Searcher.IsEI, x => x.IsEI)
                .CheckContain(Searcher.EINo, x => x.EINo)
                .CheckEqual(Searcher.IsISTP, x => x.IsISTP)
                .CheckContain(Searcher.ISTPNo, x => x.ISTPNo)
                .CheckEqual(Searcher.Num, x => x.Num)
                .CheckEqual(Searcher.ImpactFactor, x => x.ImpactFactor)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Paper_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    PaperTitle = x.PaperTitle,
                    MagazineName = x.MagazineName,
                    PublicTime = x.PublicTime,
                    Info = x.Info,
                    Category = x.Category,
                    IsSCI = x.IsSCI,
                    SCINo = x.SCINo,
                    IsEI = x.IsEI,
                    EINo = x.EINo,
                    IsISTP = x.IsISTP,
                    ISTPNo = x.ISTPNo,
                    Num = x.Num,
                    ImpactFactor = x.ImpactFactor,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                })
                .OrderBy(x => x.ID);
                return query;
            }
            else {
                var query = DC.Set<Paper>()
                .CheckEqual(Searcher.Department, x => x.Department)
                .CheckContain(Searcher.JobNo, x => x.JobNo)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Title1, x => x.Title1)
                .CheckEqual(Searcher.Title2, x => x.Title2)
                .CheckContain(Searcher.PaperTitle, x => x.PaperTitle)
                .CheckContain(Searcher.MagazineName, x => x.MagazineName)
                .CheckBetween(Searcher.PublicTime?.GetStartTime(), Searcher.PublicTime?.GetEndTime(), x => x.PublicTime, includeMax: false)
                .CheckContain(Searcher.Info, x => x.Info)
                .CheckEqual(Searcher.Category, x => x.Category)
                .CheckEqual(Searcher.IsSCI, x => x.IsSCI)
                .CheckContain(Searcher.SCINo, x => x.SCINo)
                .CheckEqual(Searcher.IsEI, x => x.IsEI)
                .CheckContain(Searcher.EINo, x => x.EINo)
                .CheckEqual(Searcher.IsISTP, x => x.IsISTP)
                .CheckContain(Searcher.ISTPNo, x => x.ISTPNo)
                .CheckEqual(Searcher.Num, x => x.Num)
                .CheckEqual(Searcher.ImpactFactor, x => x.ImpactFactor)
                .CheckEqual(Searcher.Rank, x => x.Rank)
                .CheckEqual(Searcher.IsOurSchool, x => x.IsOurSchool)
                .Where(x => x.JobNo == LoginUserInfo.ITCode)
                .Where(x => x.Examine == CheckEnum.Pass)
                .Select(x => new Paper_View
                {
                    ID = x.ID,
                    Department = x.Department,
                    JobNo = x.JobNo,
                    Name = x.Name,
                    Title1 = x.Title1,
                    Title2 = x.Title2,
                    PaperTitle = x.PaperTitle,
                    MagazineName = x.MagazineName,
                    PublicTime = x.PublicTime,
                    Info = x.Info,
                    Category = x.Category,
                    IsSCI = x.IsSCI,
                    SCINo = x.SCINo,
                    IsEI = x.IsEI,
                    EINo = x.EINo,
                    IsISTP = x.IsISTP,
                    ISTPNo = x.ISTPNo,
                    Num = x.Num,
                    ImpactFactor = x.ImpactFactor,
                    Rank = x.Rank,
                    IsOurSchool = x.IsOurSchool,
                })
                .OrderBy(x => x.ID);
                return query;
            }
                
        }

    }

    public class Paper_View : Paper{

    }
}
